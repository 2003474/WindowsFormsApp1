using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class NetworkTrainer
    {
        public NeuralNetwork[] networks;
        public Data[] trainingData;

        public NetworkTrainer(int numInputs, int numOutputs, int numNeurons, int numNetworks)
        {
            networks = new NeuralNetwork[numNetworks];
            for (int i = 0; i < networks.Length; i++) {
                networks[i] = new NeuralNetwork(numInputs, numOutputs, numNeurons);
            }
            DataGenerator dataGen = new DataGenerator(10000000);
            trainingData = dataGen.Generate();
        }
        
        public void train()
        {

        }

    }
}
