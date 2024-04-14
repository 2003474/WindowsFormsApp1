namespace WindowsFormsApp1
{
    internal class OrNeuron : Neuron
    {
        double threshold;
        public OrNeuron(int num_inputs)
        {
            weight = new double[num_inputs];
            for (int i = 0; i < weight.Length; i++)
            {
                weight[i] = 0.0;
            }
            threshold = Globals.rnd.NextDouble();
            if (Globals.rnd.Next(-1, 1) == -1.0)
            {
                threshold = -threshold;
            }

        }

        public OrNeuron(OrNeuron neuron1, OrNeuron neuron2, int MutationLvl)
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

        }

        public override void Forward(double[] inputs)
        {
            output = 0.0;
            foreach (double input in inputs)
            {
                if (input > threshold)
                {
                    output = 1.0; break;
                }
            }
        }
    }
}
