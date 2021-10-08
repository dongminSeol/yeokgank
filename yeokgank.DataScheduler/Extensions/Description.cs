using System;
using System.ComponentModel;

namespace yeokgank.DataScheduler.Extensions
{
    public static class Description
    {
        public static string GetDescription(this Enum value)
        {
            try
            {
                var field = value.GetType().GetField(value.ToString());
                var attribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                return attribute.Length == 0 ? value.ToString() : (attribute[0] as DescriptionAttribute).Description;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
    public static class Exceptions
    {
        public static string GetFullMessage(this Exception ex)
        {
            return ex.InnerException == null
                 ? ex.Message
                 : ex.Message + " --> " + ex.InnerException.GetFullMessage();
        }
    }
}
