using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace proefExamen.Models
{
    public class QualityScore
    {
        public Guid Id { get; set; }
        public string Topic { get; set; }
        [JsonProperty(PropertyName = "Score")]
        public int ScoreOutOf10 { get; set; }
        public string Color { get; set; }
        public int ScorePercentage 
        { 
            get 
            { 
                return ScoreOutOf10 * 10; 
            } 
        }

        public override string ToString()
        {
            return $"{Topic}: {ScorePercentage.ToString()}%";
        }
    }
}
