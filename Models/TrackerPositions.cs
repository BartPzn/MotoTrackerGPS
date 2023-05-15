using System;
namespace MotoTrackerGps.Models
{
    public class TrackerPositions
    {
        public int TrackerID { get; set; }
        public List<TrackerPositionDto> Positions { get; set; }
    }

}

