using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Database_Seed.Model
{
    public class Project
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        public int Frame;
        public int Slab;
        public int Living;
        public List<Category> Categories { get; set; } = new List<Category>();
        public string Name { get; set; }
        
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public Project()
        {

        }
    }
}
