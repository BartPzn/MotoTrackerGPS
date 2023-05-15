using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MotoTrackerGps.Models;
using MotoTrackerGps.TrackersGPS;

namespace MotoTrackerGps.Data;

public class ApplicationDbContext : IdentityDbContext
{
    

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<TrackerGPS> TrackerGPS { get; set; }
    public DbSet<TrackingData> TrackingData { get; set; }
    public DbSet<TrackerPosition> TrackerPositions { get; set; }
}
