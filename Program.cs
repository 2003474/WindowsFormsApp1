using System;

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
            NetworkTrainer w = new NetworkTrainer(1, 2, 8, 10);
            NeuralNetwork final = w.Train();
            
            final.input = new double[1] { 25.0 };
            final.Forward();
            // should return 0 and 1 or extremely close, like EXTREMELY close
            Console.WriteLine(final.output[0] + ", " + final.output[1]);
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
