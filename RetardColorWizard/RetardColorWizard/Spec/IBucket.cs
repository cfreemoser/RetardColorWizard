namespace RetardColorWizard
{
    using RetardColorWizard.Spec;

    public interface IBucket
    {

        byte MinX { get; }

        byte MinY { get; }

        byte MinZ { get; }

        byte MaxX { get; }

        byte MaxY { get; }

        byte MaxZ { get; }

        int GetSize { get; }

        bool AddIfFits(IPixel pixel);

        IPixel AggregatePixel();
    }
}