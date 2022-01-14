using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightSystem
{
    public interface ILightView
    {
        void ChangeSouthLight(State state);
        void ChangeWestLight(State state);
        void ChangeEastLight(State state);
        void ChangeNorthLight(State state);


        void ChangeSouthWestLight(State state);
        void ChangeNorthEastLight(State state);
        void ChangeSouthEastLight(State state);
        void ChangeNorthWestLight(State state);
    }
}
