namespace RetardColorWizard.Impl
{
    using RetardColorWizard.Spec;

    public interface IWC3ColorTestAlgo
    {
        bool ShouldIUseThisTextColor(IPixel textColor, IPixel backgroundColor);

        int ContrastConfidence(IPixel textColor, IPixel backgroundColor);
    }
}