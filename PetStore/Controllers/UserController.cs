using Microsoft.AspNetCore.Mvc;
using PetStore.Models;
using PetStore.Repositories;

namespace PetStore.Controllers
{
    public class UserController : Controller
    {
        public IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //GET: Login
        public IActionResult Login()
        {
            ViewBag.UserRank = CurrentUser.Instance.UserRank;
            return View();
        }
        //POST: Login 
        [HttpPost]
        public IActionResult Login(User user)
        {
            //Checks is user excits
            bool LoginStatus = _userRepository.LoginCheck(user);
            if (LoginStatus)
            {
                CurrentUser.Instance.UserRank = _userRepository.GetUserRank(user);
                return RedirectToAction("HomePage", "Animals");
            }
            else
            {
                ViewBag.LoginStatus = "There is something wrong with the Username/Password";

                return View();
            }
        }
        //Get: Logout
        public IActionResult Logout(User user)
        {
            CurrentUser.Instance.UserRank = 0;
            return RedirectToAction("HomePage","Animals");


        }


        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            _userRepository.AddUser(user);
            return RedirectToAction("Login");
        }
    }
}
