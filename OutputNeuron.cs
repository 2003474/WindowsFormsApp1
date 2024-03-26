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
        
        public OutputNeuron(OutputNeuron neuron1, OutputNeuron neuron2, int MutationLvl)
        {
            //chooses activation function
            //rand num 1, 2
            Random rnd = new Random();
            // 1 is neuron1 actFunc
            // 2 is neuron2 actFunc
            // prolly same one tho for now
            //combines weight values, (chooses 1 from each or averages both)
            weight = new double[8];
            for(int i = 0, i < weight.Length; i++) {
                num = rnd.Next(1, 4);
                if (num == 1) 
                {
                    weight[i] = neuron1.weight[i];
                } else if (num == 2) 
                {
                    weight[i] = neuron2.weight[i];
                } else {
                    weight[i] = (neuron1.weight[i] + neuron2.weight[i]) / 2;
                }
            }
            //combines bias values
            //rand num 1, 2, 3
            num = rnd.Next(1, 4);
            if (num == 1) 
            {
                bias = neuron1.bias;
            } else if (num == 2) 
            {
                bias = neuron2.bias;
            } else {
                bias = (neuron1.bias + neuron2.bias) / 2;
            }
            // if 1 neuron 1 bias
            // if 2 neuron 2 bias
            // if 3 bias = (neuron1.bias + neuron2.bias)/2  (avg)
            //mutation ideas
            // mutliply, or add mutation
            // activation function for mutation ( if mutation is less than a certain value than it doesn't do anything
        }
        
        public override void Forward(double[] inputs)
        {
            output = Matrix.Dot(weight, inputs) + bias;
        }
    }
}
