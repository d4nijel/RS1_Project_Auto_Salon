using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoSalon.Data.EF;
using AutoSalon.Data.Models;
using AutoSalon.Web.Areas.Iznajmljivanje.ViewModels;
using AutoSalon.Web.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoSalon.Web.Areas.Iznajmljivanje.Controllers
{
    [Autorizacija(rent: true, prodaja: false, admin: false, manager: false)]
    [Area("Iznajmljivanje")]
    public class OsiguranjaController : Controller
    {

        MojContext _db;

        public OsiguranjaController(MojContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            OsiguranjaIndexVM model = new OsiguranjaIndexVM();

            model.rows = _db.PolicaOsiguranja.Select(x => new OsiguranjaIndexVM.Row
            {
                brojPolice = x.BrojPolice.ToString(),
                krajUgovora = x.KrajUgovora.ToShortDateString(),
                policaId = x.PolicaOsiguranjaID,
                osiguravajucaFirma = x.OsiguravajucaFirma.Naziv + " " + x.OsiguravajucaFirma.Grad.Naziv,
                vozilo = x.Vozilo.Proizvodjac.Naziv + " " + x.Vozilo.Model
            }).ToList();


            return View(model);
        }

        [Route("/Iznajmljivanje/Osiguranja/Pretraga/{tekst?}")]
        public IActionResult Pretraga(string tekst)
        {
            OsiguranjaIndexVM model = new OsiguranjaIndexVM();

            model.rows = _db.PolicaOsiguranja
                .Where(x=>x.OsiguravajucaFirma.Naziv.Contains(tekst))
                .Select(x => new OsiguranjaIndexVM.Row
            {
                brojPolice = x.BrojPolice.ToString(),
                krajUgovora = x.KrajUgovora.ToShortDateString(),
                policaId = x.PolicaOsiguranjaID,
                osiguravajucaFirma = x.OsiguravajucaFirma.Naziv + " " + x.OsiguravajucaFirma.Grad.Naziv,
                vozilo = x.Vozilo.Proizvodjac.Naziv + " " + x.Vozilo.Model
            }).ToList();


            return View("Index",model);
        }

            public IActionResult Dodaj()
        {
            OsiguranjaDodajVM model = new OsiguranjaDodajVM();

            GenerisiCmb(model);
            model.KrajUgovora = DateTime.Now;

            return View(model);
        }
        [Route("/Iznajmljivanje/Osiguranja/Dodaj/{id}")]
        public IActionResult Dodaj(int id)
        {
            OsiguranjaDodajVM model = new OsiguranjaDodajVM();
            GenerisiCmb(model);
            model.KrajUgovora = DateTime.Now;
            model.VoziloID = id;

            return View(model);
        }

        private void GenerisiCmb(OsiguranjaDodajVM model)
        {
            model.osiguravajuceFirme = _db.OsiguravajucaFirma.Select(x => new SelectListItem
            {
                Text = x.Naziv,
                Value = x.OsiguravajucaFirmaID.ToString()
            }).ToList();

            model.vozila = _db.Vozilo.Select(x => new SelectListItem
            {
                Text = x.Proizvodjac.Naziv + " " + x.Model,
                Value = x.VoziloID.ToString()
            }).ToList();
        }

        public IActionResult Uredi(int id)
        {
            PolicaOsiguranja po = _db.PolicaOsiguranja.Find(id);
            OsiguranjaDodajVM model = new OsiguranjaDodajVM()
            {
                BrojPolice = po.BrojPolice,
                KrajUgovora = po.KrajUgovora,
                OsiguravajucaFirmaID = po.OsiguravajucaFirmaID,
                PolicaOsiguranjaID = po.PolicaOsiguranjaID,
                VoziloID = po.VoziloID,
                PocetakUgovora = po.PocetakUgovora
            };

            GenerisiCmb(model);

            return View("Dodaj", model);
        }

        public IActionResult Snimi(OsiguranjaDodajVM model)
        {
            if (!ModelState.IsValid)
            {
                GenerisiCmb(model);
                return View("Dodaj", model);
            }

            PolicaOsiguranja po = _db.PolicaOsiguranja.Find(model.PolicaOsiguranjaID);

            if (po == null)
            {
                po = new PolicaOsiguranja();

                _db.PolicaOsiguranja.Add(po);
                _db.SaveChanges();
            }

             po.BrojPolice = model.BrojPolice;
             po.KrajUgovora = model.KrajUgovora;
             po.OsiguravajucaFirmaID = model.OsiguravajucaFirmaID;
             po.VoziloID = model.VoziloID;
             po.PocetakUgovora = model.PocetakUgovora;
            po.Vozilo = _db.Vozilo.Where(x => x.VoziloID == model.VoziloID).SingleOrDefault();
            po.OsiguravajucaFirma = _db.OsiguravajucaFirma.Where(x => x.OsiguravajucaFirmaID == model.OsiguravajucaFirmaID).SingleOrDefault();
            _db.SaveChanges();

            return RedirectToAction("Index");
        }



        public IActionResult Obrisi(int id)
        {
            PolicaOsiguranja po = _db.PolicaOsiguranja.Find(id);
            _db.PolicaOsiguranja.Remove(po);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}