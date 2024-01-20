using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebSockets;

namespace WebForm2
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie Cook = new HttpCookie("Login");
            Cook.Values.Add("User", "Momen");
            Cook.Values.Add("pass", "0123848");
            Cook.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Add( Cook );
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["Name"] != null){
                Response.Write(Request.QueryString["Name"]);
            }
        }
    }
}