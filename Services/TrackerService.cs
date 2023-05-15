using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MotoTrackerGps.Data;
using MotoTrackerGps.Models;
using MotoTrackerGps.TrackersGPS;

namespace MotoTrackerGps.Services
{
    public class TrackerService : ITrackerService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TrackerService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public TrackerGPS GetTrackerById(int id)
        {
            return _context.TrackerGPS.SingleOrDefault(t => t.ID == id);
        }

        public IEnumerable<TrackerGPS> GetTrackers()
        {
            return _context.TrackerGPS.ToList();
        }

        public async Task<TrackerPositionDto> GetLatestPositionForTracker(int trackerId)
        {
            var latestPosition = await _context.TrackerPositions
                .Where(tp => tp.TrackerID == trackerId)
                .OrderByDescending(tp => tp.Timestamp)
                .FirstOrDefaultAsync();

            if (latestPosition == null)
            {
                return null;
            }

            var latestPositionDto = new TrackerPositionDto
            {
                Latitude = latestPosition.Latitude,
                Longitude = latestPosition.Longitude,
                Timestamp = latestPosition.Timestamp
            };

            return latestPositionDto;
        }

        public async Task<List<TrackerPositionDto>> GetPositionHistoryForTracker(int trackerId)
        {
            var positions = await _context.TrackerPositions
                .Where(p => p.TrackerID == trackerId)
                .OrderByDescending(p => p.Timestamp)
                .ToListAsync();

            var positionDtos = _mapper.Map<List<TrackerPositionDto>>(positions);

            return positionDtos;
        }

        public void UpdateTracker(TrackerGPS tracker)
        {
            _context.TrackerGPS.Update(tracker);
            _context.SaveChanges();
        }

        public void ConfigureTracker(TrackerGPS tracker)
        {
            _context.TrackerGPS.Update(tracker);
            _context.SaveChanges();
        }

        public void AddTracker(TrackerGPS tracker)
        {
            _context.TrackerGPS.Add(tracker);
            _context.SaveChanges();
        }

        public void DeleteTracker(TrackerGPS tracker)
        {
            _context.TrackerGPS.Remove(tracker);
            _context.SaveChanges();
        }
    }
}
