using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastController : ControllerBase
    {
        private readonly ICastService _castService;

        public CastController(ICastService castService)
        {
            _castService = castService;
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetCast")]
        public async Task<IActionResult> GetCastById(int id)
        {
            var casts = await _castService.GetCastDetailsWithMovies(id);
            return Ok(casts);
        }
    }
}
