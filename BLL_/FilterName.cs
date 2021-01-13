using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_
{
    public class FilterName : IFilterManager
    {
        String filterValue;

        public string GetFilterName()
        {
            return filterValue;
        }

        public void SetFilterName(string filterValue)
        {
            this.filterValue = filterValue;
        }
    }
}
