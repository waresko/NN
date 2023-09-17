//int[] model = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
//for (int i = 0; i < model.Length; ++i)
//{
//    WriteLine($"{i}: {model[i]}");
//    model[i] = 123;
//}

//WriteLine("");
//Indexer idx = new();
//Indexer idx2 = new();
//var prod = idx * idx2;
//WriteLine($"Result {prod}");

//for (int i = 0; i < 15; ++i)
//{
//    idx[i] = 123;
//    WriteLine($"{i}: {idx[i]}");
//}
//public class Indexer
//{
//    public int this[int idx]
//    {
//        get => idx * 3;
//        set { WriteLine($"Set index = {value}"); }
//    }
//    public static int operator *(Indexer left, Indexer right)
//    {
//        return 13;
//    }

//}