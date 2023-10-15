namespace NN;

public class Neuron
{
    internal StatePlane Input { get; }
    internal StatePlane Output { get; }

    internal int Pos { get; }

    internal NeuronModel Model;
    
    internal Neuron(StatePlane input, StatePlane output, int pos)
    {
        Pos = pos;
        Output = output;
        Input = input;
        Model = new(input.MemoryDepth, input.Width);
    }

    internal void Act()
    {
        Output[Pos] = Input * Model;
    }
}
