using AutoSalon.Data.EF;
using AutoSalon.Data.Models;
using AutoSalon.Web.Areas.Prodaja.ViewModels;
using AutoSalon.Web.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace AutoSalon.Web.Areas.Prodaja.Controllers
{
    [Autorizacija(rent: false, prodaja: true, admin: false, manager: false)]
    [Area("Prodaja")]
    public class VozilaController : Controller
    {
        private MojContext _context;
        public VozilaController(MojContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            VozilaIndexVM model = new VozilaIndexVM
            {
                Redovi = _context.Vozilo.Select(s => new VozilaIndexVM.Red
                {
                    VoziloId=s.VoziloID,
                    Proizvodjac=s.Proizvodjac.Naziv,
                    Model=s.Model,
                    GodinaProizvodnje=s.Godinaproizvodnje,
                    Cijena=s.Cijena,
                    Motor=s.Motor.Model
                }).ToList()
            };
            return View(model);
        }

        private void GenerisiCmb(VozilaDodajVM model)
        {
            model.Motori = _context.Motor.Select(s => new SelectListItem
            {
                Value = s.MotorID.ToString(),
                Text = s.Model+" "+s.Snaga+ " KS"
            }).ToList();

            model.Proizvodjaci = _context.Proizvodjac.Select(s => new SelectListItem
            {
                Value = s.ProizvodjacID.ToString(),
                Text = s.Naziv
            }).ToList();
        }

        public IActionResult Dodaj()
        {
            VozilaDodajVM model = new VozilaDodajVM
            {
                GodinaProizvodnje = DateTime.Now.Year,
                BrojVrata = 2,
                Garancija=5
            };

            GenerisiCmb(model);

            return View(model);        
        }

        public IActionResult Snimi(VozilaDodajVM input)
        {
            Vozilo vUredi = _context.Vozilo.Find(input.VoziloId);

            if (vUredi != null)
            {
                if (!ModelState.IsValid)
                {
                    GenerisiCmb(input);
                    return View("Detalji", input);
                }

                vUredi.Boja = input.Boja;
                vUredi.BrojVrata = input.BrojVrata;
                vUredi.Cijena = input.Cijena;
                vUredi.Garancija = input.Garancija;
                vUredi.Godinaproizvodnje = input.GodinaProizvodnje;
                vUredi.Mjenjac = input.Mjenjac;
                vUredi.Model = input.Model;
                vUredi.MotorID = input.MotorId;
                vUredi.Oprema = input.Oprema;
                vUredi.Pogon = input.Pogon;
                vUredi.ProizvodjacID = input.ProizvodjacId;
                vUredi.TipVozila = input.TipVozila;

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            if (!ModelState.IsValid)
            {
                GenerisiCmb(input);
                return View("Dodaj", input);
            }

            Vozilo vNovo = new Vozilo
            {
                Boja = input.Boja,
                BrojVrata = input.BrojVrata,
                Cijena = input.Cijena,
                Garancija = input.Garancija,
                Godinaproizvodnje = input.GodinaProizvodnje,
                Mjenjac = input.Mjenjac,
                Model = input.Model,
                MotorID = input.MotorId,
                Oprema = input.Oprema,
                Pogon = input.Pogon,
                ProizvodjacID = input.ProizvodjacId,
                TipVozila = input.TipVozila
            };

            _context.Vozilo.Add(vNovo);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Detalji(int id)
        {
            Vozilo vUredi = _context.Vozilo.Where(w => w.VoziloID == id).Include(i => i.Proizvodjac).Include(t => t.Motor).SingleOrDefault();

            VozilaDodajVM model = new VozilaDodajVM
            {
                Boja = vUredi.Boja,
                BrojVrata = vUredi.BrojVrata,
                Cijena = vUredi.Cijena,
                Garancija = vUredi.Garancija,
                GodinaProizvodnje = vUredi.Godinaproizvodnje,
                Mjenjac = vUredi.Mjenjac,
                Model = vUredi.Model,
                Motor = vUredi.Motor.Model + " " + vUredi.Motor.Snaga + " KS",
                Oprema = vUredi.Oprema,
                Pogon = vUredi.Pogon,
                Proizvodjac = vUredi.Proizvodjac.Naziv,
                TipVozila = vUredi.TipVozila,
                VoziloId=vUredi.VoziloID,
                ProizvodjacId=vUredi.ProizvodjacID,
                MotorId=vUredi.MotorID
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