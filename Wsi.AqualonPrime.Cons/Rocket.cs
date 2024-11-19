using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wsi.AqualonPrime.Cons
{
    public class Rocket
    {
        public int Height { get; set; }
        public int Distance { get; set; }
        public int Answer() => Height * Distance;
    }
}
