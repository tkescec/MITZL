using PRAPristupBazi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.RacunAccess
{
    public static class RacunAccess
    {
        /***************************************************************************************************************************************************************/
        // RETRIEVE

        public static IEnumerable<Racun> DohvatiSveRacunePoKorisniku(this KnjizaraContext db, Korisnik korisnik)
        {
            return db.Racuns.QuerryMultiple(x => x.KorisnikId == korisnik.Idkorisnik);
        }

        /***************************************************************************************************************************************************************/
        // CREATE

        public static void DodajRacun(this KnjizaraContext db, Racun racun)
        {
            db.CUDTemplate(racun, "Add");
        }

        /***************************************************************************************************************************************************************/
        // UPDATE

        // [WILL NOT BE IMPLEMENTED]

        /***************************************************************************************************************************************************************/
        // DELETE

        // [WILL NOT BE IMPLEMENTED]

        /***************************************************************************************************************************************************************/
    }
}
