using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Billing.Common.Helper
{
    public static class Helper
    {
        public static string GetEnumDescription(this System.Enum enumValue)
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
            var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : string.Empty;
        }
        public static IEnumerable<SelectListItem> GetEnumList<TEnum>()
        {
            return System.Enum.GetValues(typeof(TEnum))
                .Cast<TEnum>()
                .ToDictionary(t => ((System.Enum)((object)t)).GetEnumDescription(), t => (int)(object)t).ToList()
                .Select(t => new SelectListItem { Text = t.Key, Value = t.Value.ToString() });
        }
    }
}
