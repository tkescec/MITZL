using PRAPristupBazi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.KnjigaAccess
{
    public static class KnjigaAccess
    {
        /***************************************************************************************************************************************************************/
        // RETRIEVE

        public static IEnumerable<Knjiga> DohvatiSveKnjige(this KnjizaraContext db)
        {
            var a = db.Knjigas.QuerryAll();
            return db.Knjigas.QuerryAll();
        }

        public static IEnumerable<Knjiga> DohvatiSveKnjige(this KnjizaraContext db, int preskoci, int dohvati)
        {
            return db.Knjigas.QuerryAll_Partial(preskoci, dohvati);
        }

        public static IEnumerable<Knjiga> DohvatiIzbrisaneKnjige(this KnjizaraContext db)
        {
            return db.Knjigas.QuerryMultiple(x => x.DatumBrisanja != null);
        }

        public static IEnumerable<Knjiga> DohvatiIzbrisaneKnjige(this KnjizaraContext db, int preskoci, int dohvati)
        {
            return db.Knjigas.QuerryMultiple_Partial(x => x.DatumBrisanja != null, preskoci, dohvati);
        }

        public static IEnumerable<Knjiga> DohvatiKnjigePoNaslovu(this KnjizaraContext db, string naslov)
        {
            return db.Knjigas.QuerryMultiple(x => x.Naslov.Contains(naslov));
        }

        public static IEnumerable<Knjiga> DohvatiKnjigePoNaslovu(this KnjizaraContext db, string naslov, int preskoci, int dohvati)
        {
            return db.Knjigas.QuerryMultiple_Partial(x => x.Naslov.Contains(naslov), preskoci, dohvati);
        }

        /***************************************************************************************************************************************************************/
        // CREATE

        public static void DodajKnjigu(this KnjizaraContext db, Knjiga knjiga)
        {
            //var db = DBConnectionPool.GetDBConnection();
            db.CUDTemplate(knjiga, "Add");
        }

        /***************************************************************************************************************************************************************/
        // UPDATE

        public static void AzurirajKnjigu(this KnjizaraContext db, Knjiga knjiga)
        {
            db.CUDTemplate(knjiga, "Update");
        }

        /***************************************************************************************************************************************************************/
        // DELETE

        // [SOFT DELETE]
        public static void IzbrisiKnjigu(this KnjizaraContext db, Knjiga knjiga)
        {
            knjiga.DatumBrisanja = DateTime.Now;
            db.AzurirajKnjigu(knjiga);
        }

        // [RECOVER DELETED]
        public static void PovratiKnjigu(this KnjizaraContext db, Knjiga knjiga)
        {
            knjiga.DatumBrisanja = null;
            db.AzurirajKnjigu(knjiga);
        }

        /***************************************************************************************************************************************************************/
    }
}
