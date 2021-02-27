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
using Microsoft.EntityFrameworkCore;

namespace AutoSalon.Web.Areas.Iznajmljivanje.Controllers
{
    [Autorizacija(rent: true, prodaja: false, admin: false, manager: false)]
    [Area("Iznajmljivanje")]
    public class RentacarController : Controller
    {

        MojContext _db;

        public RentacarController(MojContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            RentacarIndexVM model = new RentacarIndexVM();

            model.rows = _db.RentBooking
                .Select(x => new RentacarIndexVM.Row
            {
                cijena = string.Format("{0:#.00}", x.UkupnaCijena),
                datumIsteka = x.DatumIsteka,
                datumRentanja = x.DatumRentanja,
                klijent = x.Klijent.Ime + " " + x.Klijent.Prezime,
                rentId = x.RentBookingID,
                vozilo = x.Vozilo.Proizvodjac.Naziv + " " + x.Vozilo.Model,
                zaposlenik = x.Zaposlenik.Ime + " " + x.Zaposlenik.Prezime,
                isZavrseno = x.isZavrseno
            }).ToList();

            return View(model);

        }

        [Route("/Iznajmljivanje/Rentacar/Pretraga/{tekst?}")]
        public IActionResult Pretraga(string tekst)
        {
            RentacarIndexVM model = new RentacarIndexVM();

            model.rows = _db.RentBooking
                .Where(x=>x.Klijent.Ime.Contains(tekst) || x.Klijent.Prezime.Contains(tekst))
                .Select(x => new RentacarIndexVM.Row
                {
                    cijena = string.Format("{0:#.00}", x.UkupnaCijena),
                    datumIsteka = x.DatumIsteka,
                    datumRentanja = x.DatumRentanja,
                    klijent = x.Klijent.Ime + " " + x.Klijent.Prezime,
                    rentId = x.RentBookingID,
                    vozilo = x.Vozilo.Proizvodjac.Naziv + " " + x.Vozilo.Model,
                    zaposlenik = x.Zaposlenik.Ime + " " + x.Zaposlenik.Prezime,
                    isZavrseno = x.isZavrseno
                }).ToList();

            return View("Index",model);
        }

        public IActionResult Obrisi(int id)
        {
            RentBooking rb = _db.RentBooking.Find(id);
            Vozilo v = _db.Vozilo.Where(x => x.VoziloID == rb.VoziloID).SingleOrDefault();

            if (!rb.isZavrseno)
                v.isIznajmljeno = false;

            List<Faktura> vezaneFakture = _db.Faktura.Where(x => x.FakturaID == rb.FakturaID).ToList();
            foreach(Faktura x in vezaneFakture)
            {
                _db.Faktura.Remove(x);
            }
            _db.RentBooking.Remove(rb);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Dodaj()
        {
            RentacarDodajVM model = new RentacarDodajVM();
            GenerisiCmb(model);
            model.DatumIsteka = DateTime.Now;

            AutentifikacijaVM logiraniKorisnik = HttpContext.GetLogiraniKorisnik();
            model.ZaposlenikID = logiraniKorisnik.ZaposlenikId;

            return View(model);
        }


        [Route("/Iznajmljivanje/Rentacar/Zavrsi/{id}")]
        public IActionResult Zavrsi(int id)
        {
            RentBooking rb = _db.RentBooking.Find(id);
            Vozilo v = _db.Vozilo.Where(x => x.VoziloID == rb.VoziloID).SingleOrDefault();
            v.isIznajmljeno = false;
            rb.isZavrseno = true;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Route("/Iznajmljivanje/Rentacar/PrikazPoKlijentu/{id}")]
        public IActionResult PrikazPoKlijentu(int id)
        {
            RentacarIndexVM model = new RentacarIndexVM();

            model.rows = _db.RentBooking
                .Where(x=>x.KlijentID == id)
                .Select(x => new RentacarIndexVM.Row
                {
                    cijena = string.Format("{0:#.00}", x.UkupnaCijena),
                    datumIsteka = x.DatumIsteka,
                    datumRentanja = x.DatumRentanja,
                    klijent = x.Klijent.Ime + " " + x.Klijent.Prezime,
                    rentId = x.RentBookingID,
                    vozilo = x.Vozilo.Proizvodjac.Naziv + " " + x.Vozilo.Model,
                    zaposlenik = x.Zaposlenik.Ime + " " + x.Zaposlenik.Prezime,
                    isZavrseno = x.isZavrseno
                }).ToList();

            return PartialView(model);
        }


        private void GenerisiCmb(RentacarDodajVM model)
        {
            model.klijenti = _db.Klijent.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = x.Ime + " " + x.Prezime,
                Value = x.KlijentID.ToString()
            }).ToList();

