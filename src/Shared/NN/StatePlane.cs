namespace NN;

class StatePlane
{
   public static StatePlane Null { get; } = new();

   public int MemoryDepth => states.GetLength(0);
   public int Width => states.GetLength(1);

   float[,] states;                                         //field
   int mem_cursor = 0;                                      //field
   public float this[int pos]                               //indexer
   {
      get => states[mem_cursor, pos];
      set => actual_states[pos] = states[mem_cursor, pos] = value;
   }
   public float this[int pos, int mem]                      //indexer
   {
      get
      {
         mem = (mem + mem_cursor) % MemoryDepth;
         return states[mem, pos];
      }
   }

   float[] actual_states;
   internal float[] Actual => actual_states;

   internal StatePlane(int memory_depth, int width)            //Construtor
   {
      mem_cursor = 0;
      states = new float[memory_depth, width];
      actual_states = new float[width];
   }
   StatePlane()
   {
      mem_cursor = 0;
      states = new float[0, 0];
      actual_states = Array.Empty<float>();
   }

   internal void Prepare()
   {
      if (mem_cursor <= 0)
         mem_cursor = MemoryDepth - 1;
      else --mem_cursor;
      Array.Clear(states, mem_cursor * Width, Width);
      Array.Clear(actual_states);
   }

   float GetProduct(NeuronModel model)
   {
      float product = 0;
      for (int mem = 0, mem_max = MemoryDepth, pos_max = Width; mem < mem_max; ++mem)
      {
         int mem_cur = (mem + mem_cursor) % mem_max;
         for (int pos = 0; pos < pos_max; ++pos)
            product += states[mem_cur, pos] * model[mem, pos];
      }
      return product;
   }
   public static float operator *(StatePlane state, NeuronModel model)
       => state.GetProduct(model);
}

