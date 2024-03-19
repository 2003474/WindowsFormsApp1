using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;

namespace WindowsFormsApp1
{
    class DenseLayer : Layer
    {

        public DenseLayer(int num_inputs, int num_neurons)
        {
            ActivationFunction ReLU = new ReLU();
            this.neurons = new DenseNeuron[num_neurons];
            for(int i = 0; i < num_neurons; i++)
            {
                this.neurons[i] = new DenseNeuron(num_inputs, ReLU);
            }
        }

        public override double[] SingleOutput(double[] inputs)
        {
            double[] tempOutput = new double[neurons.Length];
            for (int i = 0; i<neurons.Length; i++)
            {
                neurons[i].Forward(inputs);
                tempOutput[i] = neurons[i].output;
            }
            return tempOutput;
        }
    }
}