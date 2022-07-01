using PRAPristupBazi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.AutorAccess
{
    public static class AutorAccess
    {
        /***************************************************************************************************************************************************************/
        // RETRIEVE

        public static Autor DohvatiAutora(this KnjizaraContext db, string ime, string prezime)
        {
            return db.Autors.QuerryMultiple(x => x.Ime == ime && x.Prezime == prezime).FirstOrDefault();
        }

        public static IEnumerable<Autor> DohvatiAutore(this KnjizaraContext db)
        {
            return db.Autors.ToList();
        }

        public static IEnumerable<Autor> DohvatiAutorePoImenu(this KnjizaraContext db, string ime)
        {
            return db.Autors.QuerryMultiple(x => x.Ime.Contains(ime));
        }

        public static IEnumerable<Autor> DohvatiAutorePoImenu(this KnjizaraContext db, string ime, int preskoci, int dohvati)
        {
            return db.Autors.QuerryMultiple_Partial(x => x.Ime.Contains(ime), preskoci, dohvati);
        }
        
        public static IEnumerable<Autor> DohvatiAutorePoPrezimenu(this KnjizaraContext db, string prezime)
        {
            return db.Autors.Where(x => x.Prezime.Contains(prezime)).ToList();
        }

        public static IEnumerable<Autor> DohvatiAutorePoPrezimenu(this KnjizaraContext db, string prezime, int preskoci, int dohvati)
        {
            return db.Autors.QuerryMultiple_Partial(x => x.Prezime.Contains(prezime), preskoci, dohvati);
        }

        private class AutorEqualityComparer : IEqualityComparer<Autor>
        {
            public bool Equals(Autor? x, Autor? y)
            {
                return x.Idautor == y.Idautor;
            }

            public int GetHashCode([DisallowNull] Autor obj)
            {
                return HashCode.Combine(obj.Idautor);
            }
        }

        public static IEnumerable<Autor> DohvatiAutorePoImenuIPrezimenu(this KnjizaraContext db, string ime, string prezime)
        {
            var poImenu = db.DohvatiAutorePoImenu(ime);
            var poPrezimenu = db.DohvatiAutorePoPrezimenu(prezime);
            var unija = poImenu.Union(poPrezimenu, new AutorEqualityComparer());

            return unija;
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
