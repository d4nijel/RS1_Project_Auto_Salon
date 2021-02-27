using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoSalon.Data.EF;
using AutoSalon.Data.Models;
using AutoSalon.Web.Areas.Prodaja.ViewModels;
using AutoSalon.Web.Helper;
using AutoSalon.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AutoSalon.Web.Areas.Prodaja.Controllers
{
    [Autorizacija(rent: false, prodaja: true, admin: false, manager: false)]
    [Area("Prodaja")]
    public class IzvjestajiController : Controller
    {
        private MojContext _context;
        public IzvjestajiController(MojContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            AutentifikacijaVM korisnik = HttpContext.GetLogiraniKorisnik();

            IzvjestajiIndexVM model = new IzvjestajiIndexVM
            {
                Redovi = _context.Izvjestaj.Where(w => w.ZaposlenikId == korisnik.ZaposlenikId).Select(s => new IzvjestajiIndexVM.Red
                {
                    IzvjestajId = s.IzvjestajID,
                    DatumKreiranja = s.Datum,
                    Napomena = s.Napomena,
                    Naziv = s.Naziv
                }).ToList()
            };
            return View(model);
        }

        public IActionResult Dodaj()
        {
            AutentifikacijaVM korisnik = HttpContext.GetLogiraniKorisnik();

            IzvjestajiDodajVM model = new IzvjestajiDodajVM
            {
                ZaposlenikId = korisnik.ZaposlenikId,
                DatumKreiranja = DateTime.Now,
                Datum = DateTime.Now.ToString("dd/MM/yyyy")
            };
            return View(model);
        }

        public IActionResult Snimi(IzvjestajiDodajVM input)
        {
            Izvjestaj iDetalji = _context.Izvjestaj.Find(input.IzvjestajId);

            if (iDetalji != null)
            {
                if (!ModelState.IsValid)
                {
                    return View("Detalji", input);
                }

                iDetalji.Datum = input.DatumKreiranja;
                iDetalji.Napomena = input.Napomena;
                iDetalji.Naziv = input.Naziv;
                iDetalji.Sadrzaj = input.Sadrzaj;
                iDetalji.ZaposlenikId = input.ZaposlenikId;

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            if (!ModelState.IsValid)
            {
                return View("Dodaj", input);
            }

            Izvjestaj iNovi = new Izvjestaj
            {
                Datum = input.DatumKreiranja,
                Napomena = input.Napomena,
                Naziv = input.Naziv,
                Sadrzaj = input.Sadrzaj,
                ZaposlenikId = input.ZaposlenikId
            };

            _context.Izvjestaj.Add(iNovi);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Obrisi(int id)
        {
            Izvjestaj iObrisi = _context.Izvjestaj.Find(id);

            _context.Izvjestaj.Remove(iObrisi);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Detalji(int id)
        {
            Izvjestaj iDetalji = _context.Izvjestaj.Find(id);

            IzvjestajiDodajVM model = new IzvjestajiDodajVM
            {
                DatumKreiranja = iDetalji.Datum,
                Napomena = iDetalji.Napomena,
                Naziv = iDetalji.Naziv,
                Sadrzaj = iDetalji.Sadrzaj,
                ZaposlenikId = iDetalji.ZaposlenikId,
                IzvjestajId = iDetalji.IzvjestajID,
                Datum = DateTime.Now.ToString("dd/MM/yyyy")
            };
            return View(model);
        }
    }
}