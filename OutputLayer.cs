using System;
using System.Linq;

namespace WindowsFormsApp1
{
    internal class OutputLayer : Layer
    {

        public OutputLayer(int num_inputs, int num_neurons)
        {

            this.numNeurons = num_neurons;
            int change = Globals.rnd.Next(-10, 10);
            this.numNeurons += change;
            if (numNeurons < 2)
            {
                numNeurons = 2;
            }
            neurons = new OutputNeuron[num_neurons];
            for (int i = 0; i < num_neurons; i++)
            {
                neurons[i] = new OutputNeuron(num_inputs);
            }
        }

        public OutputLayer(OutputLayer oLayer1, OutputLayer oLayer2, double mutationLvl, int num_inputs)
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

            // for every neuron
            neurons = new OutputNeuron[oLayer1.neurons.Length];
            int num;
            for (int i = 0; i < neurons.Length; i++)
            {
                Neuron n1;
                Neuron n2;

                if (i >= l1NLength)
                {
                    int tempI = i;
                    while (i >= l1NLength)
                    {
                        tempI -= l1NLength;
                    }
                    n1 = oLayer1.neurons[i % l1NLength];
                    n2 = oLayer2.neurons[i];
                }
                else if (i >= l2NLength)
                {
                    n1 = oLayer1.neurons[i];
                    n2 = oLayer2.neurons[i % l2NLength];
                }
                else
                {
                    n1 = oLayer1.neurons[i];
                    n2 = oLayer2.neurons[i];
                }


                num = Globals.rnd.Next(1, 4);
                if (num == 1)
                {
                    neurons[i] = n1;
                }
                else if (num == 2)
                {
                    neurons[i] = n2;
                }
                else
                {
                    neurons[i] = new OutputNeuron(n1, n2, mutationLvl, num_inputs);
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
                tempOutput[i] = neurons[i].output;
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
