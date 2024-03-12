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
        public double output = null;

        public Neuron(int num_inputs)
        {
            weight = Vector.Random(num_inputs);
            bias = Vector.Random(1);
        }

        public void Forward(double[] inputs) {
            output = Matrix.Dot(weight, inputs) + bias;
        }
    }
}
