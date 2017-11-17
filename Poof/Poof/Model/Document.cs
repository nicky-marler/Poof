using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Poof.Model
{
    public class Document
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        
        [JsonProperty(PropertyName = "BusinessId")]
        public string BusinessId { get; set; }
        
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
    }
}
