﻿// <auto-generated />
using AutoSalon.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace AutoSalon.Data.Migrations
{
    [DbContext(typeof(MojContext))]
    [Migration("20171225010438_ServerStart")]
    partial class ServerStart
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AutoSalon.Data.Models.Dostava", b =>
                {
                    b.Property<int>("DostavaID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("BrzaDostava");

                    b.Property<double>("Cijena");

                    b.Property<DateTime>("Datum");

                    b.Property<int?>("DostavljackaFirmaID");

                    b.Property<int>("FakturaID");

                    b.Property<DateTime>("KrajnjiRok");

                    b.HasKey("DostavaID");

                    b.HasIndex("DostavljackaFirmaID");

                    b.HasIndex("FakturaID")
                        .IsUnique();

                    b.ToTable("Dostava");
                });

            modelBuilder.Entity("AutoSalon.Data.Models.DostavljackaFirma", b =>
                {
                    b.Property<int>("DostavljackaFirmaID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresa");

                    b.Property<string>("Email");

                    b.Property<string>("Faks");

                    b.Property<int?>("GradID");

                    b.Property<string>("IDBroj");

                    b.Property<string>("Naziv");

                    b.Property<string>("PDVBroj");

                    b.Property<string>("PostanskiBroj");

                    b.Property<string>("Telefon");

                    b.HasKey("DostavljackaFirmaID");

                    b.HasIndex("GradID");

                    b.ToTable("DostavljackaFirma");
                });

            modelBuilder.Entity("AutoSalon.Data.Models.Drzava", b =>
                {
                    b.Property<int>("DrzavaID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ISO_3166_1");

                    b.Property<string>("Naziv");

                    b.HasKey("DrzavaID");

                    b.ToTable("Drzava");
                });

            modelBuilder.Entity("AutoSalon.Data.Models.Faktura", b =>
                {
                    b.Property<int>("FakturaID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Datum");

                    b.Property<int?>("PopustID");

                    b.Property<int?>("StatusFaktureID");

                    b.Property<int?>("ZaposlenikID");

                    b.HasKey("FakturaID");

                    b.HasIndex("PopustID");

                    b.HasIndex("StatusFaktureID");

                    b.HasIndex("ZaposlenikID");

                    b.ToTable("Faktura");
                });

            modelBuilder.Entity("AutoSalon.Data.Models.Grad", b =>
                {
                    b.Property<int>("GradID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DrzavaID");

                    b.Property<string>("Naziv");

                    b.HasKey("GradID");

                    b.HasIndex("DrzavaID");

                    b.ToTable("Grad");
                });

            modelBuilder.Entity("AutoSalon.Data.Models.IsplataPlate", b =>
                {
                    b.Property<int>("IsplataPlateId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Bonus");

                    b.Property<int>("Iznos");

                    b.Property<string>("Napomena");

                    b.Property<int?>("PeriodGodina");

                    b.Property<int?>("PeriodID");

                    b.Property<int?>("PeriodMjesec");

                    b.Property<int?>("ZaposlenikId");

                    b.HasKey("IsplataPlateId");

                    b.HasIndex("ZaposlenikId");

                    b.HasIndex("PeriodMjesec", "PeriodGodina");

                    b.ToTable("IsplataPlate");
                });

            modelBuilder.Entity("AutoSalon.Data.Models.Izvjestaj", b =>
                {
                    b.Property<int>("IzvjestajID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Datum");

                    b.Property<string>("Napomena");

                    b.Property<string>("Naziv");

                    b.Property<string>("Sadrzaj");

                    b.Property<int?>("ZaposlenikId");

                    b.HasKey("IzvjestajID");

                    b.HasIndex("ZaposlenikId");

                    b.ToTable("Izvjestaj");
                });

            modelBuilder.Entity("AutoSalon.Data.Models.Klijent", b =>
                {
                    b.Property<int>("KlijentID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresa");

                    b.Property<DateTime>("DatumRodjenja");

                    b.Property<string>("Email");

                    b.Property<int?>("GradID");

                    b.Property<string>("Ime");

                    b.Property<string>("JMBG");

                    b.Property<string>("PostanskiBroj");

                    b.Property<string>("Prezime");

                    b.Property<string>("Spol");

                    b.Property<string>("Telefon");

                    b.HasKey("KlijentID");

                    b.HasIndex("GradID");

                    b.ToTable("Klijent");
                });

            modelBuilder.Entity("AutoSalon.Data.Models.Motor", b =>
                {
                    b.Property<int>("MotorID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BrojCilindara");

                    b.Property<string>("Model");

                    b.Property<string>("Proizvodnja");

                    b.Property<int>("Snaga");

                    b.Property<string>("VrstaMotora");

                    b.Property<int>("ZapreminaMotora");

                    b.HasKey("MotorID");

                    b.ToTable("Motor");
                });

            modelBuilder.Entity("AutoSalon.Data.Models.NacinPlacanja", b =>
                {
                    b.Property<int>("NacinPlacanjaID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.Property<string>("Opis");

                    b.HasKey("NacinPlacanjaID");

                    b.ToTable("NacinPlacanja");
                });

            modelBuilder.Entity("AutoSalon.Data.Models.Narudzba", b =>
                {
                    b.Property<int>("NarudzbaID")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Cijena");

                    b.Property<DateTime>("Datum");

                    b.Property<int?>("FakturaID");

                    b.Property<int?>("KlijentID");

                    b.Property<int?>("StatusNarudzbeID");

                    b.HasKey("NarudzbaID");

                    b.HasIndex("FakturaID")
                        .IsUnique()
                        .HasFilter("[FakturaID] IS NOT NULL");

                    b.HasIndex("KlijentID");

                    b.HasIndex("StatusNarudzbeID");

                    b.ToTable("Narudzba");
                });

            modelBuilder.Entity("AutoSalon.Data.Models.OsiguravajucaFirma", b =>
                {
                    b.Property<int>("OsiguravajucaFirmaID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresa");

                    b.Property<string>("Email");

                    b.Property<string>("Faks");

                    b.Property<int?>("GradID");

                    b.Property<string>("IDBroj");

                    b.Property<string>("Naziv");

                    b.Property<string>("PDVBroj");

                    b.Property<string>("PostanskiBroj");

                    b.Property<string>("Telefon");

                    b.HasKey("OsiguravajucaFirmaID");

                    b.HasIndex("GradID");

                    b.ToTable("OsiguravajucaFirma");
                });

            modelBuilder.Entity("AutoSalon.Data.Models.Period", b =>
                {
                    b.Property<int>("Mjesec");

                    b.Property<int>("Godina");

                    b.HasKey("Mjesec", "Godina");

                    b.ToTable("Mjesec");
                });

            modelBuilder.Entity("AutoSalon.Data.Models.PolicaOsiguranja", b =>
                {
                    b.Property<int>("PolicaOsiguranjaID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BrojPolice");

                    b.Property<DateTime>("KrajUgovora");

                    b.Property<int?>("OsiguravajucaFirmaID");

                    b.Property<DateTime>("PocetakUgovora");

                    b.Property<int?>("VoziloID");

                    b.HasKey("PolicaOsiguranjaID");

                    b.HasIndex("OsiguravajucaFirmaID");

                    b.HasIndex("VoziloID");

                    b.ToTable("PolicaOsiguranja");
                });

            modelBuilder.Entity("AutoSalon.Data.Models.Popust", b =>
                {
                    b.Property<int>("PopustID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.Property<string>("Opis");

                    b.Property<double>("Procenat");

                    b.HasKey("PopustID");

                    b.ToTable("Popust");
                });

            modelBuilder.Entity("AutoSalon.Data.Models.Proizvodjac", b =>
                {
                    b.Property<int>("ProizvodjacID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.Property<int?>("SjedisteID");

                    b.HasKey("ProizvodjacID");

                    b.HasIndex("SjedisteID");

                    b.ToTable("Proizvodjac");
                });

            modelBuilder.Entity("AutoSalon.Data.Models.Rating", b =>
                {
                    b.Property<int>("RatingID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Datum");

                    b.Property<int?>("KlijentID");

                    b.Property<string>("Komentar");

                    b.Property<double>("Ocjena");

                    b.Property<int?>("VoziloID");

                    b.HasKey("RatingID");

                    b.HasIndex("KlijentID");

                    b.HasIndex("VoziloID");

                    b.ToTable("Rating");
                });

            modelBuilder.Entity("AutoSalon.Data.Models.RentBooking", b =>
                {
                    b.Property<int>("RentBookingID")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("CijenaPoSatu");

                    b.Property<DateTime>("DatumIsteka");

                    b.Property<DateTime>("DatumRentanja");

                    b.Property<int?>("FakturaID");

                    b.Property<int?>("KlijentID");

                    b.Property<int?>("VoziloID");

                    b.Property<int?>("ZaposlenikID");

                    b.HasKey("RentBookingID");

                    b.HasIndex("FakturaID");

                    b.HasIndex("KlijentID");

                    b.HasIndex("VoziloID");

                    b.HasIndex("ZaposlenikID");

                    b.ToTable("RentBooking");
                });

            modelBuilder.Entity("AutoSalon.Data.Models.StatusFakture", b =>
                {
                    b.Property<int>("StatusFaktureID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.Property<string>("Opis");

                    b.HasKey("StatusFaktureID");

                    b.ToTable("StatusFakture");
                });

            modelBuilder.Entity("AutoSalon.Data.Models.StatusNarudzbe", b =>
                {
                    b.Property<int>("StatusNarudzbeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.Property<string>("Opis");

                    b.HasKey("StatusNarudzbeID");

                    b.ToTable("StatusNarudzbe");
                });

            modelBuilder.Entity("AutoSalon.Data.Models.StavkaNarudzbe", b =>
                {
                    b.Property<int?>("VoziloID");

                    b.Property<int?>("NarudzbaID");

                    b.Property<double>("CijenaPoKomadu");

                    b.Property<int>("Kolicina");

                    b.HasKey("VoziloID", "NarudzbaID");

                    b.HasIndex("NarudzbaID");

                    b.ToTable("StavkaNarudzbe");
                });

            modelBuilder.Entity("AutoSalon.Data.Models.Uplata", b =>
                {
                    b.Property<int>("UplataID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Datum");

                    b.Property<int?>("FakturaID");

                    b.Property<double>("Iznos");

                    b.Property<int?>("KlijentID");

                    b.Property<int?>("NacinPlacanjaID");

                    b.HasKey("UplataID");

                    b.HasIndex("FakturaID");

                    b.HasIndex("KlijentID");

                    b.HasIndex("NacinPlacanjaID");

                    b.ToTable("Uplata");
                });

            modelBuilder.Entity("AutoSalon.Data.Models.Vozilo", b =>
                {
                    b.Property<int>("VoziloID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Boja");

                    b.Property<int>("BrojVrata");

                    b.Property<double>("Cijena");

                    b.Property<int>("Garancija");

                    b.Property<int>("Godinaproizvodnje");

                    b.Property<string>("Mjenjac");

                    b.Property<string>("Model");

                    b.Property<int?>("MotorID");

                    b.Property<string>("Oprema");

                    b.Property<string>("Pogon");

                    b.Property<int?>("ProizvodjacID");

                    b.Property<string>("TipVozila");

                    b.HasKey("VoziloID");

                    b.HasIndex("MotorID");

                    b.HasIndex("ProizvodjacID");

                    b.ToTable("Vozilo");
                });

            modelBuilder.Entity("AutoSalon.Data.Models.Zaposlenik", b =>
                {
                    b.Property<int>("ZaposlenikID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DatumRodjenja");

                    b.Property<string>("Email");

                    b.Property<string>("Ime");

                    b.Property<bool>("IsAdmin");

                    b.Property<bool>("IsMenadzer");

                    b.Property<bool>("IsProdavac");

                    b.Property<bool>("IsRent");

                    b.Property<string>("JMBG");

                    b.Property<string>("KorisnickoIme");

                    b.Property<string>("Lozinka");

                    b.Property<int?>("PrebivalisteID");

                    b.Property<string>("Prezime");

                    b.Property<string>("Spol");

                    b.Property<int>("Staz");

                    b.Property<string>("Telefon");

                    b.Property<string>("TipUgovora");

                    b.HasKey("ZaposlenikID");

                    b.HasIndex("PrebivalisteID");

                    b.ToTable("Zaposlenik");
                });

            modelBuilder.Entity("AutoSalon.Data.Models.Dostava", b =>
                {
                    b.HasOne("AutoSalon.Data.Models.DostavljackaFirma", "DostavljackaFirma")
                        .WithMany()
                        .HasForeignKey("DostavljackaFirmaID");

                    b.HasOne("AutoSalon.Data.Models.Faktura", "Faktura")
                        .WithOne("Dostava")
                        .HasForeignKey("AutoSalon.Data.Models.Dostava", "FakturaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AutoSalon.Data.Models.DostavljackaFirma", b =>
                {
                    b.HasOne("AutoSalon.Data.Models.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("GradID");
                });

            modelBuilder.Entity("AutoSalon.Data.Models.Faktura", b =>
                {
                    b.HasOne("AutoSalon.Data.Models.Popust", "Popust")
                        .WithMany()
                        .HasForeignKey("PopustID");

                    b.HasOne("AutoSalon.Data.Models.StatusFakture", "StatusFakture")
                        .WithMany()
                        .HasForeignKey("StatusFaktureID");

                    b.HasOne("AutoSalon.Data.Models.Zaposlenik", "Zaposlenik")
                        .WithMany()
                        .HasForeignKey("ZaposlenikID");
                });

            modelBuilder.Entity("AutoSalon.Data.Models.Grad", b =>
                {
                    b.HasOne("AutoSalon.Data.Models.Drzava", "Drzava")
                        .WithMany()
                        .HasForeignKey("DrzavaID");
                });

            modelBuilder.Entity("AutoSalon.Data.Models.IsplataPlate", b =>
                {
                    b.HasOne("AutoSalon.Data.Models.Zaposlenik", "Zaposlenik")
                        .WithMany()
                        .HasForeignKey("ZaposlenikId");

                    b.HasOne("AutoSalon.Data.Models.Period", "Period")
                        .WithMany()
                        .HasForeignKey("PeriodMjesec", "PeriodGodina");
                });

            modelBuilder.Entity("AutoSalon.Data.Models.Izvjestaj", b =>
                {
                    b.HasOne("AutoSalon.Data.Models.Zaposlenik", "Zaposlenik")
                        .WithMany()
                        .HasForeignKey("ZaposlenikId");
                });

            modelBuilder.Entity("AutoSalon.Data.Models.Klijent", b =>
                {
                    b.HasOne("AutoSalon.Data.Models.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("GradID");
                });

            modelBuilder.Entity("AutoSalon.Data.Models.Narudzba", b =>
                {
                    b.HasOne("AutoSalon.Data.Models.Faktura", "Faktura")
                        .WithOne("Narudzba")
                        .HasForeignKey("AutoSalon.Data.Models.Narudzba", "FakturaID");

                    b.HasOne("AutoSalon.Data.Models.Klijent", "Klijent")
                        .WithMany()
                        .HasForeignKey("KlijentID");

                    b.HasOne("AutoSalon.Data.Models.StatusNarudzbe", "StatusNarudzbe")
                        .WithMany()
                        .HasForeignKey("StatusNarudzbeID");
                });

            modelBuilder.Entity("AutoSalon.Data.Models.OsiguravajucaFirma", b =>
                {
                    b.HasOne("AutoSalon.Data.Models.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("GradID");
                });

            modelBuilder.Entity("AutoSalon.Data.Models.PolicaOsiguranja", b =>
                {
                    b.HasOne("AutoSalon.Data.Models.OsiguravajucaFirma", "OsiguravajucaFirma")
                        .WithMany()
                        .HasForeignKey("OsiguravajucaFirmaID");

                    b.HasOne("AutoSalon.Data.Models.Vozilo", "Vozilo")
                        .WithMany()
                        .HasForeignKey("VoziloID");
                });

            modelBuilder.Entity("AutoSalon.Data.Models.Proizvodjac", b =>
                {
                    b.HasOne("AutoSalon.Data.Models.Grad", "Sjediste")
                        .WithMany()
                        .HasForeignKey("SjedisteID");
                });

            modelBuilder.Entity("AutoSalon.Data.Models.Rating", b =>
                {
                    b.HasOne("AutoSalon.Data.Models.Klijent", "Klijent")
                        .WithMany()
                        .HasForeignKey("KlijentID");

                    b.HasOne("AutoSalon.Data.Models.Vozilo", "Vozilo")
                        .WithMany()
                        .HasForeignKey("VoziloID");
                });

            modelBuilder.Entity("AutoSalon.Data.Models.RentBooking", b =>
                {
                    b.HasOne("AutoSalon.Data.Models.Faktura", "Faktura")
                        .WithMany()
                        .HasForeignKey("FakturaID");

                    b.HasOne("AutoSalon.Data.Models.Klijent", "Klijent")
                        .WithMany()
                        .HasForeignKey("KlijentID");

                    b.HasOne("AutoSalon.Data.Models.Vozilo", "Vozilo")
                        .WithMany()
                        .HasForeignKey("VoziloID");

                    b.HasOne("AutoSalon.Data.Models.Zaposlenik", "Zaposlenik")
                        .WithMany()
                        .HasForeignKey("ZaposlenikID");
                });

            modelBuilder.Entity("AutoSalon.Data.Models.StavkaNarudzbe", b =>
                {
                    b.HasOne("AutoSalon.Data.Models.Narudzba", "Narudzba")
                        .WithMany()
                        .HasForeignKey("NarudzbaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AutoSalon.Data.Models.Vozilo", "Vozilo")
                        .WithMany()
                        .HasForeignKey("VoziloID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AutoSalon.Data.Models.Uplata", b =>
                {
                    b.HasOne("AutoSalon.Data.Models.Faktura", "Faktura")
                        .WithMany()
                        .HasForeignKey("FakturaID");

                    b.HasOne("AutoSalon.Data.Models.Klijent", "Klijent")
                        .WithMany()
                        .HasForeignKey("KlijentID");

                    b.HasOne("AutoSalon.Data.Models.NacinPlacanja", "NacinPlacanja")
                        .WithMany()
                        .HasForeignKey("NacinPlacanjaID");
                });

            modelBuilder.Entity("AutoSalon.Data.Models.Vozilo", b =>
                {
                    b.HasOne("AutoSalon.Data.Models.Motor", "Motor")
                        .WithMany()
                        .HasForeignKey("MotorID");

                    b.HasOne("AutoSalon.Data.Models.Proizvodjac", "Proizvodjac")
                        .WithMany()
                        .HasForeignKey("ProizvodjacID");
                });

            modelBuilder.Entity("AutoSalon.Data.Models.Zaposlenik", b =>
                {
                    b.HasOne("AutoSalon.Data.Models.Grad", "Prebivaliste")
                        .WithMany()
                        .HasForeignKey("PrebivalisteID");
                });
#pragma warning restore 612, 618
        }
    }
}
