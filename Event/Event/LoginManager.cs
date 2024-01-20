using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event
{
 
    public class LoginManager
    {
        public delegate void Handler(User user);
        public event Handler UserLoginSuccessfully;
        public void LoginUser(User user)
        {
            if (!user.Email.EndsWith("@Google.com")) return;
            OnUserLoginSuccess(user);


        }
        public void OnUserLoginSuccess(User user)
        {
            if (UserLoginSuccessfully != null)

                UserLoginSuccessfully.Invoke(user);
        }
    }
}
