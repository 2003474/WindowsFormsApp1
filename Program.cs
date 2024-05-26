﻿// program file (starts the program)


using Newtonsoft.Json;
using System;
using System.IO;


namespace WindowsFormsApp1
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {
            // starts the training proccess
            NetworkTrainer w = new NetworkTrainer(2, 21, 16, 16, 100);
            //for (int i = 0; i < 100; i++)
            //{
            //    String file = "Networks" + i + ".json";
            //    NeuralNetwork f = FromFile(file);
            //    w.networks[i] = f;
            //}
            NeuralNetwork final = w.Train();
            //NeuralNetwork bestFromFIle = FromFile("Best.json");
            // testing
            final.Input = new double[2] { 0, 0 };
            final.Forward();

            int greatestIndex = 0;
            for (int i = 0; i < final.Output.Length; i++)
            {
                if (final.Output[i] > final.Output[greatestIndex])
                {
                    greatestIndex = i;
                }
            }
            Console.WriteLine(greatestIndex);

            final.Input = new double[2] { 9, 9 };
            final.Forward();

            greatestIndex = 0;
            for (int i = 0; i < final.Output.Length; i++)
            {
                if (final.Output[i] > final.Output[greatestIndex])
                {
                    greatestIndex = i;
                }
            }
            Console.WriteLine(greatestIndex);

            final.Input = new double[2] { 6, 8 };
            final.Forward();

            greatestIndex = 0;
            for (int i = 0; i < final.Output.Length; i++)
            {
                if (final.Output[i] > final.Output[greatestIndex])
                {
                    greatestIndex = i;
                }
            }
            Console.WriteLine(greatestIndex);

            final.Input = new double[2] { 1, 3 };
            final.Forward();

            greatestIndex = 0;
            for (int i = 0; i < final.Output.Length; i++)
            {
                if (final.Output[i] > final.Output[greatestIndex])
                {
                    greatestIndex = i;
                }
            }
            Console.WriteLine(greatestIndex);

            final.Input = new double[2] { 2, 7 };
            final.Forward();

            greatestIndex = 0;
            for (int i = 0; i < final.Output.Length; i++)
            {
                if (final.Output[i] > final.Output[greatestIndex])
                {
                    greatestIndex = i;
                }
            }
            Console.WriteLine(greatestIndex);

            final.Input = new double[2] { 9, 3 };
            final.Forward();

            greatestIndex = 0;
            for (int i = 0; i < final.Output.Length; i++)
            {
                if (final.Output[i] > final.Output[greatestIndex])
                {
                    greatestIndex = i;
                }
            }
            Console.WriteLine(greatestIndex);

            final.Input = new double[2] { 3, 3 };
            final.Forward();

            greatestIndex = 0;
            for (int i = 0; i < final.Output.Length; i++)
            {
                if (final.Output[i] > final.Output[greatestIndex])
                {
                    greatestIndex = i;
                }
            }
            Console.WriteLine(greatestIndex);

            final.Input = new double[2] { 11, 3 };
            final.Forward();

            greatestIndex = 0;
            for (int i = 0; i < final.Output.Length; i++)
            {
                if (final.Output[i] > final.Output[greatestIndex])
                {
                    greatestIndex = i;
                }
            }
            Console.WriteLine(greatestIndex);


            final.Input = new double[2] { 11, 15 };
            final.Forward();

            greatestIndex = 0;
            for (int i = 0; i < final.Output.Length; i++)
            {
                if (final.Output[i] > final.Output[greatestIndex])
                {
                    greatestIndex = i;
                }
            }
            Console.WriteLine(greatestIndex);

        }


#pragma warning disable IDE0051 // Remove unused private members
        static NeuralNetwork FromFile(string file)
#pragma warning restore IDE0051 // Remove unused private members
        {
            string docPath = "C:\\Users\\2003474\\source\\repos\\WindowsFormsApp1";
            //Console.WriteLine(File.ReadAllText(Path.Combine(docPath, "Networks.json")));
            var s = File.ReadAllText(Path.Combine(docPath, file));
            var f = JsonConvert.DeserializeObject<NeuralNetwork>(s);
            for (int i = 0; i < f.DLayers.Length; i++)
            {
                for (int k = 0; k < f.DLayers[i].neurons.Length; k++)
                {
                    string type = f.DLayers[i].neurons[k].Type;
                    Neuron cur = (Neuron)f.DLayers[i].neurons[k].Clone();
                    switch (type)
                    {
                        case "O":
                            f.DLayers[i].neurons[k] = new OrNeuron(cur.Weight.Length)
                            {
                                Weight = cur.Weight,
                                Bias = cur.Bias,
                                Threshold = cur.Threshold
                            };
                            break;
                        case "A":
                            f.DLayers[i].neurons[k] = new AndNeuron(cur.Weight.Length)
                            {
                                Weight = cur.Weight,
                                Bias = cur.Bias,
                                Threshold = cur.Threshold
                            };
                            break;
                        case "GT":
                            f.DLayers[i].neurons[k] = new GreaterThanNeuron(cur.Weight.Length)
                            {
                                Weight = cur.Weight,
                                Bias = cur.Bias,
                                Threshold = cur.Threshold
                            };
                            break;
                        case "LT":
                            f.DLayers[i].neurons[k] = new LessThanNeuron(cur.Weight.Length)
                            {
                                Weight = cur.Weight,
                                Bias = cur.Bias,
                                Threshold = cur.Threshold
                            };
                            break;
                        case "OT":
                            f.DLayers[i].neurons[k] = new OutputNeuron(cur.Weight.Length)
                            {
                                Weight = cur.Weight,
                                Bias = cur.Bias,
                                Threshold = cur.Threshold
                            };
                            break;
                    }
                }
            }
            return f;
        }
    }
}
