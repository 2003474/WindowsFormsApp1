// if the sum of all of the inputs is greater than the threshold than it returns that number else it returns 0

using Accord.Math;

namespace WindowsFormsApp1
{
    internal class GreaterThanNeuron : Neuron
    {
        // constructor
        // parameters: number of inputs
        public GreaterThanNeuron(int number)
            : base(number)
        {

            Type = "GT";
        }

        // constructor
        // parameters: 2 Neurons, Desired Level of Mutation, Number of Input Neurons
        public GreaterThanNeuron(Neuron neuron1, Neuron neuron2, double MutationLvl, int num_inputs)
            : base(neuron1, neuron2, MutationLvl, num_inputs)
        {

            Type = "GT";
        }

        // calculates the output of the neuron
        // parameter: array of input values
        public override void Forward(double[] inputs)
        {
            Output = Matrix.Dot(Weight, inputs) + Bias;
            if (Output < Threshold)
            {
                Output = 0.0;
            }
        }
    }
}