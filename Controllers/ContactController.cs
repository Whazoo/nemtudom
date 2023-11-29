using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Connections;
using Microsoft.Data.SqlClient;
using nemtudom.Data;
using nemtudom.Models;
namespace nemtudom.Controllers;

public class ContactController : Controller
{
    private readonly ILogger<ContactController> _logger;
    private readonly ApplicationDbContext _context;


    public ContactController(ApplicationDbContext context)
    {
        _context = context;
    }

    public ActionResult Index()
    {
        var contacts = _context.Contacts.ToList();
        return View(contacts);
    }
    
}