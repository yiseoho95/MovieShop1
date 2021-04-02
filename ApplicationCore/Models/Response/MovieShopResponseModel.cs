using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models.Response
{
    class MovieShopResponseModel
    {
    }

    public class UserRegisterResponseModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class UserProfileResponseModel
    {
    }

    public class UserLoginResponseModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public List<RoleModel> Roles { get; set; }
    }

    public class RoleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class PurchaseResponseModel
    {
        public int UserId { get; set; }
        public List<PurchasedMovieResponseModel> PurchasedMovies { get; set; }

        public class PurchasedMovieResponseModel : MovieResponseModel
        {
            public DateTime PurchaseDateTime { get; set; }
        }
    }


    public class MovieChartResponseModel
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int PurchaseCount { get; set; }
    }

    public class FavoriteResponseModel
    {
        public int UserId { get; set; }
        public List<FavoriteMovieResponseModel> FavoriteMovies { get; set; }

        public class FavoriteMovieResponseModel : MovieResponseModel
        {
        }
    }
  

    public class ReviewResponseModel
    {
        public int UserId { get; set; }
        public List<ReviewMovieResponseModel> MovieReviews { get; set; }
    }

    public class ReviewMovieResponseModel
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public string ReviewText { get; set; }
        public decimal Rating { get; set; }
        public string Name { get; set; }
    }
}
