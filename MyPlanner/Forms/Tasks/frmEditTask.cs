using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using MyPlanner.BLL;
using MyPlanner.Common;
using MyPlanner.Models;

namespace MyPlanner
{
    public partial class frmEditTask : PopupForm
    {
        TaskStatuses forwardStatus = TaskStatuses.Forwarded;

        public frmEditTask(AppUser usr, PageMode pageMode, DateTime currentdate)
        {
            InitializeComponent();
            CurrentUser = usr;
            CurrentPageMode = pageMode;
            this.lblCurrentDate.Text = currentdate.ToString(Constants.DATE_FORMAT_STRING);
        }

        public frmEditTask(AppUser usr, PageMode pageMode, DateTime currentdate, TaskStatuses currentTaskStatus)
        {
            InitializeComponent();
            CurrentUser = usr;
            CurrentPageMode = pageMode;
            this.lblCurrentDate.Text = currentdate.ToString(Constants.DATE_FORMAT_STRING);
            forwardStatus = currentTaskStatus;
        }

        private void frmEditTask_Load(object sender, EventArgs e)
        {
            initPage();
        }

        private void initPage()
        {
            this.txtTaskName.Text = "";
            this.dtpDueOn.Value = Convert.ToDateTime(this.lblCurrentDate.Text);
            this.txtTaskNotes.Text = "";

            List<TaskPriority> pri = BLLTaskPriority.GetTaskPriorities();
            //pri.Insert(0, new TaskPriority { TaskPriorityID = 0, TaskPriorityName = "<Select>" });
            this.cboPriority.DisplayMember = "TaskPriorityName";
            this.cboPriority.ValueMember = "TaskPriorityID";
            this.cboPriority.DataSource = pri;
            loadPriority(TaskPriorities.C3);

            List<TaskStatus> sts = BLLTaskStatus.GetTaskStatuses();
            //sts.Insert(0, new TaskStatus { TaskStatusID = 0, TaskStatusName = "<Select>" });
            this.cboStatus.DisplayMember = "TaskStatusName";
            this.cboStatus.ValueMember = "TaskStatusID";
            this.cboStatus.DataSource = sts;
            loadStatus(TaskStatuses.Normal);

            this.chklstCategory.DataSource = BLLCategory.GetCategoriesByUserID(CurrentUser.UserID);
            this.chklstCategory.DisplayMember = "CategoryName";
            this.chklstCategory.ValueMember = "CategoryID";
            this.chklstCategory.ClearSelected();

            switch (this.CurrentPageMode)
            {
                case PageMode.Add:
                    {
                        this.Text = ApplicationTitle + " - Add Task";
                        Form_Title = "Add Task";
                        this.lblItemID.Text = "0";
                        enableNonDateFields(true);
                        break;
                    }
                case PageMode.Edit:
                    {
                        this.Text = ApplicationTitle + " - Edit Task";
                        Form_Title = "Edit Task";
                        enableNonDateFields(true);
                        loadData();
                        break;
                    }
                case PageMode.Forward:
                    {
                        this.Text = ApplicationTitle + " - Forward Task";
                        Form_Title = "Forward Task";
                        enableNonDateFields(false);
                        loadData();
                        break;
                    }
            }
            this.IsPageDirty = false;
        }

        private void enableNonDateFields(bool enabled)
        {
            this.txtTaskName.ReadOnly = !enabled;
            this.txtTaskNotes.ReadOnly = !enabled;
            this.cboStatus.Enabled = enabled;
            this.cboPriority.Enabled = enabled;
            this.chklstCategory.Enabled = enabled;
        }

        public long ItemID
        {
            get
            {
                return (long)Convert.ToDecimal(this.lblItemID.Text);
            }
            set
            {
                this.lblItemID.Text = value.ToString();
            }
        }

        public TaskStatuses TaskStatus
        {
            get
            {
                return (TaskStatuses)this.cboStatus.SelectedValue;
            }
            set
            {
                loadStatus(value);
            }
        }

