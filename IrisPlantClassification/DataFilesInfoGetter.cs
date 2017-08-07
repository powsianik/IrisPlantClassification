using System;
using System.IO;

namespace IrisPlantClassification
{
    public class DataFilesInfoGetter
    {
        public static FileInfo BasePath = new FileInfo($@"{Directory.GetCurrentDirectory().Replace(@"IrisPlantClassification\bin\Debug", string.Empty)}Data\");

        public static FileInfo BaseFile = new FileInfo(Path.Combine(BasePath.DirectoryName, "IrisData.csv"));

        public static FileInfo ShuffledBaseFile = new FileInfo(Path.Combine(BasePath.DirectoryName, "IrisData_Shuffled.csv"));

        public static FileInfo TrainingFile = new FileInfo(Path.Combine(BasePath.DirectoryName, "IrisData_Training.csv"));

        public static FileInfo EvaluateFile = new FileInfo(Path.Combine(BasePath.DirectoryName, "IrisData_Evaluate.csv"));
    }
}