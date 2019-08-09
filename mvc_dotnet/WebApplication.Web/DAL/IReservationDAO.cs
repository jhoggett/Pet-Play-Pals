using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;
using WebApplication.Web.Models.Account;

namespace WebApplication.Web.DAL
{
    public interface IReservationDAO
    {
        IList<Reservation> GetAllReservationsForUser(int userId);

        int AddReservation(ReservationUserViewModel reservation);

        IList<Reservation> GetAcceptedReservations(int userId);

        IList<Reservation> GetPendingReservations(int userId);


    }
}
