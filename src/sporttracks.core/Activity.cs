using System;
using System.Collections.Generic;

namespace sporttracks.core
{
    public class Activity
    {
        public Guid Id { get; set; }
        public DateTime? StartTime { get; set; }
        public Double? TotalTime { get; set; }
        public Double? TotalDistance { get; set; }
        public Double? TotalCalories { get; set; }
        public string Notes { get; set; }
        public string CategoryName { get; set; }
        public Guid? CategoryId { get; set; }
        public string Location { get; set; }
        public IReadOnlyList<Lap> Laps { get; set; }

        public Weather Weather { get; set; }

        public GpsRoute GpsRoute { get; set; }
    }
}