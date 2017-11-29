using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace Poof.Model
{
    public class Document
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Frame")]
        public int Frame;

        [JsonProperty(PropertyName = "Slab")]
        public int Slab;

        [JsonProperty(PropertyName = "Living")]
        public int Living;

        [JsonProperty(PropertyName = "Categories")]
        public ObservableCollection<Category> Categories { get; set; } = new ObservableCollection<Category>();
    }
}
