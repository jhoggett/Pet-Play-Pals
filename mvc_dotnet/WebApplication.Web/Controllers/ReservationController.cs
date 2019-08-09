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

        public Reservationcontroller(IAuthProvider authProvider, IPetDAO petDAO, IUserDAL userDAL, IReservationDAO reservationDAO)
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
    }
}