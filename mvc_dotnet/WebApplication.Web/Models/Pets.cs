using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class Pets
    {
        public int Id {get; set;}
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Personality { get; set; }
        public int Weight { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public string Photo { get; set; }

    }
}
