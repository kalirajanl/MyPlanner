using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using MyPlanner.Models;
using MyPlanner.BLL;
using MyPlanner;

namespace MyPlanner.AppPages
{
    public partial class DailyView : DefaultBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                initPageForToday();
            }
            else
            {
                //string controlID = Page.Request.Params["__EVENTTARGET"];
                //if (controlID.Trim().ToLower().Equals("deletetask"))
                //{
                //    BLLTask.DeleteTask((long)Convert.ToDecimal(this.hdnTaskID.Value));
                //}
                //else if (controlID.Trim().ToLower().Equals("updatetaskstatus"))
                //{
                //    BLLTask.UpdateTaskStatus((long)Convert.ToDecimal(this.hdnTaskID.Value), (TaskStatuses)Convert.ToInt32(this.hdnTaskStatusID.Value));
                //}
                //initPage(Convert.ToDateTime(this.hdnCurrentDate.Value));
            }
            //this.hdnTaskID.Value = "";
        }


        private void initPageForToday()
        {
            initPage(DateTime.Now.AddDays(+1));
        }

        private void initPage(DateTime forDate)
        {

            this.lblSelectedDay.Attributes.Add("onclick", "return showCalendar()");

            this.hdnCurrentDate.Value = forDate.ToString(Constants.DATE_FORMAT_STRING);

            this.lblSelectedDay.Text = forDate.Day.ToString();
            this.lblDay.Text = forDate.DayOfWeek.ToString();
            this.lblMonth.Text = forDate.ToString(Constants.MONTH_FORMAT_FULL);
            this.lblYear.Text = forDate.Year.ToString();

            this.TaskListing1.CurrentDate = forDate;

        //    List<Task> MyTasks = BLLTask.GetTasks(1, null, forDate);

        //    this.gvMyTasks.DataSource = MyTasks;
        //    this.gvMyTasks.DataBind();

            this.txtNotes.Text = "";

        // //   this.calForDate.OnClientDateChanged = "onDateChange";
        }

        protected void calForDate_OnDateChanged(object sender, EventArgs e)
        {
            initPage(this.calForDate.SelectedDate);
        }

    }

}