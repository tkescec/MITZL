using PRAPristupBazi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.StanjeKnjigeAccess
{
    public static class StanjeKnjigeAccess
    {
        /***************************************************************************************************************************************************************/
        // RETRIEVE

        public static StanjeKnjige DohvatiStanjeKnjige(this KnjizaraContext db, string stanje)
        {
            return db.StanjeKnjiges.QuerryMultiple(x => x.Stanje == stanje).FirstOrDefault();
        }

        public static IEnumerable<StanjeKnjige> DohvatiStanjaKnjige(this KnjizaraContext db)
        {
            return db.StanjeKnjiges.ToList();
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
