using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyPlanner.Models;

namespace MyPlanner.AppPages
{
    public partial class WeeklyView : DefaultBasePage 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                processQueryStrings();
                initPageForToday();
            }
        }

        private void initPageForToday()
        {
            if (this.hdnCurrentDate.Value.Trim().Equals(""))
            {
                initPage(DateTime.Today);
            }
            else
            {
                initPage(Convert.ToDateTime(this.hdnCurrentDate.Value));
            }
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
            if (Request.QueryString["currentdate"] != null)
            {
                this.hdnCurrentDate.Value = Request.QueryString["currentdate"].ToString();
            }
            else
            {
                this.hdnCurrentDate.Value = "";
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
                initPage(this.calForDate.SelectedDate);
            }
        }

        private void initPage(DateTime fortheDate)
        {
            DateTime forDate = MyPlannerValidators.StartOfWeek(fortheDate, DayOfWeek.Monday);
            this.hdnCurrentDate.Value = forDate.ToString(Constants.DATE_FORMAT_STRING);
            this.calForDate.SelectedDate = forDate;

            if (ShowWorkWeekOnly)
            {
                this.lblDay.Text = forDate.ToString(Constants.DATE_FORMAT_STRING) + " - " + forDate.AddDays(4).ToString(Constants.DATE_FORMAT_STRING);
            }
            else
            {
                this.lblDay.Text = forDate.ToString(Constants.DATE_FORMAT_STRING) + " - " + forDate.AddDays(6).ToString(Constants.DATE_FORMAT_STRING);
            }
            
            this.WeekView1.CurrentDate = forDate;
        }

        protected void calForDate_OnDateChanged(object sender, EventArgs e)
        {
            initPage(this.calForDate.SelectedDate);
        }
    }
}