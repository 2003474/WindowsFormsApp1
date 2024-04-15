using System;
using System.Reflection;

namespace WindowsFormsApp1
{
    class HiddenLayer : Layer
    {
        public HiddenLayer(int num_inputs, int num_neurons)
        {
            // add -1, 0, or 1 layer
            int num = Globals.rnd.Next(-1, 2);
            //Console.WriteLine(num);
            //num_neurons += num;
            this.neurons = new Neuron[num_neurons];
            for (int i = 0; i < num_neurons; i++)
            {
                num = Globals.rnd.Next(1, 4);
                if (num == 1)
                {
                    this.neurons[i] = new MultiplicationNeuron(num_inputs);
                }
                else if (num == 2)
                {
                    this.neurons[i] = new OrNeuron(num_inputs);
                }
                else
                {
                    this.neurons[i] = new AndNeuron(num_inputs);
                }

            }
        }

        public HiddenLayer(HiddenLayer layer1, HiddenLayer layer2, int mutationLvl)
        {
            // for every neuron
            neurons = new Neuron[layer1.neurons.Length];
            int num;
            for (int i = 0; i < neurons.Length; i++)
            {
                num = Globals.rnd.Next(1, 4);
                if (num == 1)
                {
                    neurons[i] = layer1.neurons[i];
                }
                else if (num == 2)
                {
                    neurons[i] = layer2.neurons[i];
                }
                else
                {

                    //if its a combination then choose one and carry over something
                    num = Globals.rnd.Next(1, 3);
                    if (num == 1)
                    {
                        Type objectType = layer1.neurons[i].GetType();
                        Type Int = ((int)1).GetType();
                        ConstructorInfo constructor = objectType.GetConstructor(new[] { objectType, objectType, Int });
                        ConstructorInfo constructor2 = objectType.GetConstructor(new[] { Int });
                        object[] paramaters = { layer1.neurons[i].weight.Length };
                        object n = constructor2.Invoke(paramaters);
                        object[] paramaters2 = { layer1.neurons[i], n, 0 };
                        neurons[i] = (Neuron)constructor.Invoke(paramaters2);
                    }
                    else
                    {
                        Type objectType = layer2.neurons[i].GetType();
                        Type Int = ((int)1).GetType();
                        ConstructorInfo constructor = objectType.GetConstructor(new[] { objectType, objectType, Int });

                        ConstructorInfo constructor2 = objectType.GetConstructor(new[] { Int });
                        object[] paramaters = { layer2.neurons[i].weight.Length };
                        object n = constructor2.Invoke(paramaters);
                        object[] paramaters2 = { layer2.neurons[i], n, 0 };
                        neurons[i] = (Neuron)constructor.Invoke(paramaters2);
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
                tempOutput[i] = neurons[i].output;
            }
            return tempOutput;
        }
    }
}