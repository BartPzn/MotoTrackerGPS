using System;
using System.Diagnostics;

namespace MotoTrackerGps.Models
{
    public class TrackerPosition
    {
        public int ID { get; set; }
        public int TrackerID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Timestamp { get; set; }
        
    }

}

