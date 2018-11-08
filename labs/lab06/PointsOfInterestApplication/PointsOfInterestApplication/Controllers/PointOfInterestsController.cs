using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataLayer;

namespace PointsOfInterestApplication.Controllers
{
    public class PointOfInterestsController : Controller
    {
        private readonly CityContext _context;

        public PointOfInterestsController(CityContext context)
        {
            _context = context;
        }

        // GET: PointOfInterests
        public async Task<IActionResult> Index()
        {
            return View(await _context.PointOfInterests.ToListAsync());
        }

        // GET: PointOfInterests/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointOfInterest = await _context.PointOfInterests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pointOfInterest == null)
            {
                return NotFound();
            }

            return View(pointOfInterest);
        }

        // GET: PointOfInterests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PointOfInterests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,CityId")] PointOfInterest pointOfInterest)
        {
            if (ModelState.IsValid)
            {
                pointOfInterest.Id = Guid.NewGuid();
                _context.Add(pointOfInterest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pointOfInterest);
        }

        // GET: PointOfInterests/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointOfInterest = await _context.PointOfInterests.FindAsync(id);
            if (pointOfInterest == null)
            {
                return NotFound();
            }
            return View(pointOfInterest);
        }

        // POST: PointOfInterests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Description,CityId")] PointOfInterest pointOfInterest)
        {
            if (id != pointOfInterest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pointOfInterest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PointOfInterestExists(pointOfInterest.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pointOfInterest);
        }

        // GET: PointOfInterests/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointOfInterest = await _context.PointOfInterests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pointOfInterest == null)
            {
                return NotFound();
            }

            return View(pointOfInterest);
        }

        // POST: PointOfInterests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var pointOfInterest = await _context.PointOfInterests.FindAsync(id);
            _context.PointOfInterests.Remove(pointOfInterest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PointOfInterestExists(Guid id)
        {
            return _context.PointOfInterests.Any(e => e.Id == id);
        }
    }
}
