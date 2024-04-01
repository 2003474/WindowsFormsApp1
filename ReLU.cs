using System;

namespace WindowsFormsApp1
{
    internal class ReLU : ActivationFunction
    {
        public double Backward(double input)
        {
            throw new NotImplementedException();
        }

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
