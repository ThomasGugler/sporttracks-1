using System;
using System.Xml;
using sporttracks.core.tool;

namespace sporttracks.core
{
    public class Lap
    {
        public DateTime StartTime { get; set; }
        public Double TotalTime { get; set; }
        public Double? TotalDistance { get; set; }

        public Byte? AvgHeartRate { get; set; }

        public Double? TotalCalories { get; set; }

    }

    public static class LapExtensions
    {
        public static Lap ToLap(this XmlElement element)
        {
            var lap = new Lap();

            lap.StartTime = element.GetAttributeAsDateTime("startTime").Value;
            lap.TotalTime = element.GetAttributeAsDouble("totalTime").Value;
            lap.TotalDistance = element.GetAttributeAsDouble("totalDistance");
            lap.AvgHeartRate = element.GetAttributeAsByte("avgHeartRate");
            lap.TotalCalories = element.GetAttributeAsDouble("totalCalories");

            return lap;
        }
    }
}