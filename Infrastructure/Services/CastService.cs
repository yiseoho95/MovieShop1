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
        private readonly IAsyncRepository<Cast> _castRepository;

        public CastService(IAsyncRepository<Cast> castRepository)
        {
            _castRepository = castRepository;
        }
        public async Task<CastDetailsResponseModel> GetCastDetailsWithMovies(int id)
        {
            var cast = await _castRepository.GetByIdAsync(id);
            var castMovies = new List<MovieResponseModel>();
            foreach (var movie in cast.MovieCasts)
            {
                castMovies.Add(new MovieResponseModel()
                {
                    Id = movie.MovieId,
                    PosterUrl = movie.Movie.PosterUrl,
                    Title = movie.Movie.Title
                });
            }



            CastDetailsResponseModel castDetailResponseModel = new CastDetailsResponseModel();
            var response = castDetailResponseModel;
            response.Id = cast.Id;
            response.Name = cast.Name;
            response.Gender = cast.Gender;
            response.TmdbUrl = cast.TmdbUrl;
            response.ProfilePath = cast.ProfilePath;
            response.Movies = castMovies;



            return response;
        }


    }
}
