using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using nemtudom.Models;

namespace nemtudom.Controllers;

public class DownloadController : Controller
{
    private readonly ILogger<DownloadController> _logger;

    public DownloadController(ILogger<DownloadController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
}