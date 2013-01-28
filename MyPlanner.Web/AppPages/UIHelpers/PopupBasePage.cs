using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyPlanner.Models;
using MyPlanner.BLL;

namespace MyPlanner.AppPages
{
    public class PopupBasePage : System.Web.UI.Page
    {

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            this.Title = Constants.APP_TITLE;
        }

        protected PageMode CurrentPageMode
        {
            get
            {
                PageMode currentPageMode;
                string mode = "View";
                if (Request.QueryString["mode"] != null)
                {
                    mode = Request.QueryString["mode"].ToString();
                }
                mode = mode.Trim().ToLower();
                switch (mode)
                {
                    case "add":
                    case "addmission":
                    case "addvalue": { currentPageMode = PageMode.Add; break; }
                    case "forward": { currentPageMode = PageMode.Forward; break; }
                    case "edit":
                    case "editmission":
                    case "editvalue": { currentPageMode = PageMode.Edit; break; }
                    default: { currentPageMode = PageMode.View; break; }
                }
                return currentPageMode;
            }
            set { }
        }

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