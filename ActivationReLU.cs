using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class ActivationReLU
    {
        double output = 0.0;

        public void forward(double input)
        {
            if (input < 0)
            {
                output = 0.0;
            } else
            {
                output = input;
            }
        }

        public void back(double input)
        {

        }
    }
}
