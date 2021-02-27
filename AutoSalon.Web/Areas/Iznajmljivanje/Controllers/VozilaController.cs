using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoSalon.Data.EF;
using AutoSalon.Data.Models;
using AutoSalon.Web.Areas.Iznajmljivanje.ViewModels;
using AutoSalon.Web.Helper;
using Microsoft.AspNetCore.Mvc;

namespace AutoSalon.Web.Areas.Iznajmljivanje.Controllers
{
    [Autorizacija(rent: true, prodaja: false, admin: false, manager: false)]
    [Area("Iznajmljivanje")]
    public class VozilaController : Controller
    {
        MojContext _db;

        public VozilaController(MojContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            VozilaIndexVM model = new VozilaIndexVM();

            model.rows = _db.Vozilo.Select(x => new VozilaIndexVM.Row
            {
                cijena = x.Cijena.ToString(),
                godiste = x.Godinaproizvodnje.ToString(),
                iznajmljen = x.isIznajmljeno,
                naziv = x.Proizvodjac.Naziv + " " + x.Model,
                tipVozila = x.TipVozila,
                voziloId = x.VoziloID
            }).ToList();

            return View(model);

        }

        [Route("/Iznajmljivanje/Vozila/Pretraga/{tekst?}")]
        public IActionResult Pretraga(string tekst)
        {
            VozilaIndexVM model = new VozilaIndexVM();

            model.rows = _db.Vozilo
                .Where(x => x.Model.Contains(tekst))
                .Select(x => new VozilaIndexVM.Row
            {
                cijena = x.Cijena.ToString(),
                godiste = x.Godinaproizvodnje.ToString(),
                iznajmljen = x.isIznajmljeno,
                naziv = x.Proizvodjac.Naziv + " " + x.Model,
                tipVozila = x.TipVozila,
                voziloId = x.VoziloID
            }).ToList();

            return View("Index", model);
        }

        public IActionResult Obrisi(int id)
        {
            Vozilo v = _db.Vozilo.Find(id);
            List<PolicaOsiguranja> police = _db.PolicaOsiguranja.Where(x => x.VoziloID == v.VoziloID).ToList();
            List<RentBooking> booking = _db.RentBooking.Where(x => x.VoziloID == v.VoziloID).ToList();
            foreach (var x in police)
            {
                _db.PolicaOsiguranja.Remove(x);
            }
            foreach(var x in booking)
            {
                List<Faktura> fakture = _db.Faktura.Where(f => f.FakturaID == x.FakturaID).ToList();
                foreach (var y in fakture)
                    _db.Faktura.Remove(y);

                _db.RentBooking.Remove(x);
            }
            _db.Vozilo.Remove(v);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Dodaj()
        {
            VozilaDodajVM model = new VozilaDodajVM();
            GenerisiCmb(model);
            model.Godinaproizvodnje = 1900;

            return View(model);
        }

        private void GenerisiCmb(VozilaDodajVM model)
        {
            model.proizvodjaci = _db.Proizvodjac.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = x.Naziv,
                Value = x.ProizvodjacID.ToString()
            }).ToList();

            model.motori = _db.Motor.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = x.Model,
                Value = x.MotorID.ToString()
            }).ToList();
        }

        public IActionResult Snimi(VozilaDodajVM input)
        {
            if (!ModelState.IsValid)
            {
                GenerisiCmb(input);
                return View("Dodaj", input);
            }

            Vozilo v = _db.Vozilo.Find(input.VoziloID);

            if (v == null)
            {
                v = new Vozilo();
                _db.Vozilo.Add(v);
                _db.SaveChanges();
            }

            v.TipVozila = input.TipVozila;
            v.ProizvodjacID = input.ProizvodjacID;
            v.Proizvodjac = _db.Proizvodjac.Where(x => x.ProizvodjacID == input.ProizvodjacID).SingleOrDefault();
            v.Pogon = input.Pogon;
            v.Oprema = input.Oprema;
            v.MotorID = input.MotorID;
            v.Motor = _db.Motor.Where(x => x.MotorID == input.MotorID).SingleOrDefault();
            v.Model = input.Model;
            v.Mjenjac = input.Mjenjac;
            v.Godinaproizvodnje = input.Godinaproizvodnje;
            v.Garancija = input.Garancija;
            v.Cijena = input.Cijena;
            v.BrojVrata = input.BrojVrata;
            v.Boja = input.Boja;

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Uredi(int id)
        {
            Vozilo input = _db.Vozilo.Find(id);

            VozilaDodajVM model = new VozilaDodajVM()
            {
                TipVozila = input.TipVozila,
                ProizvodjacID = input.ProizvodjacID,
                Pogon = input.Pogon,
                Oprema = input.Oprema,
                MotorID = input.MotorID,
                Model = input.Model,
                Mjenjac = input.Mjenjac,
                Godinaproizvodnje = input.Godinaproizvodnje,
                Garancija = input.Garancija,
                Cijena = input.Cijena,
                BrojVrata = input.BrojVrata,
                Boja = input.Boja,
                VoziloID = input.VoziloID
            };
            GenerisiCmb(model);

            return View("Dodaj", model);
        }
    }
}