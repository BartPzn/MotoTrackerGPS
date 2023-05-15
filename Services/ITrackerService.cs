using System.Collections.Generic;
using System.Threading.Tasks;
using MotoTrackerGps.Models;
using MotoTrackerGps.TrackersGPS;

namespace MotoTrackerGps.Services
{
    public interface ITrackerService
    {
        TrackerGPS GetTrackerById(int id);
        IEnumerable<TrackerGPS> GetTrackers();
        Task<TrackerPositionDto> GetLatestPositionForTracker(int trackerId);
        Task<List<TrackerPositionDto>> GetPositionHistoryForTracker(int trackerId);
        void UpdateTracker(TrackerGPS tracker);
        void ConfigureTracker(TrackerGPS tracker);
        void AddTracker(TrackerGPS tracker);
        void DeleteTracker(TrackerGPS tracker);
    }
}
