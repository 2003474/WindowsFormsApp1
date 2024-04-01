namespace WindowsFormsApp1
{
    abstract class Neuron
    {
        public double[] weight;
        public double bias;
        public double output = 0.0;

        public abstract void Forward(double[] inputs);
    }
}
