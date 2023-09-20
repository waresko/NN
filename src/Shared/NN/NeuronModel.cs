namespace NN;

struct NeuronModel
{
    public int Width { get; }
    public int MemoryDepth { get; }
    public float this[int pos, int mem] => model[mem, pos];

    internal float[,] model;
    public NeuronModel(int memory_depth, int width)
    {
        model = new float[memory_depth, width];
        Width = width;
        MemoryDepth = memory_depth;
    }
}

