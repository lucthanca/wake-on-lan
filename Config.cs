using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WOL
{
    internal class Config
    {
        public static string? GetPropertyValue(object obj, string propName) {
            return (string) obj.GetType().GetProperty(propName).GetValue(obj, null);
        }

        public static void SetPropertyValue(object obj, string key, string value)
        {
            var prop = obj.GetType().GetProperty(key);
            if (prop != null)
            {
                prop.SetValue(obj, value, null);
            }
        }

        public string? txt_ip { get; set; }
        public string? txt_mac { get; set; }
        public string? txt_port { get; set; } = "9";
    }
}
