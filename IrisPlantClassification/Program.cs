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
    }
}
