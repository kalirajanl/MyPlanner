using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyPlanner.Models;
using MyPlanner.BLL;

namespace MyPlanner.AppPages.Calendar
{
    public partial class WeekView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                processQueryStrings();
                initPageForToday();
            }
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
                initPage(Convert.ToDateTime(this.hdnCurrentDate.Value));
            }
        }

        private void initPage(DateTime fortheDate)
        {

            DateTime forDate = MyPlannerValidators.StartOfWeek(fortheDate, DayOfWeek.Monday);
            this.hdnCurrentDate.Value = forDate.ToString(Constants.DATE_FORMAT_STRING);

            this.TaskListing1.ShowPriority = false;
            this.TaskListing1.ShowStatus = false;
            this.TaskListing1.CurrentDate = forDate;
            this.lblDayTitle1.Text = getDayTitle(forDate);
            this.TaskListing2.ShowPriority = false;
            this.TaskListing2.ShowStatus = false;
            this.TaskListing2.CurrentDate = forDate.AddDays(1);
            this.lblDayTitle2.Text = getDayTitle(forDate.AddDays(1));
            this.TaskListing3.ShowPriority = false;
            this.TaskListing3.ShowStatus = false;
            this.TaskListing3.CurrentDate = forDate.AddDays(2);
            this.lblDayTitle3.Text = getDayTitle(forDate.AddDays(2));
            this.TaskListing4.ShowPriority = false;
            this.TaskListing4.ShowStatus = false;
            this.TaskListing4.CurrentDate = forDate.AddDays(3);
            this.lblDayTitle4.Text = getDayTitle(forDate.AddDays(3));
            this.TaskListing5.ShowPriority = false;
            this.TaskListing5.ShowStatus = false;
            this.TaskListing5.CurrentDate = forDate.AddDays(4);
            this.lblDayTitle5.Text = getDayTitle(forDate.AddDays(4));
            this.TaskListing6.ShowPriority = false;
            this.TaskListing6.ShowStatus = false;
            if (!ShowWorkWeekOnly)
            {
                this.TaskListing6.CurrentDate = forDate.AddDays(5);
                this.lblDayTitle6.Text = getDayTitle(forDate.AddDays(5));
                this.TaskListing7.ShowPriority = false;
                this.TaskListing7.ShowStatus = false;
                this.TaskListing7.CurrentDate = forDate.AddDays(6);
                this.lblDayTitle7.Text = getDayTitle(forDate.AddDays(6));
            }
        }

        private string getDayTitle(DateTime forDate)
        {
            return forDate.ToString(Constants.DATE_TITLE_FORMAT_STRING);
        }
    }
}