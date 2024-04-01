using System;
using System.Linq;

namespace WindowsFormsApp1
{
    internal class OutputLayer : Layer
    {

        public OutputLayer(int num_inputs, int num_neurons)
        {


            neurons = new OutputNeuron[num_neurons];
            for (int i = 0; i < num_neurons; i++)
            {
                neurons[i] = new OutputNeuron(num_inputs);
            }
        }

        public OutputLayer(OutputLayer oLayer1, OutputLayer oLayer2, int mutationLvl)
        {
            // for every neuron
            neurons = new OutputNeuron[oLayer1.neurons.Length];
            int num;
            for (int i = 0; i < neurons.Length; i++)
            {
                num = Globals.rnd.Next(1, 4);
                if (num == 1)
                {
                    neurons[i] = oLayer1.neurons[i];
                }
                else if (num == 2)
                {
                    neurons[i] = oLayer2.neurons[i];
                }
                else
                {
                    neurons[i] = new OutputNeuron((OutputNeuron)oLayer1.neurons[i], (OutputNeuron)oLayer2.neurons[i], mutationLvl);
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
            //Console.WriteLine("" + string.Join(", ", tempOutput));
            for (int i = 0; i < tempOutput.Length; i++)
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
