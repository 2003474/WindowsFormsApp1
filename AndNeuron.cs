// this is a type of neuron that if all of the weighted inputs are greater than the threshold then it returns a 1 otherwise returns 0

namespace WindowsFormsApp1
{
    internal class AndNeuron : Neuron
    {

        // constructor
        // parameters: number of inputs
        public AndNeuron(int number)
            : base(number)
        {

            Type = "A";
        }

        // constructor
        // parameters: 2 Neurons, Desired Level of Mutation, Number of Input Neurons
        public AndNeuron(Neuron neuron1, Neuron neuron2, double MutationLvl, int num_inputs)
            : base(neuron1, neuron2, MutationLvl, num_inputs)
        {

            Type = "A";
        }

        // calculates the output of the neuron
        // parameters: array of inputs
        public override void Forward(double[] inputs)
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
