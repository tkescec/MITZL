using Microsoft.EntityFrameworkCore;
using PRAPristupBazi.Exceptions;
using PRAPristupBazi.Exceptions.ExceptionLogging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PRAPristupBazi.DAL.DatabaseAccess
{
    internal static class DBAccess
    {
        /***************************************************************************************************************************************************************/
        // RETRIEVE [COMPLETE QUERRY]

        public static IEnumerable<TEntity> QuerryAll<TEntity>(this DbSet<TEntity> dbset) where TEntity : class
        {
            return dbset.ToList();
        }

        public static IEnumerable<TEntity> QuerryAll_Partial<TEntity>(this DbSet<TEntity> dbset, int skip, int take) where TEntity : class
        {
            return dbset.Skip(skip).Take(take).ToList();
        }

        public static IEnumerable<TEntity> QuerryMultiple<TEntity>(this DbSet<TEntity> dbset, Func<TEntity, bool> lambda) where TEntity : class
        {
            return dbset.Where(lambda).ToList();
        }

        public static IEnumerable<TEntity> QuerryMultiple_Partial<TEntity>(this DbSet<TEntity> dbset, Func<TEntity, bool> lambda, int skip, int take) where TEntity : class
        {
            return dbset.Where(lambda).Skip(skip).Take(take).ToList();
        }

        public static TEntity QuerrySingle<TEntity>(this DbSet<TEntity> dbset, Func<TEntity, bool> lambda) where TEntity : class
        {
            return dbset.Single(lambda);
        }

        /***************************************************************************************************************************************************************/
        // CREATE - UPDATE - DELETE [COMPLETE TRANSACTION]

        private static string FindDbSetName(DbContext db, object obj)
        {
            string dbsetName = null;
            uint propCounter = 0;
            PropertyInfo[] dbcontextProperties = db.GetType().GetProperties();

            foreach (PropertyInfo property in dbcontextProperties)
            {
                if (property.Name.Contains(obj.GetType().Name.RemoveProxyString()))
                {
                    dbsetName = property.Name;
                    propCounter++;
                }
            }
            if (dbsetName == null || propCounter != 1)
            {
                throw new Exception("DbSet property not identified!");
            }
            return dbsetName;
        }

        private static string RemoveProxyString(this string objName)
        {
            return objName.Replace("Proxy", "");
        }

        public static void ValidateDbSetMethod<TEntity>(string method) where TEntity : class
        {
            Type dbset = typeof(DbSet<TEntity>);
            MethodInfo[] dbsetMethods = dbset.GetMethods();

            foreach (MethodInfo m in dbsetMethods)
            {
                if (m.Name == method)
                {
                    return;
                }
            }
            throw new Exception("DbSet method not found!");
        }

        public static void CUDTemplate(this DbContext db, object obj, string method)
        {
            MethodInfo dbsetMethod = null;
            object? invokeTarget = null;
            object[] invokeParameters = null;
            try
            {
                string dbsetName = FindDbSetName(db, obj);

                MethodInfo validationMethodInfo = typeof(DBAccess).GetMethod("ValidateDbSetMethod");
                MethodInfo validationMethod = validationMethodInfo.MakeGenericMethod(obj.GetType());
                validationMethod.Invoke(null, new object[] { method });

                PropertyInfo dbsetProperty = db.GetType().GetProperty(dbsetName);
                dbsetMethod = dbsetProperty.PropertyType.GetMethod(method);

                invokeTarget = dbsetProperty.GetValue(db);
                invokeParameters = new object[] { obj };
            }
            catch (Exception e)
            {
                Exception e2 = new RefleksijaException($"Puklo u refleksiji!\n:: {e.GetType()}\n:: {e.Message}\n:: {e.Source}\n:: {e.TargetSite}\n:: {e.StackTrace}");
                e2.LogExceptionToDest();
                throw e2;
            }

            try
            {
                db.Database.BeginTransaction();
                dbsetMethod.Invoke(invokeTarget, invokeParameters);
                db.SaveChanges();
                db.Database.CommitTransaction();
            }
            catch (Exception e)
            {
                db.Database.RollbackTransaction();
                Exception e2 = new BazaPodatakaException($"Puklo na bazi!\n:: {e.GetType()}\n:: {e.Message}\n:: {e.Source}\n:: {e.TargetSite}\n:: {e.StackTrace}");
                e2.LogExceptionToDest();
                throw e2;
            }

        }

        /***************************************************************************************************************************************************************/

    }
}
