using ApplicationCore.Models.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;

namespace MovieShop.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }




        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterRequestModel model)
        {
            var user = await _userService.RegisterUser(model);
            return View();
        }



        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Login(LoginRequestModel model)
        {
            return View();
        }
    }
}
