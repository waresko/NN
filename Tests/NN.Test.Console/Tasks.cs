namespace NN.Test;

internal class Tasks
{
    int idx = 0;
    public async Task Main()
    {

        Run();
        Task s1 = RunAsync();
        Task s2 = RunAsync();


        await Task.WhenAll(s1, s2);
        Console.WriteLine("value of idx: {0}", idx);
    }
    async Task RunAsync()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Thread {0} running: ", Environment.CurrentManagedThreadId);
            await Task.Delay(1000);
            idx = Environment.CurrentManagedThreadId;
        }
    }
    void Run()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Thread {0} running: ", Environment.CurrentManagedThreadId);
            Task.Delay(1000).Wait();
            idx = Environment.CurrentManagedThreadId;
        }
    }

}
