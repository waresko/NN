using System.Numerics;

namespace NN;

public class NeuronNet
{
    public static NeuronNet Null { get; } = new NeuronNet();

    public Sensors Sensors { get; private set; }
    public Motors Motors { get; private set; }
    public IReadOnlyList<Neuron> Neurons { get; private set; }

    public int MemoryDepth { get; private set; }
    internal IReadOnlyList<StatePlane> StatePlanes { get; private set; }

    public NeuronNet()
    {
        Sensors = new(this);
        Motors = new(this);
        Neurons = Array.Empty<Neuron>();
        StatePlanes = Array.Empty<StatePlane>();
    }

    public void Init(int memory_depth, params int[] layers)
    {
        if (layers is null)
            throw new ArgumentNullException(nameof(layers));

        if (layers.Length < 2)
            throw new ArgumentException("Number of layers must be greater than 2");

        if (layers.Any(width => width < 1))
            throw new ArgumentException("Layer width must be greater than 1");

        if (memory_depth <= 0)
            memory_depth = 1;

        int nof_neurons = layers.Skip(1).Sum();
        int nof_state_planes = layers.Length;

        var neurons = new Neuron[nof_neurons];
        var state_planes = new StatePlane[nof_state_planes];

        int idx = 0;

        for (int idx_layer = 0; idx_layer < layers.Length; idx_layer++)
        {
            var width = layers[idx_layer];
            state_planes[idx_layer] = new(memory_depth, width);
            if (0 == idx_layer)
            {
                continue;
            }
            var input = state_planes[idx_layer - 1];
            var output = state_planes[idx_layer];
            for (int i = 0, i_max = layers[idx_layer]; i < i_max; ++i, ++idx)
            {
                neurons[idx] = new(memory_depth, input, output, i);
            }
        }
        Sensors = new(this, state_planes[0]);
        Motors = new(this, state_planes[state_planes.Length - 1]);
        Neurons = neurons;

        StatePlanes = state_planes;
        MemoryDepth = memory_depth;
    }
    public void Run()
    {
        for (int i = 0, i_max = Neurons.Count; i < i_max; ++i)
        {
            var neuron = Neurons[i];
            neuron.Run();
        }
    }
}
