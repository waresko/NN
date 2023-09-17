namespace NN.Tests;

public class NeuronNetShould
{
    NeuronNet nn;
    public NeuronNetShould()
    {
        nn = new NeuronNet();
    }

    [Fact]
    public void InitOk()
    {
        nn.Init(10, 1000, 100, 10);
        Assert.Equal(10, nn.MemoryDepth);
        Assert.Equal(1000, nn.Sensors.Count);
        Assert.Equal(10, nn.Motors.Count);
        Assert.Equal(110, nn.Neurons.Count);
    }
}