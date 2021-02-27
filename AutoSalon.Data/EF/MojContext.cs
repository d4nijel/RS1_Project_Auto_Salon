using AutoSalon.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace AutoSalon.Data.EF
{
    public class MojContext:DbContext
    {
        public MojContext(DbContextOptions<MojContext> options)
            : base(options)
        {
        }

        public DbSet<Dostava> Dostava { get; set; }
        public DbSet<DostavljackaFirma> DostavljackaFirma { get; set; }
        public DbSet<Drzava> Drzava { get; set; }
        public DbSet<Faktura> Faktura { get; set; }
        public DbSet<Grad> Grad { get; set; }
        public DbSet<IsplataPlate> IsplataPlate { get; set; }
        public DbSet<Izvjestaj> Izvjestaj { get; set; }
        public DbSet<Klijent> Klijent { get; set; }
        public DbSet<Period> Mjesec { get; set; }
        public DbSet<Motor> Motor { get; set; }
        public DbSet<NacinPlacanja> NacinPlacanja { get; set; }
        public DbSet<Narudzba> Narudzba { get; set; }
        public DbSet<OsiguravajucaFirma> OsiguravajucaFirma { get; set; }
        public DbSet<PolicaOsiguranja> PolicaOsiguranja { get; set; }
        public DbSet<Popust> Popust { get; set; }
        public DbSet<Proizvodjac> Proizvodjac { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<RentBooking> RentBooking { get; set; }
        public DbSet<StatusFakture> StatusFakture { get; set; }
        public DbSet<StatusNarudzbe> StatusNarudzbe { get; set; }
        public DbSet<StavkaNarudzbe> StavkaNarudzbe { get; set; }
        public DbSet<Uplata> Uplata { get; set; }
        public DbSet<Vozilo> Vozilo { get; set; }
        public DbSet<Zaposlenik> Zaposlenik { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StavkaNarudzbe>()
                .HasKey(c => new { c.VoziloID, c.NarudzbaID });

            modelBuilder.Entity<Period>()
                .HasKey(p => new { p.Mjesec, p.Godina });
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=DESKTOP-PH1ABGU;Database=AutosalonTest2;Trusted_Connection=True;");
        //}
    }
}
