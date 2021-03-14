using Cw.PayslipService.Interfaces;
using Cw.PayslipService.Models;
using Cw.Platform.Jwt;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw.PayslipService.Services
{
    public class UserService : IUserService
    {
        private readonly IJwtProvider _jwtProvider = new JwtProvider(null, null);

        // users should be stored in DB and passwords encrypted
        private List<User> _users = new List<User>
        {
            new User { Id = 1, FirstName = "John", LastName = "Smith", Username = "admin", Password = "admin", UserRole = Role.Admin },
            new User { Id = 2, FirstName = "Jane", LastName = "Smith", Username = "user", Password = "user", UserRole = Role.User }
        };

        public string Authenticate(LoginRequest request)
        {
            var appUser = _users.SingleOrDefault(x => x.Username == request.Username && x.Password == request.Password);

            //return null if user is not available
            if (appUser == null)
            {
                return null;
            }

            //generate jwt token
            var token = _jwtProvider.generateJwtToken(appUser.UserRole);

            return token;
        }

        public User GetUserById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

    }

}
