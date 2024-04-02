using System.Linq;

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
                data[i].input[0] = Globals.rnd.Next(0, 11);
                data[i].output[0] = data[i].input[0];
            }
            return data;
        }
    }
}
