namespace WindowsFormsApp1
{
    class DenseLayer : Layer
    {

        public DenseLayer(int num_inputs, int num_neurons)
        {
            ActivationFunction ReLU = new ReLU();
            this.neurons = new DenseNeuron[num_neurons];
            for (int i = 0; i < num_neurons; i++)
            {
                this.neurons[i] = new DenseNeuron(num_inputs, ReLU);
            }
        }

        public DenseLayer(DenseLayer layer1, DenseLayer layer2, int mutationLvl)
        {
            // for every neuron
            neurons = new DenseNeuron[layer1.neurons.Length];
            int num = 0;
            for (int i = 0; i < neurons.Length; i++)
            {
                num = Globals.rnd.Next(1, 4);




                if (num == 1)

                {
                    neurons[i] = layer1.neurons[i];
                }
                else if (num == 2)
                {
                    neurons[i] = layer2.neurons[i];
                }
                else
                {
                    neurons[i] = new DenseNeuron((DenseNeuron)layer1.neurons[i], (DenseNeuron)layer2.neurons[i], mutationLvl);
                }
            }
            // randomly chooses between neurons either a 0 1 2
            // 0 is layer1 neruon
            // 1 is layer2 neuron
            // 2 is combination of both (neurons[i] = new DenseNeuron(layer1.neurons[i], layer2.neurons[i], mutationLvl)
        }

        public override double[] SingleOutput(double[] inputs)
        {
            double[] tempOutput = new double[neurons.Length];
            for (int i = 0; i < neurons.Length; i++)
            {
                neurons[i].Forward(inputs);
                tempOutput[i] = neurons[i].output;
            }
            return tempOutput;
        }
    }
}
