using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FillInFables.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class MadLibz
    {
       
        [JsonProperty(PropertyName="title")]
        public string title { get; set; }
        [JsonProperty(PropertyName ="blanks")]
        public string[] blanks { get; set; }
        [JsonProperty(PropertyName ="value")]
        public object[] value { get; set; }
    }
}
