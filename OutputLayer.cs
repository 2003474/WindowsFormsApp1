using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class OutputLayer : Layer
    {


        public OutputLayer(int num_inputs, int num_neurons)
        {
            

            this.neurons = new OutputNeuron[num_neurons];
            for (int i = 0; i < num_neurons; i++)
            {
                this.neurons[i] = new OutputNeuron(num_inputs);
            }
        }
        public override double[] SingleOutput(double[] inputs)
        {

            double[] tempOutput = new double[neurons.Length];
            for (int i = 0; i < neurons.Length; i++)
            {
                neurons[i].Forward(inputs);
                tempOutput[i] = neurons[i].output;
            }
            double maxValue = tempOutput.Max();
            //Console.WriteLine("" + string.Join(", ", tempOutput));
            for(int i = 0;i < tempOutput.Length; i++)
            {
                tempOutput[i] -= maxValue;
                tempOutput[i] = Math.Exp(tempOutput[i]);
            }
            double total = tempOutput.Sum();
            //Console.WriteLine("" + string.Join(", ", tempOutput));
            for (int i = 0; i < tempOutput.Length; i++)
            {
                tempOutput[i] /= total;
            }

            return tempOutput;

        }
    }
}
