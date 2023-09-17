namespace NN;

public struct NeuronModel
{
    public int Width { get; }
    public int MemoryDepth { get; }
    public float this[int pos, int mem]
    {
        get
        {
            if (pos < 0 || Width <= pos)
            {
                throw new IndexOutOfRangeException(nameof(pos));
            }
            if (mem < 0 || MemoryDepth <= mem)
            {
                throw new IndexOutOfRangeException(nameof(mem));
            }
            return model[mem, pos];
        }
    }

    internal float[,] model;
    public NeuronModel(int memory_depth, int width)
    {
        model = new float[memory_depth, width];
        Width = width;
        MemoryDepth = memory_depth;
    }
}

