// a "calculation" layer of neurons
// the output of a layer is an array of the neurons in the layer

using System;
using System.Diagnostics;
using System.Reflection;

namespace WindowsFormsApp1
{
    class HiddenLayer : Layer
    {
        // constructor
        // parameters: an array of Neurons, an array of outpus, the number of neurons
        [Newtonsoft.Json.JsonConstructor]
        public HiddenLayer(Neuron[] neurons, double[] output, int numNeurons)
        {
            this.Neurons = neurons;
            this.Output = output;
            this.NumNeurons = numNeurons;
        }

        // constructor
        // parameters: number of Inputs (number of neurons in the previous layer), Number of Neurons in the current layer
        public HiddenLayer(int num_inputs, int num_neurons)
        //: base(null, null, 0)
        {
            // add -1, 0, or 1 layer
            int num;
            //Console.WriteLine(num);
            //num_neurons += num;
            this.NumNeurons = num_neurons;
            int change = Globals.rnd.Next(-8, 9);
            this.NumNeurons += change;
            if (NumNeurons < 2)
            {
                NumNeurons = 2;
            }
            this.Neurons = new Neuron[NumNeurons];
            for (int i = 0; i < NumNeurons; i++)
            {
                num = Globals.rnd.Next(1, 5);
                if (num == 1)
                {
                    this.Neurons[i] = new AndNeuron(num_inputs);
                }
                else if (num == 2)
                {
                    this.Neurons[i] = new OrNeuron(num_inputs);
                }
                else if (num == 3)
                {
                    this.Neurons[i] = new GreaterThanNeuron(num_inputs);
                }
                else
                {
                    this.Neurons[i] = new LessThanNeuron(num_inputs);
                }

            }
        }

        // constructor
        // parameters: 2 Neuron Layers, Desired Level of Mutation, Number of inputs from previous Layer
        public HiddenLayer(HiddenLayer layer1, HiddenLayer layer2, double mutationLvl, int num_inputs)
        //: base(null, null, 0)
        {
            // for every neuron
            int num_inputs_TEST = num_inputs;
            int l1NLength = layer1.Neurons.Length;
            int l2NLength = layer2.Neurons.Length;

            // makes a new layer array with length from parents or average
            if (l1NLength != l2NLength)
            {
                int numb = Globals.rnd.Next(1, 4);
                if (numb == 1)
                {
                    Neurons = new Neuron[l1NLength];
                }
                else if (numb == 2)
                {
                    Neurons = new Neuron[l2NLength];
                }
                else
                {
                    Neurons = new Neuron[(l1NLength + l2NLength) / 2];
                }
            }
            else
            {
                Neurons = new Neuron[l1NLength];
            }
            NumNeurons = Neurons.Length;
            int num;
            for (int i = 0; i < Neurons.Length; i++)
            {

                Neuron n1;
                Neuron n2;
                Neuron nChild;

                n1 = layer1.Neurons[i % l1NLength];
                n2 = layer2.Neurons[i % l2NLength];

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
                if (nChild.Weight.Length != num_inputs)
                {
                    double[] newWeights = new double[num_inputs];
                    for (int k = 0; k < num_inputs; k++)
                    {
                        newWeights[k] = nChild.Weight[k % nChild.Weight.Length];
                    }

                    nChild.Weight = newWeights;
                }

                Neurons[i] = nChild;
                Debug.Assert(Neurons[i].Weight.Length == num_inputs_TEST);
            }
        }

        // Puts all of the outputs from the Neurons into an array
        // parameters: array of numbers as input (outpus from the previous array)
        public override double[] SingleOutput(double[] inputs)
        {
            double[] tempOutput = new double[NumNeurons];
            for (int i = 0; i < NumNeurons; i++)
            {
                Neurons[i].Forward(inputs);
                tempOutput[i] = Neurons[i].Output;
            }
            return tempOutput;
        }
    }
}