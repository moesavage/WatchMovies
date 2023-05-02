using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchMovies.Models.DTO;
using WatchMovies.Repositories.Abstract;

namespace WatchMovies.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private readonly IUserAuthenticationService _service;

        public UserAuthenticationController(IUserAuthenticationService service)
        {
            this._service = service;
        }

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            model.Role = "user";
            var result = await _service.RegisterAsync(model);
            TempData["msg"] = result.Message;
            return RedirectToAction(nameof(Registration));

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _service.LoginAsync(model);
            if (result.StatusCode == 1)
            {
                return RedirectToAction("Index", "Movies");
            }
            else
            {
                TempData["msg"] = result.Message;
                return RedirectToAction(nameof(Login));
            }
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _service.LogoutAsync();
            return RedirectToAction("Index", "Movies");
        }

        //public async Task<IActionResult> Reg()
        //{
        //    var model = new RegistrationModel
        //    {
        //        Username = "admin1",
        //        FirstName = "Moro",
        //        LastName = "savage",
        //        Email = "morosavage@gmail.com",
        //        Password = "Admin@1234"
        //    };
        //    model.Role = "admin";
        //    var result = await _service.RegisterAsync(model);
        //    TempData["msg"] = result.Message;
        //    return Ok(result);
        //}
    }

}

