namespace RetardColorWizard.Impl
{
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Text;

    using RetardColorWizard.Spec;

    public class SimplePalette : IPalette
    {
        private readonly SimpleHistogram histogram;

        private readonly IBlackOrWhiteChooser colorTestAlgo;
        private readonly IPixels workingData;
        private readonly Lazy<IPixel[]> dataPoints;

        public SimplePalette(Bitmap data)
        {
            this.histogram = new SimpleHistogram(3);
            this.workingData = new Pixels(data);
            this.colorTestAlgo = new BlackOrWhiteCooser();
            this.dataPoints = new Lazy<IPixel[]>(() => this.histogram.AccessSortedData(this.workingData).ToArray());
        }


        public IPixel PrimaryColor => this.dataPoints.Value[0];

        public IPixel PrimaryTextColor => this.colorTestAlgo.BlackOrWhiteContrast(PrimaryColor);

        public IPixel[] OtherColors => this.dataPoints.Value.Skip(1).ToArray();

        public IPixel[] OtherTextColors => this.OtherColors.Select(this.colorTestAlgo.BlackOrWhiteContrast).ToArray();

        public override string ToString()
        {
            var bulder = new StringBuilder();
            bulder.AppendLine("Color: " + PrimaryColor + " || Contrast: " + PrimaryTextColor);


            for (int i = 0; i < OtherColors.Length; i++)
            {
                bulder.AppendLine("Color: " + OtherColors[i] + " || Contrast: " + OtherTextColors[i]);

            }

            return bulder.ToString();
        }
    }
}