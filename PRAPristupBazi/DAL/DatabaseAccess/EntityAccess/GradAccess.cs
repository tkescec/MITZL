using PRAPristupBazi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.GradAccess
{
    public static class GradAccess
    {
        /***************************************************************************************************************************************************************/
        // RETRIEVE

        public static Grad DohvatiGrad(this KnjizaraContext db, string naziv)
        {
            return db.Grads.QuerryMultiple(x => x.Naziv == naziv).FirstOrDefault();
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
