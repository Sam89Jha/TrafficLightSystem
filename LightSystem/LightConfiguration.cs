using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightSystem
{
    public class LightConfiguration
    {        
        public Direction Direction { get; set; }

        public Dictionary<HourType, List<LightSetting>> LightConfig { get; set; }

        public DateTime PeakHourStartTime { get; set; }

        public DateTime PeakHourEndTime { get; set; }
    }

    public enum HourType
    {
        NH,
        PH
    }

    public enum Direction
    {
        NoDirection,
        East,        
        West,
        North,
        South,
        SouthEast,
        NorthWest,
        NorthEast,
        SouthWest
    }
}
