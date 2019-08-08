using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Web.DAL;
using WebApplication.Web.Providers.Auth;

namespace WebApplication.Web.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IAuthProvider authProvider;
        private IPetDAO petDAO;
        private IUserDAL userDAL;
        private IReservationDAO reservationDAO;

        public AccountController(IAuthProvider authProvider, IPetDAO petDAO, IUserDAL userDAL, IReservationDAO reservationDAO)
        {
            this.authProvider = authProvider;
            this.petDAO = petDAO;
            this.userDAL = userDAL;
            this.reservationDAO = reservationDAO;
        }

        public IActionResult Reservation()
        {
            return View();
        }
    }
}