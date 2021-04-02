using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models.Response;
using ApplicationCore.Models.Request;
using ApplicationCore.ServiceInterfaces;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.Exceptions;
using AutoMapper;
using ApplicationCore.Entities;

namespace Infrastructure.Services 
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IAsyncRepository<Favorite> _favoriteRepository;
        private readonly IMapper _mapper;


        public MovieService(IMovieRepository movieRepository, IMapper mapper, IAsyncRepository<Favorite> favoriteRepository)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
            _favoriteRepository = favoriteRepository;

        }



        public async Task<List<MovieCardResponseModel>> Get30HighestGrossing()
        {
            var movies = await _movieRepository.GetTop30HighestGrossingMovies();

            var result = new List<MovieCardResponseModel>();

            foreach (var movie in movies)
            {
                result.Add(
                new MovieCardResponseModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl
                });
            }

            return result;
        }



        public void CreateMovie(MovieCreateRequestModel model)
        {
            // take model and convert it to Movie Entity and send it to repository
            // if repository saves successfully return true/id:2
        }

        //public async Task<MovieCdDetailsModel> GetMovieAsync(int id)
        //{
        //    var movies = await _movieRepository.GetByIdAsync(id);

        //    var result = new List<MovieCdDetailsModel>();

        //    foreach (var movie in movies)
        //    {
        //        result.Add(
        //        new MovieCardResponseModel
        //        {
        //            Id = movie.Id,
        //            Title = movie.Title,
        //            PosterUrl = movie.PosterUrl
        //        });
        //    }

        //    return result;
        //}

        public async Task<MovieDetailsResponseModel> GetMovieAsync(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            if (movie == null) throw new NotFoundException("Movie", id);
            var favoritesCount = await _favoriteRepository.GetCountAsync(f => f.MovieId == id);
            var response = _mapper.Map<MovieDetailsResponseModel>(movie);
            response.FavoritesCount = favoritesCount;
            return response;
        }



        //public async Task<MovieDetailsResponseModel> GetMovieAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}


