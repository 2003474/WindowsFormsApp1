﻿using System;

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
            NetworkTrainer w = new NetworkTrainer(2, 2, 8, 8, 100);
            NeuralNetwork final = w.Train();

            final.input = new double[2] { 10.78, 3.234 };
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

            final.input = new double[2] { 2.435, 8.678953};
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

            final.input = new double[2] { 7.23455, 5.432543 };
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

            final.input = new double[2] {9.2345423, 1.2345342 };
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

            final.input = new double[2] { 9.2345, 9.1645267};
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
