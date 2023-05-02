using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using WatchMovies.Data;
using WatchMovies.Models;

namespace WatchMovies.Data.ViewModels

{
    public class NewMovieDropdown
    {
        public NewMovieDropdown()
        {
            Producers = new List<Producer>();
            Actors = new List<Actor>();
        }

        public List<Producer> Producers { get; set; }
        public List<Actor> Actors { get; set; }

    }
}