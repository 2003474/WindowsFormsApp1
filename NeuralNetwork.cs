using System;

namespace WindowsFormsApp1
{
    internal class NeuralNetwork
    {
        public double[] input;
        public double[] output;
        public DenseLayer dLayer1;
        public DenseLayer dLayer2;
        public OutputLayer oLayer;

        public NeuralNetwork(int numInputs, int numOutputs, int numNeurons)
        {
            input = new double[numInputs];
            output = new double[numOutputs];
            dLayer1 = new DenseLayer(numInputs, numNeurons);
            dLayer2 = new DenseLayer(numNeurons, numNeurons);
            oLayer = new OutputLayer(numNeurons, numOutputs);
        }

        public NeuralNetwork(NeuralNetwork network1, NeuralNetwork network2, int mutationLvl)
        {
           
            input = new double[network1.input.Length];
            output = new double[network1.output.Length];
            //int mutChange = rnd.Next(-mutationLvl, mutationLvl + 1);
            dLayer1 = new DenseLayer(network1.dLayer1, network2.dLayer1, mutationLvl);
            dLayer2 = new DenseLayer(network1.dLayer2, network2.dLayer2, mutationLvl);
            oLayer  = new OutputLayer(network1.oLayer, network2.oLayer,  mutationLvl);
            
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
