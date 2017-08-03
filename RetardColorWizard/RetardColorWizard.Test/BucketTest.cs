
namespace RetardColorWizard.Test
{
    using System.Diagnostics;
    using System.Drawing;
    using RetardColorWizard.Impl;
    using Xunit;

    public class BucketTest
    {
        [Fact]
        public void TestBucketFillTotalColors()
        {
            var red = new Pixel(254, 0, 0);
            var green = new Pixel(0, 254, 0);
            var blue = new Pixel(0, 0, 254);

            var blueBucket = new ColorBucket(0, 0, 254, 0, 0, 255);
            var greenBucket = new ColorBucket(0, 254, 0, 0, 255, 0);
            var redBucket = new ColorBucket(254, 0, 0, 255, 0, 0);

            Assert.True(blueBucket.AddIfFits(blue));
            Assert.True(redBucket.AddIfFits(red));
            Assert.True(greenBucket.AddIfFits(green));

            Assert.Equal(1, blueBucket.GetSize);
            Assert.Equal(1, greenBucket.GetSize);
            Assert.Equal(1, redBucket.GetSize);
        }

        [Fact]
        public void TestBucketFillMixedColors()
        {
            var bucket1Color1 = new Pixel(60, 60, 60);
            var bucket1Color2 = new Pixel(3, 59, 66);
            var bucket1Color3 = new Pixel(0, 1, 2);

            var bucket2Color1 = new Pixel(90, 90, 90);
            var bucket2Color2 = new Pixel(125, 90, 150);
            var bucket2Color3 = new Pixel(169, 155, 163);

            var bucket3Color1 = new Pixel(180, 180, 180);
            var bucket3Color2 = new Pixel(190, 190, 178);
            var bucket3Color3 = new Pixel(255, 255, 255);

            var bucket1 = new ColorBucket(0, 0, 0, 85, 85, 85);
            var bucket2 = new ColorBucket(85, 85, 85, 170, 170, 170);
            var bucket3 = new ColorBucket(170, 170, 170, 255, 255, 255);

            // Check if bucket1 accecpt correct colors
            Assert.True(bucket1.AddIfFits(bucket1Color1));
            Assert.True(bucket1.AddIfFits(bucket1Color2));
            Assert.True(bucket1.AddIfFits(bucket1Color3));

            // Check if bucket2 accecpt correct colors
            Assert.True(bucket2.AddIfFits(bucket2Color1));
            Assert.True(bucket2.AddIfFits(bucket2Color2));
            Assert.True(bucket2.AddIfFits(bucket2Color3));

            // Check if bucket3 accecpt correct colors
            Assert.True(bucket3.AddIfFits(bucket3Color1));
            Assert.True(bucket3.AddIfFits(bucket3Color2));
            Assert.True(bucket3.AddIfFits(bucket3Color3));

            // Ensure that bucket1 does not accecpt wrong colors
            Assert.False(bucket1.AddIfFits(bucket2Color1));
            Assert.False(bucket1.AddIfFits(bucket2Color2));
            Assert.False(bucket1.AddIfFits(bucket2Color3));
            Assert.False(bucket1.AddIfFits(bucket3Color1));
            Assert.False(bucket1.AddIfFits(bucket3Color2));
            Assert.False(bucket1.AddIfFits(bucket3Color3));

            // Ensure that bucket2 does not accecpt wrong colors
            Assert.False(bucket2.AddIfFits(bucket1Color1));
            Assert.False(bucket2.AddIfFits(bucket1Color2));
            Assert.False(bucket2.AddIfFits(bucket1Color3));
            Assert.False(bucket2.AddIfFits(bucket3Color1));
            Assert.False(bucket2.AddIfFits(bucket3Color2));
            Assert.False(bucket2.AddIfFits(bucket3Color3));

            // Ensure that bucket3 does not accecpt wrong colors
            Assert.False(bucket3.AddIfFits(bucket1Color1));
            Assert.False(bucket3.AddIfFits(bucket1Color2));
            Assert.False(bucket3.AddIfFits(bucket1Color3));
            Assert.False(bucket3.AddIfFits(bucket2Color1));
            Assert.False(bucket3.AddIfFits(bucket2Color2));
            Assert.False(bucket3.AddIfFits(bucket2Color3));

            // Ensure that colors has been added
            Assert.Equal(3, bucket1.GetSize);
            Assert.Equal(3, bucket2.GetSize);
            Assert.Equal(3, bucket3.GetSize);
        }

        [Fact]
        public void TestBucketAggregatetColor()
        {
            var bucket1Color1 = new Pixel(60, 60, 60);
            var bucket1Color2 = new Pixel(4, 59, 66);
            var bucket1Color3 = new Pixel(0, 1, 2);

            var expectedAggregatColor1 = new Pixel(21, 40, 42);

            var bucket2Color1 = new Pixel(90, 90, 90);
            var bucket2Color2 = new Pixel(90, 90, 150);
            var bucket2Color3 = new Pixel(90, 156, 164);

            var expectedAggregatColor2 = new Pixel(90, 112, 134);

            var bucket1 = new ColorBucket(0, 0, 0, 85, 85, 85);
            var bucket2 = new ColorBucket(85, 85, 85, 170, 170, 170);

            bucket1.AddIfFits(bucket1Color1);
            bucket1.AddIfFits(bucket1Color2);
            bucket1.AddIfFits(bucket1Color3);

            bucket2.AddIfFits(bucket2Color1);
            bucket2.AddIfFits(bucket2Color2);
            bucket2.AddIfFits(bucket2Color3);

            var agggPixel1 = bucket1.AggregatePixel();
            var agggPixel2 = bucket2.AggregatePixel();

            Assert.Equal(expectedAggregatColor1.GetRed, agggPixel1.GetRed);
            Assert.Equal(expectedAggregatColor1.GetGreen, agggPixel1.GetGreen);
            Assert.Equal(expectedAggregatColor1.GetBlue, agggPixel1.GetBlue);

            Assert.Equal(expectedAggregatColor2.GetRed, agggPixel2.GetRed);
            Assert.Equal(expectedAggregatColor2.GetGreen, agggPixel2.GetGreen);
            Assert.Equal(expectedAggregatColor2.GetBlue, agggPixel2.GetBlue);
        }

        [Fact]
        public void Temp()
        {
            var bitmap = new Bitmap(Image.FromFile("C:\\Users\\freim\\Pictures\\TestImage.bmp"));

            var pallete = new SimplePalette(bitmap);

            Debug.WriteLine(pallete.ToString());
        }
    }
}
