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
    public class NarudzbeStavkeController : Controller
    {
        private MojContext _context;
        public NarudzbeStavkeController(MojContext context)
        {
            _context = context;
        }
        public IActionResult Index(int id)
        {
            Narudzba n = _context.Narudzba.Find(id);

            NarudzbeStavkeIndexVM model = new NarudzbeStavkeIndexVM
            {
                NarudzbaId = n.NarudzbaID,
                StatusNarudzbeId = n.StatusNarudzbeID,
                Redovi = _context.StavkaNarudzbe.Where(w => w.NarudzbaID == n.NarudzbaID).Select(s => new NarudzbeStavkeIndexVM.Red
                {
                    VoziloId = s.VoziloID,
                    ModelVozila = s.Vozilo.Proizvodjac.Naziv + " / " + s.Vozilo.Model + " / " + s.Vozilo.Godinaproizvodnje,
                    Cijena = s.CijenaPoKomadu,
                    Kolicina = s.Kolicina,
                    UkupnaCijena = s.Kolicina * s.CijenaPoKomadu,
                    UkupnaCijenaSaPDV = s.Kolicina * s.CijenaPoKomadu * 1.17
                }).ToList()
            };
            return PartialView(model);
        }

        private void GenerisiCmb(NarudzbeStavkeDodajVM model, int id)
        {
            var listaNarucenihVozila = _context.StavkaNarudzbe.Where(w => w.NarudzbaID == id).Select(s => s.Vozilo).ToList();
            var listaVozila = _context.Vozilo.ToList();
            var result = listaVozila.Except(listaNarucenihVozila);

            model.NarudzbaId = id;
            model.Vozila = result.Select(s => new SelectListItem
            {
                Value = s.VoziloID.ToString(),
                Text = s.Model + " / " + s.Godinaproizvodnje + " / Cijena (KM): " + s.Cijena
            }).ToList();
        }

        public IActionResult Dodaj(int id)
        {
            Narudzba n = _context.Narudzba.Find(id);

            NarudzbeStavkeDodajVM model = new NarudzbeStavkeDodajVM();
            GenerisiCmb(model, n.NarudzbaID);

            return PartialView(model);
        }

        public IActionResult Snimi(NarudzbeStavkeDodajVM input)
        {
            if (!ModelState.IsValid || input.VoziloId == 0) //ako nije odabrano vozilo jer ih nema više na stanju
            {
                GenerisiCmb(input, input.NarudzbaId);

                if (input.VoziloId == 0)
                {
                    input.Vozila.Add(new SelectListItem { Value = "0", Text = "Nije pronađen nijedan zapis" });
                }

                return View("Dodaj", input);
            }

            StavkaNarudzbe sn = new StavkaNarudzbe
            {
                VoziloID = input.VoziloId,
                NarudzbaID = input.NarudzbaId,
                CijenaPoKomadu = _context.Vozilo.Where(w => w.VoziloID == input.VoziloId).Select(s => s.Cijena).SingleOrDefault(),
                Kolicina = input.Kolicina
            };

            _context.StavkaNarudzbe.Add(sn);
            _context.SaveChanges();

            Narudzba n = _context.Narudzba.Find(sn.NarudzbaID);
            var stavke = _context.StavkaNarudzbe.Where(w => w.NarudzbaID == sn.NarudzbaID).ToList();
            double cijena = 0;
            foreach (var x in stavke)
            {
                cijena += x.CijenaPoKomadu * x.Kolicina;
            }
            n.Cijena = cijena;
            _context.SaveChanges();

            return Redirect("/Prodaja/NarudzbeStavke/Index?id=" + input.NarudzbaId);
        }

        public IActionResult SnimiUredi(NarudzbeStavkeUrediVM input)
        {
            if (!ModelState.IsValid)
            {
                return View("Uredi", input);
            }

            StavkaNarudzbe snUredi = _context.StavkaNarudzbe.Where(w => w.NarudzbaID == input.NarudzbaId && w.VoziloID == input.VoziloId).SingleOrDefault();

            snUredi.CijenaPoKomadu = input.Cijena;
            snUredi.Kolicina = input.Kolicina;

            _context.SaveChanges();
            return Redirect("/Prodaja/NarudzbeStavke/Index?id=" + input.NarudzbaId);
        }

        public IActionResult Obrisi(int VoziloId, int NarudzbaId)
        {
            StavkaNarudzbe sn = _context.StavkaNarudzbe.Where(w => w.NarudzbaID == NarudzbaId && w.VoziloID == VoziloId).SingleOrDefault();

            Narudzba n = _context.Narudzba.Find(sn.NarudzbaID);

            _context.StavkaNarudzbe.Remove(sn);
            _context.SaveChanges();

            var stavke = _context.StavkaNarudzbe.Where(w => w.NarudzbaID == sn.NarudzbaID).ToList();
            double cijena = 0;
            foreach (var x in stavke)
            {
                cijena += x.CijenaPoKomadu * x.Kolicina;
            }
            n.Cijena = cijena;
            _context.SaveChanges();

            return Redirect("/Prodaja/NarudzbeStavke/Index?id=" + NarudzbaId);
        }

        public IActionResult Uredi(int VoziloId, int NarudzbaId)
        {
            StavkaNarudzbe sn = _context.StavkaNarudzbe.Where(w => w.NarudzbaID == NarudzbaId && w.VoziloID == VoziloId).Include(i => i.Vozilo).ThenInclude(t => t.Proizvodjac).SingleOrDefault();

            NarudzbeStavkeUrediVM model = new NarudzbeStavkeUrediVM
            {
                VoziloId = sn.VoziloID,
                NarudzbaId = sn.NarudzbaID,
                Vozilo = sn.Vozilo.Proizvodjac.Naziv + " / " + sn.Vozilo.Model + " / " + sn.Vozilo.Godinaproizvodnje,
                Cijena = _context.Vozilo.Where(w => w.VoziloID == sn.VoziloID).Select(s => s.Cijena).SingleOrDefault(),
                Kolicina = sn.Kolicina
            };

            return PartialView(model);
        }
    }
}