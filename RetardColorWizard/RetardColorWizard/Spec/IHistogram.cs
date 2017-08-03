namespace RetardColorWizard.Spec
{
    using System.Collections.Generic;

    public interface IHistogram
    {

        List<IPixel> AccessSortedData(IPixels analyzelPixels);


    }
}