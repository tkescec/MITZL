using PRAPristupBazi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.UlogaUaplikacijiAccess
{
    public static class UlogaUaplikacijiAccess
    {
        /***************************************************************************************************************************************************************/
        // RETRIEVE

        public static UlogaUaplikaciji DohvatiUloguUAplikaciji(this KnjizaraContext db, string uloga)
        {
            return db.UlogaUaplikacijis.QuerrySingle(x => x.Uloga == uloga);
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
