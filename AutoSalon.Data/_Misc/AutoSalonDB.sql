USE [AutoSalon_MAIN]
GO
SET IDENTITY_INSERT [dbo].[StatusNarudzbe] ON 

INSERT [dbo].[StatusNarudzbe] ([StatusNarudzbeID], [Naziv], [Opis]) VALUES (1, N'U obradi', N'Narudžba je kreirana i definisane su stavke narudžbe')
INSERT [dbo].[StatusNarudzbe] ([StatusNarudzbeID], [Naziv], [Opis]) VALUES (2, N'Završena', N'Narudžba je kreirana i napravljena je faktura')
INSERT [dbo].[StatusNarudzbe] ([StatusNarudzbeID], [Naziv], [Opis]) VALUES (3, N'Otkazana', N'Narudžba je otkazana')
INSERT [dbo].[StatusNarudzbe] ([StatusNarudzbeID], [Naziv], [Opis]) VALUES (4, N'Pocetna', N'Narudžba je kreirana ali nisu definisane stavke narudžbe')
SET IDENTITY_INSERT [dbo].[StatusNarudzbe] OFF
SET IDENTITY_INSERT [dbo].[Drzava] ON 

INSERT [dbo].[Drzava] ([DrzavaID], [ISO_3166_1], [Naziv]) VALUES (1, N'BA', N'Bosna i Hercegovina')
SET IDENTITY_INSERT [dbo].[Drzava] OFF
SET IDENTITY_INSERT [dbo].[Grad] ON 

INSERT [dbo].[Grad] ([GradID], [DrzavaID], [Naziv]) VALUES (1, 1, N'Sarajevo')
INSERT [dbo].[Grad] ([GradID], [DrzavaID], [Naziv]) VALUES (2, 1, N'Mostar')
INSERT [dbo].[Grad] ([GradID], [DrzavaID], [Naziv]) VALUES (3, 1, N'Brcko')
SET IDENTITY_INSERT [dbo].[Grad] OFF
SET IDENTITY_INSERT [dbo].[Klijent] ON 

