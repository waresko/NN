namespace NN;

public class Motors
{
   public NeuronNet NeuronNet { get; init; }

   public int Count => StatePlane.Width;
   public float this[int pos]
   {
      get => StatePlane.Actual[pos];
      set => StatePlane.Actual[pos] = value;
   }

   internal StatePlane StatePlane { get; }

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