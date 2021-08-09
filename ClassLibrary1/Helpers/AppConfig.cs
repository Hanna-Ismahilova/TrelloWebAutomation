using Newtonsoft.Json;
using System;
using System.IO;
using UITrelloAutomationFramework.Base.Models;

namespace UITrelloAutomationFramework.Helpers
{
    public static class AppConfig
    {
        public static AppSettingsModel appSettings;

        public static void Load()
        {

            using (var stream = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"/appSettings.json"))
            {

                appSettings = JsonConvert.DeserializeObject<AppSettingsModel>(stream.ReadToEnd());

            }
        }


    }
}
