namespace NN;

public class Sensor
{
    public Neuron Neuron { get; init; }


    internal Sensor(Neuron n)
    {
        Neuron = n;
    }
    
}