using System;
using Newtonsoft.Json;

namespace bobot.config
{
    using Newtonsoft.Json;
    using System.Text;

    namespace DiscordBotTutorialExampleProject.Config
    {
        public class ConfigJsonReader
        {
            
            public string discordToken { get; set; }
            public string discordPrefix { get; set; }

            public async Task ReadJSON() 
            {
                
                using StreamReader sr = new("config.json", new UTF8Encoding(false));

                
                string json = await sr.ReadToEndAsync();

               
                JSONStruct obj = JsonConvert.DeserializeObject<JSONStruct>(json);

                
                this.discordToken = obj.token;
                this.discordPrefix = obj.prefix;
            }
        }

        internal sealed class JSONStruct
        {
            public string token { get; set; }
            public string prefix { get; set; }
        }
    }

}