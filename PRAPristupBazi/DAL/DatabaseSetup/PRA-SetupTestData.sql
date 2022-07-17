----------------------------------------------------------------------------------------------------------------------------------------------------------
-- PRAKnjizara - Setup Test Data
----------------------------------------------------------------------------------------------------------------------------------------------------------

alter database PRAKnjizara
set single_user
with rollback immediate;

----------------------------------------------------------------------------------------------------------------------------------------------------------

use PRAKnjizara
go

----------------------------------------------------------------------------------------------------------------------------------------------------------
-- DESIGNED TO BE RUN ON A FRESH DATABASE (NO DATA EVER INSERTED) DUE TO FOREIGN KEY RANDOMIZATION
----------------------------------------------------------------------------------------------------------------------------------------------------------
-- DATABASE WIPE:

begin try
	delete from Knjizara
	delete from Drzava
	delete from Grad
	delete from Autor
	delete from Izdavac
	delete from StanjeKnjige
	delete from ZakasninaPoDanu
	delete from UlogaUAplikaciji
	delete from Stavka
	delete from Racun
	delete from Knjiga
	delete from Posudba
	delete from Korisnik
	delete from Osoba
end try
begin catch
end catch

----------------------------------------------------------------------------------------------------------------------------------------------------------
-- TEST DATA:

--PART1:
-- 1 knjizara, 2 stanja knjige, 1 zakasnina po danu, 2 uloge u aplikaciji
--PART2:
-- 200 autora, 50 izdavaca
--PART3:
-- 500 knjiga
--PART4:
-- 10 drzava, 50 gradova
--PART 5:
-- 200 osoba & korisnika -> 190 klijenata, 10 zaposlenika
-- sve lozinke: "lozinka" -> SHA512: 0F1CBF02510B6714C483462190F2059666D6A024693072E610F99EAE63572F671A1427DAB7AB1400EC727520CECF6E38F0DFAFDD21548A0050D362C833AF2BE9
--PART 6:
-- 100 posudbi, 300 stavki u 100 racuna

--PART1:
insert into Knjizara(Naziv, Adresa, OIB, IBAN, Logo, UvjetiKoristenja)
values ('TestNaziv', 'TestAdresa', '12345678901', 'TEST123456789012345678901234567890', 'TestLogo', 'TestUvjetiKoristenja')
insert into StanjeKnjige(Stanje)
values ('Nova'), ('Rabljena')
insert into ZakasninaPoDanu(Zakasnina)
values (1)
insert into UlogaUAplikaciji(Uloga)
values ('Klijent'), ('Zaposlenik')

--PART2:
declare @counter1 int
set @counter1 = 1
while @counter1 <= 200
begin
	insert into Autor(Ime, Prezime)
	values
	(
		'TestIme' + CAST(@counter1 as nvarchar(10)),
		'TestPrezime' + CAST(@counter1 as nvarchar(10))
	)
set @counter1 = @counter1 + 1
end
declare @counter2 int
set @counter2 = 1
while @counter2 <= 50
begin
	insert into Izdavac(Naziv)
	values
	(
		'TestNaziv' + CAST(@counter2 as nvarchar(10))
	)
set @counter2 = @counter2 + 1
end

--PART3:
declare @counter3 int
set @counter3 = 1
while @counter3 <= 500
begin
	--nisu dodani: DatumDodavanja, DatumBrisanja
	insert into Knjiga(AutorID, IzdavacID, StanjeKnjigeID, Naslov, Izdanje, KratakSadrzaj, Slika, DostupnaKolicina, CijenaZaKupovinu, CijenaZaNajam, Popularnost)
	values
	(
		(floor(rand()*200+1)),
		(floor(rand()*50+1)),
		(floor(rand()*2+1)),
		'TestNaslov'+ CAST(@counter3 as nvarchar(10)),
		'TestIzdanje'+ CAST(@counter3 as nvarchar(10)),
		'TestKratakSadrzaj'+ CAST(@counter3 as nvarchar(10)),
		'TestSlika'+ CAST(@counter3 as nvarchar(10)),
		(floor(rand()*20+1)),
		(floor(rand()*300+1)),
		(floor(rand()*30+1)),
		(floor(rand()*1000+1))
	)
