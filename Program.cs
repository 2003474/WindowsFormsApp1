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
            NetworkTrainer w = new NetworkTrainer(784, 10, 32, 8, 100);
            //for (int i = 0; i < 100; i++)
            //{
            //    String file = "Networks" + i + ".json";
            //    NeuralNetwork f = FromFile(file);
            //    w.networks[i] = f;
            //}
            NeuralNetwork final;
            final = w.Train();
            //final = FromFile("Best.json");
            //final = new NeuralNetwork(784, 10, 32, 8);
            // testing
            // get data
            Image[] testingdata = new Image[10000];
            int k = 0;
            foreach (var image in MnistReader.ReadTestData())
            {
                testingdata[k] = image;
                k++;
                if (k == 10000)
                {
                    break;
                }
            }
            int greatestIndex;

            for (int g = 1; g < 100; g++)
            {
                // expected
                Console.WriteLine("expected: " + testingdata[g].Label.ToString());
                // input
                final.Input = new double[784];


                int b = 0;
                for (int m = 0; m < 28; m++)
                {
                    for (int n = 0; n < 28; n++)
                    {
                        final.Input[b] = (double)testingdata[g].Data[m, n];
                        b++;
                    }
                }

                // output
                final.Forward();
                greatestIndex = 0;
                for (int i = 0; i < final.Output.Length; i++)
                {
                    if (final.Output[i] > final.Output[greatestIndex])
                    {
                        greatestIndex = i;
                    }
                }
                // actual
                Console.WriteLine("actual: " + greatestIndex);
            }
        }



        static NeuralNetwork FromFile(string file)

        {
            string docPath = "C:\\Users\\nikbr\\projects\\WindowsFormsApp1";
            //Console.WriteLine(File.ReadAllText(Path.Combine(docPath, "Networks.json")));
            var s = File.ReadAllText(Path.Combine(docPath, file));
            var f = JsonConvert.DeserializeObject<NeuralNetwork>(s);
            for (int i = 0; i < f.DLayers.Length; i++)
            {
                for (int k = 0; k < f.DLayers[i].Neurons.Length; k++)
                {
                    string type = f.DLayers[i].Neurons[k].Type;
                    Neuron cur = (Neuron)f.DLayers[i].Neurons[k].Clone();
                    switch (type)
                    {
                        case "O":
                            f.DLayers[i].Neurons[k] = new OrNeuron(cur.Weight.Length)
                            {
                                Weight = cur.Weight,
                                Bias = cur.Bias,
                                Threshold = cur.Threshold
                            };
                            break;
                        case "A":
                            f.DLayers[i].Neurons[k] = new AndNeuron(cur.Weight.Length)
                            {
                                Weight = cur.Weight,
                                Bias = cur.Bias,
                                Threshold = cur.Threshold
                            };
                            break;
                        case "GT":
                            f.DLayers[i].Neurons[k] = new GreaterThanNeuron(cur.Weight.Length)
                            {
                                Weight = cur.Weight,
                                Bias = cur.Bias,
                                Threshold = cur.Threshold
                            };
                            break;
                        case "LT":
                            f.DLayers[i].Neurons[k] = new LessThanNeuron(cur.Weight.Length)
                            {
                                Weight = cur.Weight,
                                Bias = cur.Bias,
                                Threshold = cur.Threshold
                            };
                            break;
                        case "OT":
                            f.DLayers[i].Neurons[k] = new OutputNeuron(cur.Weight.Length)
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
