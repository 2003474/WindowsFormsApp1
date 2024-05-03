// this is a type of neuron that if all of the wiehgted inputs are greater than the threshold then it returns a 1 otherwise returns 0

namespace WindowsFormsApp1
{
    internal class AndNeuron : Neuron
    {

        public AndNeuron(int number)
        {
            Intitialize(number);
        }

        public AndNeuron(Neuron neuron1, Neuron neuron2, double MutationLvl, int num_inputs)
        {
            Intitialize(neuron1, neuron2, MutationLvl, num_inputs);
        }

        public override void Forward(double[] inputs)
        {
            output = 1.0;
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
                    output = 0.0; break;
                }
            }
        }
    }
}
