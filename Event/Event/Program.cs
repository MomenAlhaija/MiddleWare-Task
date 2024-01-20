using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User("Ahmad","Abu Alhaija","haija2@Google.com");
            LoginManager loginManager=new LoginManager();
            loginManager.UserLoginSuccessfully += LoginManager_UserLoginSuccess;
            loginManager.LoginUser(user);
        }

        private static void LoginManager_UserLoginSuccess(User user)
        {
            Console.WriteLine("Login Success");
        }
    }
}
