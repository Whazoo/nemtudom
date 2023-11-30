using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using nemtudom.Data;
using nemtudom.Models;
using System.IO;

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

    public IActionResult DownloadFile(int id)
    {
        var download = _context.Download.Find(id);
        if (download == null)
        {
            return NotFound();
        }

        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "downloads", download.file_path);
        
        var memory = new MemoryStream();
        using (var stream = new FileStream(path, FileMode.Open))
        {
            stream.CopyTo(memory);
        }
        memory.Position = 0;
        return File(memory, GetContentType(path), Path.GetFileName(path));
    }

    private string GetContentType(string path)
    {
        var types = GetMimeTypes();
        var ext = Path.GetExtension(path).ToLowerInvariant();
        return types[ext];
    }

    private Dictionary<string, string> GetMimeTypes()
    {
        return new Dictionary<string, string>
        {
            {".txt", "text/plain"},
            {".pdf", "application/pdf"},
            {".doc", "application/vnd.ms-word"},
            {".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document"},
            {".xls", "application/vnd.ms-excel"},
            {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
            {".png", "image/png"},
            {".jpg", "image/jpeg"},
            {".jpeg", "image/jpeg"},
            {".gif", "image/gif"},
            {".csv", "text/csv"}
        };
    }
}
