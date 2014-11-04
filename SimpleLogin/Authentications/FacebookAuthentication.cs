using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleLogin.Authentications
{
    public class FacebookAuthentication : IAuthentication
    {
        public Models.LoginModel Authenticate(string email, string password)
        {
            return new Models.LoginModel()
            {
                Email = email,
                Password = password,
                Source = "Facebook"
            };
        }
    }
}