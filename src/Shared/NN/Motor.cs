namespace NN;

public class Motor
{
    public Neuron Neuron { get; init; }


    internal Motor(Neuron n)
    {
        Neuron = n;
    }
    
}