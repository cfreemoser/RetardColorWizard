namespace RetardColorWizard.Impl
{
    using RetardColorWizard.Spec;
    public class Pixel : IPixel
    {
        public Pixel(byte red, byte green, byte blue)
        {
            this.GetBlue = blue;
            this.GetGreen = green;
            this.GetRed = red;
        }

        public byte GetRed { get; }

        public byte GetGreen { get; }

        public byte GetBlue { get; }

        public override string ToString()
        {
            return "(" + GetRed + "," + GetGreen + "," + GetBlue + ")";
        }
    }
}