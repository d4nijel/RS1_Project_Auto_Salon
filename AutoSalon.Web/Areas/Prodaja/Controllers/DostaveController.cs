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
    public class DostaveController : Controller
    {
        private MojContext _context;
        public DostaveController(MojContext context)
        {
            _context = context;
        }
        public IActionResult Index(int id)
        {
            Faktura fIndex = _context.Faktura.Where(w => w.FakturaID == id).Include(i => i.Dostava).ThenInclude(t => t.DostavljackaFirma).SingleOrDefault();

            DostaveIndexVM model = new DostaveIndexVM();

            if (fIndex.Dostava != null)
            {
                model.DostavaId = fIndex.Dostava.DostavaID;
                model.DostavljackaFirma = fIndex.Dostava.DostavljackaFirma.Naziv;
                model.DatumDostave = fIndex.Dostava.Datum;
                model.BrzaDostava = fIndex.Dostava.BrzaDostava;
                model.Cijena = fIndex.Dostava.Cijena;
                model.KrajnjiDatumDostave = fIndex.Dostava.KrajnjiRok;
                model.FakturaId = fIndex.FakturaID;
                model.StatusFaktureId = fIndex.StatusFaktureID;
            }
            else
            {
                model.DostavaId = 0;
            }
            return PartialView(model);
        }
        public IActionResult Dodaj(int id)
        {
            Faktura f = _context.Faktura.Find(id);

            DostaveDodajVM model = new DostaveDodajVM
            {
                DostavljackeFirme = _context.DostavljackaFirma.Select(s => new SelectListItem
                {
                    Value = s.DostavljackaFirmaID.ToString(),
                    Text = s.Naziv
                }).ToList(),
                DatumDostave = DateTime.UtcNow,
                BrzaDostava = false,
                Cijena = 10,
                KrajnjiDatumDostave = DateTime.Now.AddDays(30),
                FakturaId = f.FakturaID
            };
            return PartialView(model);
        }
        public IActionResult Snimi(DostaveDodajVM input)
        {
            Dostava dIzmjena = _context.Dostava.Find(input.DostavaId);

            if (dIzmjena != null)
            {
                if (!ModelState.IsValid)
                {
                    input.DostavljackeFirme = _context.DostavljackaFirma.Select(s => new SelectListItem
                    {
                        Value = s.DostavljackaFirmaID.ToString(),
                        Text = s.Naziv
                    }).ToList();

                    return View("Detalji", input);
                }

                dIzmjena.BrzaDostava = input.BrzaDostava;
                dIzmjena.Cijena = input.Cijena;
                dIzmjena.Datum = input.DatumDostave;
                dIzmjena.DostavljackaFirmaID = input.DostavljackaFirmaId;
                dIzmjena.KrajnjiRok = input.KrajnjiDatumDostave;

                _context.SaveChanges();
                return Redirect("/Prodaja/Dostave/Index?id=" + input.FakturaId);
            }

            if (!ModelState.IsValid)
            {
                input.DostavljackeFirme = _context.DostavljackaFirma.Select(s => new SelectListItem
                {
                    Value = s.DostavljackaFirmaID.ToString(),
                    Text = s.Naziv
                }).ToList();

                return View("Dodaj", input);
            }
            Dostava dNova = new Dostava
            {
                BrzaDostava = input.BrzaDostava,
                Cijena = input.Cijena,
                Datum = input.DatumDostave,
                DostavljackaFirmaID = input.DostavljackaFirmaId,
                KrajnjiRok = input.KrajnjiDatumDostave
            };

            _context.Dostava.Add(dNova);
            _context.SaveChanges();

            Faktura fDostava = _context.Faktura.Find(input.FakturaId);
            fDostava.DostavaID = dNova.DostavaID;

            _context.SaveChanges();

            return Redirect("/Prodaja/Dostave/Index?id=" + input.FakturaId);
        }

        public IActionResult Detalji(int DostavaId, int FakturaId)
        {
            Dostava dDetalji = _context.Dostava.Find(DostavaId);
            Faktura f = _context.Faktura.Find(FakturaId);

            DostaveDodajVM model = new DostaveDodajVM
            {
                DostavljackaFirmaId = dDetalji.DostavljackaFirmaID,
                DatumDostave = dDetalji.Datum,
                BrzaDostava = dDetalji.BrzaDostava,
                Cijena = dDetalji.Cijena,
                KrajnjiDatumDostave = dDetalji.KrajnjiRok,
                FakturaId = f.FakturaID,
                DostavaId = dDetalji.DostavaID
            };

            model.DostavljackeFirme = _context.DostavljackaFirma.Select(s => new SelectListItem
            {
                Value = s.DostavljackaFirmaID.ToString(),
                Text = s.Naziv
            }).ToList();

            return View(model);
        }
    }
}