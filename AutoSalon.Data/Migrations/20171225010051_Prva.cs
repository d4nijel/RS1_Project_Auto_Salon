using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AutoSalon.Data.Migrations
{
    public partial class Prva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    DrzavaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ISO_3166_1 = table.Column<string>(nullable: true),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.DrzavaID);
                });

            migrationBuilder.CreateTable(
                name: "Mjesec",
                columns: table => new
                {
                    Mjesec = table.Column<int>(nullable: false),
                    Godina = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mjesec", x => new { x.Mjesec, x.Godina });
                });

            migrationBuilder.CreateTable(
                name: "Motor",
                columns: table => new
                {
                    MotorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrojCilindara = table.Column<int>(nullable: false),
                    Model = table.Column<string>(nullable: true),
                    Proizvodnja = table.Column<string>(nullable: true),
                    Snaga = table.Column<int>(nullable: false),
                    VrstaMotora = table.Column<string>(nullable: true),
                    ZapreminaMotora = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motor", x => x.MotorID);
                });

            migrationBuilder.CreateTable(
                name: "NacinPlacanja",
                columns: table => new
                {
                    NacinPlacanjaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NacinPlacanja", x => x.NacinPlacanjaID);
                });

            migrationBuilder.CreateTable(
                name: "Popust",
                columns: table => new
                {
                    PopustID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    Procenat = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Popust", x => x.PopustID);
                });

            migrationBuilder.CreateTable(
                name: "StatusFakture",
                columns: table => new
                {
                    StatusFaktureID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusFakture", x => x.StatusFaktureID);
                });

            migrationBuilder.CreateTable(
                name: "StatusNarudzbe",
                columns: table => new
                {
                    StatusNarudzbeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusNarudzbe", x => x.StatusNarudzbeID);
                });

            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    GradID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DrzavaID = table.Column<int>(nullable: true),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.GradID);
                    table.ForeignKey(
                        name: "FK_Grad_Drzava_DrzavaID",
                        column: x => x.DrzavaID,
                        principalTable: "Drzava",
                        principalColumn: "DrzavaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DostavljackaFirma",
                columns: table => new
                {
                    DostavljackaFirmaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adresa = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Faks = table.Column<string>(nullable: true),
                    GradID = table.Column<int>(nullable: true),
                    IDBroj = table.Column<string>(nullable: true),
                    Naziv = table.Column<string>(nullable: true),
                    PDVBroj = table.Column<string>(nullable: true),
                    PostanskiBroj = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DostavljackaFirma", x => x.DostavljackaFirmaID);
                    table.ForeignKey(
                        name: "FK_DostavljackaFirma_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Klijent",
                columns: table => new
                {
                    KlijentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adresa = table.Column<string>(nullable: true),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    GradID = table.Column<int>(nullable: true),
                    Ime = table.Column<string>(nullable: true),
                    JMBG = table.Column<string>(nullable: true),
                    PostanskiBroj = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Spol = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klijent", x => x.KlijentID);
                    table.ForeignKey(
                        name: "FK_Klijent_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OsiguravajucaFirma",
                columns: table => new
                {
                    OsiguravajucaFirmaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adresa = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Faks = table.Column<string>(nullable: true),
                    GradID = table.Column<int>(nullable: true),
                    IDBroj = table.Column<string>(nullable: true),
                    Naziv = table.Column<string>(nullable: true),
                    PDVBroj = table.Column<string>(nullable: true),
                    PostanskiBroj = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OsiguravajucaFirma", x => x.OsiguravajucaFirmaID);
                    table.ForeignKey(
                        name: "FK_OsiguravajucaFirma_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Proizvodjac",
                columns: table => new
                {
                    ProizvodjacID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    SjedisteID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvodjac", x => x.ProizvodjacID);
                    table.ForeignKey(
                        name: "FK_Proizvodjac_Grad_SjedisteID",
                        column: x => x.SjedisteID,
                        principalTable: "Grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zaposlenik",
                columns: table => new
                {
                    ZaposlenikID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Ime = table.Column<string>(nullable: true),
                    IsAdmin = table.Column<bool>(nullable: false),
                    IsMenadzer = table.Column<bool>(nullable: false),
                    IsProdavac = table.Column<bool>(nullable: false),
                    IsRent = table.Column<bool>(nullable: false),
                    JMBG = table.Column<string>(nullable: true),
                    KorisnickoIme = table.Column<string>(nullable: true),
                    Lozinka = table.Column<string>(nullable: true),
                    PrebivalisteID = table.Column<int>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Spol = table.Column<string>(nullable: true),
                    Staz = table.Column<int>(nullable: false),
                    Telefon = table.Column<string>(nullable: true),
                    TipUgovora = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaposlenik", x => x.ZaposlenikID);
                    table.ForeignKey(
                        name: "FK_Zaposlenik_Grad_PrebivalisteID",
                        column: x => x.PrebivalisteID,
                        principalTable: "Grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vozilo",
                columns: table => new
                {
                    VoziloID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Boja = table.Column<string>(nullable: true),
                    BrojVrata = table.Column<int>(nullable: false),
                    Cijena = table.Column<double>(nullable: false),
                    Garancija = table.Column<int>(nullable: false),
                    Godinaproizvodnje = table.Column<int>(nullable: false),
                    Mjenjac = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    MotorID = table.Column<int>(nullable: true),
                    Oprema = table.Column<string>(nullable: true),
                    Pogon = table.Column<string>(nullable: true),
                    ProizvodjacID = table.Column<int>(nullable: true),
                    TipVozila = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vozilo", x => x.VoziloID);
                    table.ForeignKey(
                        name: "FK_Vozilo_Motor_MotorID",
                        column: x => x.MotorID,
                        principalTable: "Motor",
                        principalColumn: "MotorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vozilo_Proizvodjac_ProizvodjacID",
                        column: x => x.ProizvodjacID,
                        principalTable: "Proizvodjac",
                        principalColumn: "ProizvodjacID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Faktura",
                columns: table => new
                {
                    FakturaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    PopustID = table.Column<int>(nullable: true),
                    StatusFaktureID = table.Column<int>(nullable: true),
                    ZaposlenikID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faktura", x => x.FakturaID);
                    table.ForeignKey(
                        name: "FK_Faktura_Popust_PopustID",
                        column: x => x.PopustID,
                        principalTable: "Popust",
                        principalColumn: "PopustID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Faktura_StatusFakture_StatusFaktureID",
                        column: x => x.StatusFaktureID,
                        principalTable: "StatusFakture",
                        principalColumn: "StatusFaktureID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Faktura_Zaposlenik_ZaposlenikID",
                        column: x => x.ZaposlenikID,
                        principalTable: "Zaposlenik",
                        principalColumn: "ZaposlenikID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IsplataPlate",
                columns: table => new
                {
                    IsplataPlateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bonus = table.Column<int>(nullable: false),
                    Iznos = table.Column<int>(nullable: false),
                    Napomena = table.Column<string>(nullable: true),
                    PeriodGodina = table.Column<int>(nullable: true),
                    PeriodID = table.Column<int>(nullable: true),
                    PeriodMjesec = table.Column<int>(nullable: true),
                    ZaposlenikId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IsplataPlate", x => x.IsplataPlateId);
                    table.ForeignKey(
                        name: "FK_IsplataPlate_Zaposlenik_ZaposlenikId",
                        column: x => x.ZaposlenikId,
                        principalTable: "Zaposlenik",
                        principalColumn: "ZaposlenikID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IsplataPlate_Mjesec_PeriodMjesec_PeriodGodina",
                        columns: x => new { x.PeriodMjesec, x.PeriodGodina },
                        principalTable: "Mjesec",
                        principalColumns: new[] { "Mjesec", "Godina" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Izvjestaj",
                columns: table => new
                {
                    IzvjestajID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    Napomena = table.Column<string>(nullable: true),
                    Naziv = table.Column<string>(nullable: true),
                    Sadrzaj = table.Column<string>(nullable: true),
                    ZaposlenikId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Izvjestaj", x => x.IzvjestajID);
                    table.ForeignKey(
                        name: "FK_Izvjestaj_Zaposlenik_ZaposlenikId",
                        column: x => x.ZaposlenikId,
                        principalTable: "Zaposlenik",
                        principalColumn: "ZaposlenikID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PolicaOsiguranja",
                columns: table => new
                {
                    PolicaOsiguranjaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrojPolice = table.Column<int>(nullable: false),
                    KrajUgovora = table.Column<DateTime>(nullable: false),
                    OsiguravajucaFirmaID = table.Column<int>(nullable: true),
                    PocetakUgovora = table.Column<DateTime>(nullable: false),
                    VoziloID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicaOsiguranja", x => x.PolicaOsiguranjaID);
                    table.ForeignKey(
                        name: "FK_PolicaOsiguranja_OsiguravajucaFirma_OsiguravajucaFirmaID",
                        column: x => x.OsiguravajucaFirmaID,
                        principalTable: "OsiguravajucaFirma",
                        principalColumn: "OsiguravajucaFirmaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PolicaOsiguranja_Vozilo_VoziloID",
                        column: x => x.VoziloID,
                        principalTable: "Vozilo",
                        principalColumn: "VoziloID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    RatingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    KlijentID = table.Column<int>(nullable: true),
                    Komentar = table.Column<string>(nullable: true),
                    Ocjena = table.Column<double>(nullable: false),
                    VoziloID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.RatingID);
                    table.ForeignKey(
                        name: "FK_Rating_Klijent_KlijentID",
                        column: x => x.KlijentID,
                        principalTable: "Klijent",
                        principalColumn: "KlijentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rating_Vozilo_VoziloID",
                        column: x => x.VoziloID,
                        principalTable: "Vozilo",
                        principalColumn: "VoziloID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dostava",
                columns: table => new
                {
                    DostavaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrzaDostava = table.Column<bool>(nullable: false),
                    Cijena = table.Column<double>(nullable: false),
                    Datum = table.Column<DateTime>(nullable: false),
                    DostavljackaFirmaID = table.Column<int>(nullable: true),
                    FakturaID = table.Column<int>(nullable: false),
                    KrajnjiRok = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dostava", x => x.DostavaID);
                    table.ForeignKey(
                        name: "FK_Dostava_DostavljackaFirma_DostavljackaFirmaID",
                        column: x => x.DostavljackaFirmaID,
                        principalTable: "DostavljackaFirma",
                        principalColumn: "DostavljackaFirmaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dostava_Faktura_FakturaID",
                        column: x => x.FakturaID,
                        principalTable: "Faktura",
                        principalColumn: "FakturaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Narudzba",
                columns: table => new
                {
                    NarudzbaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cijena = table.Column<double>(nullable: false),
                    Datum = table.Column<DateTime>(nullable: false),
                    FakturaID = table.Column<int>(nullable: true),
                    KlijentID = table.Column<int>(nullable: true),
                    StatusNarudzbeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzba", x => x.NarudzbaID);
                    table.ForeignKey(
                        name: "FK_Narudzba_Faktura_FakturaID",
                        column: x => x.FakturaID,
                        principalTable: "Faktura",
                        principalColumn: "FakturaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Narudzba_Klijent_KlijentID",
                        column: x => x.KlijentID,
                        principalTable: "Klijent",
                        principalColumn: "KlijentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Narudzba_StatusNarudzbe_StatusNarudzbeID",
                        column: x => x.StatusNarudzbeID,
                        principalTable: "StatusNarudzbe",
                        principalColumn: "StatusNarudzbeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RentBooking",
                columns: table => new
                {
                    RentBookingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CijenaPoSatu = table.Column<double>(nullable: false),
                    DatumIsteka = table.Column<DateTime>(nullable: false),
                    DatumRentanja = table.Column<DateTime>(nullable: false),
                    FakturaID = table.Column<int>(nullable: true),
                    KlijentID = table.Column<int>(nullable: true),
                    VoziloID = table.Column<int>(nullable: true),
                    ZaposlenikID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentBooking", x => x.RentBookingID);
                    table.ForeignKey(
                        name: "FK_RentBooking_Faktura_FakturaID",
                        column: x => x.FakturaID,
                        principalTable: "Faktura",
                        principalColumn: "FakturaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RentBooking_Klijent_KlijentID",
                        column: x => x.KlijentID,
                        principalTable: "Klijent",
                        principalColumn: "KlijentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RentBooking_Vozilo_VoziloID",
                        column: x => x.VoziloID,
                        principalTable: "Vozilo",
                        principalColumn: "VoziloID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RentBooking_Zaposlenik_ZaposlenikID",
                        column: x => x.ZaposlenikID,
                        principalTable: "Zaposlenik",
                        principalColumn: "ZaposlenikID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Uplata",
                columns: table => new
                {
                    UplataID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    FakturaID = table.Column<int>(nullable: true),
                    Iznos = table.Column<double>(nullable: false),
                    KlijentID = table.Column<int>(nullable: true),
                    NacinPlacanjaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uplata", x => x.UplataID);
                    table.ForeignKey(
                        name: "FK_Uplata_Faktura_FakturaID",
                        column: x => x.FakturaID,
                        principalTable: "Faktura",
                        principalColumn: "FakturaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Uplata_Klijent_KlijentID",
                        column: x => x.KlijentID,
                        principalTable: "Klijent",
                        principalColumn: "KlijentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Uplata_NacinPlacanja_NacinPlacanjaID",
                        column: x => x.NacinPlacanjaID,
                        principalTable: "NacinPlacanja",
                        principalColumn: "NacinPlacanjaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StavkaNarudzbe",
                columns: table => new
                {
                    VoziloID = table.Column<int>(nullable: false),
                    NarudzbaID = table.Column<int>(nullable: false),
                    CijenaPoKomadu = table.Column<double>(nullable: false),
                    Kolicina = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StavkaNarudzbe", x => new { x.VoziloID, x.NarudzbaID });
                    table.ForeignKey(
                        name: "FK_StavkaNarudzbe_Narudzba_NarudzbaID",
                        column: x => x.NarudzbaID,
                        principalTable: "Narudzba",
                        principalColumn: "NarudzbaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StavkaNarudzbe_Vozilo_VoziloID",
                        column: x => x.VoziloID,
                        principalTable: "Vozilo",
                        principalColumn: "VoziloID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dostava_DostavljackaFirmaID",
                table: "Dostava",
                column: "DostavljackaFirmaID");

            migrationBuilder.CreateIndex(
                name: "IX_Dostava_FakturaID",
                table: "Dostava",
                column: "FakturaID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DostavljackaFirma_GradID",
                table: "DostavljackaFirma",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Faktura_PopustID",
                table: "Faktura",
                column: "PopustID");

            migrationBuilder.CreateIndex(
                name: "IX_Faktura_StatusFaktureID",
                table: "Faktura",
                column: "StatusFaktureID");

            migrationBuilder.CreateIndex(
                name: "IX_Faktura_ZaposlenikID",
                table: "Faktura",
                column: "ZaposlenikID");

            migrationBuilder.CreateIndex(
                name: "IX_Grad_DrzavaID",
                table: "Grad",
                column: "DrzavaID");

            migrationBuilder.CreateIndex(
                name: "IX_IsplataPlate_ZaposlenikId",
                table: "IsplataPlate",
                column: "ZaposlenikId");

            migrationBuilder.CreateIndex(
                name: "IX_IsplataPlate_PeriodMjesec_PeriodGodina",
                table: "IsplataPlate",
                columns: new[] { "PeriodMjesec", "PeriodGodina" });

            migrationBuilder.CreateIndex(
                name: "IX_Izvjestaj_ZaposlenikId",
                table: "Izvjestaj",
                column: "ZaposlenikId");

            migrationBuilder.CreateIndex(
                name: "IX_Klijent_GradID",
                table: "Klijent",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_FakturaID",
                table: "Narudzba",
                column: "FakturaID",
                unique: true,
                filter: "[FakturaID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_KlijentID",
                table: "Narudzba",
                column: "KlijentID");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_StatusNarudzbeID",
                table: "Narudzba",
                column: "StatusNarudzbeID");

            migrationBuilder.CreateIndex(
                name: "IX_OsiguravajucaFirma_GradID",
                table: "OsiguravajucaFirma",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_PolicaOsiguranja_OsiguravajucaFirmaID",
                table: "PolicaOsiguranja",
                column: "OsiguravajucaFirmaID");

            migrationBuilder.CreateIndex(
                name: "IX_PolicaOsiguranja_VoziloID",
                table: "PolicaOsiguranja",
                column: "VoziloID");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvodjac_SjedisteID",
                table: "Proizvodjac",
                column: "SjedisteID");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_KlijentID",
                table: "Rating",
                column: "KlijentID");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_VoziloID",
                table: "Rating",
                column: "VoziloID");

            migrationBuilder.CreateIndex(
                name: "IX_RentBooking_FakturaID",
                table: "RentBooking",
                column: "FakturaID");

            migrationBuilder.CreateIndex(
                name: "IX_RentBooking_KlijentID",
                table: "RentBooking",
                column: "KlijentID");

            migrationBuilder.CreateIndex(
                name: "IX_RentBooking_VoziloID",
                table: "RentBooking",
                column: "VoziloID");

            migrationBuilder.CreateIndex(
                name: "IX_RentBooking_ZaposlenikID",
                table: "RentBooking",
                column: "ZaposlenikID");

            migrationBuilder.CreateIndex(
                name: "IX_StavkaNarudzbe_NarudzbaID",
                table: "StavkaNarudzbe",
                column: "NarudzbaID");

            migrationBuilder.CreateIndex(
                name: "IX_Uplata_FakturaID",
                table: "Uplata",
                column: "FakturaID");

            migrationBuilder.CreateIndex(
                name: "IX_Uplata_KlijentID",
                table: "Uplata",
                column: "KlijentID");

            migrationBuilder.CreateIndex(
                name: "IX_Uplata_NacinPlacanjaID",
                table: "Uplata",
                column: "NacinPlacanjaID");

            migrationBuilder.CreateIndex(
                name: "IX_Vozilo_MotorID",
                table: "Vozilo",
                column: "MotorID");

            migrationBuilder.CreateIndex(
                name: "IX_Vozilo_ProizvodjacID",
                table: "Vozilo",
                column: "ProizvodjacID");

            migrationBuilder.CreateIndex(
                name: "IX_Zaposlenik_PrebivalisteID",
                table: "Zaposlenik",
                column: "PrebivalisteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dostava");

            migrationBuilder.DropTable(
                name: "IsplataPlate");

            migrationBuilder.DropTable(
                name: "Izvjestaj");

            migrationBuilder.DropTable(
                name: "PolicaOsiguranja");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "RentBooking");

            migrationBuilder.DropTable(
                name: "StavkaNarudzbe");

            migrationBuilder.DropTable(
                name: "Uplata");

            migrationBuilder.DropTable(
                name: "DostavljackaFirma");

            migrationBuilder.DropTable(
                name: "Mjesec");

            migrationBuilder.DropTable(
                name: "OsiguravajucaFirma");

            migrationBuilder.DropTable(
                name: "Narudzba");

            migrationBuilder.DropTable(
                name: "Vozilo");

            migrationBuilder.DropTable(
                name: "NacinPlacanja");

            migrationBuilder.DropTable(
                name: "Faktura");

            migrationBuilder.DropTable(
                name: "Klijent");

            migrationBuilder.DropTable(
                name: "StatusNarudzbe");

            migrationBuilder.DropTable(
                name: "Motor");

            migrationBuilder.DropTable(
                name: "Proizvodjac");

            migrationBuilder.DropTable(
                name: "Popust");

            migrationBuilder.DropTable(
                name: "StatusFakture");

            migrationBuilder.DropTable(
                name: "Zaposlenik");

            migrationBuilder.DropTable(
                name: "Grad");

            migrationBuilder.DropTable(
                name: "Drzava");
        }
    }
}
