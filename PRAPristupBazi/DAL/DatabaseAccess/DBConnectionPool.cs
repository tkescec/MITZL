using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAPristupBazi.DAL.DatabaseAccess
{
    public static class DBConnectionPool
    {
        private static PooledDbContextFactory<KnjizaraContext>? instance;

        private static void CreateInstance()
        {
            var a = ($"Server={System.Environment.MachineName}; Database=PRAKnjizara; Trusted_Connection=True; MultipleActiveResultSets=True")
                    ;
            string cc = "Server=LAPTOP-CMNR2AT2\\SQLEXPRESS01;Database=PRAKnjizara; Trusted_Connection=True; MultipleActiveResultSets=True";

            var options = new DbContextOptionsBuilder<KnjizaraContext>()
                
                .UseSqlServer(cc)
                .UseLazyLoadingProxies()
                .EnableSensitiveDataLogging()
                .Options;

            instance = new PooledDbContextFactory<KnjizaraContext>(options);
        }

        public static KnjizaraContext? GetDBConnection()
        {
            if (instance == null)
            {
                CreateInstance();
                return instance.CreateDbContext();
            }
            else
            {
                return instance.CreateDbContext();
            }
        }
    }
}
