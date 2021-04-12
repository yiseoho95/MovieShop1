using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {

        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        //Attribute based routing
        [HttpGet]
        [Route("toprevenue")]
        public async Task<IActionResult> GetTopRevenueMovies()
        {
            var movies = await _movieService.Get30HighestGrossing();
            // API Methods will return JSON data along with HTTP Status codes
            // 200, 201,400,401,403,404,500
            if (!movies.Any())
            {
                return NotFound("We did not find any movies");
            }

            return Ok(movies);

            //System.Text.Json in .NET Core 3  --> used instead of Newtonsoft. for JSON Serialization
            //previous versions of .Net 1,2 and previous older .NET framework Network Newtonsoft
            //Serialization, convert your C# objects into JSON objects
            // opposite is called De-Serialization, convert your JSON obj to C# obj

        }

        // there are 2 types of routing 1. attribute based routing 2. Traditional Routing
    }

}
