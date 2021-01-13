using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_
{
    public interface IEdgeDetectionManager
    {
       // Bitmap ChoiceEdge(string Edgevalue, Bitmap sourceBitmap);
        Bitmap CopyToSquareCanvas(Bitmap sourceBitmap, int canvasSize);

        string GetEdgeDetectionName();

        void SetEdgeDetectionName(string name);
    }
}
