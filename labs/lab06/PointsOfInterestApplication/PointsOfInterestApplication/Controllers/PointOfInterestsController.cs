using System;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using PointsOfInterestApplication.Models;

namespace PointsOfInterestApplication.Controllers
{
    public class PointOfInterestsController : Controller
    {
        private readonly IRepository _repository;

        // sa adaugam ViewModel
        // entitatile din data layer nu vreau sa fie expuse
        // DTO cu gettere si settere ai UI sa fie validate inainte de a merge pe server
        // pt CREATE view model (nu am nevoie de id)
        // pt DELETE 


        public PointOfInterestsController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: PointOfInterests
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetAll());
        }

        // GET: PointOfInterests/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointOfInterest = await _repository.FirstOrDefault(id);
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
        public async Task<IActionResult> Create([Bind("Name,Description,Latitude,Longitude,City")] CreatePointOfInterestViewModel pointOfInterestViewModel)
        {
            if (ModelState.IsValid)
            {
//                var config = new MapperConfiguration(poi =>
//                    {
//                        poi.CreateMap<CreatePointOfInterestViewModel, PointOfInterest>();
//                    });
//
//                var pointOfInterest = config.CreateMapper().Map<PointOfInterest>(pointOfInterestViewModel);

                var pointOfInterest = new PointOfInterest
                {
                    City = pointOfInterestViewModel.City,
                    Description =  pointOfInterestViewModel.Description,
                    Id = Guid.NewGuid(),
                    Latitude = pointOfInterestViewModel.Latitude,
                    Longitude = pointOfInterestViewModel.Longitude,
                    Name = pointOfInterestViewModel.Name
                    //
                };
                _repository.Create(pointOfInterest);
                return RedirectToAction(nameof(Index));
            }

             // pe create click dreapta add View -> Cretae ndsmcmView Model
            return View(pointOfInterest);
        }

        // GET: PointOfInterests/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointOfInterest = await _repository.FindAsync(id);
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
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Description,Latitude,Longitude,City")] PointOfInterest pointOfInterest)
        {
            if (id != pointOfInterest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.Update(pointOfInterest);
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

            var pointOfInterest = await _repository.FirstOrDefault(id);
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
            await _repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool PointOfInterestExists(Guid id)
        {
            return _repository.Exists(id);
        }
    }
}