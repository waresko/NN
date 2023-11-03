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

   [Fact]
   public void RunOk()
   {
      nn.Init(10, 10, 10);

      nn.Prepare();
      for (int i = 0, i_max = nn.Sensors.Count; i < i_max; i++)
         Assert.Equal(0, nn.Sensors[i]);

      for (int i = 0, i_max = nn.Sensors.Count; i < i_max; i++)
      {
         nn.Sensors[i] = 1;
         Assert.Equal(1, nn.Sensors[i]);
      }

      nn.Act();
      for (int i = 0, i_max = nn.Motors.Count; i < i_max; i++)
      {
         Assert.Equal(0, nn.Motors[i]);
         nn.Motors[i] = 1;
         Assert.Equal(1, nn.Motors[i]);
         Assert.Equal(0, nn.Motors.StatePlane[i]);
      }
   }
}