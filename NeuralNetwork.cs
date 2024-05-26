// essentially a collection of layers
// can construct a neural network with number inputs, or with 2 other neural networks and it produces a single neural network

namespace WindowsFormsApp1
{
    internal class NeuralNetwork
    {
        public double[] Input { get; set; }
        public double[] Output { get; set; }
        public HiddenLayer[] DLayers { get; set; }
        public OutputLayer OLayer { get; set; }
        public int NumLayers { get; set; }
        public double Breedibility { get; set; }
        public double Mutibility { get; set; }
        public int Repetition { get; set; }



        [Newtonsoft.Json.JsonConstructor]
        public NeuralNetwork(double breedibility, HiddenLayer[] dLayers, double[] input, double mutibility, int numLayers, OutputLayer oLayer, double[] output, int repetition)

        {
            this.Input = input;
            this.Output = output;
            this.DLayers = dLayers;
            this.OLayer = oLayer;
            this.NumLayers = numLayers;
            this.Breedibility = breedibility;
            this.Mutibility = mutibility;
            this.Repetition = repetition;
        }


        public NeuralNetwork(int numInputs, int numOutputs, int numNeurons, int num_Layers)
        {
            Repetition = 0;
            Input = new double[numInputs];
            Output = new double[numOutputs];
            // add -1, 0, or 1 layer
            //int num = Globals.rnd.Next(-1, 2);
            //numLayers += num;
            NumLayers = num_Layers;
            int change = Globals.rnd.Next(-8, 9);
            NumLayers += change;
            if (NumLayers < 2)
            {
                NumLayers = 2;
            }
            DLayers = new HiddenLayer[NumLayers];
            DLayers[0] = new HiddenLayer(numInputs, numNeurons);
            for (int i = 1; i < NumLayers; i++)
            {
                DLayers[i] = new HiddenLayer(DLayers[i - 1].numNeurons, numNeurons);
            }
            OLayer = new OutputLayer(DLayers[NumLayers - 1].numNeurons, numOutputs);
            Breedibility = Globals.rnd.NextDouble();
            Mutibility = Globals.rnd.NextDouble() * 10;
        }

        public NeuralNetwork(NeuralNetwork network1, NeuralNetwork network2, int mutationLvl)
        {
            int num = Globals.rnd.Next(1, 4);
            if (num == 1)
            {
                Mutibility = network1.Mutibility;
            }
            else if (num == 2)
            {
                Mutibility = network2.Mutibility;
            }
            else
            {
                Mutibility = (network1.Mutibility + network2.Mutibility) / 2;
            }

            double mutation = mutationLvl * Mutibility;
            Input = new double[network1.Input.Length];
            Output = new double[network1.Output.Length];


            int n1DLength = network1.DLayers.Length;
            int n2DLength = network2.DLayers.Length;

            // makes a new layer array with length from parents or average
            if (network1.DLayers.Length != network2.DLayers.Length)
            {
                int numb = Globals.rnd.Next(1, 4);
                if (numb == 1)
                {
                    DLayers = new HiddenLayer[n1DLength];
                }
                else if (numb == 2)
                {
                    DLayers = new HiddenLayer[n2DLength];
                }
                else
                {
                    DLayers = new HiddenLayer[(n1DLength + n2DLength) / 2];
                }
            }
            else
            {
                DLayers = new HiddenLayer[n1DLength];
            }
            NumLayers = DLayers.Length;

            DLayers[0] = new HiddenLayer(network1.DLayers[0], network2.DLayers[0], mutation, Input.Length);

            for (int i = 1; i < DLayers.Length; i++)
            {
                //issue
                DLayers[i] = new HiddenLayer(network1.DLayers[i % n1DLength], network2.DLayers[i % n2DLength], mutation, DLayers[i - 1].numNeurons);

            }
            OLayer = new OutputLayer(network1.OLayer, network2.OLayer, mutation, DLayers[DLayers.Length - 1].numNeurons);
            num = Globals.rnd.Next(1, 4);
            if (num == 1)
            {
                Breedibility = network1.Breedibility;
            }
            else if (num == 2)
            {
                Breedibility = network2.Breedibility;
            }
            else
            {
                Breedibility = (network1.Breedibility + network2.Breedibility) / 2;
            }

            Repetition = 0;

        }

        public void Forward()
        {
            DLayers[0].Forward(Input);
            for (int i = 1; i < DLayers.Length; i++)
            {
                DLayers[i].Forward(DLayers[i - 1].output);
            }
            OLayer.Forward(DLayers[DLayers.Length - 1].output);
            Output = OLayer.output;
        }
    }
}
