using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

namespace RetardColorWizard.Spec
{
    public interface IColorWizard
    {
        Task<Color> ExtractMainColor(Bitmap imageBitmap);
    }
}