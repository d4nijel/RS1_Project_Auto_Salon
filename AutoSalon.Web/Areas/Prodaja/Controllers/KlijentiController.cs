using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoSalon.Data.EF;
using AutoSalon.Data.Models;
using AutoSalon.Web.Areas.Prodaja.ViewModels;
using AutoSalon.Web.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoSalon.Web.Areas.Prodaja.Controllers
{
    [Autorizacija(rent: false, prodaja: true, admin: false, manager: false)]
    [Area("Prodaja")]
    public class KlijentiController : Controller
    {
        private MojContext _context;
        public KlijentiController(MojContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            KlijentiIndexVM model = new KlijentiIndexVM
            {
                Redovi = _context.Klijent.Select(s => new KlijentiIndexVM.Red
                {
                    KlijentId = s.KlijentID,
                    ImePrezime = s.Ime + " " + s.Prezime,
                    Email = s.Email,
                    Telefon = s.Telefon,
                    Adresa = s.Adresa,
                    Grad = s.Grad.Naziv
                }).ToList()
            };
            return View(model);
        }

        private void GenerisiCmb(KlijentiDodajVM model)
        {
            model.Gradovi = _context.Grad.Select(s => new SelectListItem
            {
                Value = s.GradID.ToString(),
                Text = s.Naziv
            }).ToList();
        }

        public IActionResult Dodaj()
        {
            KlijentiDodajVM model = new KlijentiDodajVM
            {
                DatumRodjenja = new DateTime(1900, 1, 1)
            };
            GenerisiCmb(model);
            return View(model);
        }

        public IActionResult Snimi(KlijentiDodajVM input)
        {
            Klijent klijent = _context.Klijent.Find(input.KlijentId);

            if(klijent!=null)
            {
                if (!ModelState.IsValid)
                {
                    GenerisiCmb(input);
                    return View("Detalji", input);
                }

                klijent.Spol = input.Spol;
                klijent.Email = input.Email;
                klijent.Telefon = input.Telefon;
                klijent.Adresa = input.Adresa;
                klijent.GradID = input.GradId;
                klijent.PostanskiBroj = input.PostanskiBroj;

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            if (!ModelState.IsValid)
            {
                GenerisiCmb(input);
                return View("Dodaj", input);
            }

            Klijent k = new Klijent
            {
                Adresa = input.Adresa,
                DatumRodjenja = input.DatumRodjenja,
                Email = input.Email,
                GradID = input.GradId,
                Ime = input.Ime,
                JMBG = input.JMBG,
                PostanskiBroj = input.PostanskiBroj,
                Prezime = input.Prezime,
                Spol = input.Spol,
                Telefon = input.Telefon
            };

            _context.Klijent.Add(k);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Detalji(int id)
        {
            Klijent klijent = _context.Klijent.Find(id);

            KlijentiDodajVM model = new KlijentiDodajVM
            {
                KlijentId = klijent.KlijentID,
                Adresa = klijent.Adresa,
                DatumRodjenja = klijent.DatumRodjenja,
                Email = klijent.Email,
                GradId = klijent.GradID,
                Ime = klijent.Ime,
                JMBG = klijent.JMBG,
                PostanskiBroj = klijent.PostanskiBroj,
                Prezime = klijent.Prezime,
                Spol = klijent.Spol,
                Telefon = klijent.Telefon
            };

            GenerisiCmb(model);

            return View(model);
        }

        public IActionResult NazadIndex()
        {
            return RedirectToAction("Index");
        }
    }
}