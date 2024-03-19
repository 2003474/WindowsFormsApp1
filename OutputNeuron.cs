using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Math;

namespace WindowsFormsApp1
{
    internal class OutputNeuron :Neuron
    {
        public OutputNeuron(int num_inputs) {
            weight = Vector.Random(num_inputs);
            bias = Vector.Random(1)[0];
        }
        public override void Forward(double[] inputs)
        {
            output = Matrix.Dot(weight, inputs) + bias;
        }
    }
}
