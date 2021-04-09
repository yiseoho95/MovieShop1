using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class UserController : Controller
    {
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUserPurchasedMovies()
        {
            //HttpContext.User.Claims.Where(c=>c.Type == "first")
            // call User Service by id of user to get all the movies they purchased
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PurchaseMovie()
        {
            return View();
        }
    }
}
