using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyPlanner.Models;
using MyPlanner.BLL;

namespace MyPlanner.AppPages
{
    public partial class CompassRoles : DefaultBasePage 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string controlID = Page.Request.Params["__EVENTTARGET"];
                if (controlID.Trim().ToLower().Equals("deletecompassrole"))
                {
                    BLLCompassRole.DeleteCompassRole(Convert.ToInt32(this.hdnCompassRoleID.Value));
                }
            }
            initPage();
            this.hdnCompassRoleID.Value = "";
        }

        private void initPage()
        {
            List<CompassRole> MyCompassRoles = BLLCompassRole.GetCompassRoles(1,true);
            this.gvMyCompassRoles.DataSource = MyCompassRoles;
            this.gvMyCompassRoles.DataBind();
        }

        protected void gvMyCompassRoles_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (Convert.ToDecimal(e.Row.Cells[0].Text) > 0)
                    {
                        string ctrlID = "R" + e.Row.Cells[0].Text;
                        e.Row.Cells[1].Text = "<span id='" + ctrlID + "'>" + e.Row.Cells[1].Text + "</span>";
                        Page.RegisterStartupScript("scr" + ctrlID, "<script>" + this.ClientID + "showStatusMenu('" + ctrlID + "');</script>");
                    }
                }
        }
    }
}