INSERT [dbo].[Klijent] ([KlijentID], [Adresa], [DatumRodjenja], [Email], [GradID], [Ime], [JMBG], [PostanskiBroj], [Prezime], [Spol], [Telefon]) VALUES (1, N'Aleja lipa 122', CAST(N'1989-09-04T00:00:00.0000000' AS DateTime2), N'danijel@gmail.com', 1, N'Danijel', N'0409989152233', N'71000', N'Soldo', N'M', N'062/524-123')
INSERT [dbo].[Klijent] ([KlijentID], [Adresa], [DatumRodjenja], [Email], [GradID], [Ime], [JMBG], [PostanskiBroj], [Prezime], [Spol], [Telefon]) VALUES (2, N'Ive Andrića 4', CAST(N'1995-07-05T00:00:00.0000000' AS DateTime2), N'aleksandar_h@gmail.com', 3, N'Aleksandar', N'7539518524563', N'76100', N'Herman', N'M', N'062/524-111')
INSERT [dbo].[Klijent] ([KlijentID], [Adresa], [DatumRodjenja], [Email], [GradID], [Ime], [JMBG], [PostanskiBroj], [Prezime], [Spol], [Telefon]) VALUES (3, N'Ulica 1', CAST(N'1991-05-08T00:00:00.0000000' AS DateTime2), N'vedran@gmail.com', 1, N'Vedran', N'5481134244858', N'71000', N'Kjosevski', N'M', N'062/524-159')
INSERT [dbo].[Klijent] ([KlijentID], [Adresa], [DatumRodjenja], [Email], [GradID], [Ime], [JMBG], [PostanskiBroj], [Prezime], [Spol], [Telefon]) VALUES (4, N'Ulica 2', CAST(N'1987-01-01T00:00:00.0000000' AS DateTime2), N'sulejman@gmail.com', 1, N'Sulejman', N'1446541520679', N'71000', N'Kripić', N'M', N'061/124-777')
INSERT [dbo].[Klijent] ([KlijentID], [Adresa], [DatumRodjenja], [Email], [GradID], [Ime], [JMBG], [PostanskiBroj], [Prezime], [Spol], [Telefon]) VALUES (5, N'Ulica 3', CAST(N'1988-01-01T00:00:00.0000000' AS DateTime2), N'ivan@gmail.com', 1, N'Ivan', N'6325732158678', N'71000', N'Ćurjurić', N'M', N'062/159-852')
INSERT [dbo].[Klijent] ([KlijentID], [Adresa], [DatumRodjenja], [Email], [GradID], [Ime], [JMBG], [PostanskiBroj], [Prezime], [Spol], [Telefon]) VALUES (6, N'Ulica 4', CAST(N'1992-01-02T00:00:00.0000000' AS DateTime2), N'sinan@gmail.com', 1, N'Sinan', N'3481484474500', N'71000', N'Ramović', N'M', N'062/753-123')
INSERT [dbo].[Klijent] ([KlijentID], [Adresa], [DatumRodjenja], [Email], [GradID], [Ime], [JMBG], [PostanskiBroj], [Prezime], [Spol], [Telefon]) VALUES (7, N'Ulica 5', CAST(N'1993-01-01T00:00:00.0000000' AS DateTime2), N'kemal@gmail.com', 1, N'Kemal', N'1065229049390', N'71000', N'Osmanković', N'M', N'062/524-111')
INSERT [dbo].[Klijent] ([KlijentID], [Adresa], [DatumRodjenja], [Email], [GradID], [Ime], [JMBG], [PostanskiBroj], [Prezime], [Spol], [Telefon]) VALUES (8, N'Ulica 6', CAST(N'1993-01-03T00:00:00.0000000' AS DateTime2), N'antonio@gmail.com', 1, N'Antonio', N'2819860802706', N'71000', N'Pavić', N'M', N'061/525-159')
INSERT [dbo].[Klijent] ([KlijentID], [Adresa], [DatumRodjenja], [Email], [GradID], [Ime], [JMBG], [PostanskiBroj], [Prezime], [Spol], [Telefon]) VALUES (9, N'Ulica 7', CAST(N'1991-04-04T00:00:00.0000000' AS DateTime2), N'matej@gmail.com', 1, N'Matej', N'1053281880985', N'71000', N'Rodin', N'M', N'061/156-354')
INSERT [dbo].[Klijent] ([KlijentID], [Adresa], [DatumRodjenja], [Email], [GradID], [Ime], [JMBG], [PostanskiBroj], [Prezime], [Spol], [Telefon]) VALUES (10, N'Ulica 8', CAST(N'1993-05-05T00:00:00.0000000' AS DateTime2), N'sinisa@gmail.com', 1, N'Siniša', N'8457336004668', N'71000', N'Stevanović', N'M', N'061/148-863')
INSERT [dbo].[Klijent] ([KlijentID], [Adresa], [DatumRodjenja], [Email], [GradID], [Ime], [JMBG], [PostanskiBroj], [Prezime], [Spol], [Telefon]) VALUES (11, N'Ulica 9', CAST(N'1992-01-08T00:00:00.0000000' AS DateTime2), N'mladen@gmail.com', 1, N'Mladen', N'9349240951910', N'71000', N'Veselinović', N'M', N'061/159-838')
INSERT [dbo].[Klijent] ([KlijentID], [Adresa], [DatumRodjenja], [Email], [GradID], [Ime], [JMBG], [PostanskiBroj], [Prezime], [Spol], [Telefon]) VALUES (12, N'Ulica 10', CAST(N'1993-01-10T00:00:00.0000000' AS DateTime2), N'asim@gmail.com', 1, N'Asim', N'5887033466133', N'71000', N'Zec', N'M', N'062/147-159')
SET IDENTITY_INSERT [dbo].[Klijent] OFF
SET IDENTITY_INSERT [dbo].[Popust] ON 

INSERT [dbo].[Popust] ([PopustID], [Naziv], [Opis], [Procenat]) VALUES (1, N'Studentski', N'Za sve redovne studente', 5)
INSERT [dbo].[Popust] ([PopustID], [Naziv], [Opis], [Procenat]) VALUES (2, N'Penzionerski', N'Za sve penzionere', 3)
SET IDENTITY_INSERT [dbo].[Popust] OFF
SET IDENTITY_INSERT [dbo].[StatusFakture] ON 

INSERT [dbo].[StatusFakture] ([StatusFaktureID], [Naziv], [Opis]) VALUES (1, N'Placena', N'Faktura je izdata i placena')
INSERT [dbo].[StatusFakture] ([StatusFaktureID], [Naziv], [Opis]) VALUES (2, N'Izdata', N'Faktura je izdata ali nije placena')
INSERT [dbo].[StatusFakture] ([StatusFaktureID], [Naziv], [Opis]) VALUES (3, N'Pocetna', N'Faktura nije finalizirana')
SET IDENTITY_INSERT [dbo].[StatusFakture] OFF
SET IDENTITY_INSERT [dbo].[Zaposlenik] ON 

