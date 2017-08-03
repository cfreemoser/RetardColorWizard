namespace RetardColorWizard.Impl
{
    using System.Collections.Generic;
    using System.Linq;

    using RetardColorWizard.Spec;

    public class ColorBucket : IBucket
    {
        private readonly List<IPixel> pixelsInBucket;

        public ColorBucket(byte minX, byte minY, byte minZ, byte maxX, byte maxY, byte maxZ)
        {
            this.MaxX = maxX;
            this.MaxY = maxY;
            this.MaxZ = maxZ;
            this.MinX = minX;
            this.MinY = minY;
            this.MinZ = minZ;
            this.pixelsInBucket = new List<IPixel>();
        }

        public byte MinX { get; }

        public byte MinY { get; }

        public byte MinZ { get; }

        public byte MaxX { get; }

        public byte MaxY { get; }

        public byte MaxZ { get; }

        public int GetSize => this.pixelsInBucket.Count;

        public bool AddIfFits(IPixel pixel)
        {
            var fits = this.IsInBetween(this.MinX, this.MaxX, pixel.GetRed) 
                && this.IsInBetween(this.MinY, this.MaxY, pixel.GetGreen)
                && this.IsInBetween(this.MinZ, this.MaxZ, pixel.GetBlue);
                   
            if (fits)
            {
                this.pixelsInBucket.Add(pixel);
            }

            return fits;
        }

        public IPixel AggregatePixel()
        {
            return GetSize > 0
                       ? new Pixel(
                           red: (byte)this.pixelsInBucket.Select(p => p.GetRed).Average(x => (decimal)x),
                           green: (byte)this.pixelsInBucket.Select(p => p.GetGreen).Average(y => (decimal)y),
                           blue: (byte)this.pixelsInBucket.Select(p => p.GetBlue).Average(z => (decimal)z))
                       : new Pixel(0, 0, 0);
        }

        private bool IsInBetween(byte min, byte max, byte value)
        {
            return value >= min && value <= max;
        }
    }
}