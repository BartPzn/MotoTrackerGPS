using System;
namespace MotoTrackerGps.Models
{
	public class TrackingData
	{
        public int ID { get; set; }
        public int TrackerGPSID { get; set; }
        public DateTime Timestamp { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Speed { get; set; }
        public double Altitude { get; set; }
    }
}
	

