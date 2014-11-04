using SimpleLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogin.Authentications
{
    public interface IAuthentication
    {
        LoginModel Authenticate(string email, string password);
    }
}
