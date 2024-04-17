namespace WindowsFormsApp1
{
    abstract class Layer
    {
        public Neuron[] neurons;
        public double[] output;
        public int numNeurons;



        public void Forward(double[] inputs)
        {
            output = new double[inputs.Length];
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