INSERT [dbo].[Zaposlenik] ([ZaposlenikID], [DatumRodjenja], [Email], [Ime], [IsAdmin], [IsMenadzer], [IsProdavac], [IsRent], [JMBG], [KorisnickoIme], [Lozinka], [PrebivalisteID], [Prezime], [Spol], [Staz], [Telefon], [TipUgovora]) VALUES (1, CAST(N'1989-09-04T00:00:00.0000000' AS DateTime2), N'danijel@gmail.com', N'Danijel', 0, 0, 1, 0, N'0409989152254', N'danijel', N'test', 1, N'Soldo', N'M', 5, N'061/258-456', N'Stalni')
INSERT [dbo].[Zaposlenik] ([ZaposlenikID], [DatumRodjenja], [Email], [Ime], [IsAdmin], [IsMenadzer], [IsProdavac], [IsRent], [JMBG], [KorisnickoIme], [Lozinka], [PrebivalisteID], [Prezime], [Spol], [Staz], [Telefon], [TipUgovora]) VALUES (2, CAST(N'1997-05-05T00:00:00.0000000' AS DateTime2), N'aleksandar@gmail.com', N'Aleksandar', 0, 0, 0, 1, N'0505997152288', N'aherman123', N'test', 3, N'Herman', N'M', 5, N'062/147-452', N'Stalni')
SET IDENTITY_INSERT [dbo].[Zaposlenik] OFF
SET IDENTITY_INSERT [dbo].[DostavljackaFirma] ON 

INSERT [dbo].[DostavljackaFirma] ([DostavljackaFirmaID], [Adresa], [Email], [Faks], [GradID], [IDBroj], [Naziv], [PDVBroj], [PostanskiBroj], [Telefon]) VALUES (1, N'Ulica 11', N'sunce@gmail.com', N'033/125-236', 1, N'147251259147', N'Maher d.o.o', N'4147251259147', N'71000', N'033/258-122')
INSERT [dbo].[DostavljackaFirma] ([DostavljackaFirmaID], [Adresa], [Email], [Faks], [GradID], [IDBroj], [Naziv], [PDVBroj], [PostanskiBroj], [Telefon]) VALUES (2, N'Azize Šacirbegovic 10', N'adriatic@gmail.com', N'033/159-753', 1, N'741852963753', N'Adriatic d.d.', N'4741852963753', N'71000', N'033/126-751')
SET IDENTITY_INSERT [dbo].[DostavljackaFirma] OFF
SET IDENTITY_INSERT [dbo].[Dostava] ON 

