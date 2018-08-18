using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterCrabPots.Framework
{
    internal interface IWeighted
    {
        int Weight { get; set; }
        object Value { get; set; }
    }
}
