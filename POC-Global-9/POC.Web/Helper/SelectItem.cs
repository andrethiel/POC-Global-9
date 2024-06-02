using Microsoft.AspNetCore.Mvc.Rendering;
using POC.Negocio.Enumerador;

namespace POC.Web.Helper
{
    public class SelectItem
    {
        public static IEnumerable<SelectListItem> GetEnumSelectList<T>()
        {
            return (Enum.GetValues(typeof(UnidadeMedida)).Cast<T>().Select(
                enu => new SelectListItem() { Text = enu.ToString(), Value = enu.ToString() })).ToList();
        }
    }
}
