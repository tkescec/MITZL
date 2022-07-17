----------------------------------------------------------------------------------------------------------------------------------------------------------
-- PRAKnjizara - Clear All Data
----------------------------------------------------------------------------------------------------------------------------------------------------------

alter database PRAKnjizara
set single_user
with rollback immediate;

----------------------------------------------------------------------------------------------------------------------------------------------------------

use PRAKnjizara
go

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

alter database PRAKnjizara
set multi_user

----------------------------------------------------------------------------------------------------------------------------------------------------------