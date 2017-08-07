using System;
using IrisPlantClassification.Steps;

namespace IrisPlantClassification
{
    class Program
    {
        static void Main(string[] args)
        {
            Step1();
            Step2();
            Step3();
            Step4();
            Step5();
            Step6();

            Console.ReadKey();
        }

        static void Step1()
        {
            Console.WriteLine("STEP 1: Shuffle data...");
            DataShuffle shuffle = new DataShuffle();
            shuffle.Shuffle(DataFilesInfoGetter.BaseFile, DataFilesInfoGetter.ShuffledBaseFile, true);
        }

        static void Step2()
        {
            Console.WriteLine("STEP 2: Segregate data...");
            DataSegregator segregator = new DataSegregator(75, 25);
            segregator.Segregate(DataFilesInfoGetter.ShuffledBaseFile, DataFilesInfoGetter.TrainingFile, DataFilesInfoGetter.EvaluateFile);
        }

        static void Step3()
        {
            Console.WriteLine("STEP 3: Normalize data...");
            DataNormalizer normalizer = new DataNormalizer();
            normalizer.Normalize(DataFilesInfoGetter.BaseFile, DataFilesInfoGetter.TrainingFile, DataFilesInfoGetter.NormalizedTrainingFile, DataFilesInfoGetter.EvaluateFile, 
                                    DataFilesInfoGetter.NormalizedEvaluateFile, DataFilesInfoGetter.EncogAnalystFile);
        }

        static void Step4()
        {
            Console.WriteLine("STEP 4: Create neural network...");
            NetworkCreator networkCreator = new NetworkCreator();
            networkCreator.Create(DataFilesInfoGetter.NetworkFile);
        }

        static void Step5()
        {
            Console.WriteLine("STEP 5: Train neural network...");
            NetworkTrainer networkteTrainer = new NetworkTrainer();
            networkteTrainer.Train(DataFilesInfoGetter.NetworkFile, DataFilesInfoGetter.NormalizedTrainingFile);
        }

        static void Step6()
        {
            Console.WriteLine("STEP 6: Evaluate network...");
            NetworkEvaluator evaluator = new NetworkEvaluator();
            evaluator.Evaluate(DataFilesInfoGetter.NetworkFile, DataFilesInfoGetter.EncogAnalystFile, DataFilesInfoGetter.NormalizedEvaluateFile);
        }
    }
}
