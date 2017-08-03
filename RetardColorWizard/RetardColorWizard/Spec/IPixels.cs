namespace RetardColorWizard.Spec
{
    using System.Collections.Generic;
    using System.Drawing;

    /// <summary>  
    ///  Abstraction of a set of Pixels.  
    /// </summary>
    public interface IPixels
    {

        /// <returns>
        ///  An Emmurator with allows to iterator over this pixels. 
        /// </returns>
        IEnumerator<IPixel> GetItEnumerator();
    }
}