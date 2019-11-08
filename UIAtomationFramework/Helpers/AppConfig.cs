
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UIAtomationFramework.Base.Models;

namespace UIAtomationFramework.Helpers
    {
   public static class AppConfig
        {

        public static AppSettingsModel Load ( )
            {

            using (var stream = new StreamReader(@"C:\Users\Hanna_Ismahilova\source\repos\TrelloWebAutomation\TrelloWebAutomation\appSettings.json") )
                {

                AppSettingsModel appSettings = JsonConvert.DeserializeObject<AppSettingsModel>(stream.ReadToEnd());

                return appSettings;
                }
                //var Files = Directory.GetFiles(".\\");


            }


        }
    }
