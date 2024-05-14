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
            string docPath = "C:\\Users\\2003474\\source\\repos\\WindowsFormsApp1";
            Console.WriteLine(File.ReadAllText(Path.Combine(docPath, "Networks.txt")));
            w.networks[0] = JsonConvert.DeserializeObject<NeuralNetwork>(File.ReadAllText(Path.Combine(docPath, "Networks.txt")));
            NeuralNetwork final = w.Train();

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
    }
}
