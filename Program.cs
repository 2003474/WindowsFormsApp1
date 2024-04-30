// program file (starts the program)


using System;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        
        [STAThread]
        static void Main()
        {
            // starts the training proccess
            NetworkTrainer w = new NetworkTrainer(2, 2, 16, 16, 100);
            NeuralNetwork final = w.Train();

            // testing
            final.input = new double[2] { 10.78, 3.234 };
            final.Forward();
            
            int greatestIndex = 0;
            for (int i = 0; i < final.output.Length; i++)
            {
                if (final.output[i] > final.output[greatestIndex])
                {
                    greatestIndex = i;
                }
            }
            Console.WriteLine(greatestIndex);

            final.input = new double[2] { 2.435, 8.678953};
            final.Forward();
            
            greatestIndex = 0;
            for (int i = 0; i < final.output.Length; i++)
            {
                if (final.output[i] > final.output[greatestIndex])
                {
                    greatestIndex = i;
                }
            }
            Console.WriteLine(greatestIndex);

            final.input = new double[2] { 7.23455, 5.432543 };
            final.Forward();
            
            greatestIndex = 0;
            for (int i = 0; i < final.output.Length; i++)
            {
                if (final.output[i] > final.output[greatestIndex])
                {
                    greatestIndex = i;
                }
            }
            Console.WriteLine(greatestIndex);

            final.input = new double[2] {9.2345423, 1.2345342 };
            final.Forward();
            
            greatestIndex = 0;
            for (int i = 0; i < final.output.Length; i++)
            {
                if (final.output[i] > final.output[greatestIndex])
                {
                    greatestIndex = i;
                }
            }
            Console.WriteLine(greatestIndex);

            final.input = new double[2] { 9.2345, 9.1645267};
            final.Forward();
            
            greatestIndex = 0;
            for (int i = 0; i < final.output.Length; i++)
            {
                if (final.output[i] > final.output[greatestIndex])
                {
                    greatestIndex = i;
                }
            }
            Console.WriteLine(greatestIndex);

        }
    }
}
