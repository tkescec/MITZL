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
          
            var options = new DbContextOptionsBuilder<KnjizaraContext>()
                .UseSqlServer($"Server={System.Environment.MachineName}; Database=PRAKnjizara; Trusted_Connection=True; MultipleActiveResultSets=True")
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
