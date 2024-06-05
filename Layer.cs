﻿// parent class for hidden layer and for output layer, basically a collection of neurons that produces an array of outputs
using Newtonsoft;
namespace WindowsFormsApp1
{
    abstract class Layer
    {
        public Neuron[] Neurons { get; set; }
        public double[] Output { get; set; }
        public int NumNeurons { get; set; }

        //[Newtonsoft.Json.JsonConstructor]
        //public Layer(Neuron[] neuron, double[] outpu, int numNeuron)
        //{
        //    this.neurons = neuron;
        //    this.output = outpu;
        //    this.numNeurons = numNeuron;
        //}

        // sets the outputs of the layer as the array of outputs from the neurons
        public void Forward(double[] inputs)
        {
            Output = SingleOutput(inputs);
        }

        // abstract class, generates outputs for the layer
        public abstract double[] SingleOutput(double[] inputs);

    }
}