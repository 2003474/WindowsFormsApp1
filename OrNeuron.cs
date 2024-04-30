// 

namespace WindowsFormsApp1
{
    internal class OrNeuron : Neuron
    {
        public OrNeuron(int number)
        {
            Intitialize(number);
        }

        public OrNeuron(Neuron neuron1, Neuron neuron2, double MutationLvl, int num_inputs)
        {
            Intitialize(neuron1, neuron2, MutationLvl, num_inputs);
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
