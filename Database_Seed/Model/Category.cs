using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Seed.Model
{
    public class Category
    {
        public string Name { get; set; }
        public double Average_Bid;

        public double Completion;

        public List<Bid> Bids { get; set; }
        public List<Model.Task> Tasks { get; set; }
    }
}
