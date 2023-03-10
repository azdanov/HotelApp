using System.Globalization;

namespace HotelApp.Web.Localization.Models
{
    public class CultureSwitcherModel
    {
        public CultureInfo? CurrentUiCulture { get; set; }
        public List<CultureInfo>? SupportedCultures { get; set; }
    }
}