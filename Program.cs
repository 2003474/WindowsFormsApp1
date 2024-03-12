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
            double[] inputs = new double[2] { 5.9, 9.3 };
            NeuronLayer hidenLayer1 = new NeuronLayer(2, 8);
            NeuronLayer hidenLayer2 = new NeuronLayer(8, 8);
            Console.WriteLine(string.Join(" ", hidenLayer1.Output(inputs)) + " " + string.Join(" ", hidenLayer2.Output(hidenLayer1.Output(inputs))));

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
    }
}
