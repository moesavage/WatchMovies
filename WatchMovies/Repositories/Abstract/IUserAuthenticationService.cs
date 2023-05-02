using System;
using System.Net.NetworkInformation;
using WatchMovies.Models.DTO;

namespace WatchMovies.Repositories.Abstract
{
	
     public interface IUserAuthenticationService
     {
            Task<Status> LoginAsync(LoginModel model);

            Task<Status> RegisterAsync(RegistrationModel model);

            Task LogoutAsync();

     }
   
}

