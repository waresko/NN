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
        Assert.Equal(1110, nn.Neurons.Count);
        for (int i = 0, idx = 0;  i < 1000; i++, idx++)
        {
            Assert.Equal(nn.Neurons[idx], nn.Sensors[i].Neuron);
        }
        for (int i = 0, idx = 1100; i < 10; i++, idx++)
        {
            Assert.Equal(nn.Neurons[idx], nn.Motors[i].Neuron);
        }
    }
    
}