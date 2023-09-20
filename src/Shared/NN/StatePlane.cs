namespace NN;

class StatePlane
{
    public static StatePlane Null { get; } = new();

    public int Width { get; }                                //property 
    public int MemoryDepth { get; }                          //property 

    float[,] states;                                          //field
    int mem_cursor = 0;                                         //field
    public float this[int pos]                               //indexer
    {
        get => states[mem_cursor, pos];
        set => states[mem_cursor, pos] = value;
    }
    public float this[int pos, int mem]                      //indexer
    {
        get
        {
            mem = (mem + mem_cursor) % MemoryDepth;
            return states[mem, pos];
        }
    }

    internal StatePlane(int memory_depth, int width)            //Construtor
    {
        states = new float[memory_depth, width];
        mem_cursor = memory_depth - 1;
        Width = width;
        MemoryDepth = memory_depth;
    }
    StatePlane()
    {
        states = new float[0, 0];
        mem_cursor = 0;
        Width = 0;
        MemoryDepth = 0;
    }
    
    float GetProduct(NeuronModel model)
    {
        float product = 0;
        for (int mem = 0, mem_max = MemoryDepth; mem < mem_max; ++mem)
        {
            int mem_local = (mem + mem_cursor) % mem_max;
            for (int pos = 0, pos_max = Width; pos < pos_max; ++pos)
                product += states[mem_local, pos] * model[mem, pos];
        }
        return product;
    }
    public static float operator * (StatePlane state, NeuronModel model) 
        => state.GetProduct(model);
}

