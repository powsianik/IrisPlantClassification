using System.IO;
using Encog.App.Analyst.CSV.Shuffle;
using Encog.Util.CSV;

namespace IrisPlantClassification.Steps
{
    public class DataShuffle
    {
        public void Shuffle(FileInfo fileToShuffle, FileInfo fileToReturn, bool headersExist)
        {
            var shuffle = new ShuffleCSV();
            shuffle.Analyze(fileToShuffle, headersExist, CSVFormat.English);
            shuffle.ProduceOutputHeaders = headersExist;
            shuffle.Process(fileToReturn);
        }
    }
}