using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoSalon.Data.EF;
using AutoSalon.Data.Models;
using AutoSalon.Web.Areas.Iznajmljivanje.ViewModels;
using AutoSalon.Web.Helper;
using AutoSalon.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoSalon.Web.Areas.Iznajmljivanje.Controllers
{
    [Autorizacija(rent: true, prodaja: false, admin: false, manager: false)]
    [Area("Iznajmljivanje")]
    public class IzvjestajiController : Controller
    {

        MojContext _db;

        public IzvjestajiController(MojContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IzvjestajiIndexVM model = new IzvjestajiIndexVM();

            model.rows = _db.Izvjestaj.Select(x => new IzvjestajiIndexVM.Row
            {
                Naziv = x.Naziv,
                Datum = DateTime.Now.ToShortDateString(),
                IzvjestajID = x.IzvjestajID,
                Napomena = x.Napomena
            }).ToList();


            return View(model);
        }

        [Route("/Iznajmljivanje/Izvjestaji/Pretraga/{tekst?}")]
        public IActionResult Pretraga(string tekst)
        {
            IzvjestajiIndexVM model = new IzvjestajiIndexVM();

            model.rows = _db.Izvjestaj
                .Where(x=>x.Naziv.Contains(tekst))
                .Select(x => new IzvjestajiIndexVM.Row
            {
                Naziv = x.Naziv,
                Datum = DateTime.Now.ToShortDateString(),
                IzvjestajID = x.IzvjestajID,
                Napomena = x.Napomena
            }).ToList();


            return View("Index",model);
        }


        public IActionResult Dodaj()
        {
            IzvjestajiDodajVM model = new IzvjestajiDodajVM();

            AutentifikacijaVM logiraniKorisnik = HttpContext.GetLogiraniKorisnik();
            model.ZaposlenikId = logiraniKorisnik.ZaposlenikId;

            return View(model);
        }


        public IActionResult Uredi(int id)
        {
            Izvjestaj i = _db.Izvjestaj.Find(id);
            IzvjestajiDodajVM model = new IzvjestajiDodajVM()
            {
                Datum = i.Datum,
                Napomena = i.Napomena,
                Naziv = i.Naziv,
                Sadrzaj = i.Sadrzaj,
                IzvjestajID = i.IzvjestajID,
                Zaposlenik = i.Zaposlenik,
                ZaposlenikId = i.ZaposlenikId
            };

            return View("Dodaj", model);
        }

        public IActionResult Snimi(IzvjestajiDodajVM input)
        {
            if (!ModelState.IsValid)
            {
                return View("Dodaj", input);
            }

            Izvjestaj i = _db.Izvjestaj.Find(input.IzvjestajID);

            if (i == null)
            {
                i = new Izvjestaj();
                i.Datum = DateTime.Now;
                _db.Izvjestaj.Add(i);
                _db.SaveChanges();
            }

            i.Napomena = input.Napomena;
            i.Naziv = input.Naziv;
            i.Sadrzaj = input.Sadrzaj;
            i.Zaposlenik = input.Zaposlenik;
            i.ZaposlenikId = input.ZaposlenikId;

            _db.SaveChanges();

            return RedirectToAction("Index");
        }



        public IActionResult Obrisi(int id)
        {
            Izvjestaj i = _db.Izvjestaj.Find(id);
            _db.Izvjestaj.Remove(i);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}