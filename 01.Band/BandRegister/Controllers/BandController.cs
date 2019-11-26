using BandRegister.Data;
using BandRegister.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BandRegister.Controllers
{
    public class BandController : Controller
    {
        public IActionResult Index()
        {
            using (var db = new BandDbContext())
            {
                var allBands = db.Bands.ToList();
                return View(allBands);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Band band)
        {
            using (var db = new BandDbContext())
            {
                db.Bands.Add(band);
                db.SaveChanges();
            }

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new BandDbContext())
            {
                var bandToEdit = db.Bands.FirstOrDefault(t => t.Id == id);
                if (bandToEdit == null)
                {
                    return RedirectToAction("Index");
                }

                return this.View(bandToEdit);
            }

        }

        [HttpPost]
        public IActionResult Edit(Band band)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            using (var db = new BandDbContext())
            {
                var BandToEdit = db.Bands.FirstOrDefault(t => t.Id == band.Id);
                BandToEdit.Name = band.Name;
                BandToEdit.Members = band.Members;
                BandToEdit.Honorarium = band.Honorarium;
                BandToEdit.Genre = band.Genre;

                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db = new BandDbContext())
            {
                Band BandDetails = db.Bands.FirstOrDefault(t => t.Id == id);
                if (BandDetails == null)
                {
                    return RedirectToAction("Index");
                }

                return View(BandDetails);
            }
        }

        [HttpPost]
        public IActionResult Delete(Band band)
        {
            using (var db = new BandDbContext())
            {
                var bandToDel = db.Bands.FirstOrDefault(t => t.Id == band.Id);
                if (bandToDel == null)
                {
                    return RedirectToAction("Index");
                }

                db.Bands.Remove(bandToDel);
                db.SaveChanges();
            }

            return RedirectToAction("Index");

        }
    }
}