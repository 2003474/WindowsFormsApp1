// trains a bunch of networks to generate a network that is able to solve the problem at hand

using Accord.Math;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;


namespace WindowsFormsApp1
{
    internal class NetworkTrainer
    {
        public NeuralNetwork[] networks;
        //public Data[] trainingData;
        public NeuralNetwork[] top10;
        double[] loss;
        public Image[] data;

        // creates a new network trainer
        // parameters: number of inputs the neural network recieves,
        // number of possible outputs the network could produce
        // number of neurons per layer
        // number of layers per network
        // number  of networks to train
        public NetworkTrainer(int numInputs, int numOutputs, int numNeurons, int numLayers, int numNetworks)
        {

            networks = new NeuralNetwork[numNetworks];
            for (int i = 0; i < networks.Length; i++)
            {
                networks[i] = new NeuralNetwork(numInputs, numOutputs, numNeurons, numLayers);
            }
            //DataGenerator dataGen = new DataGenerator();
            //trainingData = dataGen.Generate(1000000);

            data = new Image[60000];
            int k = 0;
            foreach (var image in MnistReader.ReadTrainingData())
            {

                data[k] = image;
                k++;
            }
        }

        // trains the generated array of networks
        public NeuralNetwork Train()
        {
            NeuralNetwork best1 = null;
            loss = new double[networks.Length];
            Boolean convergence = false;
            for (int k = 0; convergence == false && k < 50000; k++)
            {
                if (k % 250 == 0)
                {
                    for (int i = 0; i < 100; i++)
                    {
                        ToFile(i);
                    }

                }
                for (int i = 0; i < networks.Length; i++)
                {
                    networks[i].Repetition++;

                    if (networks[i].Repetition >= 20)
                    {
                        convergence = true;
                    }
                    int batchSize = 8;
                    if (k == 500)
                    {
                        batchSize = 16;
                    }
                    double[] tempLoss = new double[batchSize];
                    for (int j = batchSize * k; j < batchSize * k + tempLoss.Length; j++)
                    {
                        double[] flatData = new double[784];

                        // go through each value in 


                        int b = 0;
                        for (int m = 0; m < 28; m++)
                        {
                            for (int n = 0; n < 28; n++)
                            {
                                flatData[b] = data[j % 60000].Data[m, n];
                                b++;
                            }
                        }


                        networks[i].Input = flatData;
                        networks[i].Forward();
                        tempLoss[j - batchSize * k] = Loss(networks[i].Output, data[j % 60000].Label);
                    }
                    loss[i] = tempLoss.Sum();
                    Console.WriteLine(k + "Network #" + (i + 1) + ": loss: " + loss[i] / (double)batchSize);
                }
                // take the top 10% of networks
                top10 = new NeuralNetwork[networks.Length / 10];
                double topNetworkLoss = loss.Min();
                double worstNetworkLoss = loss.Max();
                if ((worstNetworkLoss - topNetworkLoss) / topNetworkLoss < 0.001)
                {
                    convergence = true;
                }
                for (int i = 0; i < top10.Length; i++)
                {
                    top10[i] = networks[loss.IndexOf(loss.Min())];
                    loss[loss.IndexOf(loss.Min())] = 100000000.00;
                }
                NeuralNetwork[] tempNetworks = new NeuralNetwork[networks.Length];
                for (int i = 0; i < 10; i++)
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
                        while (networks[randInt].Breedibility < randDouble)
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



                    tempNetworks[i] = new NeuralNetwork(father, mother, 5);
                }

                networks = tempNetworks;
                best1 = top10[0];

                string path = "C:\\Users\\nikbr\\projects\\WindowsFormsApp1";
                // Write the string array to a new file named "WriteLines.txt".
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(path, "Best.json")))
                {
                    outputFile.WriteLine(JsonConvert.SerializeObject(best1));
                }

            }



            string docPath = "C:\\Users\\nikbr\\projects\\WindowsFormsApp1";
            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "Best.json")))
            {
                outputFile.WriteLine(JsonConvert.SerializeObject(best1));
            }
            return best1;
        }

        // writes a neural network to a file
        // parameters: the index of a network
        private void ToFile(int numNetwork)
        {
            //C:\\Users\\nikbr\\projects\\WindowsFormsApp1
            //C:\\Users\\2003474\\source\\repos\\WindowsFormsApp1
            string docPath = "C:\\Users\\nikbr\\projects\\WindowsFormsApp1";
            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "Networks" + numNetwork + ".json")))
            {
                outputFile.WriteLine(JsonConvert.SerializeObject(networks[numNetwork]));
            }

        }

        // calculates the loss value
        // parameters: actual output values, desired output value
        public double Loss(double[] output, double expOutput)
        {
            return -(Math.Log10(output[(int)expOutput]));
        }



    }
}
