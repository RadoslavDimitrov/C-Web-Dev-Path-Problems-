using Git.Data.ViewModels;
using Git.Services;
using Git.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Controllers
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
            if (IsUserSignedIn())
            {
                return this.Redirect("/Repositories/All");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginUserInputModel model)
        {
            var userId = this.usersService.GetUserId(model.Username, model.Password);
            if(userId != null)
            {
                this.SignIn(userId);
                return this.Redirect("/Repositories/All");
            }

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Register()
        {
            if (IsUserSignedIn())
            {
                return this.Redirect("/Repositories/All");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterUserInputModel input)
        {
            if (string.IsNullOrWhiteSpace(input.Email))
            {
                return this.Error("Email cannot be empty!");
            }

            if (input.Password.Length < 6 || input.Password.Length > 20)
            {
                return this.Error("Password must be at least 6 characters and at most 20");
            }

            if (input.Username.Length < 5 || input.Username.Length > 20)
            {
                return this.Error("Username must be at least 4 characters and at most 20");
            }

            if (input.Password != input.ConfirmPassword)
            {
                return this.Error("Password should match.");
            }

            if (this.usersService.IsEmailAvailable(input.Email))
            {
                return this.Error("Email already in use.");
            }

            if (this.usersService.IsUsernameAvailable(input.Username))
            {
                return this.Error("Username already in use.");
            }

            this.usersService.CreateUser(input.Username, input.Email, input.Password);

            return this.Redirect("/Users/Login");
        }


        public HttpResponse Logout()
        {
            this.SignOut();

            return this.Redirect("/");
        }
    }
}
