using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_
{
    public class EdgeName : IEdgeDetectionManager
    {

        String EdgeValue;

        public Bitmap CopyToSquareCanvas(Bitmap sourceBitmap, int canvasSize)
        {
            throw new NotImplementedException();
        }

        public string GetEdgeDetectionName()
        {
            return EdgeValue;
        }

        public void SetEdgeDetectionName(string EdgeValue)
        {
            this.EdgeValue = EdgeValue;
        }
    }
}
