﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Math;

namespace WindowsFormsApp1
{
    internal class DenseNeuron : Neuron
    {

        public ActivationFunction aFunction;
        //public activationFunctionBackward backword;
        public DenseNeuron(int num_inputs, ActivationFunction function)
        {
            weight = Vector.Random(num_inputs);
            bias = Vector.Random(1)[0];
            aFunction = function;
        }

        public override void Forward(double[] inputs) {
            output = Matrix.Dot(weight, inputs) + bias;
            output = aFunction.forward(output);
        }

        public double ReLU(double input, char type)
        {
            if (type == 'f')
            {
                if (input < 0)
                {
                    return 0.0;
                }
                else
                {
                    return input;
                }
            } else
            {
                //back pass
                return 0.0;
            }
        }
    }
}