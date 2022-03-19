using System.ComponentModel;
using System.Reflection;

namespace Billing.Common.ExtensionMethods
{
    public static class ApplicationExtension
    {
        public static string GetEnumDescription(this System.Enum value)
        {
            // Get the Description attribute value for the enum value
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}
