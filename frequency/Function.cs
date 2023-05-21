using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace frequency
{
    public class Function
    {
        [JsonProperty("nameFunc")]
        public string NameFunc { get; set; }
        [JsonProperty("num")]
        public int NumPlates { get; set; }
        [JsonProperty("date")]
        public string DatePlate { get; set;}

    }

}
