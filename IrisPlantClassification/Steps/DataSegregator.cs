using System.IO;
using Encog.App.Analyst.CSV.Segregate;
using Encog.Util.CSV;

namespace IrisPlantClassification.Steps
{
    public class DataSegregator
    {
        private int dataPercentForTraining;
        private int dataPercentForEvaluate;

        public DataSegregator(int dataPercentForTraining, int dataPercentForEvaluate)
        {
            this.dataPercentForTraining = dataPercentForTraining;
            this.dataPercentForEvaluate = dataPercentForEvaluate;
        }

        public void Segregate(FileInfo dataToSegregate, FileInfo trainingFile, FileInfo evaluateFile)
        {
            var segregator = new SegregateCSV();
            segregator.Targets.Add(new SegregateTargetPercent(trainingFile, this.dataPercentForTraining));
            segregator.Targets.Add(new SegregateTargetPercent(evaluateFile, this.dataPercentForEvaluate));
            segregator.ProduceOutputHeaders = true;
            segregator.Analyze(dataToSegregate, true, CSVFormat.English);
            segregator.Process();
        }
    }
}