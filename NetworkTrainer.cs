﻿using Accord.Math;
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
            DataGenerator dataGen = new DataGenerator();
            trainingData = dataGen.Generate(100);
        }

        public NeuralNetwork Train()
        {
            NeuralNetwork best1 = null;
            double[] loss = new double[networks.Length];
            for (int k = 0; k < 11; k++)
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
                best1 = networks[loss.IndexOf(loss.Min())];
                loss[loss.IndexOf(loss.Min())] = 10000.00;
                NeuralNetwork best2 = networks[loss.IndexOf(loss.Min())];
                if(k < 10) 
                {
                    for(int i = 0; i < networks.Length; i++)
                    {
                        networks[i] = new NeuralNetwork(best1, best2, 0);
                    }
                }
                //Console.WriteLine("Best Network is... #" + (loss.IndexOf(loss.Min()) + 1));
                //best.input = trainingData[100 + k].input;
                //best.Forward();
                //Console.WriteLine(best.output[0].ToString() + " " + best.output[1].ToString() + " " + trainingData[100 + k].output[0]);
                // finds the best, maybe best 2 then combines them and populates the array of Networks with their children, might be different every time,
                // add mutation, completely random, changing weights and/ or biases
            }

            return best1;
        }
        
        public double Loss(double[] output, double expOutput)
        {
            return -(Math.Log10(output[(int)expOutput]));
        }

    }
}
