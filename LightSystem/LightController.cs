using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightSystem
{
    public class LightController
    {
        private Light southLight;
        private Light westLight;
        private Light southwestLight;
        private Light northWestLight;
        private Dictionary<Direction, Light> lightConfigurations;
        private ILightView _lightView;
        public LightController(ILightView lightView)
        {
            lightConfigurations = new Dictionary<Direction, Light>();
            _lightView = lightView;
            
            //Initialize the default object with red light. 
            southLight = new Light(Direction.South);
            southLight.StateChanged += new Action<Direction>(ControlSystem);

            //Initialize the default object with red light. 
            westLight = new Light(Direction.West);
            westLight.StateChanged += new Action<Direction>(ControlSystem);

            //Initialize the default object with red light. 
            southwestLight = new Light(Direction.SouthWest);
            southwestLight.StateChanged += new Action<Direction>(ControlSystem);

            //Initialize the default object with red light. 
            northWestLight = new Light(Direction.NorthWest);
            northWestLight.StateChanged += new Action<Direction>(ControlSystem);

            //Set any object to start with Green light by setting the next state. 
            southLight.SetNextState();
                     
        }

        public void ControlSystem(Direction direction)
        {
            //Capture all state from different lights
            State southLightState = southLight.CurrentState;
            State NorthLightState = (State)southLight.CurrentState.Clone();
            if (direction == Direction.South && southLightState.LightType == LightType.Red)
            {
                southwestLight.SetNextState();                
            }

            State southWestState = southwestLight.CurrentState;
            State northEastState = (State)southwestLight.CurrentState.Clone();
            if (direction == Direction.SouthWest && southWestState.LightType == LightType.Red)
            {                
                westLight.SetNextState();
            }

            State westLightState = westLight.CurrentState;
            State eastLightState = (State)westLight.CurrentState.Clone();
            if (direction == Direction.West && westLightState.LightType == LightType.Red)
            {
                northWestLight.SetNextState();
            }

            State northWestState = northWestLight.CurrentState;
            State southEastState = (State)northWestLight.CurrentState.Clone();
            if (direction == Direction.NorthWest && northWestState.LightType == LightType.Red)
            {
                southLight.SetNextState();
            }

            //Validate them against each other to make sure its not violating the traffic rule.


            //Apply the UI change
            _lightView.ChangeEastLight(eastLightState);
            _lightView.ChangeWestLight(westLightState);
            _lightView.ChangeNorthLight(NorthLightState);
            _lightView.ChangeSouthLight(southLightState);

            _lightView.ChangeSouthWestLight(southWestState);
            _lightView.ChangeNorthEastLight(northEastState);
            _lightView.ChangeSouthEastLight(southEastState);
            _lightView.ChangeNorthWestLight(northWestState);

        }
    }
}
