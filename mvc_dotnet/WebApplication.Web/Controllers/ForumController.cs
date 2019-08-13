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
    public class ForumController : Controller
    {
        private readonly IAuthProvider authProvider;
        private IForumDAO forumDAO;
        private IUserDAL userDAL;

        public ForumController(IForumDAO forumDAO, IAuthProvider authProvider, IUserDAL userDAL)
        {
            this.userDAL = userDAL;
            this.authProvider = authProvider;
            this.forumDAO = forumDAO;
        }


        [HttpGet]
        public IActionResult Index()
        {
            if (!authProvider.IsLoggedIn)
            {
                return RedirectToAction("Login", "Account");
            }
            IList<ForumPost> forumList = forumDAO.GetAllPosts();
            return View(forumList);
        }

        [HttpGet]
        public IActionResult AddPost()
        {
            var user = authProvider.GetCurrentUser();
            ForumPostUserVM vm = new ForumPostUserVM();
            vm.CurrentUser = userDAL.GetUser(user.Username);

          
            return View(vm);

        }


        [HttpPost]
        public IActionResult AddPost(ForumPostUserVM forumPost)
        {
            var user = authProvider.GetCurrentUser();
            forumPost.CurrentUser = userDAL.GetUser(user.Username);
            forumDAO.SaveNewPost(forumPost.Post);
            return RedirectToAction("Index", "Forum");
        }


        [HttpGet]
        public IActionResult PostDetails(int id)
        {
            ForumPost post = new ForumPost();
            post = forumDAO.GetPostById(id);
            return View(post);
        }
    }
}