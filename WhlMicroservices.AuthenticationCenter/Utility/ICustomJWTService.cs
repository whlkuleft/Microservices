using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhlMicroservices.AuthenticationCenter
{
    public interface ICustomJWTService
    {
        string GetToken(string UserName, string password, User user);
    }
}
