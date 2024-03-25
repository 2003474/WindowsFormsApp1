using Accord.Math;
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

        public void Train()
        {
            double[] loss = new double[networks.Length];
            for (int k = 0; k < 10; k++)
            {
                for (int i = 0; i < networks.Length; i++)
                {

                    double[] tempLoss = new double[8];
                    for (int j = 8 * k; j < j + tempLoss.Length; j++)
                    {
                        networks[i].input = trainingData[j].input;
                        networks[i].Forward();
                        //bug
                        tempLoss[j - 8 * k] = Loss(networks[i].output, trainingData[j].output[0]);
                    }
                    loss[i] = tempLoss.Sum();
                    Console.WriteLine("Network #" + (i + 1) + ": loss: " + loss[i]);
                    //Console.WriteLine("Output: [" + network.output[0].ToString() + "," + network.output[1].ToString() + "] expected index: " + trainingData[0].output[0] + " loss: " + loss(network.output, trainingData[0].output[0]));
                }
                NeuralNetwork best = networks[loss.IndexOf(loss.Min())];
                Console.WriteLine("Best NN is... #" + (loss.IndexOf(loss.Min()) + 1));
                best.input = trainingData[9].input;
                best.Forward();
                Console.WriteLine(best.output[0].ToString() + " " + best.output[1].ToString() + " " + trainingData[9].output[0]);
            }
        }
        
        public double Loss(double[] output, double expOutput)
        {
            return -(Math.Log10(output[(int)expOutput]));
        }

    }
}
