// parent class for hidden layer and for output layer, basically a collection of neurons that produces an array of outputs

namespace WindowsFormsApp1
{
    abstract class Layer
    {
        public Neuron[] neurons { get; set; }
        public double[] output { get; set; }
        public int numNeurons { get; set; }

        public Layer(Neuron[] neurons, double[] output, int numNeurons)
        {
            this.neurons = neurons;
            this.output = output;
            this.numNeurons = numNeurons;
        }

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
                weights[i] = neurons[i].weight;
            }
            return weights;
        }
        public double[] GetBiases()
        {
            double[] biases = new double[neurons.Length];
            for (int i = 0; i < neurons.Length; i++)
            {
                biases[i] = neurons[i].bias;
            }
            return biases;
        }
    }
}