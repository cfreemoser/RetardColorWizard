namespace RetardColorWizard.Impl
{
    using RetardColorWizard.Spec;
    public class BlackOrWhiteCooser : IBlackOrWhiteChooser
    {
        private readonly IWC3ColorTestAlgo backingAlgorithm;

        public BlackOrWhiteCooser()
        {
            this.backingAlgorithm = new WC3ColorTestAlgo();
           
        }

        public IPixel BlackOrWhiteContrast(IPixel color)
        {
            var black = new Black();
            var white = new White();

            var blackConfidence = this.backingAlgorithm.ContrastConfidence(black, color);
            var whiteConfidence = this.backingAlgorithm.ContrastConfidence(white, color);

            return blackConfidence > whiteConfidence ? (IPixel)black : white;
        }
    }
}