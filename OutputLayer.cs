// a class that has a bunch of output neurons and outputs an array of the neurons outputs
// makes all of the outputs into a percentage


using System;
using System.Linq;

namespace WindowsFormsApp1
{
    internal class OutputLayer : Layer
    {

        public OutputLayer(int num_inputs, int num_neurons)
            //:base(null, null, 0)
        {

            this.numNeurons = num_neurons;
            neurons = new OutputNeuron[num_neurons];
            for (int i = 0; i < num_neurons; i++)
            {
                neurons[i] = new OutputNeuron(num_inputs);
            }
        }

        public OutputLayer(OutputLayer oLayer1, OutputLayer oLayer2, double mutationLvl, int num_inputs)
            //: base(null, null, 0)
        {
            int l1NLength = oLayer1.neurons.Length;
            int l2NLength = oLayer2.neurons.Length;

            // makes a new layer array with length from parents or average
            if (l1NLength != l2NLength)
            {
                int numb = Globals.rnd.Next(1, 4);
                if (numb == 1)
                {
                    neurons = new Neuron[l1NLength];
                }
                else if (numb == 2)
                {
                    neurons = new Neuron[l2NLength];
                }
                else
                {
                    neurons = new Neuron[(l1NLength + l2NLength) / 2];
                }
            }
            else
            {
                neurons = new Neuron[l1NLength];
            }
            numNeurons = neurons.Length;
            // for every neuron
            neurons = new OutputNeuron[oLayer1.neurons.Length];
            int num;
            for (int i = 0; i < neurons.Length; i++)
            {
                Neuron n1;
                Neuron n2;

                n1 = oLayer1.neurons[i % l1NLength];
                n2 = oLayer2.neurons[i % l2NLength];



                num = Globals.rnd.Next(1, 4);
                if (num == 1)
                {
                    neurons[i] = (Neuron)n1.Clone();
                }
                else if (num == 2)
                {
                    neurons[i] = (Neuron)n2.Clone();
                }
                else
                {
                    neurons[i] = new OutputNeuron(n1, n2, mutationLvl, num_inputs);
                }

                if (neurons[i].Weight.Length != num_inputs)
                {
                    Neuron n = neurons[i];
                    double[] oldWeights = n.Weight;
                    n.Weight = new double[num_inputs];
                    for (int k = 0; k < num_inputs; k++)
                    {
                        n.Weight[k] = oldWeights[k % oldWeights.Length];
                    }
                }


            }
            // randomly chooses between neurons either a 0 1 2
            // 0 is layer1 neruon
            // 1 is layer2 neuron
            // 2 is combination of both (neurons[i] = new DenseNeuron(layer1.neurons[i], layer2.neurons[i], mutationLvl)
        }

        public override double[] SingleOutput(double[] inputs)
        {

            double[] tempOutput = new double[neurons.Length];
            for (int i = 0; i < neurons.Length; i++)
            {
                neurons[i].Forward(inputs);
                tempOutput[i] = neurons[i].Output;
            }
            double maxValue = tempOutput.Max();
            for (int i = 0; i < tempOutput.Length; i++)
            {
                tempOutput[i] -= maxValue;
                tempOutput[i] = Math.Exp(tempOutput[i]);
            }
            double total = tempOutput.Sum();
            for (int i = 0; i < tempOutput.Length; i++)
            {
                tempOutput[i] /= total;
            }

            return tempOutput;

        }
    }
}
