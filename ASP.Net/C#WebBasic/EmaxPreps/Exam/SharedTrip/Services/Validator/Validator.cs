using SharedTrip.Models.Users;
using SharedTrip.Services.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Services.Validator
{
    public class Validator : IValidator
    {
        public bool ValidateUser(InputUserRegistrationModel model, IUsersService usersService)
        {

            if (model.Username.Length < 5 || model.Username.Length > 20)
            {
                return false;
            }

            if (String.IsNullOrEmpty(model.Email))
            {
                return false;
            }

            if (model.Password.Length < 6 || model.Password.Length > 20)
            {
                return false;
            }

            if (model.Password != model.ConfirmPassword)
            {
                return false;

            }


            return true;
        }

    }
}
