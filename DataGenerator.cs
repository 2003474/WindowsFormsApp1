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
                data[i].input[0] = Globals.rnd.Next(0,4);
                data[i].input[1] = Globals.rnd.Next(0,4);
                data[i].output[0] = data[i].input[0] * data[i].input[1];
                //if ((data[i].input[0] * data[i].input[1]) > 50)
                //{
                //    data[i].output[0] = 0.0;
                //}
                //else
                //{
                //    data[i].output[0] = 1.0;
                //}

            }
            return data;
        }
    }
}
