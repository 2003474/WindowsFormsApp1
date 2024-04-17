namespace WindowsFormsApp1
{
    internal class ReLU : IActivationFunction
    {
        public double Forward(double input)
        {
            if (input < 0)
            {
                return 0.0;
            }
            else
            {
                return input;
            }
        }
    }
}
