// a class that has a bunch of output neurons and outputs an array of the neurons outputs
// makes all of the outputs into a percentage


using System;
using System.Linq;

namespace WindowsFormsApp1
{
    internal class OutputLayer : Layer
    {
        public OutputNeuron[] oNeurons;
        
        [Newtonsoft.Json.JsonConstructor]
        public OutputLayer(Neuron[] neurons, double[] output, int numNeurons, OutputNeuron[] oNeurons)
        {
            this.Neurons = neurons;
            this.Output = output;
            this.NumNeurons = numNeurons;
            this.oNeurons = oNeurons;
        }

        public OutputLayer(int num_inputs, int num_neurons)
            //:base(null, null, 0)
        {

            this.NumNeurons = num_neurons;
            oNeurons = new OutputNeuron[num_neurons];
            for (int i = 0; i < num_neurons; i++)
            {
                oNeurons[i] = new OutputNeuron(num_inputs);
            }
        }

        public OutputLayer(OutputLayer oLayer1, OutputLayer oLayer2, double mutationLvl, int num_inputs)
            //: base(null, null, 0)
        {
            int l1NLength = oLayer1.oNeurons.Length;
            int l2NLength = oLayer2.oNeurons.Length;

            // makes a new layer array with length from parents or average
            if (l1NLength != l2NLength)
            {
                int numb = Globals.rnd.Next(1, 4);
                if (numb == 1)
                {
                    oNeurons = new OutputNeuron[l1NLength];
                }
                else if (numb == 2)
                {
                    oNeurons = new OutputNeuron[l2NLength];
                }
                else
                {
                    oNeurons = new OutputNeuron[(l1NLength + l2NLength) / 2];
                }
            }
            else
            {
                oNeurons = new OutputNeuron[l1NLength];
            }
            NumNeurons = oNeurons.Length;
            // for every neuron
            int num;
            for (int i = 0; i < oNeurons.Length; i++)
            {
                OutputNeuron n1;
                OutputNeuron n2;

                n1 = oLayer1.oNeurons[i % l1NLength];
                n2 = oLayer2.oNeurons[i % l2NLength];



                num = Globals.rnd.Next(1, 4);
                if (num == 1)
                {
                    oNeurons[i] = (OutputNeuron)n1.Clone();
                }
                else if (num == 2)
                {
                    oNeurons[i] = (OutputNeuron)n2.Clone();
                }
                else
                {
                    oNeurons[i] = new OutputNeuron(n1, n2, mutationLvl, num_inputs);
                }

                if (oNeurons[i].Weight.Length != num_inputs)
                {
                    OutputNeuron n = oNeurons[i];
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
            // new neuron
            double[] tempOutput = new double[oNeurons.Length];
            for (int i = 0; i < oNeurons.Length; i++)
            {
                oNeurons[i].Forward(inputs);
                tempOutput[i] = oNeurons[i].Output;
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
