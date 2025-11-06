using Microsoft.AspNetCore.Mvc;
using CaseManagement.Models;
using CaseManagement.Services;

namespace CaseManagement.Controllers
{
    public class CaseController : Controller
    {
        private readonly CaseService _caseService;

        public CaseController(CaseService caseService)
        {
            _caseService = caseService;
        }

        // GET: Case
        public IActionResult Index(string caseType)
        {
            var cases = _caseService.GetAll(caseType ?? "");
            return View(cases);
        }

        // GET: Case/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Case/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Case caseItem)
        {
            if (ModelState.IsValid)
            {
                _caseService.Create(caseItem);
                return RedirectToAction(nameof(Index));
            }
            return View(caseItem);
        }

        // GET: Case/Edit/5
        public IActionResult Edit(string id, string caseType)
        {
            var caseList = _caseService.GetAll(caseType ?? "");
            var caseItem = caseList.FirstOrDefault(c => c.Id == id);
            if (caseItem == null) return NotFound();
            return View(caseItem);
        }

        // POST: Case/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Case caseItem)
        {
            if (ModelState.IsValid)
            {
                _caseService.Update(caseItem);
                return RedirectToAction(nameof(Index));
            }
            return View(caseItem);
        }

        // GET: Case/Delete/5
        public IActionResult Delete(string id, string caseType)
        {
            var caseList = _caseService.GetAll(caseType ?? "");
            var caseItem = caseList.FirstOrDefault(c => c.Id == id);
            if (caseItem == null) return NotFound();
            return View(caseItem);
        }

        // POST: Case/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id, string caseType)
        {
            _caseService.Delete(id, caseType);
            return RedirectToAction(nameof(Index));
        }
    }
}
