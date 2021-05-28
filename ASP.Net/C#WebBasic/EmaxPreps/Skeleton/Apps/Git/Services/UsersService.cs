using Git.Data;
using Git.Data.Models;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Git.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public string CreateUser(string username, string email, string password)
        {
            User user = new User
            {
                Id = Guid.NewGuid().ToString(),
                Username = username,
                Email = email,
                Password = this.Hash(password),
                Role = IdentityRole.User
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();

            return user.Username;
        }

        public string GetUsername(string id)
        {
            var username = this.db.Users
                .Where(x => x.Id == id)
                .Select(x => x.Username)
                .FirstOrDefault();
            return username;
        }

        public string GetUserId(string username, string password)
        {
            var hashPass = this.Hash(password);
            var user = this.db.Users.FirstOrDefault(x => x.Username == username && x.Password == hashPass);

            if(user == null)
            {
                return null;
            }

            return user.Id;
        }

        public bool IsEmailAvailable(string email)
        {
            return this.db.Users.Any(x => x.Email == email);
        }

        public bool IsUsernameAvailable(string username)
        {
            return this.db.Users.Any(x => x.Username == username);
        }

        private string Hash(string input)
        {
            if (input == null)
            {
                return null;
            }

            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}
