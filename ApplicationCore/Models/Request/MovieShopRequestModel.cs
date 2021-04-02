using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ApplicationCore.Entities;
//using ApplicationCore.Validations;

namespace ApplicationCore.Models.Request
{
    class MovieShopRequestModel
    {
    }
    public class UserRegisterRequestModel
    {
        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{8,}$", ErrorMessage =
            "Password Should have minimum 8 with at least one upper, lower, number and special character")]
        public string Password { get; set; }

        [StringLength(50)] public string FirstName { get; set; }

        [StringLength(50)] public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }

    public class UserProfileRequestModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public string ProfilePictureUrl { get; set; }
        // public IFormFile File { get; set; }
    }

    public class ReviewRequestModel
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public string ReviewText { get; set; }
        public decimal Rating { get; set; }
    }
    public class LoginRequestModel
    {
        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class FavoriteRequestModel
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
    }

    public class PurchaseRequestModel
    {
        public PurchaseRequestModel()
        {
            PurchaseDateTime = DateTime.Now;
            PurchaseNumber = Guid.NewGuid();
        }

        public int UserId { get; set; }
        public Guid? PurchaseNumber { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime? PurchaseDateTime { get; set; }
        public int MovieId { get; set; }
    }
}
