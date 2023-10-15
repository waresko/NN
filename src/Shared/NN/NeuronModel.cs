namespace NN;

struct NeuronModel
{
   public int MemoryDepth => model.GetLength(0);
   public int Width => model.GetLength(1);

   internal float[,] model;
   public float this[int pos, int mem] => model[mem, pos];

   public NeuronModel(int memory_depth, int width)
   {
      model = new float[memory_depth, width];
   }
}

