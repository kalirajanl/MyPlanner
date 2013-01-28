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
    public partial class BigRockEdit : PopupBasePage 
    {

        private string defaultDate = "";

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            switch (CurrentPageMode)
            {
                case PageMode.Add: { this.Title = Constants.APP_TITLE + " - Add Big Rock"; break; }
                case PageMode.Edit: { this.Title = Constants.APP_TITLE + " - Edit Big Rock"; break; }
                case PageMode.View: { this.Title = Constants.APP_TITLE + " - View Big Rock"; break; }
                default: { this.Title = Constants.APP_TITLE; break; }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                processQueryStrings();
                initPage();
                ddlCompassRoles.Focus();
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
        }

        private void initControls()
        {
            this.lblErrorText.Text = "";
            //this.txtItemID.Text = "";
            if (defaultDate.Trim().Equals(""))
            {
                this.txtCurrentDate.Text = DateTime.Today.ToString(Constants.DATE_FORMAT_STRING);
            }
            else
            {
                this.txtCurrentDate.Text = Convert.ToDateTime(defaultDate).ToString(Constants.DATE_FORMAT_STRING);
            }
            this.txtBigRockName.Text = "";
            this.ddlCompassRoles.DataSource = BLLCompassRole.GetCompassRoles(CurrentUser.UserID, false);
            this.ddlCompassRoles.DataTextField = "CompassRoleName";
            this.ddlCompassRoles.DataValueField = "CompassRoleID";
            this.ddlCompassRoles.DataBind();
            this.ddlCompassRoles.Items.Insert(0, new ListItem("<Select>", "0"));
            this.ddlCompassRoles.SelectedIndex = 0;
            this.btnCancel.Attributes.Add("onclick", "window.returnValue = 0;window.close();return false;");
        }

        private void loadControls()
        {
            long BigRockID = (long)Convert.ToDouble(this.txtItemID.Text);
            BigRock bigRock = BLLBigRock.GetBigRockByID(BigRockID);
            if (bigRock != null)
            {
                this.txtCurrentDate.Text = bigRock.ForWeek.ToString(Constants.DATE_FORMAT_STRING);
                this.txtBigRockName.Text = bigRock.BigRockName;

                this.ddlCompassRoles.ClearSelection();
                if (this.ddlCompassRoles.Items.FindByValue(bigRock.AsCompassRole.CompassRoleID.ToString()) != null)
                {
                    this.ddlCompassRoles.Items.FindByValue(bigRock.AsCompassRole.CompassRoleID.ToString()).Selected = true;
                }
                else
                {
                    this.ddlCompassRoles.SelectedIndex = 0;
                }
            }
        }

        private void processQueryStrings()
        {
            string BigRockID = "0";
            if (Request.QueryString["itemid"] != null)
            {
                BigRockID = Request.QueryString["itemid"].ToString();
            }
            this.txtItemID.Text = BigRockID;

            defaultDate = "";
            if (Request.QueryString["currentdate"] != null)
            {
                defaultDate = Request.QueryString["currentdate"].ToString();
            }
        }

        private bool isValidData()
        {
            bool returnValue = true;
            string errMessage = "";
            if (this.txtBigRockName.Text.Trim().Equals(""))
            {
                returnValue = false;
                errMessage = "Please enter Big Rock.";
                this.txtBigRockName.Focus();
            }
            else if (this.ddlCompassRoles.SelectedIndex <= 0)
            {
                returnValue = false;
                errMessage = "Please select Compass Role.";
                this.ddlCompassRoles.Focus();
            }
            this.lblErrorText.Text = errMessage;
            return returnValue;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (isValidData())
            {
                BigRock bigRock = new BigRock();
                try
                {
                    if (CurrentPageMode != PageMode.Add)
                    {
                        bigRock = BLLBigRock.GetBigRockByID((long)Convert.ToDecimal(this.txtItemID.Text));
                    }
                    bigRock.ForUser = new AppUser();
                    bigRock.ForUser.UserID = 1;
                    bigRock.AsCompassRole = BLLCompassRole.GetCompassRoleByID( Convert.ToInt32(this.ddlCompassRoles.SelectedValue));
                    bigRock.ForWeek = Convert.ToDateTime(this.txtCurrentDate.Text);
                    bigRock.BigRockName = this.txtBigRockName.Text;
                    if (CurrentPageMode == PageMode.Add)
                    {
                        BLLBigRock.AddBigRock(bigRock);
                        this.lblErrorText.Text = "Completed";
                    }
                    else if (CurrentPageMode == PageMode.Edit)
                    {
                        BLLBigRock.UpdateBigRock(bigRock);
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
                    ddlCompassRoles.Focus();
                }

            }
        }
    }
}