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


    public class UserProfileResponseModel
    {
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
