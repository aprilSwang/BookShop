﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Group1BookshopCA.Logic;

namespace Group1BookshopCA
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            RoleActions roleActions = new RoleActions();
            roleActions.AddUserandRole();
        }
        void Session_Start(object sender, EventArgs e)
        {
            Session["cart"]= new List<GVI>();

            Session["books"] = new List<Book>();

            Session["user"] = "logged out";
        }
    }
}