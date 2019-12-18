using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace proefExamen.Models
{
    public class AreaData
    {
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        
        private string _mayor;
        [JsonProperty(PropertyName = "Mayor")]
        public string Mayor
        {
            get
            {
                if (_mayor == null || _mayor == "")
                {
                    return "mayor unknow";
                }
                else
                {
                    return _mayor;
                }
            }
            set { _mayor = value; }
        }


        [JsonProperty(PropertyName = "FullName")]
        public string FullName { get; set; }

        [JsonProperty(PropertyName = "Continent")]
        public string Continent { get; set; }

        public string imgMobile { get; set; }

        [JsonExtensionData]
        private Dictionary<string, JToken> _extraJsonData = new Dictionary<string, JToken>();

        [OnDeserialized]
        private void ProcessExtraJsonData(StreamingContext context)
        {
            //prefs.backgroundColor
            JToken prefsData = (JToken)_extraJsonData["ImageData"];
            imgMobile = (string)prefsData.SelectToken("Mobile");
        }
    }
}
