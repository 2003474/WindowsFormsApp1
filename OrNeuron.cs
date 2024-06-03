// same as normal neuron but if one of the weighted inputs is greater than the threshold than it retunrs 1 otherwise it returns 0

namespace WindowsFormsApp1
{
    internal class OrNeuron : Neuron
    {

        // constructor
        // parameters: number of inputs
        public OrNeuron(int number)
            : base(number)
        {

            Type = "O";
        }

        // constructor
        // parameters: 2 Neurons, Desired Level of Mutation, Number of Input Neurons
        public OrNeuron(Neuron neuron1, Neuron neuron2, double MutationLvl, int num_inputs)
            : base(neuron1, neuron2, MutationLvl, num_inputs)
        {

            Type = "O";
        }

        // calculates the output of the neuron
        // parameter: array of input values
        public override void Forward(double[] inputs)
        {
            Output = 0.0;
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
                    Output = 1.0; break;
                }
            }
        }
    }
}
