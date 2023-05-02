using System;
using System.ComponentModel.DataAnnotations;

namespace WatchMovies.Models
{
	public class Actor
	{
		[Key]
		public int Id { get; set; }

		[Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile Picture is required")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Full Name must be between 2 and 50 chars")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required")]
        public string Bio { get; set; }

		//Relationship

		public List<Actor_Movie> Actors_Movies { get; set; }
    }
}

