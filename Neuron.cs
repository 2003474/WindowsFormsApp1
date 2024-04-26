using System;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    abstract class Neuron : ICloneable
    {
        public double[] weight;
        public double bias;
        public double output = 0.0;
        public double threshold;

        public object Clone()
        {
            return this.MemberwiseClone();
        }


        public void Intitialize(int num_inputs)
        {
            Debug.Assert(num_inputs != 0);
            weight = new double[num_inputs];
            for (int i = 0; i < num_inputs; i++)
            {
                weight[i] = Globals.rnd.NextDouble();
                if (Globals.rnd.Next(-1, 1) == -1.0)
                {
                    weight[i] = -weight[i];
                }
            }
            bias = Globals.rnd.NextDouble();
            threshold = Globals.rnd.NextDouble();
            if (Globals.rnd.Next(-1, 1) == -1.0)
            {
                threshold = -threshold;
            }
        }


        public void Intitialize(Neuron neuron1, Neuron neuron2, double MutationLvl, int num_inputs)
        {
            int num = Globals.rnd.Next(1, 4);
            if (num == 1)
            {
                threshold = neuron1.threshold;
            }
            else if (num == 2)
            {
                threshold = neuron2.threshold;
            }
            else
            {
                threshold = (neuron1.threshold + neuron2.threshold) / 2;
            }

            //mutation threshold
            if (Globals.rnd.Next(0, 100) < MutationLvl)
            {
                threshold = Globals.rnd.NextDouble() * 4 - 2;
            }


            int weight1Length = neuron1.weight.Length;
            int weight2Length = neuron2.weight.Length;
            weight = new double[num_inputs];


            for (int i = 0; i < weight.Length; i++)
            {
                num = Globals.rnd.Next(1, 4);
                if (num == 1)
                {
                    weight[i] = neuron1.weight[i % weight1Length];
                }
                else if (num == 2)
                {
                    weight[i] = neuron2.weight[i % weight2Length];
                }
                else
                {
                    weight[i] = (neuron1.weight[i % weight1Length] + neuron2.weight[i % weight2Length]) / 2;
                }
            }

            //mutation weights
            if (Globals.rnd.Next(0, 100) < MutationLvl)
            {
                weight[Globals.rnd.Next(0, weight.Length)] = Globals.rnd.NextDouble() * 4 - 2;
            }



            num = Globals.rnd.Next(1, 4);
            if (num == 1)
            {
                bias = neuron1.bias;
            }
            else if (num == 2)
            {
                bias = neuron2.bias;
            }
            else
            {
                bias = (neuron1.bias + neuron2.bias) / 2;
            }
        }

        public abstract void Forward(double[] inputs);
    }
}
