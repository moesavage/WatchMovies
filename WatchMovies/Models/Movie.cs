using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WatchMovies.Data;
using WatchMovies.Data.Base;

namespace WatchMovies.Models
{
	public class Movie : IEntityBase
	{
		[Key]

		public int Id  { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

        public string ImageURL { get; set; }

		public string Duration { get; set; }

		public MovieCategory MovieCategory { get; set; }

		// Relationships

		public List<Actor_Movie> Actors_Movies { get; set; }

        //Producer

        public int ProducerId { get; set; }
		[ForeignKey("ProducerId")]

        public Producer Producer { get; set; }
    }
}

