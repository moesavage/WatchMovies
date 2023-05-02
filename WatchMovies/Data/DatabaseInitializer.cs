using System;
using System.Xml.Linq;
using WatchMovies.Models;
using WatchMovies.Models.Domain;
using static System.Net.WebRequestMethods;

namespace WatchMovies.Data
{
	public class DatabaseInitializer
	{
		public static void seed(IApplicationBuilder applicationBuilder) 
		{
			using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetService<DatabaseContext>();

				context.Database.EnsureCreated();

				//Actors
				if (!context.Actors.Any())
				{
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName = "Actor 1",
                            Bio = "Bio of the first actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-1.jpeg"

                        },
                        new Actor()
                        {
                            FullName = "Actor 2",
                            Bio = "Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 3",
                            Bio = "Bio of the third actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 4",
                            Bio = "Bio of the fourth actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 5",
                            Bio = "Bio of the fifth actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                //Producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName = "Producer 1",
                            Bio = "Bio of the first producer",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-1.jpeg"

                        },
                        new Producer()
                        {
                            FullName = "Producer 2",
                            Bio = "Bio of the second producer",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-2.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 3",
                            Bio = "Bio of the third producer",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-3.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 4",
                            Bio = "Bio of the fourth producer",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-4.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 5",
                            Bio = "Bio of the fifth producer",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                //Movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "Life",
                            Description = "This is the Life movie description",
                            ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            Duration = "1hr 30m",
                            ProducerId = 3,
                            MovieCategory = MovieCategory.SciFi | MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "The Shawshank Redemption",
                            Description = "This is the Shawshank Redemption description",
                            ImageURL = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            Duration = "3hr 30m",
                            ProducerId = 1,
                            MovieCategory = MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "Ghost",
                            Description = "This is the Ghost movie description",
                            ImageURL = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            Duration = "1hr 55m",
                            ProducerId = 4,
                            MovieCategory = MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "Race",
                            Description = "This is the Race movie description",
                            ImageURL = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            Duration = "1hr 30m",
                            ProducerId = 2,
                            MovieCategory = MovieCategory.Comedy | MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "Scoob",
                            Description = "This is the Scoob movie description",
                            ImageURL = "http://dotnethow.net/images/movies/movie-7.jpeg",
                            Duration = "1hr 30m",
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Cartoon
                        },
                        new Movie()
                        {
                            Name = "Cold Soles",
                            Description = "This is the Cold Soles movie description",
                            ImageURL = "http://dotnethow.net/images/movies/movie-8.jpeg",
                            Duration = "3hr 10m",
                            ProducerId = 5,
                            MovieCategory = MovieCategory.Comedy | MovieCategory.Action
                        },

                        new Movie()
                        {
                            Name = "Toy Story",
                            Description = "This is the Toy Story movie description",
                            ImageURL = "https://dotnethow.net/images/movies/movie-9.jpeg",
                            Duration = "2hr 30m",
                            ProducerId = 5,
                            MovieCategory = MovieCategory.Cartoon
                        },

                        new Movie()
                        {
                            Name = "Public Enemies",
                            Description = "This is the Public Enemies movie description",
                            ImageURL = "https://dotnethow.net/images/movies/movie-10.jpeg",
                            Duration = "2hr 45m",
                            ProducerId = 5,
                            MovieCategory = MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "No Country for Old Men",
                            Description = "This is the No Country for Old Men movie description",
                            ImageURL = "https://dotnethow.net/images/movies/movie-2.jpeg",
                            Duration = "2hr 30m",
                            ProducerId = 5,
                            MovieCategory = MovieCategory.Action | MovieCategory.Family
                        }

                    });
                    context.SaveChanges();
                }
                //Actore & Movies
                if (context.Actors_Movies.Any())
                {
                    context.Actors_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 1
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 1
                        },

                         new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 2
                        },
                         new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 2
                        },

                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 4
                        },


                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 5
                        },


                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 6
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 9
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 8
                        },


                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 7
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 6
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 6
                        },
                    });
                    context.SaveChanges();
                }
            }
		}
	}
}

