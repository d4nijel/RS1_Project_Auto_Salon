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
    public class KlijentiController : Controller
    {
        MojContext _db;

        public KlijentiController(MojContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        { 
            KlijentIndexVM model = new KlijentIndexVM();

            model.rows = _db.Klijent.Select(x => new KlijentIndexVM.Row
            {
                imePrezime = x.Ime + " " + x.Prezime,
                adresa = x.Adresa,
                klijentId = x.KlijentID,
                telefon = x.Telefon
            }).ToList();
            
            return View(model);
        }

       [Route("/Iznajmljivanje/Klijenti/Pretraga/{tekst?}")]
        public IActionResult Pretraga(string tekst)
        {
            KlijentIndexVM model = new KlijentIndexVM();

            model.rows = _db.Klijent
                .Where(x => x.Ime.Contains(tekst) || x.Prezime.Contains(tekst))
                .Select(x => new KlijentIndexVM.Row
                {
                    imePrezime = x.Ime + " " + x.Prezime,
                    adresa = x.Adresa,
                    klijentId = x.KlijentID,
                    telefon = x.Telefon
                }).ToList();

            return View("Index", model);
        }
        
        public IActionResult Dodaj()
        {
            KlijentDodajVM model = new KlijentDodajVM();

            model.gradovi = _db.Grad.Select(x => new SelectListItem
            {
                Text = x.Naziv,
                Value = x.GradID.ToString()
            }).ToList();

            model.DatumRodjenja = new DateTime(1900, 1, 1);

            return View(model);
        }
        
        
        public IActionResult Uredi(int id)
        {
            Klijent k = _db.Klijent.Find(id);
            KlijentDodajVM model = new KlijentDodajVM()
            {
                Adresa = k.Adresa,
                Telefon = k.Telefon,
                Spol = k.Spol,
                DatumRodjenja = k.DatumRodjenja,
                Email = k.Email,
                GradID = k.GradID,
                Ime = k.Ime,
                PostanskiBroj = k.PostanskiBroj,
                JMBG = k.JMBG,
                Prezime = k.Prezime,
                KlijentID = k.KlijentID
            };

            model.gradovi = _db.Grad.Select(x => new SelectListItem
            {
                Text = x.Naziv,
                Value = x.GradID.ToString()
            }).ToList();

            return View("Dodaj", model);
        }

        public IActionResult Snimi(KlijentDodajVM model)
        {
            if (!ModelState.IsValid)
            {
                model.gradovi = _db.Grad.Select(x => new SelectListItem
                {
                    Text = x.Naziv,
                    Value = x.GradID.ToString()
                }).ToList();

                return View("Dodaj", model);
            }


            Klijent k = _db.Klijent.Find(model.KlijentID);

            if(k == null)
            {
                k = new Klijent();

                _db.Klijent.Add(k);
                _db.SaveChanges();
            }

            k.Adresa = model.Adresa;
            k.DatumRodjenja = model.DatumRodjenja;
            k.Spol = model.Spol;
            k.Email = model.Email;
            k.Grad = _db.Grad.Where(x => x.GradID == model.GradID).SingleOrDefault();
            k.GradID = model.GradID;
            k.Ime = model.Ime;
            k.JMBG = model.JMBG;
            k.PostanskiBroj = model.PostanskiBroj;
            k.Prezime = model.Prezime;
            k.Telefon = model.Telefon;

            _db.SaveChanges();

            return RedirectToAction("Index");
        }



        public IActionResult Obrisi(int id)
        {
            Klijent k = _db.Klijent.Find(id);

            List<RentBooking> bookings = _db.RentBooking.Where(x => x.KlijentID == k.KlijentID).ToList();

            foreach(RentBooking x in bookings)
            {
                List<Faktura> fakture = _db.Faktura.Where(f => f.FakturaID == x.FakturaID).ToList();
                foreach (Faktura fkt in fakture)
                    _db.Faktura.Remove(fkt);

                _db.RentBooking.Remove(x);
            }

            _db.Klijent.Remove(k);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}