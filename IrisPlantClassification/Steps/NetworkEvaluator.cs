using System;
using System.IO;
using Encog.App.Analyst;
using Encog.MathUtil;
using Encog.Neural.Networks;
using Encog.Persist;
using Encog.Util.CSV;
using Encog.Util.Simple;

namespace IrisPlantClassification.Steps
{
    public class NetworkEvaluator
    {
        public void Evaluate(FileInfo networkFile, FileInfo analystFile, FileInfo EvaluationFile)
        {
            var network = EncogDirectoryPersistence.LoadObject(networkFile) as BasicNetwork;
            var analyst = new EncogAnalyst();
            analyst.Load(analystFile);

            var evaluationSet = EncogUtility.LoadCSV2Memory(EvaluationFile.ToString(), network.InputCount,
                network.OutputCount, true, CSVFormat.English, false);

            int count = 0;
            int correctCount = 0;

            foreach (var item in evaluationSet)
            {
                var sepal_l = analyst.Script.Normalize.NormalizedFields[0].DeNormalize(item.Input[0]);
                var sepal_w = analyst.Script.Normalize.NormalizedFields[1].DeNormalize(item.Input[1]);
                var petal_l = analyst.Script.Normalize.NormalizedFields[2].DeNormalize(item.Input[2]);
                var petal_w = analyst.Script.Normalize.NormalizedFields[3].DeNormalize(item.Input[3]);

                int classCount = analyst.Script.Normalize.NormalizedFields[4].Classes.Count;

                double normalizationHigh = analyst.Script.Normalize.NormalizedFields[4].NormalizedHigh;
                double normalizationLow = analyst.Script.Normalize.NormalizedFields[4].NormalizedLow;

                var output = network.Compute(item.Input);
                var resulter = new Equilateral(classCount, normalizationHigh, normalizationLow);
                var predictedClassInt = resulter.Decode(output);
                var predictedClass = analyst.Script.Normalize.NormalizedFields[4].Classes[predictedClassInt].Name;

                var idealClassInt = resulter.Decode(item.Ideal);
                var idealClass = analyst.Script.Normalize.NormalizedFields[4].Classes[idealClassInt].Name;

                if (predictedClassInt == idealClassInt)
                {
                    ++correctCount;
                }

                Console.WriteLine($"Count: {++count} | Ideal: {idealClass} Predicted:{predictedClass}");
            }

            Console.WriteLine($"Total test count: {count}");
            Console.WriteLine($"Total correct test count: {correctCount}");
            Console.WriteLine($"% Success: {(correctCount*100.0)/count}");
        }
    }
}