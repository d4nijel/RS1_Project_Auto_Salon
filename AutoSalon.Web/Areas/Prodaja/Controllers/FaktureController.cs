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
    public class FaktureController : Controller
    {
        private MojContext _context;
        public FaktureController(MojContext context)
        {
            _context = context;
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
        public IActionResult Index()
        {
            FaktureIndexVM model = new FaktureIndexVM
            {
                Redovi = _context.Faktura.Select(s => new FaktureIndexVM.Red
                {
                    FakturaId = s.FakturaID,
                    DatumFakture = s.Datum,
                    Popust = s.Popust.Procenat + "%",
                    Status = s.StatusFakture.Naziv,
                    ZaposlenikImePrezime = s.Zaposlenik.Ime + " " + s.Zaposlenik.Prezime,
                    StatusFaktureId = s.StatusFaktureID,
                    NarudzbaId = _context.Narudzba.Where(w => w.FakturaID == s.FakturaID).Select(p => p.NarudzbaID).FirstOrDefault(),
                    KlijentImePrezime = _context.Narudzba.Where(w => w.FakturaID == s.FakturaID).Select(r => r.Klijent.Ime + " " + r.Klijent.Prezime).FirstOrDefault()
                }).ToList()
            };

            foreach (var x in model.Redovi)
            {
                x.UkupnaCijena = UkupnaCijena(x.FakturaId);
                x.UkupnaCijenaSaPDV = x.UkupnaCijena * 1.17;
            }
            return View(model);
        }
        private void GenerisiCmb(FaktureDodajVM model)
        {
            model.Popusti = _context.Popust.Select(s => new SelectListItem
            {
                Value = s.PopustID.ToString(),
                Text = s.Naziv + ": " + s.Procenat + "%"
            }).ToList();
        }
        public IActionResult Dodaj(int id)
        {
            AutentifikacijaVM korisnik = HttpContext.GetLogiraniKorisnik();

            Narudzba n = _context.Narudzba.Find(id);

            FaktureDodajVM model = new FaktureDodajVM
            {
                DatumFakturisanja = DateTime.Now,
                Datum = DateTime.Now.ToString("dd/MM/yyyy"),
                ZaposlenikId = korisnik.ZaposlenikId,
                NarudzbaId = n.NarudzbaID
            };

            GenerisiCmb(model);

            return View(model);
        }

        public IActionResult Snimi(FaktureDodajVM input)
        {
            if (!ModelState.IsValid)
            {
                GenerisiCmb(input);
                return View("Dodaj", input);
            }

            Faktura fNova = new Faktura
            {
                Datum = input.DatumFakturisanja,
                PopustID = input.PopustId,
                StatusFaktureID = 3, // Status Početna Faktura je kreirana ali nije definisana dostava ni uplata 
                ZaposlenikID = input.ZaposlenikId
            };

            _context.Faktura.Add(fNova);
            _context.SaveChanges();

            Narudzba n = _context.Narudzba.Find(input.NarudzbaId);
            n.FakturaID = fNova.FakturaID;
            n.StatusNarudzbeID = 2; //Status Završena - Narudžba je kreirana i napravljena je faktura

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Detalji(int id)
        {
            Faktura fDetalji = _context.Faktura.Where(w => w.FakturaID == id).Include(i => i.Popust).Include(i => i.StatusFakture).Include(i => i.Zaposlenik).SingleOrDefault();

            FaktureDetaljiVM model = new FaktureDetaljiVM
            {
                FakturaId = fDetalji.FakturaID,
                DatumFakture = fDetalji.Datum,
                Datum=fDetalji.Datum.ToString("dd/MM/yyyy"),
                Status = fDetalji.StatusFakture.Naziv,
                PopustId = fDetalji.PopustID,
                ZaposlenikImePrezime = fDetalji.Zaposlenik.Ime + " " + fDetalji.Zaposlenik.Prezime,
                DostavaId = fDetalji.DostavaID,
                StatusFaktureId = fDetalji.StatusFaktureID,
                NarudzbaId = _context.Narudzba.Where(w => w.FakturaID == fDetalji.FakturaID).Select(p => p.NarudzbaID).FirstOrDefault(),
                KlijentImePrezime = _context.Narudzba.Where(w => w.FakturaID == fDetalji.FakturaID).Select(r => r.Klijent.Ime + " " + r.Klijent.Prezime).FirstOrDefault()
            };

            if(fDetalji.Popust==null)
            {
                model.Popust = "";
            }

            model.UkupnaCijena = UkupnaCijena(model.FakturaId);
            model.UkupnaCijenaSaPDV = model.UkupnaCijena * 1.17;

            model.Popusti = _context.Popust.Select(s => new SelectListItem
            {
                Value = s.PopustID.ToString(),
                Text = s.Naziv + ": " + s.Procenat + "%"
            }).ToList();

            return View(model);
        }

        public IActionResult UrediSnimi(FaktureDetaljiVM input)
        {
            if (!ModelState.IsValid)
            {
                input.Popusti = _context.Popust.Select(s => new SelectListItem
                {
                    Value = s.PopustID.ToString(),
                    Text = s.Naziv + ": " + s.Procenat + "%"
                }).ToList();

                input.UkupnaCijena = UkupnaCijena(input.FakturaId);
                input.UkupnaCijenaSaPDV = input.UkupnaCijena * 1.17;

                return View("Detalji", input);
            }

            Faktura fDetalji = _context.Faktura.Find(input.FakturaId);

            fDetalji.PopustID = input.PopustId;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Kreiraj(int id)
        {
            Faktura nZavrsi = _context.Faktura.Find(id);

            nZavrsi.StatusFaktureID = 2; //Staus fakture Izdata - Faktura je izdata ali nije plaćena
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult NazadIndex()
        {
            return Redirect("/Prodaja/Fakture/Index");
        }
    }
}