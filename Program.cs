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
            DenseLayer hiddenLayer1 = new DenseLayer(2, 8);
            DenseLayer hiddenLayer2 = new DenseLayer(8, 8);
            OutputLayer outputLayer1 = new OutputLayer(8, 2);
            
            hiddenLayer1.Forward(inputs);
            hiddenLayer2.Forward(hiddenLayer1.output);
            outputLayer1.Forward(hiddenLayer2.output);
            // print outputs
            var output = outputLayer1.output;
            for (int x = 0; x < output.Length; x++)
            {
                Console.Write("Output " + (x + 1) + ": ");
                for (int y = 0; y < output[x].Length; y++)
                {
                    Console.Write(output[x][y] + ", ");

                }
                Console.WriteLine();
            }

            //var weights = hiddenLayer1.GetWeights();
            //var biases = hiddenLayer1.GetBiases();
            //var output = hiddenLayer1.output;
            //Console.WriteLine("Weights: ");
            //for (int x = 0; x < weights.Length; x++)
            //{
            //    Console.Write("Neuron " + (x+1) + ": ");
            //    for (int y = 0; y < weights[x].Length; y++)
            //    {
            //        Console.Write(weights[x][y] + ", ") ;

            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine();
            //Console.WriteLine("Biases: ");
            //Console.WriteLine(string.Join(", ", biases));
            //Console.WriteLine();
            //Console.WriteLine("Outputs: ");
            //for (int x = 0; x < output.Length; x++)
            //{
            //    Console.Write("Output " + (x + 1) + ": ");
            //    for (int y = 0; y < output[x].Length; y++)
            //    {
            //        Console.Write(output[x][y] + ", ");

            //    }
            //    Console.WriteLine();
            //}

            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();


            //var weights2 = hiddenLayer2.GetWeights();
            //var biases2 = hiddenLayer2.GetBiases();
            //var output2 = hiddenLayer2.output;
            ////prints weights
            //Console.WriteLine("Weights: ");
            //for (int x = 0; x < weights2.Length; x++)
            //{
            //    Console.Write("Neuron " + (x + 1) + ": ");
            //    for (int y = 0; y < weights2[x].Length; y++)
            //    {
            //        Console.Write(weights2[x][y] + ", ");

            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine();
            //Console.WriteLine("Biases: ");
            //Console.WriteLine(string.Join(", ", biases2));
            //Console.WriteLine();
            //Console.WriteLine("Outputs: ");
            //for (int x = 0; x < output2.Length; x++)
            //{
            //    Console.Write("Output " + (x + 1) + ": ");
            //    for (int y = 0; y < output2[x].Length; y++)
            //    {
            //        Console.Write(output2[x][y] + ", ");

            //    }
            //    Console.WriteLine();
            //}

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
    }
}