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
    public partial class WeeklyCompass : BaseUserControl 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                processQueryStrings();
            }
            else
            {
                string controlID = Page.Request.Params["__EVENTTARGET"];
                if (controlID.Trim().ToLower().Equals("deletebigrock"))
                {
                    BLLBigRock.DeleteBigRock((long)Convert.ToDecimal(this.hdnBigRockID.Value));
                }
                
            }
            initPageForToday();
        }

        private void processQueryStrings()
        {
            if (Request.QueryString["swwo"] != null)
            {
                this.hdnShowWorkWeekOnly.Value = true.ToString();
            }
            else
            {
                this.hdnShowWorkWeekOnly.Value = false.ToString();
            }
        }

        private void initPageForToday()
        {
            initPage(DateTime.Today);
        }

        public DateTime CurrentDate
        {
            get
            {
                if (this.hdnCurrentDate.Value.Trim().Equals(""))
                {
                    this.hdnCurrentDate.Value = DateTime.Today.ToString(Constants.DATE_FORMAT_STRING);
                    return DateTime.Today;
                }
                else
                {
                    return Convert.ToDateTime(this.hdnCurrentDate.Value);
                }
            }
            set
            {
                this.hdnCurrentDate.Value = value.ToString(Constants.DATE_FORMAT_STRING);
                initPage(value);
            }
        }

        public bool ShowWorkWeekOnly
        {
            get
            {
                if (this.hdnShowWorkWeekOnly.Value.Trim().Equals(""))
                {
                    this.hdnShowWorkWeekOnly.Value = false.ToString();
                    return false;
                }
                else
                {
                    return Convert.ToBoolean(this.hdnShowWorkWeekOnly.Value);
                }
            }
            set
            {
                this.hdnShowWorkWeekOnly.Value = value.ToString();
                initPage(Convert.ToDateTime(this.hdnCurrentDate.Value));
            }
        }

        private void initPage(DateTime fortheDate)
        {

            DateTime forDate = MyPlannerValidators.StartOfWeek(fortheDate, DayOfWeek.Monday);
            this.hdnCurrentDate.Value = forDate.ToString(Constants.DATE_FORMAT_STRING);
            this.gvMyWeeklyCompass.DataSource = BLLBigRock.GetBigRocks(CurrentUser.UserID, Convert.ToDateTime(this.hdnCurrentDate.Value), false);
            this.gvMyWeeklyCompass.AutoGenerateColumns = false;
            this.gvMyWeeklyCompass.DataBind();
            
        }

        private string getDayTitle(DateTime forDate)
        {
            return forDate.ToString(Constants.DATE_TITLE_FORMAT_STRING);
        }


        protected void gvMyWeeklyCompass_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}