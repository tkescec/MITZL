using PRAPristupBazi.Exceptions;
using PRAPristupBazi.Exceptions.ExceptionLogging;
using PRAPristupBazi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.KnjizaraAccess
{
    public static class KnjizaraAccess
    {
        /***************************************************************************************************************************************************************/
        // RETRIEVE

        public static Knjizara DohvatiPodatkeOKnjizari(this KnjizaraContext db)
        {
            return db.Knjizaras.FirstOrDefault();
        }

        /***************************************************************************************************************************************************************/
        // CREATE

        public static void DodajPodatkeOKnjizari(this KnjizaraContext db, Knjizara knjizara)
        {
            if (db.DohvatiPodatkeOKnjizari() == null)
            {
                db.CUDTemplate(knjizara, "Add");
            }
            else
            {
                Exception e = new KnjizaraCreateException("Podaci o knjizari vec postoje!");
                e.LogExceptionToDest();
                throw e;
            }
        }

        /***************************************************************************************************************************************************************/
        // UPDATE

        public static void AzurirajPodatkeOKnjizari(this KnjizaraContext db, Knjizara knjizara)
        {
            db.CUDTemplate(knjizara, "Update");
        }

        /***************************************************************************************************************************************************************/
        // DELETE

        // [WILL NOT BE IMPLEMENTED]

        /***************************************************************************************************************************************************************/
    }
}
