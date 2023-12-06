using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using nemtudom.Data;
using nemtudom.Models;

namespace nemtudom.Controllers
{
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

        [HttpGet]
        

        [HttpPost]
        public IActionResult AddContent(ContentModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Content.Add(model);
                _context.SaveChanges();

                // Redirect to the content index or another page
                return RedirectToAction("Index", "Content");
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var contentItem = _context.Content.Find(id);

            if (contentItem == null)
            {
                return NotFound();
            }

            return View(contentItem);
        }

        [HttpPost]
        public IActionResult Edit(ContentModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Content.Update(model);
                _context.SaveChanges();

                return RedirectToAction("Index", "Content");
            }

            return View(model);
        }

        // Example: Action to delete a specific content item
        public IActionResult Delete(int id)
        {
            var contentItem = _context.Content.Find(id);

            if (contentItem == null)
            {
                return NotFound();
            }

            return View(contentItem);
        }
        [HttpGet]
        public ActionResult EditIndex()
        {
            var contentList = _context.Content.ToList();
            return View(contentList);
        }
        
    }
}
