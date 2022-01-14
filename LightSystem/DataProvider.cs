using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightSystem
{
    public class DataProvider
    {        
        private DateTime _peakHourStartTime = new DateTime(DateTime.Today.Year, 
            DateTime.Today.Month, DateTime.Today.Day, 8, 0, 0);
        private DateTime _peakHourEndTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month
            , DateTime.Today.Day, 10, 0, 0);
        private static DataProvider _provider;
        private static object _lock = new object();
        private DataProvider()
        {

        }

        public static DataProvider GetDataProvider()
        {
            if(_provider ==null)
            {
                lock(_lock)
                {
                    if (_provider == null)
                    {
                        _provider = new DataProvider();
                    }
                }
            }

            return _provider;
        }

        public LightConfiguration GetLightConfiguration(Direction direction)
        {
            LightConfiguration lightConfiguration = new LightConfiguration();
            if (direction == Direction.West || direction == Direction.East)
            {
                lightConfiguration.Direction = direction;
                lightConfiguration.LightConfig = new Dictionary<HourType, List<LightSetting>>();
                lightConfiguration.LightConfig.Add(HourType.NH, new List<LightSetting>()
            {
                new LightSetting()
                {
                    LightType = LightType.Green,
                    Duration = 20,
                },
                new LightSetting()
                {
                    LightType = LightType.Yellow,
                    Duration = 5,
                },
                new LightSetting()
                {
                    LightType = LightType.BufferRed,
                    Duration = 4,
                },
                new LightSetting()
                {
                    LightType = LightType.Red,
                    Duration = 20,
                }
            });

                lightConfiguration.LightConfig.Add(HourType.PH, new List<LightSetting>()
            {
                new LightSetting()
                {
                    LightType = LightType.Green,
                    Duration = 10,
                },
                new LightSetting()
                {
                    LightType = LightType.Yellow,
                    Duration = 5,
                },
                new LightSetting()
                {
                    LightType = LightType.BufferRed,
                    Duration = 4,
                },
                new LightSetting()
                {
                    LightType = LightType.Red,
                    Duration = 40,
                }
            });

                lightConfiguration.PeakHourStartTime = _peakHourStartTime;
                lightConfiguration.PeakHourEndTime = _peakHourEndTime;
            }
            else if (direction == Direction.South || direction == Direction.North)
            {
                lightConfiguration.Direction = Direction.South;
                lightConfiguration.LightConfig = new Dictionary<HourType, List<LightSetting>>();
                lightConfiguration.LightConfig.Add(HourType.NH, new List<LightSetting>()
            {
                new LightSetting()
                {
                    LightType = LightType.Green,
                    Duration = 20,
                },
                new LightSetting()
                {
                    LightType = LightType.Yellow,
                    Duration = 5,
                },
                new LightSetting()
                {
                    LightType = LightType.BufferRed,
                    Duration = 4,
                },
                new LightSetting()
                {
                    LightType = LightType.Red,
                    Duration = 20,
                }
            });

                lightConfiguration.LightConfig.Add(HourType.PH, new List<LightSetting>()
            {
                new LightSetting()
                {
                    LightType = LightType.Green,
                    Duration = 40,
                },
                new LightSetting()
                {
                    LightType = LightType.Yellow,
                    Duration = 5,
                },
                new LightSetting()
                {
                    LightType = LightType.BufferRed,
                    Duration = 4,
                },
                new LightSetting()
                {
                    LightType = LightType.Red,
                    Duration = 40,
                }
            });

                lightConfiguration.PeakHourStartTime = _peakHourStartTime;
                lightConfiguration.PeakHourEndTime = _peakHourEndTime;
                return lightConfiguration;
            }
            else if (direction == Direction.SouthWest || direction == Direction.NorthEast)
            {
                lightConfiguration.Direction = direction;
                lightConfiguration.LightConfig = new Dictionary<HourType, List<LightSetting>>();
                lightConfiguration.LightConfig.Add(HourType.NH, new List<LightSetting>()
                {
                    new LightSetting()
                    {
                        LightType = LightType.Green,
                        Duration = 8,
                    },
                    new LightSetting()
                    {
                        LightType = LightType.Yellow,
                        Duration = 5,
                    },
                    new LightSetting()
                    {
                        LightType = LightType.BufferRed,
                        Duration = 2,
                    },
                    new LightSetting()
                    {
                        LightType = LightType.Red,
                        Duration = 20,
                    }
                });
            }
            else
            {
                lightConfiguration.Direction = direction;
                lightConfiguration.LightConfig = new Dictionary<HourType, List<LightSetting>>();
                lightConfiguration.LightConfig.Add(HourType.NH, new List<LightSetting>()
                {
                    new LightSetting()
                    {
                        LightType = LightType.Green,
                        Duration = 8,
                    },
                    new LightSetting()
                    {
                        LightType = LightType.Yellow,
                        Duration = 5,
                    },
                    new LightSetting()
                    {
                        LightType = LightType.BufferRed,
                        Duration = 2,
                    },
                    new LightSetting()
                    {
                        LightType = LightType.Red,
                        Duration = 20,
                    }
                });
            }

            return lightConfiguration;
        }
    }
}
