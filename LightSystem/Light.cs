using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LightSystem
{
    public class Light
    {
        private DataProvider dataProvider = DataProvider.GetDataProvider();

        public Light(Direction direction)
        {
            LightConfiguration = dataProvider.GetLightConfiguration(direction);
            CurrentState = new State
            {
                LightType = LightType.Red,
                StateType = StateType.Solid,
            };            
        }

        private LightConfiguration LightConfiguration { get; set; }
        public State CurrentState { get; private set; }

        public Action<Direction> StateChanged;

        public void SetNextState()
        {
            Thread t = new Thread(SetNewState);
            t.Start();
        }

        private void SetNewState(Object state)
        {            
            while (true)
            {
                try
                {
                    if (DateTime.Now > CurrentState.EndTime)
                    {
                        var nextState = GetNextState(CurrentState);
                        CurrentState = nextState;
                        StateChanged(LightConfiguration.Direction);
                        if(CurrentState.LightType == LightType.Red)
                        {
                            break;
                        }
                    }
                }
                finally
                {                    
                    Thread.Sleep(200);
                }
            }
        }

        private State GetNextState(State currentState)
        {
            HourType hourType = HourType.NH;
            if(DateTime.Now.TimeOfDay >= LightConfiguration.PeakHourStartTime.TimeOfDay
                 && DateTime.Now.TimeOfDay < LightConfiguration.PeakHourStartTime.TimeOfDay)
            {
                hourType = HourType.PH;
            }

            var configs = LightConfiguration.LightConfig[hourType];
            State nextState = null;
            switch(currentState.LightType)
            {
                case LightType.Green:
                    var yellowLightConfig = configs.First(x => x.LightType == LightType.Yellow);
                    nextState = new State
                    {
                        LightType = LightType.Yellow,
                        StateType = StateType.Solid,
                        StartTime = DateTime.Now,
                        EndTime = DateTime.Now.AddSeconds(yellowLightConfig.Duration)
                    };
                    break;
                case LightType.Yellow:
                    var bufferRedLightConfig = configs.First(x => x.LightType == LightType.BufferRed);
                    nextState = new State
                    {
                        LightType = LightType.BufferRed,
                        StateType = StateType.Solid,
                        StartTime = DateTime.Now,
                        EndTime = DateTime.Now.AddSeconds(bufferRedLightConfig.Duration)
                    };
                    break;
                case LightType.BufferRed:                                        
                    var redLightConfig = configs.First(x => x.LightType == LightType.Red);
                    nextState = new State
                    {
                        LightType = LightType.Red,
                        StateType = StateType.Solid,
                        StartTime = DateTime.Now,
                        EndTime = DateTime.Now.AddSeconds(redLightConfig.Duration)
                    };
                    break;
                case LightType.Red:                                      
                    var greenLightConfig = configs.First(x => x.LightType == LightType.Green);
                    nextState = new State
                    {
                        LightType = LightType.Green,
                        StateType = StateType.Solid,
                        StartTime = DateTime.Now,
                        EndTime = DateTime.Now.AddSeconds(greenLightConfig.Duration)
                    };
                    break;
            }

            return nextState;
        }
    }
}
