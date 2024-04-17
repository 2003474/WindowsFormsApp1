﻿namespace WindowsFormsApp1
{
    internal class OrNeuron : Neuron
    {
        public OrNeuron(int num_inputs)
        {
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

        public OrNeuron(Neuron neuron1, Neuron neuron2, double MutationLvl)
        {
            weight = new double[neuron1.weight.Length];
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

            for (int i = 0; i < weight.Length; i++)
            {
                num = Globals.rnd.Next(1, 4);
                if (num == 1)
                {
                    weight[i] = neuron1.weight[i];
                }
                else if (num == 2)
                {
                    weight[i] = neuron2.weight[i];
                }
                else
                {
                    weight[i] = (neuron1.weight[i] + neuron2.weight[i]) / 2;
                }
            }

            //mutation chance for one weight
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

        public override void Forward(double[] inputs)
        {
            output = 0.0;
            //output = Matrix.Dot(weight, inputs) + bias;
            double[] weightedInputs = new double[inputs.Length];
            for (int i = 0; i < weightedInputs.Length; i++)
            {
                weightedInputs[i] = inputs[i] * weight[i];
            }
            foreach (double input in weightedInputs)
            {
                if (input < threshold)
                {
                    output = 1.0; break;
                }
            }
        }
    }
}
