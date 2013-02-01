using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyPlanner.BLL;
using MyPlanner.Common;
using MyPlanner.Models;

namespace MyPlanner
{
    public partial class EditGoalStep : PopupForm
    {

        public EditGoalStep(AppUser usr, PageMode pageMode, int goalID)
        {
            InitializeComponent();
            CurrentUser = usr;
            CurrentPageMode = pageMode;
            GoalID = goalID;
        }

        private void EditGoalStep_Load(object sender, EventArgs e)
        {
            initPage();
        }

        private void initPage()
        {
            this.txtTaskName.Text = "";
            this.dtpDueOn.Value = DateTime.Now;
            this.txtTaskNotes.Text = "";
            switch (this.CurrentPageMode)
            {
                case PageMode.Add:
                    {
                        this.Text = ApplicationTitle + " - Add Goal Step";
                        Form_Title = "Add Goal Step";
                        this.lblItemID.Text = "0";
                        this.btnMarkCompleted.Visible = false;
                        break;
                    }
                case PageMode.Edit:
                    {
                        this.Text = ApplicationTitle + " - Edit Goal Step";
                        Form_Title = "Edit Goal Step";
                        loadData();
                        break;
                    }
            }
            this.IsPageDirty = false;
        }

        public int ItemID
        {
            get
            {
                return Convert.ToInt32(this.lblItemID.Text);
            }
            set
            {
                this.lblItemID.Text = value.ToString();
            }
        }

        public int GoalID
        {
            get
            {
                return Convert.ToInt32(this.lblGoalID.Text);
            }
            set
            {
                this.lblGoalID.Text = value.ToString();
            }
        }

        private void loadData()
        {
            GoalStep goalStep = BLLGoalStep.GetGoalStepByID(Convert.ToInt32(this.lblItemID.Text));
            if (goalStep != null)
            {
                this.txtTaskNotes.Text = goalStep.taskInfo.TaskNotes;
                this.dtpDueOn.Value = goalStep.taskInfo.TaskDate;
                this.txtTaskName.Text = goalStep.taskInfo.TaskName;
                this.btnMarkCompleted.Visible = (goalStep.taskInfo.Status != TaskStatuses.Completed);
            }
        }

        private void txtSubject_TextChanged(object sender, EventArgs e)
        {
            IsPageDirty = true;
        }

        private void txtReason_TextChanged(object sender, EventArgs e)
        {
            IsPageDirty = true;
        }

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {
            IsPageDirty = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (IsPageDirty)
            {
                DialogResult rslt = ShowConfirmation("Do you want to save changes?", Form_Title, MessageBoxButtons.YesNo);
                if (rslt == System.Windows.Forms.DialogResult.Yes)
                {
                    btnSave_Click(null, null);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool returnValue = false;
            if (isValidData(true))
            {
                if (IsPageDirty)
                {
                    GoalStep goalStep = null;
                    switch (this.CurrentPageMode)
                    {
                        case PageMode.Add:
                            {
                                goalStep = new GoalStep();
                                break;
                            }
                        case PageMode.Edit:
                            {
                                goalStep = BLLGoalStep.GetGoalStepByID(Convert.ToInt32(this.lblItemID.Text));
                                break;
                            }
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
                    goalStep.taskInfo.TaskDate = this.dtpDueOn.Value;
                    goalStep.taskInfo.TaskName = this.txtTaskName.Text;
                    goalStep.taskInfo.TaskNotes = this.txtTaskNotes.Text;
                    goalStep.taskInfo.TaskRecurrence = null;

                    goalStep.taskInfo.Categories = new List<Category>();
                    switch (this.CurrentPageMode)
                    {
                        case PageMode.Add:
                            {
                                returnValue = BLLGoalStep.AddGoalStep(GoalID, goalStep);
                                break;
                            }
                        case PageMode.Edit:
                            {
                                returnValue = BLLGoalStep.UpdateGoalStep(GoalID, goalStep);
                                break;
                            }
                    }
                    goalStep = null;
                }
                this.Hide();
                this.Close();
            }
        }

        private bool isValidData(bool showMessage)
        {
            bool returnValue = true;
            if (this.txtTaskName.Text.Trim().Equals(""))
            {
                ShowError("Please enter subject.", Form_Title);
                returnValue = false;
                this.txtTaskName.Focus();
            }
            return returnValue;
        }

        private void dtpDueOn_ValueChanged(object sender, EventArgs e)
        {
            IsPageDirty = true;
        }

        private void btnMarkCompleted_Click(object sender, EventArgs e)
        {
            BLLGoalStep.SetGoalStepAsCompleted(GoalID, Convert.ToInt32(this.lblItemID.Text));
            this.Hide();
            this.Close();
        }
    }
}
