// if the sum of all of the inputs is greater than the threshold than it returns that number else it returns 0

using Accord.Math;

namespace WindowsFormsApp1
{
    internal class GreaterThanNeuron : Neuron
    {
        public GreaterThanNeuron(int number)
            : base(number)
        {

            Type = "GT";
        }

        public GreaterThanNeuron(Neuron neuron1, Neuron neuron2, double MutationLvl, int num_inputs)
            : base(neuron1, neuron2, MutationLvl, num_inputs)
        {

            Type = "GT";
        }


        public new void Forward(double[] inputs)
        {
            Output = Matrix.Dot(Weight, inputs) + Bias;
            if (Output < Threshold)
            {
                Output = 0.0;
            }
        }
    }
}