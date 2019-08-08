using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models.Account
{
    public class Reservation
    {

        public int ReservationId { get; set; }
        public string Address { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string PetName { get; set;}

    }
}
