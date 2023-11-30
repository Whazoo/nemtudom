using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using nemtudom.Data;
using nemtudom.Models;

namespace nemtudom.Controllers;

[Authorize]
public class DownloadController : Controller
{
    private readonly ApplicationDbContext _context;

    public DownloadController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var download = _context.Download.ToList();
        return View(download);
    }
    
}