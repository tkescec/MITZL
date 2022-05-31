# MITZL

********************************************************************************************************************************************************************
Ivan
********************************************************************************************************************************************************************
UPUTE ZA PODIZANJE I KORISTENJE BAZE PODATAKA:

0) Priprema:

  Koristite microsoft SQL server instancu, nacin autentikacije, te protokol za spajanje na server po zelji.
  
  PREPORUKA:
  Koristite defaultnu instancu SQL servera (koja se zove jednako kao i vase racunalo, bez \SQLEXPRESS nastavka).
  Koristite windows autentikaciju za pristup SQL serveru iz programa (mora biti omoguceno na razini servera).
  SQL serveru iz programa pristupite preko shared memory protokola (omoguceno po defaultu) (ne TCP/IP).
  (Ako radite po preporuci, ne morate mijenjati connection string na bazu u programu.)
  (Connection string je konfiguriran da se spaja na defaultnu instancu SQL servera na vasem racunalu, sa windows autentifikacijom, preko shared memory protokola)
  
  Ako se NE spajate na bazu na preporuceni nacin:
  Pogledajte https://www.connectionstrings.com/sql-server/ za pomoc u pripravljanju connection stringa.
  MultipleActiveResultSets mora biti ukljucen da bi sve radilo.
  Connection string morate popraviti u DBConnectionPool.cs fileu.
  Preporuceno je da connection string popravite i u KnjizaraConext.cs fileu.
  
1) Podizanje baze (po preporuci):

  Spojite se na defaultnu instancu microsoft SQL servera preko SSMSa (slobodno koristite SQL server autentikaciju za spajanje na bazu preko SSMSa).
  U projektu PRAPristupBazi pronadite folder DAL, te u njemu folder DatabaseSetup.
  Otvorite SQL skriptu "PRA-CreateDatabase.sql".
  Pokrenite skritptu u SSMSu.
  Desnim klikom na server napravite refresh strukture servera.
  Trebala bi se pojaviti baza "PRAKnjizara" sa 14 tablica.
  
2) Unos testnih podataka na bazu (po preporuci):

  Spojite se na defaultnu instancu microsoft SQL servera preko SSMSa (slobodno koristite SQL server autentikaciju za spajanje na bazu preko SSMSa).
  Provjerite da baza "PRAKnjizara" postoji na serveru.
  Ako ste vec radili na toj bazi (umetali i brisali podatke itd.), OBAVEZNO ponovno pokrenite skriptu za kreiranje baze iz prethodnog koraka.
  (U protivnom unos testnih podataka nece raditi kako treba - skripta ce se izvesti djelomicno ili ne uopce - SSMS ce javiti greske).
  U projektu PRAPristupBazi pronadite folder DAL, te u njemu folder DatabaseSetup.
  Otvorite SQL skriptu "PRA-SetupTestData.sql".
  Pokrenite skritptu u SSMSu.
  
3) Brisanje podataka iz baze (po preporuci):

  Ako zelite pobrisati podatke iz baze, jednostano ponovno odradite korak 1 (podizanje baze).
  Ista skripta koja kreira bazu ce, ako ta baza vec postoji, izbrisati postojecu, te kreirati novu s istim imenom (ne morate rucno brisati postojecu bazu).
  Podatke iz baze takoder mozete brisati koristenjem SQL skripte "PRA-ClearData.sql" u PRAPristupBazi\DAL\DatabaseSetup (NIJE PREPORUCENO).
  
********************************************************************************************************************************************************************
  
