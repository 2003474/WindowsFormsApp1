using Accord.Math;
using System;
using System.Linq;

namespace WindowsFormsApp1
{
    internal class NetworkTrainer
    {
        public NeuralNetwork[] networks;
        public Data[] trainingData;
        public NeuralNetwork[] top10;
        double[] loss;
        public NetworkTrainer(int numInputs, int numOutputs, int numNeurons, int numLayers, int numNetworks)
        {
            networks = new NeuralNetwork[numNetworks];
            for (int i = 0; i < networks.Length; i++)
            {
                networks[i] = new NeuralNetwork(numInputs, numOutputs, numNeurons, numLayers);
            }
            DataGenerator dataGen = new DataGenerator();
            trainingData = dataGen.Generate(100000);
        }

        public NeuralNetwork Train()
        {
            NeuralNetwork best1 = null;
            loss = new double[networks.Length];
            Boolean convergence = false;
            for (int k = 0; k < 100; k++)
            {
                for (int i = 0; i < networks.Length; i++)
                {

                    double[] tempLoss = new double[16];
                    for (int j = 16 * k; j < 16 * k + tempLoss.Length; j++)
                    {
                        if (j > (trainingData.Length - 1))
                            Console.WriteLine(j + " is not a valid index in trainingData of size : " + trainingData.Length);

                        networks[i].input = trainingData[j].input;
                        networks[i].Forward();
                        tempLoss[j - 16 * k] = Loss(networks[i].output, trainingData[j].output[0]);
                    }
                    loss[i] = tempLoss.Sum();
                    Console.WriteLine("Network #" + (i + 1) + ": loss: " + loss[i]);
                }
                // take the top 10% of networks
                top10 = new NeuralNetwork[networks.Length / 10];
                convergence = true;
                for (int i = 0; i < top10.Length; i++)
                {
                    top10[i] = networks[loss.IndexOf(loss.Min())];
                    if(loss[loss.IndexOf(loss.Min())] > 0.000000000000000000000000000000001)
                    {
                        convergence = false;
                    }
                    loss[loss.IndexOf(loss.Min())] = 100000000.00;
                }
                NeuralNetwork[] tempNetworks = new NeuralNetwork[networks.Length];
                for(int i = 0; i < 10; i++)
                {
                    tempNetworks[i] = top10[i];
                }
                for (int i = 10; i < tempNetworks.Length; i++)
                {
                    int fatherNum = Globals.rnd.Next(0, top10.Length);
                    NeuralNetwork father = top10[fatherNum];
                    NeuralNetwork mother;
                    //father chooses a random "mate" high chance of it being from top 10, if from bottom 90 then the random double has to be greater than the breedibility
                    int randNum = Globals.rnd.Next(0, 25);
                    // this is choosing from lower 90%
                    if (randNum == 3)
                    {
                        double randDouble = Globals.rnd.NextDouble();
                        int randInt = Globals.rnd.Next(top10.Length, networks.Length);
                        while (networks[randInt].breedibility < randDouble)
                        {
                            randInt = Globals.rnd.Next(top10.Length, networks.Length);
                            randDouble = Globals.rnd.NextDouble();
                        }
                        mother = networks[randInt];
                    }
                    else
                    // chosse a random other network from the top10
                    {
                        int motherNum = Globals.rnd.Next(0, top10.Length);
                        while (fatherNum == motherNum)
                        {
                            motherNum = Globals.rnd.Next(0, top10.Length);
                        }
                        mother = top10[motherNum];
                    }



                    tempNetworks[i] = new NeuralNetwork(father, mother, 3);
                }

                networks = tempNetworks;
                best1 = top10[0];
            }

            return best1;
        }

        public double Loss(double[] output, double expOutput)
        {
            return -(Math.Log10(output[(int)expOutput]));
        }



    }
}
