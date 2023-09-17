namespace NN;

public class Sensors
{
    public NeuronNet NeuronNet { get; init; }
    internal StatePlane StatePlane { get; }
    public int Count => StatePlane.Width;
    public float this[int pos]
    {
        get => StatePlane[pos];
        set
        {
            StatePlane[pos] = value;
        }
    }
    internal Sensors(NeuronNet neuron_net)
    {
        NeuronNet = neuron_net;
        StatePlane = StatePlane.Null;
    }
    internal Sensors(NeuronNet neuron_net, StatePlane state_plane)
    {
        NeuronNet = neuron_net;
        StatePlane = state_plane;
    }
}