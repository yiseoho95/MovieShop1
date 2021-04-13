using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTests
{
    [TestClass]
    public class MovieServiceUnitTest
    {
        private MovieService _sut;
        private static List<Movie> _movies;
        private Mock<IMovieRepository> _mockMovieRepository;

        [TestInitialize]
        //[OneTimeSetUp] in nUnit
        public void OneTimeSetup()
        {
            _mockMovieRepository = new Mock<IMovieRepository>();

            _sut = new MovieService(_mockMovieRepository.Object);
            _mockMovieRepository.Setup(m => m.GetTop30HighestGrossingMovies()).ReturnsAsync(_movies);

        }

        [ClassInitialize]
        public static void SetUp(TestContext context)
        { 
            _movies = new List<Movie>
            {
                new Movie{Id = 1, Title = "Avengers: Infinity War", Budget = 1200000},
                new Movie{Id = 2,Title = "Avatar", Budget = 1200000},
                new Movie{Id = 3, Title = "Star Wars: The Force Awakens", Budget = 1200000},
                new Movie{Id = 4, Title = "Titanic", Budget = 1200000},
                new Movie{Id = 5, Title = "Inception", Budget = 1200000},
                new Movie{Id = 6, Title = "Avengers Age of Ultron", Budget = 1200000},
                new Movie{Id = 7, Title = "Interstellar", Budget = 1200000},
                new Movie{Id = 8, Title = "Fight Club", Budget = 1200000},
                new Movie{Id = 9, Title = "The Lord of the Rings: The Fellowship of the Ring", Budget = 1200000},
                new Movie{Id = 10, Title = "The Dark Knight", Budget = 1200000},
                new Movie{Id = 11, Title = "The Hunger Games", Budget = 1200000},
                new Movie{Id = 12, Title = "Django Unchained", Budget = 120000},
                new Movie{Id = 13, Title = "The Lord of the Rings: The Return of the King", Budget = 1200000},
                new Movie{Id = 14, Title = "Harry Potter and the Philosopher's Stone", Budget = 1200000},
                new Movie{Id = 15, Title = "Iron Man", Budget = 1200000},
                new Movie{Id = 16, Title = "Furious 7", Budget = 1200000}
            };
           
        }


        [TestMethod]
        public async Task TestListOfHighestGrossingMoviesFromFakeData()
        {
            // SUT: system under Test. MovieService => Get30HighestGrossing
            //Check the actual output with the expected Data.
            //AAA
            //Arrange, Act, and Assert

            //Arrange
            // process of creating mock objects, data, methods ...etc.
            // This is our Dependency Injection point
            //_sut = new MovieService(new MockMovieRepository());

            //Act
            var movies = await _sut.Get30HighestGrossing();



            //Assert -- checking for actual values and comparing them
            Assert.IsNotNull(movies);
            Assert.IsInstanceOfType(movies,typeof(MovieResponseModel));
            Assert.AreEqual(16,movies.Count());
            

        }
    }

    public class MockMovieRepository : IMovieRepository
    {
        public Task<Movie> AddAsync(Movie entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Movie entity)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCountAsync(Expression<Func<Movie, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetExistAsync(Expression<Func<Movie, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Review>> GetMovieReviews(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> GetMoviesByGenre(int genreId, int pageSize = 25, int page = 1)
        {
            throw new NotImplementedException();
        }
        //-------------------------------
        public async Task<IEnumerable<Movie>> GetTop30HighestGrossingMovies()
        {
            // this method will get the fake data
            var _movies = new List<Movie>
            {
                new Movie{Id = 1, Title = "Avengers: Infinity War", Budget = 1200000},
                new Movie{Id = 2,Title = "Avatar", Budget = 1200000},
                new Movie{Id = 3, Title = "Star Wars: The Force Awakens", Budget = 1200000},
                new Movie{Id = 4, Title = "Titanic", Budget = 1200000},
                new Movie {Id = 5, Title = "Inception", Budget = 1200000},
                new Movie{Id = 6, Title = "Avengers Age of Ultron", Budget = 1200000},
                new Movie{Id = 7, Title = "Interstellar", Budget = 1200000},
                new Movie{Id = 8, Title = "Fight Club", Budget = 1200000},
                new Movie {Id = 9, Title = "The Lord of the Rings: The Fellowship of the Ring", Budget = 1200000},
                new Movie{ Id = 10, Title = "The Dark Knight", Budget = 1200000},
                new Movie{Id = 11, Title = "The Hunger Games", Budget = 1200000},
                new Movie{Id = 12, Title = "Django Unchained", Budget = 120000},
                new Movie{Id = 13, Title = "The Lord of the Rings: The Return of the King", Budget = 1200000},
                new Movie{Id = 14, Title = "Harry Potter and the Philosopher's Stone", Budget = 1200000},
                new Movie{Id = 15, Title = "Iron Man", Budget = 1200000},
                new Movie{Id = 16, Title = "Furious 7", Budget = 1200000}
            };
            return _movies;
        }

        public Task<IEnumerable<Movie>> GetTopRatedMovies()
        {
            throw new NotImplementedException();
        }

        //-------------------------------------------------------------------
        public Task<IEnumerable<Movie>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> ListAsync(Expression<Func<Movie, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> UpdateAsync(Movie entity)
        {
            throw new NotImplementedException();
        }
    }
}
