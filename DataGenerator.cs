using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class DataGenerator
    {
        public int numData;

        public DataGenerator(int numData) {
            this.numData = numData;
        }

        public Data[] Generate()
        {
            Data[] data = new Data[numData];
            Random rnd = new Random();
            
            for (int i = 0; i < numData; i++)
            {
                data[i] = new Data
                {
                    input = new double[] { rnd.Next(-100, 100) }
                };
                if (data[i].input[0] < 0)
                {
                    data[i].output = new double[] { 0.0 };
                } else
                {
                    data[i].output = new double[] { 1.0 };
                }
            }
            return data;
        }
    }
}
