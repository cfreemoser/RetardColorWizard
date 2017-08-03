namespace RetardColorWizard
{
    using System.Collections.Generic;
    using System.Drawing;

    using RetardColorWizard.Impl;
    using RetardColorWizard.Spec;

    public class Pixels : IPixels
    {
        private readonly Bitmap underlayingImage;

        public Pixels(Bitmap underlayingImage)
        {
            this.underlayingImage = underlayingImage;
        }

        public IEnumerator<IPixel> GetItEnumerator()
        {
            for (int x = 0; x < this.underlayingImage.Width; x++)
            {
                for (int y = 0; y < this.underlayingImage.Height; y++)
                {
                    var color = this.underlayingImage.GetPixel(x, y);
                    yield return new Pixel(color.R, color.G, color.B);
                }
            }
        }
    }
}