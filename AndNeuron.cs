namespace WindowsFormsApp1
{
    internal class AndNeuron : Neuron
    {
        double threshold;
        public AndNeuron(int num_inputs)
        {
            weight = new double[num_inputs];
            threshold = Globals.rnd.NextDouble();
            if (Globals.rnd.Next(-1, 1) == -1.0)
            {
                threshold = -threshold;
            }

        }

        public AndNeuron(AndNeuron neuron1, AndNeuron neuron2, int MutationLvl)
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
        }

        public override void Forward(double[] inputs)
        {
            output = 1.0;
            foreach (double input in inputs)
            {
                if (input < threshold)
                {
                    output = 0.0; break;
                }
            }
        }
    }
}
