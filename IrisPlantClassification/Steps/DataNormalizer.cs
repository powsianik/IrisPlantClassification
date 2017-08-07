using System.IO;
using Encog.App.Analyst;
using Encog.App.Analyst.CSV.Normalize;
using Encog.App.Analyst.Wizard;
using Encog.Util.CSV;

namespace IrisPlantClassification.Steps
{
    public class DataNormalizer
    {
        public void Normalize(FileInfo baseFile, FileInfo trainingFile, FileInfo normalizedTrainingFile, FileInfo evaluateFile, FileInfo normalizedEvaluateFile, FileInfo analystFile)
        {
            var encogAnalyst = new EncogAnalyst();
            var analystWizard = new AnalystWizard(encogAnalyst);
            analystWizard.Wizard(baseFile, true, AnalystFileFormat.DecpntComma);

            var normalizer = new AnalystNormalizeCSV();
            normalizer.Analyze(trainingFile, true, CSVFormat.English, encogAnalyst);
            normalizer.ProduceOutputHeaders = true;
            normalizer.Normalize(normalizedTrainingFile);

            normalizer.Analyze(evaluateFile, true, CSVFormat.English, encogAnalyst);
            normalizer.Normalize(normalizedEvaluateFile);

            encogAnalyst.Save(analystFile);
        }
    }
}