using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Neuron
    {
        public decimal[] weight;
        public decimal bias;

        public decimal output(decimal[] inputs) {
            return bias + inputs[0] * weight[0] + inputs[1] * weight[1] + inputs[2] * weight[2] + inputs[3] * weight[3];
        }
    }
}
