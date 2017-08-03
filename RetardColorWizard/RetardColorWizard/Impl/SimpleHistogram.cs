namespace RetardColorWizard.Impl
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using RetardColorWizard.Spec;

    public class SimpleHistogram : IHistogram
    {
        private const byte maxSpectrumValue = 255;

        private readonly byte splitSize;
        private readonly byte bucketSize;

        private readonly IList<IBucket> buckets;

        public SimpleHistogram(byte splitSize)
        {
            this.splitSize = splitSize;
            this.bucketSize = (byte)(maxSpectrumValue / splitSize);
            this.buckets = new List<IBucket>();
            generateBucketsFromSpec();
        }

        private void generateBucketsFromSpec()
        {
                for (var x = 0; x < this.splitSize; x++)
                {
                    for (var y = 0; y < this.splitSize; y++)
                    {
                        for (var z = 0; z < this.splitSize; z++)
                        {
                            var currentMinX = (byte)(x * this.bucketSize);
                            var currentMinY = (byte)(y * this.bucketSize);
                            var currentMinZ = (byte)(z * this.bucketSize);

                            this.buckets.Add(new ColorBucket(
                                minX: currentMinX,
                                minY: currentMinY,
                                minZ: currentMinZ,
                                maxX: (byte)(currentMinX + this.bucketSize),
                                maxY: (byte)(currentMinY + this.bucketSize),
                                maxZ: (byte)(currentMinZ + this.bucketSize)));
                        }
                    }
                }
        }

        public List<IPixel> AccessSortedData(IPixels anlizePixels)
        {
            var ennumerator = anlizePixels.GetItEnumerator();
            while (ennumerator.MoveNext())
            {
                this.buckets.First(b => b.AddIfFits(ennumerator.Current));
            }

            return this.buckets
                .OrderByDescending(b => b.GetSize)
                .Take(10)
                .Select(b => b.AggregatePixel())
                .ToList();
        }
    }
}