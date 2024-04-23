using Accord.Math;

namespace WindowsFormsApp1
{
    internal class OutputNeuron : Neuron
    {

        public OutputNeuron(int num_inputs)
        {
            weight = Vector.Random(num_inputs);
            bias = Vector.Random(1)[0];
        }

        public OutputNeuron(Neuron neuron1, Neuron neuron2, double MutationLvl, int num_inputs)
        {
            Intitialize(neuron1, neuron2, MutationLvl, num_inputs);
        }

        //public OutputNeuron(Neuron neuron1, Neuron neuron2, double MutationLvl, int num_inputs)
        //{
        //    //chooses activation function
        //    //rand num 1, 2
        //    int num;
        //    // 1 is neuron1 actFunc
        //    // 2 is neuron2 actFunc
        //    // prolly same one tho for now
        //    //combines weight values, (chooses 1 from each or averages both)
        //    int weight1Length = neuron1.weight.Length;
        //    int weight2Length = neuron2.weight.Length;
        //    weight = new double[num_inputs];


        //    for (int i = 0; i < weight.Length; i++)
        //    {
        //        num = Globals.rnd.Next(1, 4);
        //        if (num == 1)
        //        {
        //            weight[i] = neuron1.weight[i % weight1Length];
        //        }
        //        else if (num == 2)
        //        {
        //            weight[i] = neuron2.weight[i % weight2Length];
        //        }
        //        else
        //        {
        //            weight[i] = (neuron1.weight[i % weight1Length] + neuron2.weight[i % weight2Length]) / 2;
        //        }
        //    }

        //    //mutation weights
        //    if (Globals.rnd.Next(0, 100) < MutationLvl)
        //    {
        //        weight[Globals.rnd.Next(0, weight.Length)] = Globals.rnd.NextDouble() * 4 - 2;
        //    }


        //    //combines bias values
        //    //rand num 1, 2, 3
        //    num = Globals.rnd.Next(1, 4);
        //    if (num == 1)
        //    {
        //        bias = neuron1.bias;
        //    }
        //    else if (num == 2)
        //    {
        //        bias = neuron2.bias;
        //    }
        //    else
        //    {
        //        bias = (neuron1.bias + neuron2.bias) / 2;
        //    }

        //    //mutation threshold
        //    if (Globals.rnd.Next(0, 100) < MutationLvl)
        //    {
        //        bias = Globals.rnd.NextDouble() * 4 - 2;
        //    }

        //}

        public override void Forward(double[] inputs)
        {
            output = Matrix.Dot(weight, inputs) + bias;
        }
    }
}
