using PRAPristupBazi.Exceptions;
using PRAPristupBazi.Exceptions.ExceptionLogging;
using PRAPristupBazi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.KorisnikAccess
{
    public static class KorisnikAccess
    {
        /***************************************************************************************************************************************************************/
        // HELPER METHODS:

        private static bool korisnikCreateLock = false;

        private static string HashirajLozinku(this string lozinka)
        {
            byte[] data = Encoding.UTF8.GetBytes(lozinka);

            SHA512 sha = SHA512.Create();
            byte[] result = sha.ComputeHash(data);

            string resultString = BitConverter.ToString(result).Replace("-", String.Empty);

            return resultString;
        }

        private static string GenerirajSifruKorisnika()
        {
            string datum = DateTime.Now.ToShortDateString();
            string[] datumParts = datum.Split('/');
            datumParts[2] = datumParts[2].Remove(0, 2);

            int maxID;
            var db = DBConnectionPool.GetDBConnection();
            if (db.Korisniks.Select(x => x.Idkorisnik).Count() == 0)
            {
                maxID = 0;
            }
            else
            {
                maxID = db.Korisniks.Select(x => x.Idkorisnik).Max();
            }
            string newID = (maxID + 1).ToString().PadLeft(4, '0');

            string sifraKorisnika = "K" + datumParts[2] + datumParts[1] + datumParts[0] + newID;

            return sifraKorisnika;
        }

        private static string GenerirajRandomString()
        {
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[] randomBytes = new byte[50];
            rng.GetBytes(randomBytes, 0, 50);

            string randomString = BitConverter.ToString(randomBytes).Replace("-", String.Empty);

            return randomString;
        }

        /***************************************************************************************************************************************************************/
        // RETRIEVE

        public static IEnumerable<Korisnik> DohvatiSveKorisnike(this KnjizaraContext db)
        {
            return db.Korisniks.QuerryAll();
        }

        public static IEnumerable<Korisnik> DohvatiSveKorisnike(this KnjizaraContext db, int preskoci, int dohvati)
        {
            return db.Korisniks.QuerryAll_Partial(preskoci, dohvati);
        }

        public static Korisnik DohvatiJednogKorisnika(this KnjizaraContext db, int idkorisnik)
        {
            return db.Korisniks.QuerrySingle(x => x.Idkorisnik == idkorisnik);
        }

        public static Korisnik DohvatiKorisnikaPoSifri(this KnjizaraContext db, string sifra)
        {
            return  db.Korisniks.Where(x => x.SifraKorisnika == sifra).FirstOrDefault();
           
        }

        public static Korisnik AutentificirajKorisnika(this KnjizaraContext db, string email, string lozinka)
        {
            return db.Korisniks.QuerrySingle(x => x.Lozinka == lozinka.HashirajLozinku() && x.Osoba.Email == email);
        }

        /***************************************************************************************************************************************************************/
        // CREATE

        public static void DodajKorisnika(this KnjizaraContext db, Korisnik korisnik)
        {
            var postojeci = db.Osobas.QuerryMultiple(x => x.Email == korisnik.Osoba.Email);
            if (postojeci.Count() != 0)
            {
                Exception e = new KorisnikCreateException("Korisnik sa tom email adresom vec postoji!");
                e.LogExceptionToDest();
                throw e;
            }

            int retry = 0;
            while (korisnikCreateLock)
            {
                if (retry < 40)
                {
                    retry++;
                    Thread.Sleep(50);
                }
                else
                {
                    Exception e = new KorisnikCreateTimeoutException("Nije uspjelo dodavanje korisnika!");
                    e.LogExceptionToDest();
                    throw e;
                }
            }
            korisnikCreateLock = true;

            try
            {
                korisnik.SifraKorisnika = GenerirajSifruKorisnika();
                korisnik.Aktiviran = false;
                korisnik.Lozinka = korisnik.Lozinka.HashirajLozinku();
                korisnik.DatumBrisanja = null;
                korisnik.DatumRegistracije = DateTime.Now;
                db.CUDTemplate(korisnik, "Add");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                korisnikCreateLock = false;

            }
        }

        /***************************************************************************************************************************************************************/
        // UPDATE

        // korisnik ne moze promijeniti mail
        public static void AzurirajKorisnika(this KnjizaraContext db, Korisnik korisnik, bool promjenaLozinke)
        {
            if (promjenaLozinke)
            {
                korisnik.Lozinka = korisnik.Lozinka.HashirajLozinku();
            }

            db.CUDTemplate(korisnik, "Update");
        }

        /***************************************************************************************************************************************************************/
        // DELETE

        // [HARD OVERWRITE DELETE]
        public static void IzbrisiKorisnika(this KnjizaraContext db, Korisnik korisnik)
        {
            korisnik.Osoba.Ime = GenerirajRandomString();
            korisnik.Osoba.Prezime = GenerirajRandomString();
            korisnik.Osoba.Email = GenerirajRandomString();
            korisnik.Osoba.Adresa = GenerirajRandomString();
            korisnik.Osoba.PostanskiBroj = GenerirajRandomString();
            korisnik.DatumBrisanja = DateTime.Now;

            db.AzurirajKorisnika(korisnik, false);
        }

        /***************************************************************************************************************************************************************/
    }
}
