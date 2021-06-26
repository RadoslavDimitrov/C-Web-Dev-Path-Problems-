using SharedTrip.Models.Users;
using SharedTrip.Services.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Services.Validator
{
    public interface IValidator
    {
        bool ValidateUser(InputUserRegistrationModel model, IUsersService usersService);
    }
}
