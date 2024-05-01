// a "calculation" layer of neurons
// the output of a layer is an array of the neurons in the layer
// constructor either takes inputs, or takes 2 layers and makes a singe layer

using System;
using System.Diagnostics;
using System.Reflection;

namespace WindowsFormsApp1
{
    class HiddenLayer : Layer
    {
        public HiddenLayer(int num_inputs, int num_neurons)
        {
            // add -1, 0, or 1 layer
            int num;
            //Console.WriteLine(num);
            //num_neurons += num;
            this.numNeurons = num_neurons;
            int change = Globals.rnd.Next(-8, 9);
            this.numNeurons += change;
            if (numNeurons < 2)
            {
                numNeurons = 2;
            }
            this.neurons = new Neuron[numNeurons];
            for (int i = 0; i < numNeurons; i++)
            {
                num = Globals.rnd.Next(1, 4);
                if (num == 1)
                {
                    this.neurons[i] = new AndNeuron(num_inputs);
                }
                else if (num == 2)
                {
                    this.neurons[i] = new OrNeuron(num_inputs);
                }
                else if (num == 3)
                {
                    this.neurons[i] = new GreaterThanNeuron(num_inputs);
                }
                else
                {
                    this.neurons[i] = new LessThanNeuron(num_inputs);
                }

            }
        }

        public HiddenLayer(HiddenLayer layer1, HiddenLayer layer2, double mutationLvl, int num_inputs)
        {
            // for every neuron
            int num_inputs_TEST = num_inputs;
            int l1NLength = layer1.neurons.Length;
            int l2NLength = layer2.neurons.Length;

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
            int num;
            for (int i = 0; i < neurons.Length; i++)
            {

                Neuron n1;
                Neuron n2;
                Neuron nChild;

                n1 = layer1.neurons[i % l1NLength];
                n2 = layer2.neurons[i % l2NLength];

                num = Globals.rnd.Next(1, 4);
                if (num == 1)
                {
                    nChild = (Neuron)n1.Clone();
                }
                else if (num == 2)
                {
                    nChild = (Neuron)n2.Clone(); ;
                }
                else
                {
                    //if its a combination then choose one and carry over something
                    num = Globals.rnd.Next(1, 3);
                    if (num == 1)
                    {
                        Type objectType = n1.GetType();
                        Type Int = ((int)1).GetType();
                        ConstructorInfo constructor = objectType.GetConstructor(new[] { objectType, objectType, Int, Int });
                        object[] paramaters = { n1, n2, mutationLvl, num_inputs };
                        nChild = (Neuron)constructor.Invoke(paramaters);
                    }
                    else
                    {
                        Type objectType = n2.GetType();
                        Type Int = ((int)1).GetType();
                        ConstructorInfo constructor = objectType.GetConstructor(new[] { objectType, objectType, Int, Int });
                        object[] paramaters = { n1, n2, mutationLvl, num_inputs };
                        nChild = (Neuron)constructor.Invoke(paramaters);
                    }
                }

                //check to make sure the weights are right
                if (nChild.weight.Length != num_inputs)
                {
                    double[] newWeights = new double[num_inputs];
                    for (int k = 0; k < num_inputs; k++)
                    {
                        newWeights[k] = nChild.weight[k % nChild.weight.Length];
                    }

                    nChild.weight = newWeights;
                }

                neurons[i] = nChild;
                Debug.Assert(neurons[i].weight.Length == num_inputs_TEST);
            }
        }

        public override double[] SingleOutput(double[] inputs)
        {
            double[] tempOutput = new double[numNeurons];
            for (int i = 0; i < numNeurons; i++)
            {
                 neurons[i].Forward(inputs);
                tempOutput[i] = neurons[i].output;
            }
            return tempOutput;
        }
    }
}