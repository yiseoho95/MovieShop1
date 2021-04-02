using ApplicationCore.Entities;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CastService : ICastService
    {
        //private readonly IAsyncRepository<Cast> _castRepository;
        private readonly ICastRepository _castRepository;
        private readonly IMovieRepository _movieRepository;



        public CastService(/*IAsyncRepository<Cast> castRepository*/ ICastRepository castRepository, IMovieRepository movieRepository)
        {
            _castRepository = castRepository;
            _movieRepository = movieRepository;
        }
        public async Task<CastDetailsResponseModel> GetCastDetailsWithMovies(int id)
        {
            var cast = await _castRepository.GetByIdAsync(id);
            var movie = await _movieRepository.GetByIdAsync(id);
            var result = new List<CastDetailsResponseModel>();
            result.Add(new CastDetailsResponseModel
            {
                Id = cast.Id,
                Name = cast.Name,
                Gender = cast.Gender,
                TmdbUrl = cast.TmdbUrl,
                ProfilePath = cast.ProfilePath,
                Movies = (IEnumerable<MovieResponseModel>)movie



            });



            return null;
        }


    }
}
