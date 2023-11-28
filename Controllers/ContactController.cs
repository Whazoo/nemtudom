using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using nemtudom.Models;
namespace nemtudom.Controllers;

public class ContactController : Controller
{
    private readonly ILogger<ContactController> _logger;

    public ContactController(ILogger<ContactController> logger)
    {
        _logger = logger;
    }

    public ActionResult Index()
    {
        return View();
    }
}