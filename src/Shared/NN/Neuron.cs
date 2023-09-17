namespace NN;

public class Neuron
{
    public StatePlane Input { get; }
    public StatePlane Output { get; }
    public int Pos { get; }

    internal NeuronModel Model;
    
    internal Neuron(int memory_depth, StatePlane input, StatePlane output, int pos)
    {
        Pos = pos;
        Output = output;
        Input = input;
        Model = new(memory_depth, input.Width);
    }
}
