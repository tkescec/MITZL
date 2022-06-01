using PRAPristupBazi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.PosudbaAccess
{
    public static class PosudbaAccess
    {
        /***************************************************************************************************************************************************************/
        // RETRIEVE

        public static IEnumerable<Posudba> DohvatiSvePosudbe(this KnjizaraContext db)
        {
            return db.Posudbas.QuerryAll();
        }

        public static IEnumerable<Posudba> DohvatiSvePosudbe(this KnjizaraContext db, int preskoci, int dohvati)
        {
            return db.Posudbas.QuerryAll_Partial(preskoci, dohvati);
        }

        public static IEnumerable<Posudba> DohvatiSvePosudbePoKorisniku(this KnjizaraContext db, Korisnik korisnik)
        {
            return db.Posudbas.QuerryMultiple(x => x.KorisnikId == korisnik.Idkorisnik);
        }

        /***************************************************************************************************************************************************************/
        // CREATE

        public static void DodajPosudbu(this KnjizaraContext db, Posudba posudba)
        {
            db.CUDTemplate(posudba, "Add");
        }

        /***************************************************************************************************************************************************************/
        // UPDATE

        public static void AzurirajPosudbu(this KnjizaraContext db, Posudba posudba)
        {
            db.CUDTemplate(posudba, "Update");
        }

        /***************************************************************************************************************************************************************/
        // DELETE

        // [WILL NOT BE IMPLEMENTED]

        /***************************************************************************************************************************************************************/
    }
}