set @counter3 = @counter3 + 1
end

--PART4:
declare @counter4 int
set @counter4 = 1
while @counter4 <= 10
begin
	insert into Drzava(Naziv)
	values
	(
		'TestNaziv'+ CAST(@counter4 as nvarchar(10))
	)
set @counter4 = @counter4 + 1
end
declare @counter5 int
set @counter5 = 1
while @counter5 <= 50
begin
	insert into Grad(DrzavaID, Naziv)
	values
	(
		(floor(rand()*10+1)),
		'TestNaziv'+ CAST(@counter5 as nvarchar(10))
	)
set @counter5 = @counter5 + 1
end

--PART 5:
declare @counter6 int
set @counter6 = 1
while @counter6 <= 200
begin
	insert into Osoba(GradID, Ime, Prezime, Email, Adresa, PostanskiBroj)
	values
	(
		(floor(rand()*50+1)),
		'TestIme'+ CAST(@counter6 as nvarchar(10)),
		'TestPrezime'+ CAST(@counter6 as nvarchar(10)),
		'TestEmail'+ CAST(@counter6 as nvarchar(10)),
		'TestAdresa'+ CAST(@counter6 as nvarchar(10)),
		'TestPostanskiBroj'+ CAST(@counter6 as nvarchar(10))
	)
set @counter6 = @counter6 + 1
end
declare @counter7 int
set @counter7 = 1
while @counter7 <= 190
begin
	--nisu dodani: DatumRegistracije, DatumBrisanja
	insert into Korisnik(OsobaID, UlogaUAplikacijiID, Lozinka, SifraKorisnika, Aktiviran)
	values
	(
		(@counter7),
		1,
		'0F1CBF02510B6714C483462190F2059666D6A024693072E610F99EAE63572F671A1427DAB7AB1400EC727520CECF6E38F0DFAFDD21548A0050D362C833AF2BE9',
		'Sifra'+ CAST(@counter7 as nvarchar(10)),
		1
	)
set @counter7 = @counter7 + 1
end
declare @counter8 int
set @counter8 = 190
while @counter8 <= 200
begin
	--svi su racuni aktivirani
	insert into Korisnik(OsobaID, UlogaUAplikacijiID, Lozinka, SifraKorisnika, Aktiviran)
	values
	(
		(@counter8),
		2,
		'0F1CBF02510B6714C483462190F2059666D6A024693072E610F99EAE63572F671A1427DAB7AB1400EC727520CECF6E38F0DFAFDD21548A0050D362C833AF2BE9',
		null,
		null
	)
set @counter8 = @counter8 + 1
end

--PART 6:
declare @counter9 int
set @counter9 = 1
while @counter9 <= 100
begin
	--nisu dodani: DatumPosudbe, PeriodPosudbe, DatumVracanja
	--niti jedna posudena knjiga nije kupljena
	insert into Posudba(KnjigaID, KorisnikID, ZakasninaPoDanuID, Kupljeno)
	values
	(
		(floor(rand()*500+1)),
		(floor(rand()*190+1)),
		1,
		0
	)
set @counter9 = @counter9 + 1
end
declare @counter10 int
set @counter10 = 1
while @counter10 <= 100
begin
	--nisu dodani: DatumIzdavanja
	insert into Racun(KorisnikID)
	values
	(
		(floor(rand()*190+1))
	)
set @counter10 = @counter10 + 1
end
declare @counter11 int
set @counter11 = 1
while @counter11 <= 300
begin
	insert into Stavka(RacunID, KnjigaID)
	values
	(
		(floor(rand()*100+1)),
		(floor(rand()*500+1))
	)
set @counter11 = @counter11 + 1
end

----------------------------------------------------------------------------------------------------------------------------------------------------------

alter database PRAKnjizara
set multi_user

----------------------------------------------------------------------------------------------------------------------------------------------------------