INSERT [dbo].[Dostava] ([DostavaID], [BrzaDostava], [Cijena], [Datum], [DostavljackaFirmaID], [KrajnjiRok]) VALUES (1, 1, 20, CAST(N'2018-12-16T00:00:00.0000000' AS DateTime2), 1, CAST(N'2019-01-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Dostava] ([DostavaID], [BrzaDostava], [Cijena], [Datum], [DostavljackaFirmaID], [KrajnjiRok]) VALUES (2, 0, 10, CAST(N'2018-12-17T00:00:00.0000000' AS DateTime2), 1, CAST(N'2019-01-16T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Dostava] ([DostavaID], [BrzaDostava], [Cijena], [Datum], [DostavljackaFirmaID], [KrajnjiRok]) VALUES (3, 0, 10, CAST(N'2018-12-17T00:00:00.0000000' AS DateTime2), 1, CAST(N'2019-01-16T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Dostava] ([DostavaID], [BrzaDostava], [Cijena], [Datum], [DostavljackaFirmaID], [KrajnjiRok]) VALUES (4, 0, 10, CAST(N'2018-12-17T00:00:00.0000000' AS DateTime2), 1, CAST(N'2019-01-16T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Dostava] ([DostavaID], [BrzaDostava], [Cijena], [Datum], [DostavljackaFirmaID], [KrajnjiRok]) VALUES (5, 1, 15, CAST(N'2018-12-17T00:00:00.0000000' AS DateTime2), 1, CAST(N'2019-01-16T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Dostava] ([DostavaID], [BrzaDostava], [Cijena], [Datum], [DostavljackaFirmaID], [KrajnjiRok]) VALUES (6, 1, 10, CAST(N'2018-12-21T00:00:00.0000000' AS DateTime2), 1, CAST(N'2019-01-29T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Dostava] ([DostavaID], [BrzaDostava], [Cijena], [Datum], [DostavljackaFirmaID], [KrajnjiRok]) VALUES (7, 1, 10, CAST(N'2018-12-21T00:00:00.0000000' AS DateTime2), 2, CAST(N'2019-01-20T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Dostava] OFF
SET IDENTITY_INSERT [dbo].[Faktura] ON 

INSERT [dbo].[Faktura] ([FakturaID], [Datum], [PopustID], [StatusFaktureID], [ZaposlenikID], [DostavaID]) VALUES (1, CAST(N'2018-12-16T23:19:01.5180000' AS DateTime2), NULL, 1, 1, 1)
INSERT [dbo].[Faktura] ([FakturaID], [Datum], [PopustID], [StatusFaktureID], [ZaposlenikID], [DostavaID]) VALUES (3, CAST(N'2018-12-17T18:34:46.8420000' AS DateTime2), NULL, 1, 1, 4)
INSERT [dbo].[Faktura] ([FakturaID], [Datum], [PopustID], [StatusFaktureID], [ZaposlenikID], [DostavaID]) VALUES (4, CAST(N'2018-12-17T18:35:59.7540000' AS DateTime2), NULL, 1, 1, NULL)
INSERT [dbo].[Faktura] ([FakturaID], [Datum], [PopustID], [StatusFaktureID], [ZaposlenikID], [DostavaID]) VALUES (5, CAST(N'2018-12-17T18:36:33.4340000' AS DateTime2), NULL, 1, 1, NULL)
INSERT [dbo].[Faktura] ([FakturaID], [Datum], [PopustID], [StatusFaktureID], [ZaposlenikID], [DostavaID]) VALUES (6, CAST(N'2018-12-17T18:37:02.9060000' AS DateTime2), NULL, 2, 1, NULL)
INSERT [dbo].[Faktura] ([FakturaID], [Datum], [PopustID], [StatusFaktureID], [ZaposlenikID], [DostavaID]) VALUES (7, CAST(N'2018-12-17T18:37:23.5560000' AS DateTime2), NULL, 2, 1, 5)
INSERT [dbo].[Faktura] ([FakturaID], [Datum], [PopustID], [StatusFaktureID], [ZaposlenikID], [DostavaID]) VALUES (8, CAST(N'2018-12-21T07:37:54.4740000' AS DateTime2), 1, 2, 1, 7)
SET IDENTITY_INSERT [dbo].[Faktura] OFF
SET IDENTITY_INSERT [dbo].[Narudzba] ON 

INSERT [dbo].[Narudzba] ([NarudzbaID], [Cijena], [Datum], [FakturaID], [KlijentID], [StatusNarudzbeID]) VALUES (1, 18000, CAST(N'2018-12-16T23:16:10.1800000' AS DateTime2), NULL, 1, 3)
INSERT [dbo].[Narudzba] ([NarudzbaID], [Cijena], [Datum], [FakturaID], [KlijentID], [StatusNarudzbeID]) VALUES (2, 25000, CAST(N'2018-12-16T23:18:33.0620000' AS DateTime2), 1, 1, 2)
INSERT [dbo].[Narudzba] ([NarudzbaID], [Cijena], [Datum], [FakturaID], [KlijentID], [StatusNarudzbeID]) VALUES (3, 60000, CAST(N'2018-12-17T18:03:47.9380000' AS DateTime2), NULL, 1, 4)
INSERT [dbo].[Narudzba] ([NarudzbaID], [Cijena], [Datum], [FakturaID], [KlijentID], [StatusNarudzbeID]) VALUES (4, 48000, CAST(N'2018-12-17T18:04:18.2330000' AS DateTime2), NULL, 2, 1)
INSERT [dbo].[Narudzba] ([NarudzbaID], [Cijena], [Datum], [FakturaID], [KlijentID], [StatusNarudzbeID]) VALUES (5, 22300, CAST(N'2018-12-17T18:08:20.4750000' AS DateTime2), NULL, 2, 3)
INSERT [dbo].[Narudzba] ([NarudzbaID], [Cijena], [Datum], [FakturaID], [KlijentID], [StatusNarudzbeID]) VALUES (6, 17500, CAST(N'2018-12-17T18:33:29.2910000' AS DateTime2), 3, 3, 2)
INSERT [dbo].[Narudzba] ([NarudzbaID], [Cijena], [Datum], [FakturaID], [KlijentID], [StatusNarudzbeID]) VALUES (7, 33000, CAST(N'2018-12-17T18:33:37.8820000' AS DateTime2), 4, 4, 2)
INSERT [dbo].[Narudzba] ([NarudzbaID], [Cijena], [Datum], [FakturaID], [KlijentID], [StatusNarudzbeID]) VALUES (8, 0, CAST(N'2018-12-17T18:33:42.7610000' AS DateTime2), NULL, 5, 3)
INSERT [dbo].[Narudzba] ([NarudzbaID], [Cijena], [Datum], [FakturaID], [KlijentID], [StatusNarudzbeID]) VALUES (9, 22300, CAST(N'2018-12-17T18:33:47.1540000' AS DateTime2), 5, 6, 2)
INSERT [dbo].[Narudzba] ([NarudzbaID], [Cijena], [Datum], [FakturaID], [KlijentID], [StatusNarudzbeID]) VALUES (10, 0, CAST(N'2018-12-17T18:33:52.2720000' AS DateTime2), NULL, 12, 3)
INSERT [dbo].[Narudzba] ([NarudzbaID], [Cijena], [Datum], [FakturaID], [KlijentID], [StatusNarudzbeID]) VALUES (11, 22300, CAST(N'2018-12-17T18:33:56.4790000' AS DateTime2), 6, 8, 2)
INSERT [dbo].[Narudzba] ([NarudzbaID], [Cijena], [Datum], [FakturaID], [KlijentID], [StatusNarudzbeID]) VALUES (12, 37260, CAST(N'2018-12-17T18:34:02.0340000' AS DateTime2), 7, 9, 2)
INSERT [dbo].[Narudzba] ([NarudzbaID], [Cijena], [Datum], [FakturaID], [KlijentID], [StatusNarudzbeID]) VALUES (13, 0, CAST(N'2018-12-17T18:34:06.9340000' AS DateTime2), NULL, 10, 3)
INSERT [dbo].[Narudzba] ([NarudzbaID], [Cijena], [Datum], [FakturaID], [KlijentID], [StatusNarudzbeID]) VALUES (14, 0, CAST(N'2018-12-17T18:34:13.0780000' AS DateTime2), NULL, 5, 4)
INSERT [dbo].[Narudzba] ([NarudzbaID], [Cijena], [Datum], [FakturaID], [KlijentID], [StatusNarudzbeID]) VALUES (15, 50000, CAST(N'2018-12-21T07:36:45.3040000' AS DateTime2), 8, 3, 2)
SET IDENTITY_INSERT [dbo].[Narudzba] OFF
SET IDENTITY_INSERT [dbo].[Motor] ON 

INSERT [dbo].[Motor] ([MotorID], [BrojCilindara], [Model], [Potrosnja], [Snaga], [VrstaMotora], [ZapreminaMotora]) VALUES (1, 3, N'1.4 TSI BlueMotion', N'8', 138, N'Benzin', 1395)
INSERT [dbo].[Motor] ([MotorID], [BrojCilindara], [Model], [Potrosnja], [Snaga], [VrstaMotora], [ZapreminaMotora]) VALUES (2, 3, N'1.6 TDI BlueMotion', N'6', 89, N'Dizel', 1598)
INSERT [dbo].[Motor] ([MotorID], [BrojCilindara], [Model], [Potrosnja], [Snaga], [VrstaMotora], [ZapreminaMotora]) VALUES (3, 4, N'2.0 TDI BlueMotion', N'10', 148, N'Benzin', 1968)
INSERT [dbo].[Motor] ([MotorID], [BrojCilindara], [Model], [Potrosnja], [Snaga], [VrstaMotora], [ZapreminaMotora]) VALUES (4, 4, N'3.0 L S55B30T0 twin-turbo I6', N'10', 350, N'Benzin', 3000)
INSERT [dbo].[Motor] ([MotorID], [BrojCilindara], [Model], [Potrosnja], [Snaga], [VrstaMotora], [ZapreminaMotora]) VALUES (5, 4, N'1.4L turbocharged straight-4 16-valve', N'11', 80, N'Benzin', 1210)
INSERT [dbo].[Motor] ([MotorID], [BrojCilindara], [Model], [Potrosnja], [Snaga], [VrstaMotora], [ZapreminaMotora]) VALUES (6, 4, N'1.4L twincharger straight-4 16-valve', N'9', 72, N'Benzin', 1110)
INSERT [dbo].[Motor] ([MotorID], [BrojCilindara], [Model], [Potrosnja], [Snaga], [VrstaMotora], [ZapreminaMotora]) VALUES (7, 6, N'V6 DOHC', N'12', 187, N'Benzin', 1500)
INSERT [dbo].[Motor] ([MotorID], [BrojCilindara], [Model], [Potrosnja], [Snaga], [VrstaMotora], [ZapreminaMotora]) VALUES (8, 8, N'V8 DOHC', N'15', 345, N'Benzin', 1600)
INSERT [dbo].[Motor] ([MotorID], [BrojCilindara], [Model], [Potrosnja], [Snaga], [VrstaMotora], [ZapreminaMotora]) VALUES (9, 6, N'2.6 V6 12v SOHC', N'8', 148, N'Benzin', 1500)
INSERT [dbo].[Motor] ([MotorID], [BrojCilindara], [Model], [Potrosnja], [Snaga], [VrstaMotora], [ZapreminaMotora]) VALUES (10, 4, N'1.9 DI I4 8v SOHC	', N'8', 75, N'Dizel', 1000)
SET IDENTITY_INSERT [dbo].[Motor] OFF
SET IDENTITY_INSERT [dbo].[Proizvodjac] ON 

INSERT [dbo].[Proizvodjac] ([ProizvodjacID], [Naziv], [GradID]) VALUES (1, N'Volkswagen', 1)
INSERT [dbo].[Proizvodjac] ([ProizvodjacID], [Naziv], [GradID]) VALUES (2, N'BMW', 2)
INSERT [dbo].[Proizvodjac] ([ProizvodjacID], [Naziv], [GradID]) VALUES (3, N'Audi', 3)
SET IDENTITY_INSERT [dbo].[Proizvodjac] OFF
SET IDENTITY_INSERT [dbo].[Vozilo] ON 

INSERT [dbo].[Vozilo] ([VoziloID], [Boja], [BrojVrata], [Cijena], [Garancija], [Godinaproizvodnje], [Mjenjac], [Model], [MotorID], [Oprema], [Pogon], [ProizvodjacID], [TipVozila], [isIznajmljeno]) VALUES (1, N'Crna', 2, 25000, 5, 2017, N'Manual', N'Golf Mk7', 3, N'Sport', N'Front', 1, N'Sedan', 0)
INSERT [dbo].[Vozilo] ([VoziloID], [Boja], [BrojVrata], [Cijena], [Garancija], [Godinaproizvodnje], [Mjenjac], [Model], [MotorID], [Oprema], [Pogon], [ProizvodjacID], [TipVozila], [isIznajmljeno]) VALUES (2, N'siva', 2, 20000, 5, 2016, N'Manual', N'Golf Mk7', 1, N'Active', N'Front', 1, N'Sedan', 0)
INSERT [dbo].[Vozilo] ([VoziloID], [Boja], [BrojVrata], [Cijena], [Garancija], [Godinaproizvodnje], [Mjenjac], [Model], [MotorID], [Oprema], [Pogon], [ProizvodjacID], [TipVozila], [isIznajmljeno]) VALUES (3, N'crvena', 2, 18000, 6, 2015, N'Manual', N'Golf Mk7', 2, N'Ambition', N'Front', 1, N'Sedan', 0)
INSERT [dbo].[Vozilo] ([VoziloID], [Boja], [BrojVrata], [Cijena], [Garancija], [Godinaproizvodnje], [Mjenjac], [Model], [MotorID], [Oprema], [Pogon], [ProizvodjacID], [TipVozila], [isIznajmljeno]) VALUES (4, N'siva', 2, 23000, 5, 2017, N'Semiautomatic', N'F80 M3', 4, N'Sport', N'Back', 2, N'Sport', 0)
INSERT [dbo].[Vozilo] ([VoziloID], [Boja], [BrojVrata], [Cijena], [Garancija], [Godinaproizvodnje], [Mjenjac], [Model], [MotorID], [Oprema], [Pogon], [ProizvodjacID], [TipVozila], [isIznajmljeno]) VALUES (5, N'Crvena', 2, 17500, 5, 2015, N'Manual', N'Volkswagen Polo Mk5', 5, N'Style', N'Front', 1, N'Sedan', 0)
INSERT [dbo].[Vozilo] ([VoziloID], [Boja], [BrojVrata], [Cijena], [Garancija], [Godinaproizvodnje], [Mjenjac], [Model], [MotorID], [Oprema], [Pogon], [ProizvodjacID], [TipVozila], [isIznajmljeno]) VALUES (6, N'Siva', 2, 21000, 10, 2016, N'Manual', N'Volkswagen Polo Mk5', 6, N'Ambition', N'Back', 1, N'Sedan', 0)
INSERT [dbo].[Vozilo] ([VoziloID], [Boja], [BrojVrata], [Cijena], [Garancija], [Godinaproizvodnje], [Mjenjac], [Model], [MotorID], [Oprema], [Pogon], [ProizvodjacID], [TipVozila], [isIznajmljeno]) VALUES (7, N'Zelena', 2, 22300, 5, 2018, N'Manual', N'Volkswagen Polo Mk5', 6, N'Active', N'Front', 1, N'Sedan', 0)
INSERT [dbo].[Vozilo] ([VoziloID], [Boja], [BrojVrata], [Cijena], [Garancija], [Godinaproizvodnje], [Mjenjac], [Model], [MotorID], [Oprema], [Pogon], [ProizvodjacID], [TipVozila], [isIznajmljeno]) VALUES (8, N'Crna', 2, 33000, 5, 2016, N'Manual', N'Audi A6', 7, N'Sport', N'Front', 3, N'Sedan', 0)
INSERT [dbo].[Vozilo] ([VoziloID], [Boja], [BrojVrata], [Cijena], [Garancija], [Godinaproizvodnje], [Mjenjac], [Model], [MotorID], [Oprema], [Pogon], [ProizvodjacID], [TipVozila], [isIznajmljeno]) VALUES (9, N'Bijela', 2, 35000, 10, 2018, N'Manual', N'Audi A6', 8, N'Sport', N'Front', 3, N'Sport', 0)
INSERT [dbo].[Vozilo] ([VoziloID], [Boja], [BrojVrata], [Cijena], [Garancija], [Godinaproizvodnje], [Mjenjac], [Model], [MotorID], [Oprema], [Pogon], [ProizvodjacID], [TipVozila], [isIznajmljeno]) VALUES (10, N'Bijela', 2, 33712, 7, 2017, N'Manual', N'Audi A6', 8, N'Sport', N'Front', 3, N'Sport', 0)
INSERT [dbo].[Vozilo] ([VoziloID], [Boja], [BrojVrata], [Cijena], [Garancija], [Godinaproizvodnje], [Mjenjac], [Model], [MotorID], [Oprema], [Pogon], [ProizvodjacID], [TipVozila], [isIznajmljeno]) VALUES (11, N'Crna', 2, 18630, 5, 2016, N'Manual', N'Audi A4', 9, N'Active', N'Front', 3, N'Sport', 0)
INSERT [dbo].[Vozilo] ([VoziloID], [Boja], [BrojVrata], [Cijena], [Garancija], [Godinaproizvodnje], [Mjenjac], [Model], [MotorID], [Oprema], [Pogon], [ProizvodjacID], [TipVozila], [isIznajmljeno]) VALUES (12, N'Siva', 2, 19632, 5, 2016, N'Manual', N'Audi A4', 10, N'Active', N'Front', 3, N'Sedan', 0)
SET IDENTITY_INSERT [dbo].[Vozilo] OFF
INSERT [dbo].[StavkaNarudzbe] ([VoziloID], [NarudzbaID], [CijenaPoKomadu], [Kolicina]) VALUES (1, 2, 25000, 1)
INSERT [dbo].[StavkaNarudzbe] ([VoziloID], [NarudzbaID], [CijenaPoKomadu], [Kolicina]) VALUES (1, 4, 25000, 1)
INSERT [dbo].[StavkaNarudzbe] ([VoziloID], [NarudzbaID], [CijenaPoKomadu], [Kolicina]) VALUES (1, 15, 25000, 2)
INSERT [dbo].[StavkaNarudzbe] ([VoziloID], [NarudzbaID], [CijenaPoKomadu], [Kolicina]) VALUES (3, 1, 18000, 1)
INSERT [dbo].[StavkaNarudzbe] ([VoziloID], [NarudzbaID], [CijenaPoKomadu], [Kolicina]) VALUES (3, 3, 18000, 1)
INSERT [dbo].[StavkaNarudzbe] ([VoziloID], [NarudzbaID], [CijenaPoKomadu], [Kolicina]) VALUES (4, 4, 23000, 1)
INSERT [dbo].[StavkaNarudzbe] ([VoziloID], [NarudzbaID], [CijenaPoKomadu], [Kolicina]) VALUES (5, 6, 17500, 1)
INSERT [dbo].[StavkaNarudzbe] ([VoziloID], [NarudzbaID], [CijenaPoKomadu], [Kolicina]) VALUES (6, 3, 21000, 2)
INSERT [dbo].[StavkaNarudzbe] ([VoziloID], [NarudzbaID], [CijenaPoKomadu], [Kolicina]) VALUES (7, 5, 22300, 1)
INSERT [dbo].[StavkaNarudzbe] ([VoziloID], [NarudzbaID], [CijenaPoKomadu], [Kolicina]) VALUES (7, 9, 22300, 1)
INSERT [dbo].[StavkaNarudzbe] ([VoziloID], [NarudzbaID], [CijenaPoKomadu], [Kolicina]) VALUES (7, 11, 22300, 1)
INSERT [dbo].[StavkaNarudzbe] ([VoziloID], [NarudzbaID], [CijenaPoKomadu], [Kolicina]) VALUES (8, 7, 33000, 1)
INSERT [dbo].[StavkaNarudzbe] ([VoziloID], [NarudzbaID], [CijenaPoKomadu], [Kolicina]) VALUES (11, 12, 18630, 2)
SET IDENTITY_INSERT [dbo].[NacinPlacanja] ON 

INSERT [dbo].[NacinPlacanja] ([NacinPlacanjaID], [Naziv], [Opis]) VALUES (1, N'Gotovina', N'Placanje u gotovini')
INSERT [dbo].[NacinPlacanja] ([NacinPlacanjaID], [Naziv], [Opis]) VALUES (2, N'Karticno', N'Placanje putem debitne kartice')
SET IDENTITY_INSERT [dbo].[NacinPlacanja] OFF
SET IDENTITY_INSERT [dbo].[Uplata] ON 

INSERT [dbo].[Uplata] ([UplataID], [Datum], [FakturaID], [Iznos], [KlijentID], [NacinPlacanjaID]) VALUES (1, CAST(N'2018-12-16T23:19:55.4560000' AS DateTime2), 1, 29273.4, 1, 1)
INSERT [dbo].[Uplata] ([UplataID], [Datum], [FakturaID], [Iznos], [KlijentID], [NacinPlacanjaID]) VALUES (2, CAST(N'2018-12-17T18:35:39.4940000' AS DateTime2), 3, 20486.7, 3, 1)
INSERT [dbo].[Uplata] ([UplataID], [Datum], [FakturaID], [Iznos], [KlijentID], [NacinPlacanjaID]) VALUES (3, CAST(N'2018-12-17T18:36:07.5960000' AS DateTime2), 4, 38610, 4, 1)
INSERT [dbo].[Uplata] ([UplataID], [Datum], [FakturaID], [Iznos], [KlijentID], [NacinPlacanjaID]) VALUES (4, CAST(N'2018-12-17T18:36:39.7290000' AS DateTime2), 5, 26091, 6, 1)
SET IDENTITY_INSERT [dbo].[Uplata] OFF
SET IDENTITY_INSERT [dbo].[OsiguravajucaFirma] ON 

INSERT [dbo].[OsiguravajucaFirma] ([OsiguravajucaFirmaID], [Adresa], [Email], [Faks], [GradID], [IDBroj], [Naziv], [PDVBroj], [PostanskiBroj], [Telefon]) VALUES (1, N'Ulica bb', N'bosna@gmail.com', N'033/258-159', 1, N'147258369147', N'Bosna Sunce osiguranje d.d.', N'4147258369147', N'71000', N'033/125-123')
SET IDENTITY_INSERT [dbo].[OsiguravajucaFirma] OFF
SET IDENTITY_INSERT [dbo].[Izvjestaj] ON 

INSERT [dbo].[Izvjestaj] ([IzvjestajID], [Datum], [Napomena], [Naziv], [Sadrzaj], [ZaposlenikId]) VALUES (2, CAST(N'2018-12-17T18:37:59.3390000' AS DateTime2), N'a', N'Izvjestaj o radu 15.12.2018', N'Danas sam prodao dva automobila.3', 1)
INSERT [dbo].[Izvjestaj] ([IzvjestajID], [Datum], [Napomena], [Naziv], [Sadrzaj], [ZaposlenikId]) VALUES (3, CAST(N'2018-12-17T18:38:27.6980000' AS DateTime2), NULL, N'Izvjestaj o radu 16.12.2018', N'Danas sam prodao tri automobila.', 1)
INSERT [dbo].[Izvjestaj] ([IzvjestajID], [Datum], [Napomena], [Naziv], [Sadrzaj], [ZaposlenikId]) VALUES (4, CAST(N'2018-12-17T18:38:38.7810000' AS DateTime2), NULL, N'Izvjestaj o radu 17.12.2018', N'Danas sam prodao dva automobila.', 1)
SET IDENTITY_INSERT [dbo].[Izvjestaj] OFF
