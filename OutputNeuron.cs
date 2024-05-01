// returns the dot product of the weights and the inputs

using Accord.Math;

namespace WindowsFormsApp1
{
    internal class OutputNeuron : Neuron
    {

        public OutputNeuron(int num_inputs)
        {
            weight = Vector.Random(num_inputs);
            bias = Vector.Random(1)[0];
        }

        public OutputNeuron(Neuron neuron1, Neuron neuron2, double MutationLvl, int num_inputs)
        {
            Intitialize(neuron1, neuron2, MutationLvl, num_inputs);
        }

        public override void Forward(double[] inputs)
        {
            output = Matrix.Dot(weight, inputs) + bias;
        }
    }
}
