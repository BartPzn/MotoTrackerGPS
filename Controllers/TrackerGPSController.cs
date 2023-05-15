using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MotoTrackerGps.Data;
using MotoTrackerGps.Models;
using MotoTrackerGps.Services;
using MotoTrackerGps.TrackersGPS;

namespace MotoTrackerGps.Controllers
{
    [Route("TrackerGps")]
    [ApiController]
    [Authorize]

    public class TrackerGPSController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ITrackerService _trackerService;

        public TrackerGPSController(ApplicationDbContext context, ITrackerService trackerService)
        {
            _context = context;
            _trackerService = trackerService;
        }

        public IActionResult Index()
        {
            var trackers = _trackerService.GetTrackers();
            return View("~/Views/TrackerGPS/Index.cshtml", trackers);
        }

        [HttpGet("Edit")]
        public IActionResult Edit()
        {
            var trackers = _trackerService.GetTrackers();
            return View("~/Views/TrackerGPS/EditTracker.cshtml", trackers);
        }

        [HttpGet("AddTracker")]
        public IActionResult AddTracker()
        {
            return View("~/Views/TrackerGPS/AddTracker.cshtml");
        }

        [HttpGet("TrackerList")]
        public IActionResult TrackerList()
        {
            var trackers = _trackerService.GetTrackers();
            return View(trackers);
        }

        [HttpGet("TrackerView")]
        public async Task<IActionResult> TrackerView(int id)
        {
            var tracker =  _trackerService.GetTrackerById(id);

            if (tracker == null)
            {
                return NotFound();
            }

            var model = new TrackerViewModel
            {
                Tracker = tracker,
                LatestPosition = await _trackerService.GetLatestPositionForTracker(tracker.ID),
                PositionHistory = await _trackerService.GetPositionHistoryForTracker(tracker.ID)
            };

            return View("~/Views/TrackerGPS/TrackersView.cshtml", model);
        }



        [HttpGet("EditTracker")]
        public IActionResult EditTracker(EditTrackerModel model)
        {
            if (ModelState.IsValid)
            {
                var existingTracker = _trackerService.GetTrackerById(model.ID);

                if (existingTracker != null)
                {
                    existingTracker.ID = model.ID;
                    existingTracker.TrackerName = model.TrackerName;
                    existingTracker.Description = model.Description;
                    existingTracker.Imei = model.Imei;
                    existingTracker.TrackerIP = model.TrackerIP;
                    existingTracker.TrackerPort = model.TrackerPort;

                    _trackerService.UpdateTracker(existingTracker);

                    return RedirectToAction("EditTracker", model);
                }
            }

            return View("~/Views/TrackerGPS/EditTracker.cshtml", model);

        }

        [HttpPost("EditTracker")]
        public IActionResult EditTracker(TrackerGPS tracker)
        {
            if (ModelState.IsValid)
            {
                _trackerService.UpdateTracker(tracker);

                return View("~/Views/TrackerGPS/EditTracker.cshtml", tracker);
            }
            _trackerService.UpdateTracker(tracker);
            return RedirectToAction("TrackerList", "TrackerGPS");
        }

        [HttpPost("AddTracker")]
        public IActionResult AddTracker(TrackerGPS tracker)
        {
            if (ModelState.IsValid)
            {
                _trackerService.AddTracker(tracker);

                return View("~/Views/TrackerGPS/AddTracker.cshtml", tracker);
            }
            _trackerService.AddTracker(tracker);
            return RedirectToAction("TrackerList", "TrackerGPS");
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(TrackerGPS tracker)
        {
            var existingTracker = _trackerService.GetTrackerById(tracker.ID);

            if (existingTracker != null)
            {
                _trackerService.DeleteTracker(existingTracker);
            }

            return RedirectToAction("TrackerList", "TrackerGPS");
        }

        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
