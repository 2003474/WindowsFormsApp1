namespace WindowsFormsApp1
{
    internal class NeuralNetwork
    {
        public double[] input;
        public double[] output;
        DenseLayer dLayer1;
        DenseLayer dLayer2;
        OutputLayer oLayer;

        public NeuralNetwork(int numInputs, int numOutputs, int numNeurons)
        {
            input = new double[numInputs];
            output = new double[numOutputs];
            dLayer1 = new DenseLayer(numInputs, numNeurons);
            dLayer2 = new DenseLayer(numNeurons, numNeurons);
            oLayer = new OutputLayer(numNeurons, numOutputs);
        }

        public void Forward()
        {
            dLayer1.Forward(input);
            dLayer2.Forward(dLayer1.output);
            oLayer.Forward(dLayer2.output);
            output = oLayer.output;
        }
    }
}
