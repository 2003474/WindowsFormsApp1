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
        public double[][] output = null;
        

        public NeuronLayer(int num_inputs, int num_neurons)
        {
            this.neurons = new Neuron[num_neurons];
            for(int i = 0; i < num_neurons; i++)
            {
                this.neurons[i] = new Neuron(num_inputs);
            }
        }



        public void Forward(double[] inputs)
        {
            output = new double[1][];
            output[0] = SingleOutput(inputs);
        }

        private double[] SingleOutput(double[] inputs){
            double[] tempOutput = new double[neurons.Length];
            for(int i = 0; i < neurons.Length; i++)
            {
                neurons[i].Forward(inputs);
                tempOutput[i] = neurons[i].output;
            }
            return tempOutput;
        }

        public void Forward(double[][] inputs) {
            output = new double[inputs.Length][];
            for(int i = 0; i < inputs.Length; i++)
            {
                output[i] = SingleOutput(inputs[i]);
            }
        }

        public double[][] GetWeights() {
            double[][] weights = new double[neurons.Length][];
            for(int i = 0; i < neurons.Length; i++) {
                weights[i] = neurons[i].weight;
            }
            return weights;
        }

        public double[] GetBiases() {
            double[] biases = new double[neurons.Length];
            for(int i = 0; i < neurons.Length; i++) {
                biases[i] = neurons[i].bias;
            }
            return biases;
        }
        
    }
}