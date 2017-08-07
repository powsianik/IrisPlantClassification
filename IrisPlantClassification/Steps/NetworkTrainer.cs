using System;
using System.IO;
using Encog.Neural.Networks;
using Encog.Neural.Networks.Training.Propagation.Resilient;
using Encog.Persist;
using Encog.Util.CSV;
using Encog.Util.Simple;

namespace IrisPlantClassification.Steps
{
    public class NetworkTrainer
    {
        public void Train(FileInfo networkFile, FileInfo trainingDataFile)
        {
            var network = EncogDirectoryPersistence.LoadObject(networkFile) as BasicNetwork;

            var trainingSet = EncogUtility.LoadCSV2Memory(trainingDataFile.ToString(), network.InputCount,
                network.OutputCount, true, CSVFormat.English, false);

            var trainer = new ResilientPropagation(network, trainingSet);
            int iter = 1;
            do
            {
                trainer.Iteration();
                Console.WriteLine($"\tIteration: {iter++} | Error: {trainer.Error}");

            } while (trainer.Error > 0.01);

            EncogDirectoryPersistence.SaveObject(networkFile,  network);
        }
    }
}