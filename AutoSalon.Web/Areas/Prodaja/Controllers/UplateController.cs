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
    public class UplateController : Controller
    {
        private MojContext _context;
        public UplateController(MojContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? id)
        {
            UplateIndexVM model = new UplateIndexVM();

            Faktura fIndex = _context.Faktura.Where(w => w.FakturaID == id).SingleOrDefault();

            if (fIndex!=null)
            {            
                model.Redovi = _context.Uplata.Where(w => w.FakturaID == fIndex.FakturaID).Select(s => new UplateIndexVM.Red
                {
                    FakturaId = s.FakturaID,
                    DatumUplate = s.Datum,
                    Iznos = s.Iznos,
                    KlijentImePrezime = s.Klijent.Ime + " " + s.Klijent.Prezime,
                    NacinPlacanja = s.NacinPlacanja.Naziv
                }).ToList();

                return View("IndexFaktura",model);
            }

            model.Redovi = _context.Uplata.Select(s => new UplateIndexVM.Red
            {
                FakturaId = s.FakturaID,
                DatumUplate = s.Datum,
                Iznos = s.Iznos,
                KlijentImePrezime = s.Klijent.Ime + " " + s.Klijent.Prezime,
                NacinPlacanja = s.NacinPlacanja.Naziv
            }).ToList();

            return View(model);
        }

        private void GenerisiCmb(UplateDodajVM model)
        {
            model.NaciniPlacanja = _context.NacinPlacanja.Select(s => new SelectListItem
            {
                Value = s.NacinPlacanjaID.ToString(),
                Text = s.Naziv
            }).ToList();
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

        public IActionResult Dodaj(int FakturaId)
        {
            Faktura fDodaj = _context.Faktura.Find(FakturaId);

            Narudzba n = _context.Narudzba.Where(w => w.FakturaID == fDodaj.FakturaID).Include(i=>i.Klijent).FirstOrDefault();

            UplateDodajVM model = new UplateDodajVM
            {
                FakturaId = fDodaj.FakturaID,
                DatumUplate = DateTime.Now,
                Datum = DateTime.Now.ToString("dd/MM/yyyy"),
                Iznos = UkupnaCijena(FakturaId) * 1.17,
                KlijentId = n.KlijentID,
                KlijentImePrezime = n.Klijent.Ime + " " + n.Klijent.Prezime
            };

            model.IznosSaPDV = model.Iznos.ToString("F2");

            GenerisiCmb(model);

            return PartialView(model);
        }

        public IActionResult Snimi(UplateDodajVM input)
        {
            if(!ModelState.IsValid)
            {
                GenerisiCmb(input);
                return View("Dodaj", input);
            }

            Uplata uNova = new Uplata
            {
                Datum = input.DatumUplate,
                FakturaID = input.FakturaId,
                Iznos = input.Iznos,
                KlijentID = input.KlijentId,
                NacinPlacanjaID = input.NacinPlacanjaId
            };

            _context.Uplata.Add(uNova);
            _context.SaveChanges();

            Faktura fNadji = _context.Faktura.Find(input.FakturaId);

            fNadji.StatusFaktureID = 1; //Plaćena - Faktura je plaćena
            _context.SaveChanges();

            return Redirect("/Prodaja/Fakture/Detalji?id=" + input.FakturaId);
        }
    }
}