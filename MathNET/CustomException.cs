namespace MathNET
{
    public class TypeError(string message) : Exception(message)
    {
    }

    public class ValueError(string message) : Exception(message)
    {
    }
}