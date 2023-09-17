namespace NN;

public class Motors
{
    public NeuronNet NeuronNet { get; init; }
    internal StatePlane StatePlane { get; }
    public int Count => StatePlane.Width;
    public float this[int pos] => StatePlane[pos];

    internal Motors(NeuronNet neuron_net)
    {
        NeuronNet = neuron_net;
        StatePlane = StatePlane.Null;
    }

    internal Motors(NeuronNet neuron_net, StatePlane state_plane)
    {
        NeuronNet = neuron_net;
        StatePlane = state_plane;
    }
}