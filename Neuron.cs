// has weights and bias
// can be constructed using 2 other neurons

using System;
using System.Diagnostics;


namespace WindowsFormsApp1
{
    public class Neuron : ICloneable
    {
        public double[] Weight { get; set; }
        public double Bias { get; set; }
        public double Output { get; set; }
        public double Threshold { get; set; }
        public String Type { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        [Newtonsoft.Json.JsonConstructor]
        public Neuron(double[] weight, double bias, double output, double threshold, string type)
        {

            this.Weight = weight;
            this.Bias = bias;
            this.Output = output;
            this.Threshold = threshold;
            this.Type = type;


        }
        public Neuron(int num_inputs)
        {
            Debug.Assert(num_inputs != 0);
            Weight = new double[num_inputs];
            for (int i = 0; i < num_inputs; i++)
            {
                Weight[i] = Globals.rnd.NextDouble();
                if (Globals.rnd.Next(-1, 1) == -1.0)
                {
                    Weight[i] = -Weight[i];
                }
            }
            Bias = Globals.rnd.NextDouble();
            Threshold = Globals.rnd.NextDouble();
            if (Globals.rnd.Next(-1, 1) == -1.0)
            {
                Threshold = -Threshold;
            }
        }


        public Neuron(Neuron neuron1, Neuron neuron2, double MutationLvl, int num_inputs)
        {
            int num = Globals.rnd.Next(1, 4);
            if (num == 1)
            {
                Threshold = neuron1.Threshold;
            }
            else if (num == 2)
            {
                Threshold = neuron2.Threshold;
            }
            else
            {
                Threshold = (neuron1.Threshold + neuron2.Threshold) / 2;
            }

            //mutation threshold
            if (Globals.rnd.Next(0, 100) < MutationLvl)
            {
                Threshold = Globals.rnd.NextDouble() * 4 - 2;
            }


            int weight1Length = neuron1.Weight.Length;
            int weight2Length = neuron2.Weight.Length;
            Weight = new double[num_inputs];


            for (int i = 0; i < Weight.Length; i++)
            {
                num = Globals.rnd.Next(1, 4);
                if (num == 1)
                {
                    Weight[i] = neuron1.Weight[i % weight1Length];
                }
                else if (num == 2)
                {
                    Weight[i] = neuron2.Weight[i % weight2Length];
                }
                else
                {
                    Weight[i] = (neuron1.Weight[i % weight1Length] + neuron2.Weight[i % weight2Length]) / 2;
                }
            }

            //mutation weights
            int rNum = Globals.rnd.Next(0, Weight.Length);
            for (int i = 0; i < rNum; i++)
            {
                if (Globals.rnd.Next(0, 100) < MutationLvl)
                {
                    Weight[Globals.rnd.Next(0, Weight.Length)] = Globals.rnd.NextDouble() * 4 - 2;
                }
            }


            num = Globals.rnd.Next(1, 4);
            if (num == 1)
            {
                Bias = neuron1.Bias;
            }
            else if (num == 2)
            {
                Bias = neuron2.Bias;
            }
            else
            {
                Bias = (neuron1.Bias + neuron2.Bias) / 2;
            }
        }

        public virtual void Forward(double[] inputs)
        {

        }
    }
}
