using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;

namespace WindowsFormsApp1
{
    internal class NeuronLayer
    {
        public Neuron[] neurons = null;
        public decimal[] output = null;


        public NeuronLayer(int num_inputs, int num_neurons)
        {
            this.neurons = new Neuron[num_neurons];
            for(int i = 0; i < num_neurons; i++)
            {
                this.neurons[i] = new Neuron(num_inputs);
            }
        }



        public Forward Output(double[] inputs)
        {
            output = new double[neurons.Length];
            for(int i = 0; i < inputs.Length; i++)
            {
                neurons[i].Forward(inputs);
                output[i] = neurons[i].output;
            }
        }
    }
}
