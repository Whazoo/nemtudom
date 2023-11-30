
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using nemtudom.Data;
using nemtudom.Models;
namespace nemtudom.Controllers;

public class ContentController : Controller
{
    private readonly ILogger<ContentController> _logger;
    private readonly ApplicationDbContext _context;


    public ContentController(ApplicationDbContext context)
    {
        _context = context;
    }

    public ActionResult Index()
    {
        var contentList = _context.Content.ToList();
        return View(contentList);
    }
}