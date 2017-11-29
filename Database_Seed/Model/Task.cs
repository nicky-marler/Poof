using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Seed.Model
{
    public class Task
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public bool Finish { get; set; }

        public Task()
        {

        }
    }
}
