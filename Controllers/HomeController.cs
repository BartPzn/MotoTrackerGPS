using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using MotoTrackerGps.Models;


namespace MotoTrackerGps.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IConfiguration _config;

    public HomeController(ILogger<HomeController> logger, IConfiguration config)
    {
        _logger = logger;
        _config = config;
    }
    
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ConnectTrackerGPS()
    {
        string ipAddress = _config["TrackerGPS:IPAddress"];
        int port = int.Parse(_config["TrackerGPS:Port"]);
        TcpClient client = new TcpClient(ipAddress, port);
        NetworkStream stream = client.GetStream();

        byte[] data = new byte[1024];
        int bytesRead = stream.Read(data, 0, data.Length);
        string response = Encoding.ASCII.GetString(data, 0, bytesRead);

        ViewData["Message"] = "Odebrano dane od trackera GPS: " + response;
        return View();
    }

    public IActionResult NotifySMS(int option)
    {
        switch (option)
        {
            case 1:
                // Kod do wysyłania powiadomienia SMS w przypadku utraty połączenia z trackerem GPS
                break;
            case 2:
                // Kod do wysyłania powiadomienia SMS w przypadku przekroczenia określonej prędkości
                break;
            default:
                ViewData["Message"] = "Nieprawidłowa opcja";
                break;
        }

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

