namespace NN;

public class StatePlane
{
    public static StatePlane Null { get; } = new();
    public int Width { get; }                                //property 
    public int MemoryDepth { get; }                          //property 

    float[,] states;                                          //field
    int mem_cursor = 0;                                         //field
    public float this[int pos]                               //indexer
    {
        get
        {
            if (pos < 0 || Width <= pos)
            {
                throw new IndexOutOfRangeException(nameof(pos));
            }
            return states[mem_cursor, pos];
        }

        set
        {
            if (pos < 0 || Width <= pos)
            {
                throw new IndexOutOfRangeException(nameof(pos));
            }
            states[mem_cursor, pos] = value;
        }
    }
    public float this[int pos, int mem]                      //indexer
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
            mem = (mem + mem_cursor) % MemoryDepth;
            return states[mem, pos];
        }
    }

    public StatePlane(int memory_depth, int width)            //Construtor
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
}

