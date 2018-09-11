using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using Eron.Core.ValueObjects;

namespace Eron.SharedKernel.Helpers.AppSettingsHelper
{
    public static class ApplicationSettingsHelper
    {
        public static T AppSetting<T>(string key)
        {
            return (T)Convert.ChangeType(ConfigurationManager.AppSettings[key], typeof(T));
        }

        public static string AppSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public static IList<SelectListObject> ApplicationSettings(string key)
        {
            var settings = ConfigurationManager.AppSettings;
            var keySettings = settings.AllKeys.SelectMany(settings.GetValues, (k, v) => new SelectListObject(k, v)).Where(x => x.Id.ToLower().Contains(key.ToLower()));
            return keySettings.ToList();
        }
    }
}
