using SharedTrip.Data;
using SharedTrip.Models.Users;
using SharedTrip.Services.Users;
using SharedTrip.Services.Validator;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            if (IsUserLoggedIn())
            {
                return this.Redirect("/Trips/All");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(InputUserModel input)
        {
            var userId = this.usersService.GetUserId(input.Username, input.Password);
            if (userId != null)
            {
                this.SignIn(userId);
                return this.Redirect("/Trips/All");
            }

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Register()
        {
            if (IsUserLoggedIn())
            {
                return this.Redirect("/Trips/All");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(InputUserRegistrationModel input)
        {
            if (string.IsNullOrWhiteSpace(input.Email))
            {
                return this.Redirect("/Users/Register");
            }

            if (input.Password.Length < DataConstants.UserPasswordMinLength || input.Password.Length > DataConstants.UserPasswordMaxLength)
            {
                return this.Redirect("/Users/Register");
            }

            if (input.Username.Length < DataConstants.UsernameMinLenght || input.Username.Length > DataConstants.UsernameMaxLenght)
            {
                return this.Redirect("/Users/Register");
            }

            if (input.Password != input.ConfirmPassword)
            {
                return this.Redirect("/Users/Register");
            }

            if (this.usersService.EmailExists(input.Email))
            {
                return this.Redirect("/Users/Register");
            }

            if (this.usersService.UsernameExists(input.Username))
            {
                return this.Redirect("/Users/Register");
            }

            this.usersService.Register(input.Username, input.Email, input.Password);
            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            this.SignOut();
            return this.Redirect("/");
        }
    }



    
}
