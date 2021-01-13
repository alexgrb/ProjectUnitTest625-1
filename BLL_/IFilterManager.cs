using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_
{
    public interface IFilterManager
    {
        string GetFilterName();

        void SetFilterName(string name);
    }
}
