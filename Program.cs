using Newtonsoft.Json;
using System;
using System.IO;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            NetworkTrainer w = new NetworkTrainer(2, 10, 16, 16, 100);
            NeuralNetwork final = w.Train();


            string path = "C:\\Users\\nikbr\\projects\\WindowsFormsApp1";
            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(path, "Working.json")))
            {
                outputFile.WriteLine(JsonConvert.SerializeObject(final));
            }



            final.input = new double[2] { 0, 0 };
            final.Forward();
            // should return 0 and 1 or extremely close
            int greatestIndex = 0;
            for (int i = 0; i < final.output.Length; i++)
            {
                if (final.output[i] > final.output[greatestIndex])
                {
                    greatestIndex = i;
                }
            }
            Console.WriteLine(greatestIndex);

            final.input = new double[2] { 3, 2 };
            final.Forward();
            // should return 1 and 0 or extremely close
            greatestIndex = 0;
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
            // should return 0 and 1 or extremely close
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
            // should return 1 and 0 or extremely close
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
            // should return 1 and 0 or extremely close
            greatestIndex = 0;
            for (int i = 0; i < final.output.Length; i++)
            {
                if (final.output[i] > final.output[greatestIndex])
                {
                    greatestIndex = i;
                }
            }
            Console.WriteLine(greatestIndex);

            //NeuralNetwork network = new NeuralNetwork(2, 2, 8);
            //network.input = input;
            //network.Forward();
            //var output = network.output;
            //Console.WriteLine("" + string.Join(" ", output));

            // TODO
            // test network trainer
            // add some sort of training/ selection algorithm
        }
    }
}
