using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal interface ActivationFunction
    {
        double forward(double input);

        double backward(double input);
    }
}
