using AutoSalon.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Web.Helper
{
    public static class Autentifikacija
    {

        private const string logiraniKorisnik = "logirani_korisnik";

        public static void SetLogiraniKorisnik(this HttpContext context, AutentifikacijaVM korisnik, bool snimiUCookie = false)
        {
            context.Session.Set(logiraniKorisnik, korisnik);
        }

        public static AutentifikacijaVM GetLogiraniKorisnik(this HttpContext context)
        {
            AutentifikacijaVM korisnik = context.Session.Get<AutentifikacijaVM>(logiraniKorisnik);

            return korisnik;
        }
    }
}
