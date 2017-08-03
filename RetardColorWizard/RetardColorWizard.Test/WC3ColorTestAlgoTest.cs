namespace RetardColorWizard.Test
{
    using System.Diagnostics;
    using System.Drawing;

    using RetardColorWizard.Impl;

    using Xunit;

    public class WC3ColorTestAlgoTest
    {
        [Fact]
        public void Temp()
        {
           var algo = new WC3ColorTestAlgo();
           var background = new Pixel(0, 0, 0);
           var text = new Pixel(255,255,255);

           Assert.True(algo.ShouldIUseThisTextColor(text, background));
        }
    }
}