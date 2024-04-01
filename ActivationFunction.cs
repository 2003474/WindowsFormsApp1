namespace WindowsFormsApp1
{
    internal interface ActivationFunction
    {
        double Forward(double input);

        double Backward(double input);
    }
}
