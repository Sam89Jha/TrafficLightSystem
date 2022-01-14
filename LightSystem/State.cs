using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightSystem
{
    public class State : ICloneable
    {
        public LightType LightType { get; set; }

        public StateType StateType { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public object Clone()
        {
            return new State
            {
                LightType = this.LightType,
                StateType = this.StateType,
                StartTime = this.StartTime,
                EndTime = this.EndTime
            };            
        }        
    }

    public enum StateType
    {
        Solid,
        Blink
    }
}
