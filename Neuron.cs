namespace WindowsFormsApp1
{
    abstract class Neuron
    {
        public double[] weight;
        public double bias;
        public double output = 0.0;
        public double threshold;

        public abstract void Forward(double[] inputs);
    }
}
