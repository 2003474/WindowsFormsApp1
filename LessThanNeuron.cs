// if the sum of the weighted inputs is less than the threshold than it returns that number otherwise returns 0.0

using Accord.Math;

namespace WindowsFormsApp1
{
    internal class LessThanNeuron : Neuron
    {
        public LessThanNeuron(int number)
            : base(number)
        {

            Type = "LT";
        }

        public LessThanNeuron(Neuron neuron1, Neuron neuron2, double MutationLvl, int num_inputs)
            : base(neuron1, neuron2, MutationLvl, num_inputs)
        {
            Type = "LT";
        }


        public new void Forward(double[] inputs)
        {

            Output = Matrix.Dot(Weight, inputs) + Bias;
            if (Output > Threshold)
            {
                Output = 0.0;
            }
        }
    }
}