using Cw.PayslipService.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw.PayslipService.Interfaces
{
    public interface IUserService
    {
        string Authenticate(LoginRequest request);
        public User GetUserById(int id);
    }
}
