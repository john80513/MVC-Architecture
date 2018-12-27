using System;
using System.ComponentModel;
using System.Reflection;

namespace AP.Service.Helper
{
    public static class EnumDescriptionHelper
    {
        public static string GetEnumDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            // 先取 Description，沒有則改取 value
            if ((attributes != null) && (attributes.Length > 0))
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}
