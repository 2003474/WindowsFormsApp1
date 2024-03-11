using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class NeuronLayer
    {
        decimal[] inputs;
        Neuron[] neurons;
    
        public decimal[] output() {
            decimal[] output = new decimal[neurons.size()];
            for(int i = 0; i < output.size(); i++) {
                output[i] = neurons[i].output(inputs);
            }
            return output;
        }
    }
}
