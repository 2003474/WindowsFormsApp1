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
            double[][] inputs = new double[4, 2] { {5.9, 9.3}, {7.2, -4.6}, {0.1, -1.3}, {-0.7, -2.1},};
            NeuronLayer hidenLayer1 = new NeuronLayer(2, 8);
            NeuronLayer hidenLayer2 = new NeuronLayer(8, 8);
            
            hiddenLayer1.Forward(inputs);
            Console.WriteLine(string.Join(" ", hiddenLayer1.getWeights()));
            Console.WriteLine(string.Join(" ", hiddenLayer1.getBiases()));
            Console.WriteLine(string.Join(" ", hiddenLayer1.output));

            
            hiddenLayer2.Forward(hiddenLayer1.output);
            Console.WriteLine(string.Join(" ", hiddenLayer2.getWeights()));
            Console.WriteLine(string.Join(" ", hiddenLayer2.getBiases()));
            Console.WriteLine(string.Join(" ", hiddenLayer2.output));
            
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
    }
}
