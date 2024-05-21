// this is a type of neuron that if all of the wiehgted inputs are greater than the threshold then it returns a 1 otherwise returns 0

namespace WindowsFormsApp1
{
    internal class AndNeuron : Neuron
    {

        public AndNeuron(int number)
        {
            Intitialize(number);
            Type = "A";
        }

        public AndNeuron(Neuron neuron1, Neuron neuron2, double MutationLvl, int num_inputs)
        {
            Intitialize(neuron1, neuron2, MutationLvl, num_inputs);
            Type = "A";
        }

        public new void Forward(double[] inputs)
        {
            Output = 1.0;
            //output = Matrix.Dot(weight, inputs) + bias;
            double[] weightedInputs = new double[inputs.Length];
            for (int i = 0; i < weightedInputs.Length; i++)
            {
                weightedInputs[i] = inputs[i] * Weight[i];
            }
            foreach (double input in weightedInputs)
            {
                if (input < Threshold)
                {
                    Output = 0.0; break;
                }
            }
        }
    }
}
