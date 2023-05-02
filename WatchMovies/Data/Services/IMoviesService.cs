using WatchMovies.Data.Base;
using WatchMovies.Data.ViewModels;
using WatchMovies.Models;
using WatchMovies.Data.Base;
using WatchMovies.Data.ViewModels;
using WatchMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WatchMovies.Data.Services
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdown> GetNewMovieDropdownsValues();
        Task AddNewMovieAsync(NewMovieVM data);
        Task UpdateMovieAsync(NewMovieVM data);
    }
}
