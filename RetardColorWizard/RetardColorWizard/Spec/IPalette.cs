namespace RetardColorWizard.Spec
{
    public interface IPalette
    {
        IPixel PrimaryColor { get; }

        IPixel PrimaryTextColor { get; }
        
        IPixel[] OtherColors { get; }

        IPixel[] OtherTextColors { get; }

    }
}