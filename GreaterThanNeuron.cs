using Accord.Math;

namespace WindowsFormsApp1
{
    internal class GreaterThanNeuron : Neuron
    {
        public GreaterThanNeuron(int number)
        {
            Intitialize(number);
        }

        public GreaterThanNeuron(Neuron neuron1, Neuron neuron2, double MutationLvl, int num_inputs)
        {
            Intitialize(neuron1, neuron2, MutationLvl, num_inputs);
        }


        public override void Forward(double[] inputs)
        {
            output = Matrix.Dot(weight, inputs) + bias;
            if (output < threshold)
            {
                output = 0.0;
            }
            else
            {
                output = threshold;
            }
        }
    }
}