using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterCrabPots.Framework
{
    enum QualityIDs {
        None = 0,
        Silver = 1,
        Gold = 2,
        Iridium = 4
    };
    public class WeightedQuality
    {
        public string Quality { get; set; }
        public int Weight { get; set; }
    }
}
