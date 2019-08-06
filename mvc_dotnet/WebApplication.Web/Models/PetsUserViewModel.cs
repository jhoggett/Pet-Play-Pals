using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class PetsUserViewModel
    {
        public List<Pets> Pets { get; set; }
        public User User { get; set; }


    }
}
