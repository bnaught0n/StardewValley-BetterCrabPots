using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterCrabPots.Framework
{
    enum QualityIDs {
        Zero,
        None = 1,
        Silver = 2,
        Gold = 3, 
        Iridium = 4
    };
    public class WeightedQuality
    {
        public string Quality { get; set; }
        public int Weight { get; set; }
    }
}
