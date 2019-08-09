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

        IList<Reservation> GetAllAcceptedReservations(int userId);

        IList<Reservation> GetAllPendingReservations(int userId);

        Reservation GetPendingReservation(int userId, int reservationId);


    }
}
