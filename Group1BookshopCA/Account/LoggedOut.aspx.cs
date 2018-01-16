using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group1BookshopCA.Account
{
    public partial class LoggedOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Abandon();
            Session["user"] = "logged out";
            Session["cart"] = new List<GVI>();

            Session["books"] = new List<Book>();
        }
    }
}