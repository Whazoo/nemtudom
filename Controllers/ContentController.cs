
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using nemtudom.Models;
namespace nemtudom.Controllers;

public class ContentController : Controller
{
    private readonly ILogger<ContentController> _logger;

    public ContentController(ILogger<ContentController> logger)
    {
        _logger = logger;
    }

    public ActionResult Index()
    {
        return View();
    }
}