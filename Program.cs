using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI.HtmlControls;
using System.Windows.Forms;

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
            double[][] inputs = new double[3][] { new double[] {5.9, -9.3}, new double[] { 1, 2 }, new double[] { -1, -2 } };
            NeuronLayer hiddenLayer1 = new NeuronLayer(2, 8);
            NeuronLayer hiddenLayer2 = new NeuronLayer(8, 8);
            
            hiddenLayer1.Forward(inputs);
            var weights = hiddenLayer1.getWeights();
            var biases = hiddenLayer1.getBiases();
            var output = hiddenLayer1.output;
            Console.WriteLine("Weights: ");
            for (int x = 0; x < weights.Length; x++)
            {
                Console.Write("Neuron " + (x+1) + ": ");
                for (int y = 0; y < weights[x].Length; y++)
                {
                    Console.Write(weights[x][y] + ", ") ;

                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Biases: ");
            Console.WriteLine(string.Join(", ", biases));
            Console.WriteLine();
            Console.WriteLine("Outputs: ");
            for (int x = 0; x < output.Length; x++)
            {
                Console.Write("Output " + (x + 1) + ": ");
                for (int y = 0; y < output[x].Length; y++)
                {
                    Console.Write(output[x][y] + ", ");

                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            hiddenLayer2.Forward(hiddenLayer1.output);
            var weights2 = hiddenLayer2.getWeights();
            var biases2 = hiddenLayer2.getBiases();
            var output2 = hiddenLayer2.output;
            //prints weights
            Console.WriteLine("Weights: ");
            for (int x = 0; x < weights2.Length; x++)
            {
                Console.Write("Neuron " + (x + 1) + ": ");
                for (int y = 0; y < weights2[x].Length; y++)
                {
                    Console.Write(weights2[x][y] + ", ");

                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Biases: ");
            Console.WriteLine(string.Join(", ", biases2));
            Console.WriteLine();
            Console.WriteLine("Outputs: ");
            for (int x = 0; x < output2.Length; x++)
            {
                Console.Write("Output " + (x + 1) + ": ");
                for (int y = 0; y < output2[x].Length; y++)
                {
                    Console.Write(output2[x][y] + ", ");

                }
                Console.WriteLine();
            }

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
    }
}
