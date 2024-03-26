using System;
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
        public DenseNeuron(int num_inputs, ActivationFunction function)
        {
            weight = Vector.Random(num_inputs);
            bias = Vector.Random(1)[0];
            aFunction = function;
        }

        //combine 2 neurons together
        //public DenseNeuron(DenseNeuron neuron1, DenseNeuron neuron2, int MutationLvl)
        //{
        //chooses activation function, or combines (smh)
        //combines weight values, (chooses 1 from each or averages both)
        //mutation
        //}

        public override void Forward(double[] inputs) {
            output = Matrix.Dot(weight, inputs) + bias;
            output = aFunction.forward(output);
        }
    }
}