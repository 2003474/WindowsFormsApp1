using Accord.Math;
using System;
using System.Linq;

namespace WindowsFormsApp1
{
    internal class NetworkTrainer
    {
        public NeuralNetwork[] networks;
        public Data[] trainingData;

        public NetworkTrainer(int numInputs, int numOutputs, int numNeurons, int numLayers, int numNetworks)
        {
            networks = new NeuralNetwork[numNetworks];
            for (int i = 0; i < networks.Length; i++)
            {
                networks[i] = new NeuralNetwork(numInputs, numOutputs, numNeurons, numLayers);
            }
            DataGenerator dataGen = new DataGenerator();
            trainingData = dataGen.Generate(10000);
        }

        public NeuralNetwork Train()
        {
            NeuralNetwork best1 = null;
            double[] loss = new double[networks.Length];
            for (int k = 0; k < 25; k++)
            {
                for (int i = 0; i < networks.Length; i++)
                {

                    double[] tempLoss = new double[8];
                    for (int j = 8 * k; j < 8 * k + tempLoss.Length; j++)
                    {
                        if (j > (trainingData.Length - 1))
                            Console.WriteLine(j + " is not a valid index in trainingData of size : " + trainingData.Length);

                        networks[i].input = trainingData[j].input;
                        networks[i].Forward();
                        tempLoss[j - 8 * k] = Loss(networks[i].output, trainingData[j].output[0]);
                    }
                    loss[i] = tempLoss.Sum();
                    Console.WriteLine("Network #" + (i + 1) + ": loss: " + loss[i]);
                }
                // take the top 10% of networks
                NeuralNetwork[] top10 = new NeuralNetwork[networks.Length/10];
                for(int i = 0; i < top10.Length; i++)
                {
                    top10[i] = networks[loss.IndexOf(loss.Min())];
                    loss[loss.IndexOf(loss.Min())] = 100000000.00;
                }
                NeuralNetwork[] tempNetworks = new NeuralNetwork[networks.Length];
                for (int i = 0; i < networks.Length; i++)
                {
                    NeuralNetwork father = top10[0];
                    NeuralNetwork mother = top10[1];
                    tempNetworks[i] = new NeuralNetwork(father, mother, 0);
                }

                networks = tempNetworks;
            }

            return best1;
        }

        public double Loss(double[] output, double expOutput)
        {
            return -(Math.Log10(output[(int)expOutput]));
        }

    }
}
