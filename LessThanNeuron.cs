// if the sum of the weighted inputs is less than the threshold than it returns that number otherwise returns 0.0

using Accord.Math;

namespace WindowsFormsApp1
{
    internal class LessThanNeuron : Neuron
    {

        // constructor
        // parameters: number of inputs
        public LessThanNeuron(int number)
            : base(number)
        {

            Type = "LT";
        }

        // constructor
        // parameters: 2 Neurons, Desired Level of Mutation, Number of Input Neurons
        public LessThanNeuron(Neuron neuron1, Neuron neuron2, double MutationLvl, int num_inputs)
            : base(neuron1, neuron2, MutationLvl, num_inputs)
        {
            Type = "LT";
        }

        // calculates the output of the neuron
        // parameter: array of input values
        public override void Forward(double[] inputs)
        {

            Output = Matrix.Dot(Weight, inputs) + Bias;
            if (Output > Threshold)
            {
                Output = 0.0;
            }
        }
    }
}