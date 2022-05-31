using PRAPristupBazi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.ZakasninaPoDanuAccess
{
    public static class ZakasninaPoDanuAccess
    {
        /***************************************************************************************************************************************************************/
        // RETRIEVE

        public static ZakasninaPoDanu DohvatiZakasninuPoDanu(this KnjizaraContext db, decimal zakasnina)
        {
            return db.ZakasninaPoDanus.QuerryMultiple(x => x.Zakasnina == zakasnina).FirstOrDefault();
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
