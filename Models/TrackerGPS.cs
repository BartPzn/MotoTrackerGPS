using System;
using System.Net.Sockets;
using Microsoft.EntityFrameworkCore;
using MotoTrackerGps.Models;
using MotoTrackerGps.Services;

namespace MotoTrackerGps.TrackersGPS
{
    public class TrackerGPS
    {
        public int ID { get; set; }
        public string TrackerName { get; set; }
        public string Description { get; set; }
        public string TrackerIP { get; set; }
        public string Imei { get; set; }
        public int TrackerPort { get; set; }
        public int TrackerGPSID { get; set; }
        public DateTime Timestamp { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Speed { get; set; }
        public double Altitude { get; set; }
    

        public ICollection<TrackingData> TrackingData { get; set; }
        public DateTime LastActive { get; set; } = DateTime.Now;

    }
    

}

