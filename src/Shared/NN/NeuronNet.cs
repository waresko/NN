using System.Numerics;

namespace NN;

public class NeuronNet
{
    public static NeuronNet Null { get; } = new NeuronNet();
    
    int[] layers = Array.Empty<int>();

    public IReadOnlyList<Sensor> Sensors { get; private set; }
    public IReadOnlyList<Motor> Motors { get; private set; }

    public IReadOnlyList<Neuron> Neurons { get; private set; }

    public int MemoryDepth{ get; private set; }

    public NeuronNet()
    {
       Sensors = Array.Empty<Sensor>();
       Motors = Array.Empty<Motor>();
       Neurons = Array.Empty<Neuron>();
    }

    public void Init(int memory_depth, params int[] layers)
    {              
        if (layers is null)
            throw new ArgumentNullException(nameof(layers));

        if (layers.Length < 2)
            throw new ArgumentException("Number of layers must be greater than 2");

        if (layers.Any(l => l < 1)) 
            throw new ArgumentException("Layer size must be greater than 1");

        if (memory_depth <= 0)
            memory_depth = 1;

        int nof_sensors = layers[0];
        int nof_motors = layers[layers.Length -1];
        int nof_neurons = layers.Sum();
        
        var sensors = new Sensor[nof_sensors];
        var motors = new Motor[nof_motors];
        var neurons = new Neuron[nof_neurons];
        
        var idx = 0;  // Index of neurons

        for (int i = 0; i < nof_sensors; i++, idx++)
        {
            neurons[idx] = new(idx, 0);
            sensors[i] = new(neurons[idx]);          
        }
        
        for (int idx_max = nof_neurons - nof_motors; idx < idx_max; idx++)
        {
            neurons[idx] = new(idx, 1);
        }

        for (int i = 0; i < nof_motors; i++, idx++)
        {
            neurons[idx] = new(idx, layers.Length - 1);
            motors[i] = new(neurons[idx]);
        }
        
        Sensors = sensors;
        Motors = motors;
        Neurons = neurons;

        this.layers = layers;
        MemoryDepth = memory_depth;

    }

}
