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


        public Neuron(double[] weight, double bias)
        {
            this.weight = weight;
            this.bias = bias;
        }

        public Neuron(int num_inputs)
        {
            this.weight = Vector.Random(num_inputs);
            this.bias = 0.0;
        }

        public double Output(double[] inputs) {
            return Matrix.Dot(weight, inputs) + bias;
        }
    }
}
