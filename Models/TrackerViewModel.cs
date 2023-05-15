using MotoTrackerGps.TrackersGPS;

namespace MotoTrackerGps.Models
{
    public class TrackerViewModel
    {
        public TrackerGPS Tracker { get; set; }
        public TrackerPositionDto LatestPosition { get; set; }
        public List<TrackerPositionDto> PositionHistory { get; set; }
    }

}