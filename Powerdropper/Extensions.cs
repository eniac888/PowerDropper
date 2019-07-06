using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Powerdropper
{
    public static class Extensions
    {

        public static string GetReplacementName(this object obj, string propertyName)
        {
            dynamic target = obj.GetProperty(propertyName);

            if (target == null)
                target = obj.GetField(propertyName);

            if (target == null)
                throw new Exception("Couldn't find property or field: " + propertyName);

            object[] dbFieldAtts = target.GetCustomAttributes(typeof(ReplacementAttribute), true);

            if (dbFieldAtts != null && dbFieldAtts.Length > 0)
            {
                return ((ReplacementAttribute)dbFieldAtts[0]).Name;
            }

            return "UNDEFINED";
        }

        public static PropertyInfo GetProperty(this object obj, string property_name)
        {
            return obj.GetType().GetProperty(property_name);
        }

        public static FieldInfo GetField(this object obj, string field_name)
        {
            return obj.GetType().GetField(field_name);
        }
    }
}
