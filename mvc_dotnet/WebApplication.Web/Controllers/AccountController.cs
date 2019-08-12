using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Web.DAL;
using WebApplication.Web.Models;
using WebApplication.Web.Models.Account;
using WebApplication.Web.Providers.Auth;

namespace WebApplication.Web.Controllers
{    
    public class AccountController : Controller
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
        
        //[AuthorizationFilter] // actions can be filtered to only those that are logged in
        [AuthorizationFilter("Admin", "Author", "Manager", "User")]  //<-- or filtered to only those that have a certain role
        [HttpGet]
        public IActionResult Index()
        {
            var user = authProvider.GetCurrentUser();

            // This is where I started using VM
            PetsUserViewModel vm = new PetsUserViewModel();
            vm.User = userDAL.GetUser(user.Username);
            vm.Pets = petDAO.GetAllPets(user.Id);

            // used to pass in user
            return View(vm);
            
        }

        [HttpGet]
        public IActionResult Login()
        {            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            // Ensure the fields were filled out
            if (ModelState.IsValid)
            {
                // Check that they provided correct credentials
                bool validLogin = authProvider.SignIn(loginViewModel.Email, loginViewModel.Password);
                if (validLogin)
                {
                    // Redirect the user where you want them to go after successful login
                    return RedirectToAction("UserHome", "Account");
                }
            }

            return View(loginViewModel);
        }
        
         public IActionResult UserHome()
        {
            var user = authProvider.GetCurrentUser();

            
            ReservationUserViewModel vm = new ReservationUserViewModel();
            vm.User = userDAL.GetUser(user.Username);
            vm.Pets = petDAO.GetAllPets(user.Id);
            vm.Accepted = reservationDAO.GetAllAcceptedReservations(user.Id);
            vm.Pending = reservationDAO.GetAllPendingReservations(user.Id);
            
            return View(vm);
        }


        [HttpGet]
        public IActionResult LogOff()
        {
            // Clear user from session
            authProvider.LogOff();

            // Redirect the user where you want them to go after logoff
            return RedirectToAction("Index", "Home");
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {            
            if (ModelState.IsValid)
            {
                // Register them as a new user (and set default role)
                // When a user registeres they need to be given a role. If you don't need anything special
                // just give them "User".
                authProvider.Register(registerViewModel.Email, registerViewModel.Password, registerViewModel.FirstName, registerViewModel.LastName, role: "User"); 

                // Redirect the user where you want them to go after registering
                return RedirectToAction("RegisterPet", "Account");
            }

            return View(registerViewModel);
        }

        [HttpGet]
        public IActionResult RegisterPet()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterPet(PetsUserViewModel vm)
        {
            var user = authProvider.GetCurrentUser();
            vm.User = userDAL.GetUserById(user.Id);
            vm.Pet.UserId = vm.User.Id;
            petDAO.AddPet(vm.Pet);

            return RedirectToAction("Index", "Account");
        }

        [HttpGet]
        public IActionResult DeletePet(int id)
        {
            Pets pet = new Pets();
            pet = petDAO.GetPetById(id);
            return View(pet);
        }

        [HttpPost]
        public IActionResult DeletePet(Pets pet)
        {
            //Pets pet = new Pets();
            //var user = authProvider.GetCurrentUser();
            //vm.User = userDAL.GetUserById(user.Id);
            //pet.UserId = vm.User.Id;
            //vm.Pet = petDAO.GetPetById(pet.Id);

            //petDAO.DeletePet(vm.Pet);
            petDAO.DeletePet(pet);

            return RedirectToAction("Index", "Account");
        }

        [HttpGet]
        public IActionResult UpdatePet(int id)
        {
            Pets pet = new Pets();
            pet = petDAO.GetPetById(id);

            return View(pet);
        }

        [HttpPost]
        public IActionResult UpdatePet(Pets pet)
        {
            petDAO.UpdatePet(pet);

            return RedirectToAction("Index", "Account");
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel vm)
        {
            authProvider.ChangePassword(vm.OldPassword, vm.Password);

            return RedirectToAction("Index", "Account");
        }

        [HttpGet]
        public IActionResult ChangeEmail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangeEmail(ChangeEmailUserViewModel vm)
        {            
            authProvider.ChangeEmail(vm.OldUserName, vm.NewUserName);

            return RedirectToAction("Index", "Account");            
        }

        [HttpGet]
        public IActionResult ChangeName()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangeName(ChangeNameViewModel vm)
        {
            authProvider.ChangeFirstName(vm.OldFirstName, vm.NewFirstName);
            authProvider.ChangeLastName(vm.OldLastName, vm.NewLastName);

            return RedirectToAction("Index", "Account");
        }

    }
}