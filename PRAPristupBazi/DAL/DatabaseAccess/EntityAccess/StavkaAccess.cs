using PRAPristupBazi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.StavkaAccess
{
    public static class StavkaAccess
    {
        /***************************************************************************************************************************************************************/
        // RETRIEVE

        public static IEnumerable<Stavka> DohvatiSveStavkeRacunaPoKorisniku(this KnjizaraContext db, Korisnik korisnik)
        {
            return db.Stavkas.QuerryMultiple(x => x.Racun.KorisnikId == korisnik.Idkorisnik);
        }

        /***************************************************************************************************************************************************************/
        // CREATE

        // [WILL NOT BE IMPLEMENTED]

        /***************************************************************************************************************************************************************/
        // UPDATE

        // [WILL NOT BE IMPLEMENTED]

        /***************************************************************************************************************************************************************/
        // DELETE

        // [WILL NOT BE IMPLEMENTED]

        /***************************************************************************************************************************************************************/
    }
}
