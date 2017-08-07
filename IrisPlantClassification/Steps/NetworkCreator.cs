using System.IO;
using Encog.Engine.Network.Activation;
using Encog.Neural.Networks;
using Encog.Neural.Networks.Layers;
using Encog.Persist;

namespace IrisPlantClassification.Steps
{
    public class NetworkCreator
    {
        public void Create(FileInfo networkFile)
        {
            var network = new BasicNetwork();
            network.AddLayer(new BasicLayer(new ActivationLinear(), true, 4));
            network.AddLayer(new BasicLayer(new ActivationTANH(), true, 6));
            network.AddLayer(new BasicLayer(new ActivationTANH(), true, 2));

            network.Structure.FinalizeStructure();
            network.Reset();

            EncogDirectoryPersistence.SaveObject(networkFile, network);
        }
    }
}