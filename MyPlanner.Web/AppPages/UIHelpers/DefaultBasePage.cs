using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyPlanner.Models;
using MyPlanner.BLL;

namespace MyPlanner.AppPages
{
    public class DefaultBasePage : System.Web.UI.Page
    {

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            this.Title = Constants.APP_TITLE;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Page.RegisterClientScriptBlock("DUMMY", "<script language='javascript'>function dummy() { " + this.Page.GetPostBackEventReference(this) + "; } </script>");

        }

        protected void showErrorMessageAsAlert(string message)
        {
            string sbScript = "<script language='javascript' type='text/javascript'>";
            sbScript += "alert('" + message.Trim().Replace("'", "''");
            sbScript += "</script>";

            Page.RegisterStartupScript("alert", sbScript);
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
                    case "add": { currentPageMode = PageMode.Add; break; }
                    case "edit": { currentPageMode = PageMode.Edit; break; }
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