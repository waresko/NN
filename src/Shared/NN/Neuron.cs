namespace NN;

public class Neuron
{
    internal StatePlane Input { get; }
    internal StatePlane Output { get; }
    internal int Pos { get; }

    internal NeuronModel Model;
    
    internal Neuron(int memory_depth, StatePlane input, StatePlane output, int pos)
    {
        Pos = pos;
        Output = output;
        Input = input;
        Model = new(memory_depth, input.Width);
    }

    internal void Run()
    {
        Output[Pos] = Input * Model;
    }
}
