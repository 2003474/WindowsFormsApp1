﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class DataGenerator
    {
        public Data[] Generate(int numData)
        {
            Data[] data = new Data[numData];
            
            for (int i = 0; i < numData; i++)
            {
                data[i] = new Data();
                data[i].input[0] = Globals.rnd.Next(-100, 100);
                data[i].input[1] = Globals.rnd.Next(-100, 100);
                if (data[i].input.Sum() < 0)
                {
                    data[i].output[0] = 0.0;
                } else
                {
                    data[i].output[0] = 1.0;
                }
            }
            return data;
        }
    }
}
