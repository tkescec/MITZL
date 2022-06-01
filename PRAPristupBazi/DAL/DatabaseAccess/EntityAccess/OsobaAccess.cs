using PRAPristupBazi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.OsobaAccess
{
    public static class OsobaAccess
    {
        /***************************************************************************************************************************************************************/
        // RETRIEVE

        public static Osoba DohvatiOsobu(this KnjizaraContext db, string email)
        {
            return db.Osobas.QuerrySingle(x => x.Email == email);
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
