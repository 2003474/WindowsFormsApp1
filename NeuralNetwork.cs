
// essentially a collection of layers
// can construct a neural network with number inputs, or with 2 other neural networks and it produces a single neural network

using System.Text.Json.Serialization;
using Newtonsoft;
using Newtonsoft.Json;
namespace WindowsFormsApp1
{
    internal class NeuralNetwork
    {
        public double[] input { get; set; }
        public double[] output { get; set; }
        public HiddenLayer[] dLayers { get; set; }
        public OutputLayer oLayer { get; set; }
        public int numLayers { get; set; }
        public double breedibility { get; set; }
        public double mutibility { get; set; }



        [Newtonsoft.Json.JsonConstructor]
        public NeuralNetwork(double breedibility, HiddenLayer[] dLayers, double[] input, double mutibility, int numLayers, OutputLayer oLayer, double[] output)

        {
            this.input = input;
            this.output = output;
            this.dLayers = dLayers;
            this.oLayer = oLayer;
            this.numLayers = numLayers;
            this.breedibility = breedibility;
            this.mutibility = mutibility;
        }

        //public NeuralNetwork(string s) {
        //    this = JsonConvert.DeserializeObject<NeuralNetwork>(s);
        //}

        public NeuralNetwork(int numInputs, int numOutputs, int numNeurons, int num_Layers)
        {
            input = new double[numInputs];
            output = new double[numOutputs];
            // add -1, 0, or 1 layer
            //int num = Globals.rnd.Next(-1, 2);
            //numLayers += num;
            numLayers = num_Layers;
            int change = Globals.rnd.Next(-8, 9);
            numLayers += change;
            if (numLayers < 2)
            {
                numLayers = 2;
            }
            dLayers = new HiddenLayer[numLayers];
            dLayers[0] = new HiddenLayer(numInputs, numNeurons);
            for (int i = 1; i < numLayers; i++)
            {
                dLayers[i] = new HiddenLayer(dLayers[i - 1].numNeurons, numNeurons);
            }
            oLayer = new OutputLayer(dLayers[numLayers - 1].numNeurons, numOutputs);
            breedibility = Globals.rnd.NextDouble();
            mutibility = Globals.rnd.NextDouble() * 10;
        }

        public NeuralNetwork(NeuralNetwork network1, NeuralNetwork network2, int mutationLvl)
        {
            int num = Globals.rnd.Next(1, 4);
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

            double mutation = mutationLvl * mutibility;
            input = new double[network1.input.Length];
            output = new double[network1.output.Length];


            int n1DLength = network1.dLayers.Length;
            int n2DLength = network2.dLayers.Length;

            // makes a new layer array with length from parents or average
            if (network1.dLayers.Length != network2.dLayers.Length)
            {
                int numb = Globals.rnd.Next(1, 4);
                if (numb == 1)
                {
                    dLayers = new HiddenLayer[n1DLength];
                }
                else if (numb == 2)
                {
                    dLayers = new HiddenLayer[n2DLength];
                }
                else
                {
                    dLayers = new HiddenLayer[(n1DLength + n2DLength) / 2];
                }
            }
            else
            {
                dLayers = new HiddenLayer[n1DLength];
            }
            numLayers = dLayers.Length;

            dLayers[0] = new HiddenLayer(network1.dLayers[0], network2.dLayers[0], mutation, input.Length);

            for (int i = 1; i < dLayers.Length; i++)
            {
                //issue
                dLayers[i] = new HiddenLayer(network1.dLayers[i % n1DLength], network2.dLayers[i % n2DLength], mutation, dLayers[i - 1].numNeurons);

            }
            oLayer = new OutputLayer(network1.oLayer, network2.oLayer, mutation, dLayers[dLayers.Length - 1].numNeurons);
            num = Globals.rnd.Next(1, 4);
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



        }

        public void Forward()
        {
            dLayers[0].Forward(input);
            for (int i = 1; i < dLayers.Length; i++)
            {
                dLayers[i].Forward(dLayers[i - 1].output);
            }
            oLayer.Forward(dLayers[dLayers.Length - 1].output);
            output = oLayer.output;
        }
    }
}
