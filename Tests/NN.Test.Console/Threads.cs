namespace NN.Test;

internal class Threads
{
    void Run()
    {
        var s1 = new Thread(Run);
        var s2 = new Thread(Run);

        s1.Start();
        s2.Start();

        s1.Join();
        s2.Join();

        static void Run()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Thread {0} running: ", Environment.CurrentManagedThreadId);
                Thread.Sleep(1000);
            }
        }

    }
}
