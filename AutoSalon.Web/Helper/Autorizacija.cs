using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoSalon.Data.EF;
using AutoSalon.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;


namespace AutoSalon.Web.Helper
{
    public class AutorizacijaAttribute : TypeFilterAttribute
    {
        public AutorizacijaAttribute(bool rent, bool prodaja, bool admin, bool manager)
            : base(typeof(MyAuthorizeImpl))
        {
            Arguments = new object[] { rent, prodaja, admin, manager };
        }
    }

    public class MyAuthorizeImpl : IAsyncActionFilter
    {
        public MyAuthorizeImpl(bool rent, bool prodaja, bool admin, bool manager)
        {
            _rent = rent;
            _prodaja = prodaja;
            _admin = admin;
            _manager = manager;
        }

        private readonly bool _rent;
        private readonly bool _prodaja;
        private readonly bool _admin;
        private readonly bool _manager;

        public async Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
        {
            AutentifikacijaVM k = filterContext.HttpContext.GetLogiraniKorisnik();

            if (k == null)
            {
                if (filterContext.Controller is Controller controller)
                {
                    controller.TempData["error_poruka"] = "Niste se prijavili";
                }

                filterContext.Result = new RedirectToActionResult("Index", "Autentifikacija", new { @area = "" });
                return;
            }

            //Preuzimamo DbContext preko app services
            MojContext db = filterContext.HttpContext.RequestServices.GetService<MojContext>();

            //provjeravamo da li je logirani zaposlenik Rent, Podavac, Admin ili Manager
            if (_rent && db.Zaposlenik.Any(s => s.ZaposlenikID == k.ZaposlenikId) && k.IsRent)
            {
                await next(); //ok - ima pravo pristupa
                return;
            }

            if (_prodaja && db.Zaposlenik.Any(s => s.ZaposlenikID == k.ZaposlenikId) && k.IsProdavac)
            {
                await next(); //ok - ima pravo pristupa
                return;
            }

            if (_admin && db.Zaposlenik.Any(s => s.ZaposlenikID == k.ZaposlenikId) && k.IsAdmin)
            {
                await next(); //ok - ima pravo pristupa
                return;
            }

            if (_manager && db.Zaposlenik.Any(s => s.ZaposlenikID == k.ZaposlenikId) && k.IsMenadzer)
            {
                await next(); //ok - ima pravo pristupa
                return;
            }

            if (filterContext.Controller is Controller c1)
            {
                c1.TempData["error_poruka"] = "Nemate pravo pristupa";
            }

            filterContext.Result = new RedirectToActionResult("Index", "Dashboard", new { @area = "" });
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // throw new NotImplementedException();
        }
    }
}