            model.vozila = _db.Vozilo
                .Where(d => d.isIznajmljeno == false)
                .Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = x.Proizvodjac.Naziv + " " + x.Model,
                Value = x.VoziloID.ToString()
            }).ToList();

            model.zaposlenici = _db.Zaposlenik.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = x.Ime + " " + x.Prezime,
                Value = x.ZaposlenikID.ToString()
            }).ToList();

            model.popusti = _db.Popust.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = x.Naziv,
                Value = x.PopustID.ToString()
            }).ToList();
        }

        public IActionResult Snimi(RentacarDodajVM input)
        {
            if (!ModelState.IsValid)
            {
                GenerisiCmb(input);
                return View("Dodaj", input);
            }

            RentBooking rb = _db.RentBooking.Find(input.RentBookingID);

                rb = new RentBooking();
                rb.isZavrseno = false;
                _db.RentBooking.Add(rb);

                Faktura faktura = new Faktura()
                {
                    Datum = DateTime.Now,
                    StatusFakture = _db.StatusFakture.Where(x => x.StatusFaktureID == 1).SingleOrDefault(),
                    StatusFaktureID = 1,
                    ZaposlenikID = input.ZaposlenikID,
                    Zaposlenik = _db.Zaposlenik.Where(x => x.ZaposlenikID == input.ZaposlenikID).SingleOrDefault(),
                    PopustID = input.PopustID,
                    Popust = _db.Popust.Where(x => x.PopustID == input.PopustID).SingleOrDefault()
                };
                _db.Faktura.Add(faktura);
                _db.SaveChanges();
                rb.Faktura = faktura;
                rb.FakturaID = faktura.FakturaID;


                rb.ZaposlenikID = input.ZaposlenikID;
                rb.Zaposlenik = _db.Zaposlenik.Where(x => x.ZaposlenikID == input.ZaposlenikID).SingleOrDefault();
                rb.VoziloID = input.VoziloID;
                rb.Vozilo = _db.Vozilo.Where(x => x.VoziloID == input.VoziloID).SingleOrDefault();
                rb.Vozilo.isIznajmljeno = true;
                rb.KlijentID = input.KlijentID;
                rb.Klijent = _db.Klijent.Where(x => x.KlijentID == input.KlijentID).SingleOrDefault();
                rb.DatumRentanja = DateTime.Now;
                rb.DatumIsteka = input.DatumIsteka;

                double faktorVozila = rb.Vozilo.Cijena / 4000;

                rb.CijenaPoSatu = 0.5 * faktorVozila;
                if (input.PopustID != null)
                {
                    rb.CijenaPoSatu = rb.CijenaPoSatu * ((100 - rb.Faktura.Popust.Procenat) / 100);
                }

                if (!rb.isZavrseno)
                    rb.Vozilo.isIznajmljeno = true;

                _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Uredi(int id)
        {
            RentBooking input = _db.RentBooking.Where(x=>x.RentBookingID == id)
                .Include("Klijent")
                .Include("Faktura")
                .Include("Faktura.Popust")
                .Include("Vozilo")
                .Include("Vozilo.Proizvodjac")
                .SingleOrDefault();

            RentacarUrediVM model = new RentacarUrediVM()
            {
                RentBookingID = input.RentBookingID,
                DatumIsteka = input.DatumIsteka,
                klijent = input.Klijent.Ime + " " + input.Klijent.Prezime,
                vozilo = input.Vozilo.Proizvodjac.Naziv + " " + input.Vozilo.Model,
                isZavrsen = input.isZavrseno
        };
            if (input.Faktura.PopustID != null)
                model.popust = input.Faktura.Popust.Naziv;
         
            return View("Uredi", model);
        }

        public IActionResult UrediSnimi(RentacarUrediVM input)
        {
            if (!ModelState.IsValid)
            {
                return View("Uredi", input);
            }
            RentBooking rb = _db.RentBooking.Find(input.RentBookingID);

            rb.DatumIsteka = input.DatumIsteka;
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}