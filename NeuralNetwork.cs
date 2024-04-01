namespace WindowsFormsApp1
{
    internal class NeuralNetwork
    {
        public double[] input;
        public double[] output;
        public DenseLayer[] dLayers;
        public OutputLayer oLayer;

        public NeuralNetwork(int numInputs, int numOutputs, int numNeurons, int numLayers)
        {
            input = new double[numInputs];
            output = new double[numOutputs];
            dLayers = new DenseLayer[numLayers];
            for (int i = 0; i < numLayers; i++)
            {
                dLayers[i] = new DenseLayer(numInputs, numNeurons);
            }
            oLayer = new OutputLayer(numNeurons, numOutputs);
        }

        public NeuralNetwork(NeuralNetwork network1, NeuralNetwork network2, int mutationLvl)
        {

            input = new double[network1.input.Length];
            output = new double[network1.output.Length];
            dLayers = new DenseLayer[network1.dLayers.Length];
            for (int i = 0; i < dLayers.Length; i++)
            {
                dLayers[i] = new DenseLayer(network1.dLayers[i], network2.dLayers[i], mutationLvl);
            }
            oLayer = new OutputLayer(network1.oLayer, network2.oLayer, mutationLvl);

        }

        public void Forward()
        {
            dLayers[0].Forward(input);
            double[] tempOutput = dLayers[0].output;
            for (int i = 1; i < dLayers.Length; i++)
            {
                dLayers[i].Forward(tempOutput);
                tempOutput = dLayers[i].output;
            }
            oLayer.Forward(tempOutput);
            output = oLayer.output;
        }
    }
}
