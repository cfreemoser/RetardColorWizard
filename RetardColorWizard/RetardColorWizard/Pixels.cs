using System.Collections.Generic;
using System.Drawing;
using RetardColorWizard.Spec;

namespace RetardColorWizard
{
    public class Pixels : IPixels
    {
        private readonly Bitmap underlayingImage;

        public Pixels(Bitmap underlayingImage)
        {
            this.underlayingImage = underlayingImage;
        }

        public IEnumerator<Color> GetItEnumerator()
        {
            for (int x = 0; x < underlayingImage.Width; x++)
            {
                for (int y = 0; y < underlayingImage.Height; y++)
                {
                    yield return underlayingImage.GetPixel(x, y);
                }
            }
        }
    }
}