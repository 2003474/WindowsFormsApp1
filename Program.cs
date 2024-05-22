// program file (starts the program)


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
            NetworkTrainer w = new NetworkTrainer(2, 101, 32, 32, 100);
            for (int i = 0; i < 100; i++)
            {
                String file = "Networks" + i + ".json";
                NeuralNetwork f = FromFile(file);
                w.networks[i] = f;
            }
            NeuralNetwork final = w.Train();
            NeuralNetwork bestFromFIle = FromFile("Best.json");
            // testing
            final.input = new double[2] { 0, 0 };
            final.Forward();

            int greatestIndex = 0;
            for (int i = 0; i < final.output.Length; i++)
            {
                if (final.output[i] > final.output[greatestIndex])
                {
                    greatestIndex = i;
                }
            }
            Console.WriteLine(greatestIndex);

            final.input = new double[2] { 1, 1 };
            final.Forward();

            greatestIndex = 0;
            for (int i = 0; i < final.output.Length; i++)
            {
                if (final.output[i] > final.output[greatestIndex])
                {
                    greatestIndex = i;
                }
            }
            Console.WriteLine(greatestIndex);

            final.input = new double[2] { 1, 2 };
            final.Forward();

            greatestIndex = 0;
            for (int i = 0; i < final.output.Length; i++)
            {
                if (final.output[i] > final.output[greatestIndex])
                {
                    greatestIndex = i;
                }
            }
            Console.WriteLine(greatestIndex);

            final.input = new double[2] { 1, 3 };
            final.Forward();

            greatestIndex = 0;
            for (int i = 0; i < final.output.Length; i++)
            {
                if (final.output[i] > final.output[greatestIndex])
                {
                    greatestIndex = i;
                }
            }
            Console.WriteLine(greatestIndex);

            final.input = new double[2] { 2, 2 };
            final.Forward();

            greatestIndex = 0;
            for (int i = 0; i < final.output.Length; i++)
            {
                if (final.output[i] > final.output[greatestIndex])
                {
                    greatestIndex = i;
                }
            }
            Console.WriteLine(greatestIndex);

            final.input = new double[2] { 2, 3 };
            final.Forward();

            greatestIndex = 0;
            for (int i = 0; i < final.output.Length; i++)
            {
                if (final.output[i] > final.output[greatestIndex])
                {
                    greatestIndex = i;
                }
            }
            Console.WriteLine(greatestIndex);

            final.input = new double[2] { 3, 3 };
            final.Forward();

            greatestIndex = 0;
            for (int i = 0; i < final.output.Length; i++)
            {
                if (final.output[i] > final.output[greatestIndex])
                {
                    greatestIndex = i;
                }
            }
            Console.WriteLine(greatestIndex);

            final.input = new double[2] { 5, 4 };
            final.Forward();

            greatestIndex = 0;
            for (int i = 0; i < final.output.Length; i++)
            {
                if (final.output[i] > final.output[greatestIndex])
                {
                    greatestIndex = i;
                }
            }
            Console.WriteLine(greatestIndex);

        }

        static NeuralNetwork FromFile(string file)
        {
            string docPath = "C:\\Users\\2003474\\source\\repos\\WindowsFormsApp1";
            //Console.WriteLine(File.ReadAllText(Path.Combine(docPath, "Networks.json")));
            var s = File.ReadAllText(Path.Combine(docPath, file));
            var f = JsonConvert.DeserializeObject<NeuralNetwork>(s);
            for (int i = 0; i < f.dLayers.Length; i++)
            {
                for (int k = 0; k < f.dLayers[i].neurons.Length; k++)
                {
                    string type = f.dLayers[i].neurons[k].Type;
                    Neuron cur = (Neuron)f.dLayers[i].neurons[k].Clone();
                    switch (type)
                    {
                        case "O":
                            f.dLayers[i].neurons[k] = new OrNeuron(cur.Weight.Length)
                            {
                                Weight = cur.Weight,
                                Bias = cur.Bias,
                                Threshold = cur.Threshold
                            };
                            break;
                        case "A":
                            f.dLayers[i].neurons[k] = new AndNeuron(cur.Weight.Length)
                            {
                                Weight = cur.Weight,
                                Bias = cur.Bias,
                                Threshold = cur.Threshold
                            };
                            break;
                        case "GT":
                            f.dLayers[i].neurons[k] = new GreaterThanNeuron(cur.Weight.Length)
                            {
                                Weight = cur.Weight,
                                Bias = cur.Bias,
                                Threshold = cur.Threshold
                            };
                            break;
                        case "LT":
                            f.dLayers[i].neurons[k] = new LessThanNeuron(cur.Weight.Length)
                            {
                                Weight = cur.Weight,
                                Bias = cur.Bias,
                                Threshold = cur.Threshold
                            };
                            break;
                        case "OT":
                            f.dLayers[i].neurons[k] = new OutputNeuron(cur.Weight.Length)
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