        private void loadData()
        {
            Task task = BLLTask.GetTaskByID((long)Convert.ToDecimal(this.lblItemID.Text));
            if (task != null)
            {
                this.txtTaskNotes.Text = task.TaskNotes;
                this.dtpDueOn.Value = task.TaskDate;
                this.txtTaskName.Text = task.TaskName;

                loadPriority(task.Priority);
                if (this.CurrentPageMode == PageMode.Forward)
                {
                    loadStatus(forwardStatus);
                }
                else
                {
                    loadStatus(task.Status);
                }
                for (int i = 0; i <= task.Categories.Count - 1; i++)
                {
                    int idx = getIndexOfCategory(task.Categories[i]);
                    if (idx >= 0)
                    {
                        this.chklstCategory.SetItemChecked(idx, true);
                    }
                }

            }
        }

        private void loadPriority(TaskPriorities pri)
        {
            this.cboPriority.SelectedIndex = 0;
            for (int i = 0; i <= this.cboPriority.Items.Count - 1; i++)
            {
                TaskPriority tskPri = (TaskPriority)this.cboPriority.Items[i];
                if (tskPri.TaskPriorityID == Convert.ToInt32(pri))
                {
                    this.cboPriority.SelectedItem = tskPri;
                    break;
                }
            }
        }

        private void loadStatus(TaskStatuses sts)
        {
            this.cboStatus.SelectedIndex = 0;
            for (int i = 0; i <= this.cboStatus.Items.Count - 1; i++)
            {
                TaskStatus tskSts = (TaskStatus)this.cboStatus.Items[i];
                if (tskSts.TaskStatusID == Convert.ToInt32(sts))
                {
                    this.cboStatus.SelectedItem = tskSts;
                    break;
                }
            }
        }

        private int getIndexOfCategory(Category category)
        {
            int returnData = -1;
            for (int i = 0; i <= chklstCategory.Items.Count - 1; i++)
            {
                Category cat = (Category)chklstCategory.Items[i];
                if (cat.CategoryID == category.CategoryID)
                {
                    returnData = i;
                    break;
                }
            }
            return returnData;
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
                    Task task = null;
                    switch (this.CurrentPageMode)
                    {
                        case PageMode.Add:
                            {
                                task = new Task();
                                break;
                            }
                        case PageMode.Edit:
                        case PageMode.Forward:
                            {
                                task = BLLTask.GetTaskByID((long)Convert.ToDecimal(this.lblItemID.Text));
                                break;
                            }
                    }

                    task.ForUser = CurrentUser;
                    task.IsGoalStep = false;
                    task.IsMasterTask = false;
                    task.IsRecurring = false;
                    task.Priority = (TaskPriorities)this.cboPriority.SelectedValue;
                    task.Status = (TaskStatuses)this.cboStatus.SelectedValue;
                    task.TaskDate = this.dtpDueOn.Value;
                    task.TaskName = this.txtTaskName.Text;
                    task.TaskNotes = this.txtTaskNotes.Text;
                    task.TaskRecurrence = null;

                    task.Categories = new List<Category>();
                    foreach (object itemChecked in chklstCategory.CheckedItems)
                    {
                        Category category = itemChecked as Category;
                        task.Categories.Add(BLLCategory.GetCategoryByID(category.CategoryID));
                    }
                    switch (this.CurrentPageMode)
                    {
                        case PageMode.Add:
                            {
                                returnValue = (BLLTask.AddTask(task) > 0);
                                break;
                            }
                        case PageMode.Edit:
                            {
                                returnValue = BLLTask.UpdateTask(task);
                                break;
                            }
                        case PageMode.Forward:
                            {
                                returnValue = BLLTask.ForwardTask(task.TaskID, this.dtpDueOn.Value, task.Status);
                                break;
                            }
                    }
                    task = null;
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
                ShowError("Please enter Task.", Form_Title);
                returnValue = false;
                this.txtTaskName.Focus();
            }
            else if (this.cboPriority.SelectedIndex < 0)
            {
                ShowError("Please select Priority.", Form_Title);
                returnValue = false;
                this.cboPriority.Focus();
            }
            else if (this.cboStatus.SelectedIndex < 0)
            {
                ShowError("Please select Status.", Form_Title);
                returnValue = false;
                this.cboStatus.Focus();
            }
            return returnValue;
        }

        private void dtpDueOn_ValueChanged(object sender, EventArgs e)
        {
            IsPageDirty = true;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void cboPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsPageDirty = true;
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsPageDirty = true;
        }
    }
}
