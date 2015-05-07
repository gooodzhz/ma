using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace MA.Common
{
    public class ConfigHelper
    {
        public static string GetValue(string key, string defaultValue = "")
        {
            try
            {
                return ConfigurationManager.AppSettings[key];
            }
            catch
            {
                return defaultValue;
            }
        }

        public static string GetConnection(string key, string defaultValue = "")
        {
            try
            {
                return ConfigurationManager.ConnectionStrings[key].ToString();
            }
            catch
            {
                return defaultValue;
            }
        }
    }

}
