using System;
using System.Collections.Generic;
//using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Math;

namespace WindowsFormsApp1
{
    internal class Neuron
    {
        public double[] weight;
        public double bias;
        public double output = 0.0;

        public Neuron(int num_inputs)
        {
            weight = Vector.Random(num_inputs);
            bias = Vector.Random(1)[0];
        }

        public void Forward(double[] inputs) {
            output = Matrix.Dot(weight, inputs) + bias;
        }
    }
}
