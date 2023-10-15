namespace NN;

public class Sensors
{
   public NeuronNet NeuronNet { get; init; }

   public int Count => StatePlane.Width;
   public float this[int pos]
   {
      get => StatePlane[pos];
      set => StatePlane[pos] = value;
   }

   internal StatePlane StatePlane { get; }

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

   public void Set(params float[] states)
   {
      ArgumentNullException.ThrowIfNull(states, nameof(states));
      for (int i = 0, i_max = Math.Min(Count, states.Length); i < i_max; i++)
         this[i] = states[i];
   }
}