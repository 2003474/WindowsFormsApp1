using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class ReLU : ActivationFunction
    {
        public double backward(double input)
        {
            throw new NotImplementedException();
        }

        public double forward(double input)
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
