using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightSystem
{
    public class LightSetting
    {
        public LightType LightType { get; set; }

        public int Duration { get; set; }
    }

    public enum LightType
    {
        NoLight,
        Green,
        Yellow,
        BufferRed,
        Red
    }
}
