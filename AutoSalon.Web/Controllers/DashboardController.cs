using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoSalon.Data.EF;
using AutoSalon.Data.Models;
using AutoSalon.Web.Helper;
using AutoSalon.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AutoSalon.Web.Controllers
{
    [Autorizacija(rent: true, prodaja: true, admin: true, manager: true)]
    public class DashboardController : Controller
    {
        private MojContext _db;

        public DashboardController(MojContext db)
        {
            _db = db;
        }

        [Route("/Dashboard/Index/")]
        public IActionResult Index()
        {
            AutentifikacijaVM korisnik = HttpContext.GetLogiraniKorisnik();

            DashboardVM model = new DashboardVM()
            {
                BrojKlijenata = _db.Klijent.Count(),
                BrojIzvjestaja = _db.Izvjestaj.Count(),
                BrojOsiguranja = _db.PolicaOsiguranja.Count(),
                BrojRentacar = _db.RentBooking.Count(),
                BrojVozila = _db.Vozilo.Count(),
                BrojNarudzbi = _db.Narudzba.Count(),
                BrojFaktura = _db.Faktura.Count(),
                BrojUplata = _db.Uplata.Count()
            };

            if (korisnik.IsAdmin)
            {
                return View("AdminDashboard", model);
            }
            else if (korisnik.IsMenadzer)
            {
                return View("ManagerDashboard", model);
            }
            else if (korisnik.IsProdavac)
            {
                return View("ProdajaDashboard", model);
            }
            else
            {
                return View("RentDashboard", model);
            }
        }
    }
}