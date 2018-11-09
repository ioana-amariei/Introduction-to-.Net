using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using PointsOfInterestApplication.ViewModel;

namespace PointsOfInterestApplication.Controllers
{
    public class PointOfInterestsController : Controller
    {
        private readonly IRepository _repository;
        private readonly MapperConfiguration _config;
       
        public PointOfInterestsController(IRepository repository)
        {
            _repository = repository;
            _config = new MapperConfiguration(poi =>
            {
                poi.CreateMap<PoiViewModel, PointOfInterest>();
            });
        }

        // GET: PointOfInterests
        public async Task<IActionResult> Index()
        {
            var poiViewModels = EntityListToDtoListMapper(await _repository.GetAll());
            return View(poiViewModels);
        }

        // GET: PointOfInterests/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointOfInterest = await _repository.FirstOrDefault(id);
            var poiViewModel = EntityToDtoMapper(pointOfInterest);
            if (pointOfInterest == null)
            {
                return NotFound();
            }

            return View(poiViewModel);
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
        public async Task<IActionResult> Create([Bind("Name,Description,Latitude,Longitude,City")] PoiViewModel poiViewModel)
        {
            if (ModelState.IsValid)
            {
                var pointOfInterest = DtoToEntityMapper(poiViewModel);
               
                await _repository.Create(pointOfInterest);
                return RedirectToAction(nameof(Index));

            }

            return View(poiViewModel);
        }

        // GET: PointOfInterests/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointOfInterest = await _repository.FindAsync(id);
            var poiViewModel = EntityToDtoMapper(pointOfInterest);
            if (pointOfInterest == null)
            {
                return NotFound();
            }
            return View(poiViewModel);
        }

        // POST: PointOfInterests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Description,Latitude,Longitude,City")] PoiViewModel poiViewModel)
        {
            if (id != poiViewModel.Id)
            {
                return NotFound();
            }

            var pointOfInterest = DtoToEntityMapper(poiViewModel);

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
            return View(poiViewModel);
        }

        // GET: PointOfInterests/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointOfInterest = await _repository.FirstOrDefault(id);
            var poiViewModel = EntityToDtoMapper(pointOfInterest);
            if (pointOfInterest == null)
            {
                return NotFound();
            }

            return View(poiViewModel);
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

        private PointOfInterest DtoToEntityMapper(PoiViewModel poiViewModel)
        {
            var pointOfInterest = _config.CreateMapper().Map<PointOfInterest>(poiViewModel);
            return pointOfInterest;
        }

        private PoiViewModel EntityToDtoMapper(PointOfInterest pointOfInterest)
        {
            var poiViewModel = _config.CreateMapper().Map<PoiViewModel>(pointOfInterest);
            return poiViewModel;
        }

        private List<PoiViewModel> EntityListToDtoListMapper(List<PointOfInterest> pointOfInterests)
        {
            var poiViewModels = _config.CreateMapper().Map<List<PointOfInterest>, List<PoiViewModel>>(pointOfInterests);
            return poiViewModels;
        }
    }
}