----------------------------------------------------------------------------------------------------------------------------------------------------------
-- PRAKnjizara - Create Database
----------------------------------------------------------------------------------------------------------------------------------------------------------
-- Baza

use master;
go

if db_id('PRAKnjizara') is not null
begin
	alter database PRAKnjizara
	set single_user
	with rollback immediate;
	drop database PRAKnjizara
end

----------------------------------------------------------------------------------------------------------------------------------------------------------
-- Baza

create database PRAKnjizara
go

alter database PRAKnjizara
set single_user
with rollback immediate;

use PRAKnjizara
go

----------------------------------------------------------------------------------------------------------------------------------------------------------
-- Knjige

create table Autor
(
	IDAutor int primary key identity,
	Ime nvarchar(100),
	Prezime nvarchar(100),
)
go

create table Izdavac
(
	IDIzdavac int primary key identity,
	Naziv nvarchar(100)
)
go

create table StanjeKnjige
(
	IDStanjeKnjige int primary key identity,
	Stanje nvarchar(10)
)
go

create table Knjiga
(
	IDKnjiga int primary key identity,
	AutorID int foreign key references Autor(IDAutor),
	IzdavacID int foreign key references Izdavac(IDIzdavac),
	StanjeKnjigeID int foreign key references StanjeKnjige(IDStanjeKnjige),
	Naslov nvarchar(100),
	Izdanje nvarchar(100),
	KratakSadrzaj nvarchar(max),
	Slika nvarchar(max),
	DostupnaKolicina int,
	CijenaZaKupovinu money,
	CijenaZaNajam money,
	Popularnost bigint,
	DatumDodavanja datetime,
	DatumBrisanja datetime
)
go

----------------------------------------------------------------------------------------------------------------------------------------------------------
-- Osobe

create table Drzava
(
	IDDrzava int primary key identity,
	Naziv nvarchar(100)
)
go

create table Grad
(
	IDGrad int primary key identity,
	DrzavaID int foreign key references Drzava(IDDrzava),
	Naziv nvarchar(100)
)
go

create table Osoba
(
	IDOsoba int primary key identity,
	GradID int foreign key references Grad(IDGrad),
	Ime nvarchar(100),
	Prezime nvarchar(100),
	Email nvarchar(100),
	Adresa nvarchar(100),
	PostanskiBroj nvarchar(100)
)
go

----------------------------------------------------------------------------------------------------------------------------------------------------------
-- Korisnici

create table UlogaUAplikaciji
(
	IDUlogaUAplikaciji int primary key identity,
	Uloga nvarchar(100)
)
go

create table Korisnik
(
	IDKorisnik int primary key identity,
	OsobaID int foreign key references Osoba(IDOsoba),
	UlogaUAplikacijiID int foreign key references UlogaUAplikaciji(IDUlogaUAplikaciji),
	Lozinka char(128),
	SifraKorisnika char(11) null,
	Aktiviran bit null,
	DatumRegistracije datetime,
	DatumBrisanja datetime
)
go

----------------------------------------------------------------------------------------------------------------------------------------------------------
-- Promet

create table ZakasninaPoDanu
(
	IDZakasninaPoDanu int primary key identity,
	Zakasnina money
)
go

create table Posudba
(
	IDPosudba int primary key identity,
	KnjigaID int foreign key references Knjiga(IDKnjiga),
	KorisnikID int foreign key references Korisnik(IDKorisnik),
	ZakasninaPoDanuID int foreign key references ZakasninaPoDanu(IDZakasninaPoDanu),
	DatumPosudbe datetime,
	PeriodPosudbe datetime,
	DatumVracanja datetime,
	Kupljeno bit
)
go

create table Racun
(
	IDRacun int primary key identity,
	KorisnikID int foreign key references Korisnik(IDKorisnik),
	DatumIzdavanja datetime
)
go

create table Stavka
(
	IDStavka int primary key identity,
	RacunID int foreign key references Racun(IDRacun),
	KnjigaID int foreign key references Knjiga(IDKnjiga)
)
go

----------------------------------------------------------------------------------------------------------------------------------------------------------
-- Knjizara

create table Knjizara
(
	IDKnjizara int primary key identity,
	Naziv nvarchar(100),
	Adresa nvarchar(100),
	OIB char(11),
	IBAN varchar(34),
	Logo nvarchar(100),
	UvjetiKoristenja nvarchar(100)
)

----------------------------------------------------------------------------------------------------------------------------------------------------------
-- Baza

alter database PRAKnjizara
set multi_user

----------------------------------------------------------------------------------------------------------------------------------------------------------
