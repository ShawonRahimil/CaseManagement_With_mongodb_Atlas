using CaseManagement.Models;
using CaseManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CaseManagement.Controllers
{
    [Authorize]
    public class AdalotController : Controller
    {
        private readonly AdalotService _adalotService;

        public AdalotController(AdalotService adalotService)
        {
            _adalotService = adalotService;
        }

        // GET: Adalot
        public IActionResult Index()
        {
            var adalots = _adalotService.GetAll();
            return View(adalots);
        }

        // GET: Adalot/Create
        public IActionResult Create() => View();

        // POST: Adalot/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Adalot adalot)
        {
            if (ModelState.IsValid)
            {
                _adalotService.Create(adalot);
                return RedirectToAction(nameof(Index));
            }
            return View(adalot);
        }

        // GET: Adalot/Edit/5
        public IActionResult Edit(string id)
        {
            var adalot = _adalotService.GetAll().FirstOrDefault(a => a.Id == id);
            if (adalot == null) return NotFound();
            return View(adalot);
        }

        // POST: Adalot/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Adalot adalot)
        {
            if (ModelState.IsValid)
            {
                _adalotService.Update(adalot);
                return RedirectToAction(nameof(Index));
            }
            return View(adalot);
        }

        // GET: Adalot/Delete/5
        public IActionResult Delete(string id)
        {
            var adalot = _adalotService.GetAll().FirstOrDefault(a => a.Id == id);
            if (adalot == null) return NotFound();
            return View(adalot);
        }

        // POST: Adalot/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id, string location)
        {
            _adalotService.Delete(id, location);
            return RedirectToAction(nameof(Index));
        }
    }
}
