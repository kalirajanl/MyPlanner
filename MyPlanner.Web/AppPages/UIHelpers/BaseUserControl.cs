using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyPlanner.Models;
using MyPlanner.BLL;

namespace MyPlanner.AppPages
{
    public class BaseUserControl : System.Web.UI.UserControl
    {
        protected AppUser CurrentUser
        {
            get
            {
                AppUser currentUser = new AppUser();
                currentUser = BLLAppUser.GetUserByID(1);
                return currentUser;
            }
            set { }
        }

    }
}