using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using MyPlanner.Models;
using MyPlanner.BLL;

namespace MyPlanner.AppPages
{
    public partial class TaskListing : BaseUserControl 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string controlID = Page.Request.Params["__EVENTTARGET"];
                if (controlID.Trim().ToLower().Equals("deletetask"))
                {
                    BLLTask.DeleteTask((long)Convert.ToDecimal(this.hdnTaskID.Value));
                }
                else if (controlID.Trim().ToLower().Equals("updatetaskstatus"))
                {
                    if ((!this.hdnTaskID.Value.Trim().Equals("")) && (!this.hdnTaskStatusID.Value.Trim().Equals("")))
                    {
                        BLLTask.UpdateTaskStatus((long)Convert.ToDecimal(this.hdnTaskID.Value), (TaskStatuses)Convert.ToInt32(this.hdnTaskStatusID.Value));
                    }
                }
                initPage(Convert.ToDateTime(this.hdnCurrentDate.Value));
            }
            this.hdnTaskID.Value = "";
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

        public bool ShowPriority
        {
            get
            {
                if (this.hdnShowPriority.Value.Trim().Equals(""))
                {
                    this.hdnShowPriority.Value = true.ToString();
                    return true;
                }
                else
                {
                    return Convert.ToBoolean(this.hdnShowPriority.Value);
                }
            }
            set
            {
                this.hdnShowPriority.Value = value.ToString();
                this.gvMyTasks.Columns[2].Visible = value;
            }
        }

        public bool ShowStatus
        {
            get
            {
                if (this.hdnShowStatus.Value.Trim().Equals(""))
                {
                    this.hdnShowStatus.Value = true.ToString();
                    return true;
                }
                else
                {
                    return Convert.ToBoolean(this.hdnShowStatus.Value);
                }
            }
            set
            {
                this.hdnShowStatus.Value = value.ToString();
                this.gvMyTasks.Columns[1].Visible = value;
            }
        }

        private void initPage(DateTime forDate)
        {
            List<Task> MyTasks = BLLTask.GetTasks(1, null, forDate);
            this.gvMyTasks.Columns[2].Visible = ShowPriority;
            this.gvMyTasks.Columns[1].Visible = ShowStatus;
            this.gvMyTasks.DataSource = MyTasks;
            this.gvMyTasks.DataBind();
        }

        protected void gvMyTasks_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (ShowStatus)
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
}