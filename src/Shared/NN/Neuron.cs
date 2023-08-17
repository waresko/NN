namespace NN;

public class Neuron
{
    public int Id { get; }
    public int Layer { get; }

    internal Neuron(int id, int layer)
    {
        Id = id;
        Layer = layer;
    }
}