using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Web.DAL;
using WebApplication.Web.Models;
using WebApplication.Web.Providers.Auth;

namespace WebApplication.Web.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IAuthProvider authProvider;
        private IPetDAO petDAO;
        private IUserDAL userDAL;
        private IReservationDAO reservationDAO;

        public ReservationController(IAuthProvider authProvider, IPetDAO petDAO, IUserDAL userDAL, IReservationDAO reservationDAO)
        {
            this.authProvider = authProvider;
            this.petDAO = petDAO;
            this.userDAL = userDAL;
            this.reservationDAO = reservationDAO;
        }

        [HttpGet]
        public IActionResult Reservation()
        {

            if (!authProvider.IsLoggedIn)
            {
                return RedirectToAction("Login", "Account");
            }
            var user = authProvider.GetCurrentUser();

            ReservationUserViewModel vm = new ReservationUserViewModel();
            vm.User = userDAL.GetUser(user.Username);
            vm.Reservations = reservationDAO.GetAllReservationsForUser(user.Id);
            vm.Pets = petDAO.GetAllPets(user.Id);

            return View(vm);
        }


        [HttpPost]
        public IActionResult Reservation(ReservationUserViewModel vm)
        {
            if (vm.InvitedUser.Username == null)
            {
                return RedirectToAction("Reservation", "Reservation");
            }

            var user = authProvider.GetCurrentUser();
            vm.User = userDAL.GetUserById(user.Id);
            vm.InvitedUser = userDAL.GetUser(vm.InvitedUser.Username);

            vm.Reservation.StartTime = vm.Reservation.StartTime.AddHours(vm.StartHour);
            vm.Reservation.StartTime = vm.Reservation.StartTime.AddMinutes(vm.StartMinute);
            vm.Reservation.EndTime = vm.Reservation.EndTime.AddHours(vm.EndHour);
            vm.Reservation.EndTime = vm.Reservation.EndTime.AddMinutes(vm.EndMinute);
            reservationDAO.AddReservation(vm);


            return RedirectToAction("UserHome", "Account");
        }

        [HttpGet]
        public IActionResult PendingReservation(int id)
        {

            ReservationUserViewModel vm = new ReservationUserViewModel();

            var user = authProvider.GetCurrentUser();
            vm.User = userDAL.GetUserById(user.Id);
            
            // got to figure out the reservationid to pass over

            vm.User = userDAL.GetUser(user.Username);
            vm.Pets = petDAO.GetAllPets(user.Id);
            vm.Reservation = reservationDAO.GetPendingReservation(user.Id, id);

            return View(vm);
        }

        [HttpPost]
        public IActionResult AcceptReservation(int ReservationId, int UserId)
        {

            reservationDAO.AcceptPendingReservation(UserId, ReservationId);
            return RedirectToAction("UserHome", "Account");
        }


        [HttpPost]
        public IActionResult DeclineReservation(int ReservationId)
        {

            reservationDAO.DeclinePendingReservation(ReservationId);
            return RedirectToAction("UserHome", "Account");
        }


        [HttpGet]
        public IActionResult AcceptedReservation(int id)
        {

            ReservationUserViewModel vm = new ReservationUserViewModel();

            var user = authProvider.GetCurrentUser();
            vm.User = userDAL.GetUserById(user.Id);

            // got to figure out the reservationid to pass over

            vm.User = userDAL.GetUser(user.Username);
            vm.Pets = petDAO.GetAllPets(user.Id);
            vm.Reservation = reservationDAO.GetAcceptedReservation(user.Id, id);

            return View(vm);
        }
    }
}