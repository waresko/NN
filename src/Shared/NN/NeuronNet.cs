using System.Runtime.CompilerServices;

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

      memory_depth = Math.Max(1, memory_depth);

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
            continue;

         var input = state_planes[idx_layer - 1];
         var output = state_planes[idx_layer];
         for (int i = 0, i_max = width; i < i_max; ++i, ++idx)
            neurons[idx] = new(input, output, i);
      }

      MemoryDepth = memory_depth;
      StatePlanes = state_planes;
      Neurons = neurons;

      Sensors = new(this, state_planes[0]);
      Motors = new(this, state_planes[state_planes.Length - 1]);
   }

   public void Prepare()
   {
      for (int i = 0, i_max = StatePlanes.Count; i < i_max; ++i)
         StatePlanes[i].Prepare();
   }
   public void Prepare(params float[] input)
   {
      Prepare();
      Sensors.Set(input);
   }
   public void Act()
   {
      for (int i = 0, i_max = Neurons.Count; i < i_max; ++i)
         Neurons[i].Act();
   }
   public void Learn()
   {

   }
}
