using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nemtudom.Data;
using nemtudom.Models;

namespace nemtudom.Controllers
{
    public class ContentController : Controller
    {
        private readonly ILogger<ContentController> _logger;
        private readonly ApplicationDbContext _context;

        public ContentController(ILogger<ContentController> logger,ApplicationDbContext context)
        {    
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var contentList = _context.Content.ToList();
            return View(contentList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ContentModel content)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Content.Add(content);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Error creating content: {ex.Message}");
                ModelState.AddModelError(string.Empty, "An error occurred while saving the content.");
            }

            return View(content);
        }

        public IActionResult Edit(int id)
        {
            var content = _context.Content.Find(id);
            if (content == null)
            {
                return NotFound();
            }

            return View(content);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int content_id, ContentModel content)
        {
            try
            {
                if (content_id != content.content_id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    _context.Entry(content).State = EntityState.Modified;
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Content");
                }
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Error updating content: {ex.Message}");
                ModelState.AddModelError(string.Empty, "An error occurred while updating the content.");
            }

            return View(content);
        }

        public IActionResult Delete(int id)
        {
            var content = _context.Content.Find(id);
            if (content == null)
            {
                return NotFound();
            }

            return View(content);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var content = _context.Content.Find(id);
                if (content == null)
                {
                    return NotFound();
                }

                _context.Content.Remove(content);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Error deleting content: {ex.Message}");
                return RedirectToAction(nameof(Index), new { id, saveChangesError = true });
            }
        }
    }
}


        

