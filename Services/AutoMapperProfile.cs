using AutoMapper;
using MotoTrackerGps.Models;
using MotoTrackerGps.TrackersGPS;


namespace MotoTrackerGps.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TrackerGPS, TrackerViewModel>().ReverseMap();
            CreateMap<TrackerPosition, TrackerPositionDto>().ReverseMap();
        }
    }
}
