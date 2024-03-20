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

            double[] input = { 0, 1 };
            NeuralNetwork network = new NeuralNetwork(2, 2, 8);
            network.input = input;
            network.Forward();
            var output = network.output;
            Console.WriteLine("" + string.Join(" ", output));
        }
    }
}