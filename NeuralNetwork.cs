namespace WindowsFormsApp1
{
    internal class NeuralNetwork
    {
        public double[] input;
        public double[] output;
        public HiddenLayer[] dLayers;
        public OutputLayer oLayer;
        public double breedibility;
        public double mutibility;

        public NeuralNetwork(int numInputs, int numOutputs, int numNeurons, int numLayers)
        {
            input = new double[numInputs];
            output = new double[numOutputs];
            // add -1, 0, or 1 layer
            //int num = Globals.rnd.Next(-1, 2);
            //numLayers += num;
            dLayers = new HiddenLayer[numLayers];
            for (int i = 0; i < numLayers; i++)
            {
                dLayers[i] = new HiddenLayer(numInputs, numNeurons);
            }
            oLayer = new OutputLayer(numNeurons, numOutputs);
            breedibility = Globals.rnd.NextDouble();
            mutibility = Globals.rnd.NextDouble();
        }

        public NeuralNetwork(NeuralNetwork network1, NeuralNetwork network2, int mutationLvl)
        {

            input = new double[network1.input.Length];
            output = new double[network1.output.Length];
            dLayers = new HiddenLayer[network1.dLayers.Length];
            for (int i = 0; i < dLayers.Length; i++)
            {
                dLayers[i] = new HiddenLayer(network1.dLayers[i], network2.dLayers[i], mutationLvl);
            }
            oLayer = new OutputLayer(network1.oLayer, network2.oLayer, mutationLvl);
            int num = Globals.rnd.Next(1, 4);
            if (num == 1)
            {
                breedibility = network1.breedibility;
            }
            else if (num == 2)
            {
                breedibility = network2.breedibility;
            }
            else
            {
                breedibility = (network1.breedibility + network2.breedibility) / 2;
            }


            num = Globals.rnd.Next(1, 4);
            if (num == 1)
            {
                mutibility = network1.mutibility;
            }
            else if (num == 2)
            {
                mutibility = network2.mutibility;
            }
            else
            {
                mutibility = (network1.mutibility + network2.mutibility) / 2;
            }
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
