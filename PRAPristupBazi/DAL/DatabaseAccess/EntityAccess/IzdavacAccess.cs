using PRAPristupBazi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.IzdavacAccess
{
    public static class IzdavacAccess
    {
        /***************************************************************************************************************************************************************/
        // RETRIEVE

        public static Izdavac DohvatiIzdavaca(this KnjizaraContext db, string naziv)
        {
            return db.Izdavacs.QuerryMultiple(x => x.Naziv == naziv).FirstOrDefault();
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
