using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Infrastructure.Filters
{
    public class MovieShopHeaderFilter : IActionFilter
    {
        private readonly ICurrentUserService _currentUserService;

        public MovieShopHeaderFilter(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Log each and every user's Ipaddress, his name if authenticated, authentication status, date time
            //context.HttpContext.Response.Headers.Add("job", "antra.com/jobs");

            var email = _currentUserService.Email;
            var datetime = DateTime.UtcNow;
            var isAuthenticated = _currentUserService.IsAuthenticated;
            var name = _currentUserService.FullName;

            //log this info to text files
            // use system.IO to log it into txt files
            // Serilog. Nlog, Log4net



        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            int x = 20 / 10;
        }


    }
}
