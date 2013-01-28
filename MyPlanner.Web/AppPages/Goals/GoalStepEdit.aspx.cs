using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using MyPlanner.Models;
using MyPlanner.BLL;

namespace MyPlanner.AppPages.Goals
{
    public partial class GoalStepEdit : PopupBasePage
    {
        private string defaultDate = "";

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            switch (CurrentPageMode)
            {
                case PageMode.Add: { this.Title = Constants.APP_TITLE + " - Add Goal Step"; break; }
                case PageMode.Edit: { this.Title = Constants.APP_TITLE + " - Edit Goal Step"; break; }
                case PageMode.View: { this.Title = Constants.APP_TITLE + " - View Goal Step"; break; }
                default: { this.Title = Constants.APP_TITLE; break; }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                processQueryStrings();
                initPage();
                this.txtTaskName.Focus();
            }

            this.lblErrorText.Text = "&nbsp;";
        }

        private void initPage()
        {
            initControls();
            if (!this.txtGoalStepID.Text.Trim().Equals(""))
            {
                loadControls();
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

            this.btnCancel.Attributes.Add("onclick", "window.returnValue = 0;window.close();return false;");
        }

        private void loadControls()
        {
            int goalStepID = Convert.ToInt32(this.txtGoalStepID.Text);
            GoalStep goalStep = BLLGoalStep.GetGoalStepByID(goalStepID);
            if (goalStep != null)
            {
                if (goalStep.taskInfo != null)
                {
                    this.calForDate.SelectedDate = goalStep.taskInfo.TaskDate;
                    this.txtTaskName.Text = goalStep.taskInfo.TaskName;
                    this.txtTaskNotes.Text = goalStep.taskInfo.TaskNotes;
                }
            }
        }

        private void processQueryStrings()
        {
            string goalID = "0";
            if (Request.QueryString["goalid"] != null)
            {
                goalID = Request.QueryString["goalid"].ToString();
            }
            this.txtGoalID.Text = goalID;

            string goalStepID = "0";
            if (Request.QueryString["goalstepid"] != null)
            {
                goalStepID = Request.QueryString["goalstepid"].ToString();
            }
            if (goalStepID.StartsWith("G"))
            {
                goalStepID = goalStepID.Substring(1);
            }
            this.txtGoalStepID.Text = goalStepID;

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
            if (this.txtTaskName.Text.Trim().Equals(""))
            {
                returnValue = false;
                errMessage = "Please enter Name.";
                this.txtTaskName.Focus();
            }
            else if (this.txtForDate.Text.Trim().Equals(""))
            {
                returnValue = false;
                errMessage = "Please enter due date.";
                this.calForDate.Focus();
            }
            else if (!MyPlannerValidators.IsValidDateText(this.txtForDate.Text))
            {
                returnValue = false;
                errMessage = "Please enter a valid due date.";
                this.calForDate.Focus();
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
                    GoalStep goalStep = new GoalStep();
                    if (CurrentPageMode != PageMode.Add)
                    {
                        goalStep = BLLGoalStep.GetGoalStepByID(Convert.ToInt32(this.txtGoalStepID.Text));
                    }

                    if (goalStep.taskInfo == null)
                    {
                        goalStep.taskInfo = new Task();
                    }
                    goalStep.taskInfo.ForUser = new AppUser();
                    goalStep.taskInfo.ForUser.UserID = 1;
                    goalStep.taskInfo.IsGoalStep = true;
                    goalStep.taskInfo.IsMasterTask = false;
                    goalStep.taskInfo.IsRecurring = false;
                    goalStep.taskInfo.Priority = TaskPriorities.A;
                    goalStep.taskInfo.Status = TaskStatuses.Normal;
                    goalStep.taskInfo.TaskDate = this.calForDate.SelectedDate;
                    goalStep.taskInfo.TaskName = this.txtTaskName.Text;
                    goalStep.taskInfo.TaskNotes = this.txtTaskNotes.Text;
                    goalStep.taskInfo.TaskRecurrence = null;

                    goalStep.taskInfo.Categories = new List<Category>();

                    if (CurrentPageMode == PageMode.Add)
                    {
                        BLLGoalStep.AddGoalStep(Convert.ToInt32(this.txtGoalID.Text),goalStep);
                        this.lblErrorText.Text = "Completed";
                    }
                    else if (CurrentPageMode == PageMode.Edit)
                    {
                        BLLGoalStep.UpdateGoalStep(Convert.ToInt32(this.txtGoalID.Text),goalStep);
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