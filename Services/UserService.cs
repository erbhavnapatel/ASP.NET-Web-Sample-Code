using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerOrderWebApplication.Services
{
    public class UserService : IUserService
    {
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        public bool ValidateCredentials(string userid, string username, string password)
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
        {
            return userid.Equals("U854") && username.Equals("user1") && password.Equals("Pa$$WoRd");
        }
    }
}
