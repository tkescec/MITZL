using Microsoft.AspNetCore.Mvc;
using PRAPristupBazi.DAL;
using PRAPristupBazi.DAL.DatabaseAccess;

namespace Knjižara.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BaseController : Controller
    {
        private KnjizaraContext db = DBConnectionPool.GetDBConnection();

        internal KnjizaraContext Db { get => db; set => db = value; }

        internal void GetTempData()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
                TempData["Message"] = null;
            }
            if (TempData["Error"] != null)
            {
                ViewBag.Error = TempData["Error"];
                TempData["Error"] = null;
            }
        }

        internal IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal string CopyPropertyValues<TIn, TOut>(TIn source, TOut destination, bool tryParse = false)
        {
            string result = "";
            if (destination == null)
            {
                destination = Activator.CreateInstance<TOut>();
            }
            if (source == null)
            {
                return "Input model empty";
            }

            var inType = source.GetType();

            var outType = destination != null ? destination.GetType() : Activator.CreateInstance<TOut>().GetType();
            var inProps = inType.GetProperties();
            var outProps = outType.GetProperties();

            foreach (var prop in outProps)
            {
                var inProp = inProps.FirstOrDefault(x => x.Name == prop.Name);
                if (inProp != null)
                {
                    if (prop.PropertyType == inProp.PropertyType)
                    {
                        var inValue = inProp.GetValue(source);
                        if (inValue == DBNull.Value)
                        {
                            inValue = null;
                        }
                        var propType = prop.PropertyType;
                        Type t = Nullable.GetUnderlyingType(propType) ?? propType;
                        inValue = (inValue == null) ? null : Convert.ChangeType(inValue, t);
                        if (prop.CanWrite && prop.GetSetMethod(/*nonPublic*/ true).IsPublic)
                        {
                            prop.SetValue(destination, inValue);
                        }
                    }
                    else if (tryParse)
                    {
                        try
                        {
                            var inValue = Convert.ChangeType(inProp.GetValue(source), prop.PropertyType);
                            prop.SetValue(destination, inValue);
                        }
                        catch
                        {
                            result += string.Format("Unable to cast {0} to {1}", inProp.PropertyType, prop.PropertyType);
                        }
                    }
                }
            }
            return result;
        }
    }
}
