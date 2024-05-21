// parent class for hidden layer and for output layer, basically a collection of neurons that produces an array of outputs
using Newtonsoft;
namespace WindowsFormsApp1
{
    abstract class Layer
    {
        public Neuron[] neurons { get; set; }
        public double[] output { get; set; }
        public int numNeurons { get; set; }

        //[Newtonsoft.Json.JsonConstructor]
        //public Layer(Neuron[] neuron, double[] outpu, int numNeuron)
        //{
        //    this.neurons = neuron;
        //    this.output = outpu;
        //    this.numNeurons = numNeuron;
        //}

        public void Forward(double[] inputs)
        {
            output = SingleOutput(inputs);
        }

        public abstract double[] SingleOutput(double[] inputs);

        public double[][] GetWeights()
        {
            double[][] weights = new double[neurons.Length][];
            for (int i = 0; i < neurons.Length; i++)
            {
                weights[i] = neurons[i].Weight;
            }
            return weights;
        }
        public double[] GetBiases()
        {
            double[] biases = new double[neurons.Length];
            for (int i = 0; i < neurons.Length; i++)
            {
                biases[i] = neurons[i].Bias;
            }
            return biases;
        }
    }
}