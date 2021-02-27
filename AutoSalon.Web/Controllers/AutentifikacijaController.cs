using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoSalon.Data.EF;
using AutoSalon.Data.Models;
using AutoSalon.Web.Helper;
using AutoSalon.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoSalon.Web.Controllers
{
    public class AutentifikacijaController : Controller
    {
        private MojContext _db;

        public AutentifikacijaController(MojContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Prijava(AutentifikacijaVM input)
        {
            
            Zaposlenik z = _db.Zaposlenik.Where(x => x.KorisnickoIme == input.Username && x.Lozinka == input.Password).SingleOrDefault();

            if(z == null)
            {
                TempData["error_poruka"] = "Pogrešno korisničko ime ili lozinka";
                return View("Index", input);
            }

            string imePrezime = z.Ime + " " + z.Prezime;
            input.ImePrezime = imePrezime;

            input.ZaposlenikId = z.ZaposlenikID;
            input.IsAdmin = z.IsAdmin;
            input.IsMenadzer = z.IsMenadzer;
            input.IsProdavac = z.IsProdavac;
            input.IsRent = z.IsRent;

            HttpContext.SetLogiraniKorisnik(input);

            return Redirect("/Dashboard/Index");
        }

        public IActionResult Odjava()
        {
            HttpContext.SetLogiraniKorisnik(null);
            return RedirectToAction("Index");
        }
    }
}