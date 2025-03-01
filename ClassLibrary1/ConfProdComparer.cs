using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class ConfProdComparer : IComparer<ConfProd>
    {
        public int Compare(ConfProd pre, ConfProd next)
        {
            return string.Compare(pre.Name, next.Name);
        }
    }
}
