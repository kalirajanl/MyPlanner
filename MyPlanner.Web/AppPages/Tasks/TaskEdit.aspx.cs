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
    public partial class TaskEdit : PopupBasePage
    {

        private string defaultDate = "";

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            switch (CurrentPageMode)
            {
                case PageMode.Add: { this.Title = Constants.APP_TITLE + " - Add Task"; break; }
                case PageMode.Edit: { this.Title = Constants.APP_TITLE + " - Edit Task"; break; }
                case PageMode.View: { this.Title = Constants.APP_TITLE + " - View Task"; break; }
                default: { this.Title = Constants.APP_TITLE; break; }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                processQueryStrings();
                initPage();
                if (this.txtTaskName.Enabled)
                {
                    this.txtTaskName.Focus();
                }
                else
                {
                    this.txtForDate.Focus();
                }
            }

            this.lblErrorText.Text = "&nbsp;";
        }

        private void initPage()
        {
            initControls();
            if (!this.txtTaskID.Text.Trim().Equals(""))
            {
                loadControls();
            }
            if (CurrentPageMode == PageMode.Forward)
            {
                this.txtTaskName.Enabled = false;
                this.txtTaskNotes.Enabled = false;
                this.chklstCategory.Enabled = false;
                this.ddlTaskStatus.SelectedIndex = (int)TaskStatuses.Forwarded;
                this.ddlTaskStatus.Enabled = false;
                this.ddlTaskPriority.Enabled = false;
            }
        }

        private void initControls()
        {
            this.lblErrorText.Text = "";
            //this.txtTaskID.Text = "";
            if (defaultDate.Trim().Equals(""))
            {
                this.calForDate.SelectedDate = DateTime.Today;
            }
            else
            {
                this.calForDate.SelectedDate = Convert.ToDateTime(defaultDate);
            }
            this.txtTaskName.Text = "";
            this.txtTaskNotes.Text = "";
            this.ddlTaskPriority.DataSource = BLLTaskPriority.GetTaskPriorities();
            this.ddlTaskPriority.DataTextField = "TaskPriorityName";
            this.ddlTaskPriority.DataValueField = "TaskPriorityID";
            this.ddlTaskPriority.DataBind();
            this.ddlTaskPriority.Items.Insert(0, new ListItem("<Select>", "0"));
            this.ddlTaskPriority.SelectedIndex = 0;

            this.ddlTaskStatus.DataSource = BLLTaskStatus.GetTaskStatuses();
            this.ddlTaskStatus.DataTextField = "TaskStatusName";
            this.ddlTaskStatus.DataValueField = "TaskStatusID";
            this.ddlTaskStatus.DataBind();
            this.ddlTaskStatus.Items.Insert(0, new ListItem("<Select>", "0"));
            this.ddlTaskStatus.SelectedIndex = 0;

            this.chklstCategory.DataSource = BLLCategory.GetCategoriesByUserID(1);
            this.chklstCategory.DataTextField = "CategoryName";
            this.chklstCategory.DataValueField = "CategoryID";
            this.chklstCategory.DataBind();

            this.btnCancel.Attributes.Add("onclick", "window.returnValue = 0;window.close();return false;");
        }

        private void loadControls()
        {
            long taskID = (long)Convert.ToDouble(this.txtTaskID.Text);
            Task task = BLLTask.GetTaskByID(taskID);
            if (task != null)
            {
                this.calForDate.SelectedDate = task.TaskDate;
                this.txtTaskName.Text = task.TaskName;
                this.txtTaskNotes.Text = task.TaskNotes;

                this.ddlTaskPriority.SelectedIndex = (int)(task.Priority);
                this.ddlTaskStatus.SelectedIndex = (int)(task.Status);

                this.chklstCategory.ClearSelection();
                for (int i = 0; i <= task.Categories.Count - 1; i++)
                {
                    if (this.chklstCategory.Items.FindByValue(task.Categories[i].CategoryID.ToString()) != null)
                    {
                        this.chklstCategory.Items.FindByValue(task.Categories[i].CategoryID.ToString()).Selected = true;
                    }
                }
            }
        }

        private void processQueryStrings()
        {
            string taskID = "0";
            if (Request.QueryString["taskid"] != null)
            {
                taskID = Request.QueryString["taskid"].ToString();
            }
            this.txtTaskID.Text = taskID;

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
            if (this.ddlTaskStatus.SelectedIndex <= 0)
            {
                this.ddlTaskStatus.SelectedIndex = 1;
            }
            if (this.txtTaskName.Text.Trim().Equals(""))
            {
                returnValue = false;
                errMessage = "Please enter Task Name.";
                this.txtTaskName.Focus();
            }
            else if (this.ddlTaskPriority.SelectedIndex <= 0)
            {
                returnValue = false;
                errMessage = "Please select Priority.";
                this.ddlTaskPriority.Focus();
            }
            else if (this.txtForDate.Text.Trim().Equals(""))
            {
                returnValue = false;
                errMessage = "Please enter a date.";
                this.calForDate.Focus();
            }
            else if (!MyPlannerValidators.IsValidDateText(this.txtForDate.Text))
            {
                returnValue = false;
                errMessage = "Please enter a valid date.";
                this.calForDate.Focus();
            }
            this.lblErrorText.Text = errMessage;
            return returnValue;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (isValidData())
            {
                Task task = new Task();
                try
                {
                    if (CurrentPageMode != PageMode.Add)
                    {
                        task = BLLTask.GetTaskByID((long)Convert.ToDecimal(this.txtTaskID.Text));
                    }
                    task.ForUser = new AppUser();
                    task.ForUser.UserID = 1;
                    task.IsGoalStep = false;
                    task.IsMasterTask = false;
                    task.IsRecurring = false;
                    task.Priority = (TaskPriorities)Convert.ToInt32(this.ddlTaskPriority.SelectedValue);
                    task.Status = (TaskStatuses)Convert.ToInt32(this.ddlTaskStatus.SelectedValue);
                    task.TaskDate = this.calForDate.SelectedDate;
                    task.TaskName = this.txtTaskName.Text;
                    task.TaskNotes = this.txtTaskNotes.Text;
                    task.TaskRecurrence = null;

                    task.Categories = new List<Category>();
                    for (int i = 0; i <= chklstCategory.Items.Count - 1; i++)
                    {
                        if (chklstCategory.Items[i].Selected)
                        {
                            Category cate = BLLCategory.GetCategoryByID(Convert.ToInt32(chklstCategory.Items[i].Value));
                            task.Categories.Add(cate);
                            cate = null;
                        }
                    }

                    if (CurrentPageMode == PageMode.Add)
                    {
                        BLLTask.AddTask(task);
                        this.lblErrorText.Text = "Completed";
                    }
                    else if (CurrentPageMode == PageMode.Forward) 
                    {
                        BLLTask.ForwardTask((long)Convert.ToDecimal(this.txtTaskID.Text),  calForDate.SelectedDate);
                    }
                    else if (CurrentPageMode == PageMode.Edit)
                    {
                        BLLTask.UpdateTask(task);
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
                    this.txtTaskName.Focus();
                }

            }
        }
    }
}