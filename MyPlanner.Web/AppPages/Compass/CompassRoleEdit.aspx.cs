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
    public partial class CompassRoleEdit : PopupBasePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            switch (CurrentPageMode)
            {
                case PageMode.Add: { this.Title = Constants.APP_TITLE + " - Add Compass Role"; break; }
                case PageMode.Edit: { this.Title = Constants.APP_TITLE + " - Edit Compass Role"; break; }
                case PageMode.View: { this.Title = Constants.APP_TITLE + " - View Compass Role"; break; }
                default: { this.Title = Constants.APP_TITLE; break; }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                processQueryStrings();
                initPage();
            }
            this.lblErrorText.Text = "&nbsp;";
        }

        private void initPage()
        {
            initControls();
            if (!this.txtItemID.Text.Trim().Equals(""))
            {
                loadControls();
            }
            this.txtRoleName.Focus();
        }

        private void initControls()
        {
            this.lblErrorText.Text = "";
            this.txtRoleName.Text = "";
            this.txtNotes.Text = "";

            this.btnCancel.Attributes.Add("onclick", "window.returnValue = 0;window.close();return false;");
        }

        private void loadControls()
        {
            int roleID = Convert.ToInt32(this.txtItemID.Text);
            CompassRole CompassRole = BLLCompassRole.GetCompassRoleByID(roleID);
            if (CompassRole != null)
            {
                this.txtItemID.Text = roleID.ToString();
                this.txtRoleName.Text = CompassRole.CompassRoleName;
                this.txtNotes.Text = CompassRole.Notes;
            }
        }

        private void processQueryStrings()
        {
            string taskID = "0";
            if (Request.QueryString["itemid"] != null)
            {
                taskID = Request.QueryString["itemid"].ToString();
            }
            this.txtItemID.Text = taskID;
        }

        private bool isValidData()
        {
            bool returnValue = true;
            string errMessage = "";
            if (this.txtRoleName.Text.Trim().Equals(""))
            {
                returnValue = false;
                errMessage = "Please enter Role Name.";
                this.txtRoleName.Focus();
            }
            this.lblErrorText.Text = errMessage;
            return returnValue;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (isValidData())
            {
                try
                {
                    CompassRole compassRole = new CompassRole();
                    if (CurrentPageMode != PageMode.Add)
                    {
                        compassRole = BLLCompassRole.GetCompassRoleByID(Convert.ToInt32(this.txtItemID.Text));
                    }
                    compassRole.CompassRoleName = this.txtRoleName.Text;
                    compassRole.Notes = this.txtNotes.Text;
                    compassRole.ForUser = CurrentUser;

                    if (CurrentPageMode == PageMode.Add)
                    {
                        BLLCompassRole.AddCompassRole(compassRole);
                        this.lblErrorText.Text = "Completed";
                    }
                    else if (CurrentPageMode == PageMode.Edit)
                    {

                        BLLCompassRole.UpdateCompassRole(compassRole);
                        this.lblErrorText.Text = "Completed";
                    }
                    else
                    {
                        throw new Exception("Invalid Action");
                    }
                    string script = "<script language='javascript' type='text/javascript'>window.returnValue = 1;;window.close();</script>";

                    Page.RegisterClientScriptBlock("closescript", script);
                }
                catch (Exception ex)
                {
                    this.lblErrorText.Text = ex.Message;
                    this.txtRoleName.Focus();
                }
            }
        }
    }
}