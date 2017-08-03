namespace RetardColorWizard.Impl
{
    using System;
    using RetardColorWizard.Spec;

    public class WC3ColorTestAlgo : IWC3ColorTestAlgo
    {
        public bool ShouldIUseThisTextColor(IPixel textColor, IPixel backgroundColor)
        {
            var brightnessDifference = this.CalculateBrightnessDifference(textColor, backgroundColor);

            var colorDifference = CalculateColorDifference(textColor, backgroundColor);

            return brightnessDifference > 125 && colorDifference > 500;
        }

        public int ContrastConfidence(IPixel textColor, IPixel backgroundColor)
        {
            var brightnessDifference = this.CalculateBrightnessDifference(textColor, backgroundColor);

            var colorDifference = CalculateColorDifference(textColor, backgroundColor);

            return (brightnessDifference + colorDifference) - 625;
        }

        private int CalculateBrightnessDifference(IPixel textColor, IPixel backgroundColor)
        {
            var textYIQ = this.CalculateYIQ(textColor);
            var backgroundYIQ = this.CalculateYIQ(backgroundColor);

            var brightnessDifference = Math.Abs(textYIQ - backgroundYIQ);
            return brightnessDifference;
        }

        private int CalculateColorDifference(IPixel textColor, IPixel backgroundColor)
        {
            var minRed = Math.Min(textColor.GetRed, backgroundColor.GetRed);
            var minGreen = Math.Min(textColor.GetGreen, backgroundColor.GetGreen);
            var minBlue = Math.Min(textColor.GetBlue, backgroundColor.GetBlue);

            var maxRed = Math.Max(textColor.GetRed, backgroundColor.GetRed);
            var maxGreen = Math.Max(textColor.GetGreen, backgroundColor.GetGreen);
            var maxBlue = Math.Max(textColor.GetBlue, backgroundColor.GetBlue);

            var diffRed = maxRed - minRed;
            var diffGreen = maxGreen - minGreen;
            var diffBlue = maxBlue - minBlue;

            return diffRed + diffGreen + diffBlue;
        }

        private int CalculateYIQ(IPixel color)
        {
            var scaledRed = color.GetRed * 299;
            var scaledGreen = color.GetGreen * 587;
            var scaledBlue = color.GetBlue * 114;
            var sumScaled = scaledRed + scaledGreen + scaledBlue;

            return sumScaled / 1000;
        }
    }
}