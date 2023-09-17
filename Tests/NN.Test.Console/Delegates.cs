namespace NN.Test;

public enum OperationType
{
    Sum,
    Sub,
    Mult,
    Div
}
public class MyClass
{
    public OperationType Type { get; set; }

    public static int Sum(int x, int y)
    {
        WriteLine($"{x} + {y} = {x + y}");
        return x + y;
    }
    public static int Sub(int x, int y)
    {
        Console.WriteLine($"{x} - {y} = {x - y}");
        return x - y;
    }


    public int Op(int x, int y)
    {
        switch (Type)
        {
            case OperationType.Sum:
                Console.WriteLine($"{x} + {y} = {x + y}");
                return x + y;
            case OperationType.Sub:
                Console.WriteLine($"{x} - {y} = {x - y}");
                return x - y;
            case OperationType.Mult:
                Console.WriteLine($"{x} * {y} = {x * y}");
                return x * y;
            case OperationType.Div:
                Console.WriteLine($"{x} / {y} = {x / y}");
                return x / y;
        }
        throw new Exception();
    }
}
public interface IMyInterface
{
    int DoSomething(double g, string v)
    {
        return -1;
    }
}
public class MyClass2 : MyAbstractClass, IMyInterface
{
    public int DoSomething(double g, string v)
    {
        return 0;
    }
    protected override void Print()
    {
    }
}
public struct MyStruct : IMyInterface
{

}
public abstract class MyAbstractClass
{
    int id = 0;
    protected abstract void Print();
}
internal static class Delegates
{
    delegate int Operation(int a, int b);

    public static void Examples()
    {
        Operation op = (int a, int b) =>
        {
            Console.WriteLine("Call a + b {0}, {1}", a, b);
            return a + b;
        };

        int sum = op(10, 20);
        Console.WriteLine("Call op = {0}", sum);

        op = (int a, int b) =>
        {
            Console.WriteLine("Call a - b {0}, {1}", a, b);
            return a - b;
        };
        sum = op(10, 20);
        Console.WriteLine("Call op = {0}", sum);

        op = MyClass.Sum;
        sum = op(11, 21);
        Console.WriteLine("Call op = {0}", sum);


        op = MyClass.Sub;
        sum = op(11, 21);
        Console.WriteLine("Call op = {0}", sum);

        MyClass mc = new()
        {
            Type = OperationType.Sub
        };

        op = mc.Op;
        sum = op(11, 21);
        Console.WriteLine("Call op = {0}", sum);

        mc.Type = OperationType.Div;
        sum = op(11, 21);
        Console.WriteLine("Call op = {0}", sum);
    }
}
