// returns the dot product of the weights and the inputs

using Accord.Math;

namespace WindowsFormsApp1
{
    internal class OutputNeuron : Neuron
    {

        public OutputNeuron(int num_inputs)
            : base(new double[] { 0, 0 }, 0, 0, 0, null)
        {
            Weight = Vector.Random(num_inputs);
            Bias = Vector.Random(1)[0];
            Type = "OT";
        }

        public OutputNeuron(Neuron neuron1, Neuron neuron2, double MutationLvl, int num_inputs)
            : base(new double[] { 0, 0 }, 0, 0, 0, null)
        {
            Intitialize(neuron1, neuron2, MutationLvl, num_inputs);
            Type = "OT";
        }

        public override void Forward(double[] inputs)
        {
            Output = Matrix.Dot(Weight, inputs) + Bias;
        }
    }
}
