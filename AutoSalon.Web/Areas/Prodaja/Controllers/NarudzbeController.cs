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
using Microsoft.EntityFrameworkCore;

namespace AutoSalon.Web.Areas.Prodaja.Controllers
{
    [Autorizacija(rent: false, prodaja: true, admin: false, manager: false)]
    [Area("Prodaja")]
    public class NarudzbeController : Controller
    {
        private MojContext _context;
        public NarudzbeController(MojContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            NarudzbeIndexVM model = new NarudzbeIndexVM
            {
                Redovi = _context.Narudzba.Select(s => new NarudzbeIndexVM.Red
                {
                    BrojNarudzbe = s.NarudzbaID,
                    DatumNarudzbe = s.Datum,
                    StatusNarudzbe = s.StatusNarudzbe.Naziv,
                    StatusNarudzbeId = s.StatusNarudzbeID,
                    KlijentImePrezime = s.Klijent.Ime + " " + s.Klijent.Prezime,
                    Cijena = s.Cijena,
                    CijenaSaPDV = s.Cijena * 1.17
                }).ToList()
            };
            return View(model);
        }

        public double UkupnaCijena(int fakturaId)
        {
            double sum = 0;
            var cijena = _context.Narudzba.Where(w => w.FakturaID == fakturaId).Sum(c => c.Cijena);
            double? cijenaDostave = _context.Faktura.Where(w => w.FakturaID == fakturaId && w.Dostava != null).Select(s => s.Dostava.Cijena).SingleOrDefault();
            double? iznosPopusta = _context.Faktura.Where(w => w.FakturaID == fakturaId && w.Popust != null).Select(s => s.Popust.Procenat).SingleOrDefault();
            sum = (cijena + (cijenaDostave ?? 0)) - ((cijena + (cijenaDostave ?? 0)) * (iznosPopusta ?? 0) / 100);
            return sum;
        }

        public IActionResult IndexZavrsene(int id)
        {
            Klijent kIndex = _context.Klijent.Find(id);

            NarudzbeIndexVM model = new NarudzbeIndexVM
            {
                Redovi = _context.Narudzba.Where(w => w.KlijentID == kIndex.KlijentID && (w.StatusNarudzbeID == 2 || w.StatusNarudzbeID == 3)).Select(s => new NarudzbeIndexVM.Red
                {
                    BrojNarudzbe = s.NarudzbaID,
                    DatumNarudzbe = s.Datum,
                    StatusNarudzbe = s.StatusNarudzbe.Naziv,
                    KlijentImePrezime = s.Klijent.Ime + " " + s.Klijent.Prezime,
                    FakturaId = s.FakturaID,
                    StatusFakture=s.Faktura.StatusFakture.Naziv
                }).ToList()
            };

            foreach (var x in model.Redovi)
            {
                Narudzba n = _context.Narudzba.Where(w => w.NarudzbaID == x.BrojNarudzbe).SingleOrDefault();
                if (n.FakturaID != null)
                {
                    x.Cijena = UkupnaCijena(n.FakturaID??0);
                    x.CijenaSaPDV = x.Cijena * 1.17;
                }
                else
                {
                    x.Cijena = n.Cijena;
                    x.CijenaSaPDV = n.Cijena * 1.17;
                }
            }

            return PartialView(model);
        }

        public IActionResult Dodaj()
        {
            NarudzbeDodajVM model = new NarudzbeDodajVM
            {
                DatumNarudzbe = DateTime.Now,
                Datum = DateTime.Now.ToString("dd/MM/yyyy"),
                Klijenti = _context.Klijent.Select(s => new SelectListItem
                {
                    Value = s.KlijentID.ToString(),
                    Text = s.Ime + " " + s.Prezime,
                }).ToList()
            };
            return View(model);
        }

        public IActionResult Snimi(NarudzbeDodajVM input)
        {
            if (!ModelState.IsValid)
            {
                input.Klijenti = _context.Klijent.Select(s => new SelectListItem
                {
                    Value = s.KlijentID.ToString(),
                    Text = s.Ime + " " + s.Prezime,
                }).ToList();
                return View("Dodaj", input);
            }

            Narudzba n = new Narudzba
            {
                Cijena = 0,
                Datum = input.DatumNarudzbe,
                KlijentID = input.KlijentId,
                StatusNarudzbeID = 4 //Status Početni - Narudžba je kreirana ali nisu definisane stavke narudžbe
            };

            _context.Narudzba.Add(n);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Detalji(int id)
        {
            Narudzba n = _context.Narudzba.Where(w => w.NarudzbaID == id).Include(i => i.Klijent).Include(i => i.StatusNarudzbe).SingleOrDefault();

            NarudzbeDetaljiVM model = new NarudzbeDetaljiVM
            {
                BrojNarudzbe = n.NarudzbaID,
                DatumNarudzbe = n.Datum.ToString("dd/MM/yyyy"),
                Status = n.StatusNarudzbe.Naziv,
                KlijentImePrezime = n.Klijent.Ime + " " + n.Klijent.Prezime,
                StatusNarudzbeId = n.StatusNarudzbeID,
            };

            StavkaNarudzbe ns = _context.StavkaNarudzbe.Where(w => w.NarudzbaID == n.NarudzbaID).FirstOrDefault();
            if(ns!=null)
            {
                model.Provjera = true;
            }

            return View(model);
        }

        public IActionResult Kreiraj(int id)
        {
            Narudzba nZavrsi = _context.Narudzba.Find(id);

            nZavrsi.StatusNarudzbeID = 1; //Status U obradi - Narudžba je kreirana i definisane su stavke narudžbe
            _context.SaveChanges();

            return Redirect("/Prodaja/Narudzbe/Detalji?id=" + id);
        }

        public IActionResult Otkazi(int id)
        {
            Narudzba nOtkazi = _context.Narudzba.Find(id);

            nOtkazi.StatusNarudzbeID = 3; //Status Otkazana - Narudžba je otkazana
            _context.SaveChanges();

            return Redirect("/Prodaja/Narudzbe/Detalji?id=" + id);
        }

        public IActionResult Nazad(int id)
        {
            return Redirect("/Prodaja/Narudzbe/Detalji?id=" + id);
        }

        public IActionResult NazadIndex()
        {
            return Redirect("/Prodaja/Narudzbe/Index");
        }
    }
}