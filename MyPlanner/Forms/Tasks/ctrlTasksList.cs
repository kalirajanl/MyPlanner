using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyPlanner.Models;
using MyPlanner.BLL;

namespace MyPlanner
{
    public partial class CtrlTasksList : BaseUserControl
    {

        private bool _showStatus = true;
        private bool _showPriority = true;

        public CtrlTasksList()
        {
            InitializeComponent();
        }

        public CtrlTasksList(AppUser usr, DateTime forDate)
        {
            InitializeComponent();
            CurrentUser = usr;
            CurrentDate = forDate;
            _showStatus = true;
            _showPriority = true;
         }

        public CtrlTasksList(AppUser usr, DateTime forDate, bool showStatus, bool showPriority)
        {
            InitializeComponent();
            CurrentUser = usr;
            CurrentDate = forDate;
            _showStatus = showStatus;
            _showPriority = showPriority;
            LoadTasks();
        }

        public bool ShowStatus
        {
            get
            {
                return _showStatus;
            }
            set
            {
                _showStatus = value;
            }
        }

        public bool ShowPriority
        {
            get
            {
                return _showPriority;
            }
            set
            {
                _showPriority = value;
            }
        }

        public DateTime CurrentDate
        {
            get
            {
                return Convert.ToDateTime(this.lblCurrentDate.Text);
            }
            set
            {
                this.lblCurrentDate.Text = value.ToString(Constants.DATE_FORMAT_STRING);
            }
        }

        public void LoadTasks()
        {
            this.dgTasks.Left = 0;
            this.dgTasks.Top = 30;
            this.dgTasks.Height = this.Height - 35;
            this.dgTasks.Width = this.Width - 5;
            this.dgTasks.AutoGenerateColumns = false;
            this.dgTasks.Columns[1].Width = 70;
            this.dgTasks.Columns[2].Width = 40;
            this.dgTasks.Columns[1].Visible = _showStatus;
            this.dgTasks.Columns[2].Visible = _showPriority;
            Form_Title = "Tasks List";
            initPage();
        }

        private void initPage()
        {
            this.lblDay.Text = Convert.ToDateTime(this.lblCurrentDate.Text).ToString("dddd");
            if (CurrentUser != null)
            {
                this.dgTasks.DataSource = BLLTask.GetTasks(CurrentUser.UserID, null, Convert.ToDateTime(this.lblCurrentDate.Text), false);
            }
        }

        private void addTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditTask childform = new frmEditTask(CurrentUser, PageMode.Add, CurrentDate);
            childform.ShowDialog();
            initPage();
        }

        private void editTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgTasks.CurrentRow == null)
            {
                ShowError("Please select a row.", Form_Title);
            }
            else
            {
                frmEditTask childform = new frmEditTask(CurrentUser, PageMode.Edit, CurrentDate);
                childform.ItemID = (long)Convert.ToDecimal(this.dgTasks.CurrentRow.Cells[0].Value);
                childform.ShowDialog();
                initPage();
            }
        }

        private void dgTasks_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            bool returnValue = false;

            if (dgTasks.IsCurrentRowDirty)
            {
                returnValue = addupdateRow(e);
            }

            if (!returnValue)
            {

            }
        }

        private bool addupdateRow(DataGridViewCellEventArgs e)
        {
            bool returnValue = false;
            if (validateCurrentRowData(false))
            {
                long taskID = (long)Convert.ToDecimal(this.dgTasks.CurrentRow.Cells[0].Value);
                Task task;
                if (taskID <= 0)
                {
                    task = new Task();
                }
                else
                {
                    task = BLLTask.GetTaskByID(taskID);
                }
                task.ForUser = CurrentUser;
                task.Categories = new List<Category>();
                task.IsGoalStep = false;
                task.IsMasterTask = false;
                task.IsRecurring = false;
                task.Priority = TaskPriorities.C;
                task.Status = TaskStatuses.Normal;
                task.TaskNotes = "";
                task.TaskRecurrence = null;
                task.TaskName = this.dgTasks.CurrentRow.Cells[3].EditedFormattedValue.ToString();
                task.TaskDate = CurrentDate;
                if (taskID <= 0)
                {
                    BLLTask.AddTask(task);
                }
                else
                {
                    BLLTask.UpdateTask(task);
                }
                returnValue = true;
            }

            return returnValue;
        }

        private bool validateCurrentRowData(bool showMessage)
        {
            bool returnValue = true;
            int colIndex = 1;
            int currentRowIndex = this.dgTasks.CurrentRow.Index;
            string errMessage = "";
            if (this.dgTasks.CurrentRow != null)
            {
                if (this.dgTasks.CurrentRow.Cells[2].EditedFormattedValue.ToString().Trim().Equals(""))
                {
                    errMessage = "Please enter Task Name";
                    returnValue = false;
                }
            }
            else
            {
                errMessage = "No Active Selection";
                returnValue = false;
            }

            if (!returnValue)
            {
                if (showMessage)
                {
                    ShowError(errMessage, Form_Title);
                }
                dgTasks.ClearSelection();
                dgTasks.Rows[currentRowIndex].Selected = true;
                dgTasks.CurrentCell = dgTasks[colIndex, currentRowIndex];
                dgTasks.CurrentCell.ReadOnly = false;
                //this.dgTasks.BeginEdit(true);
            }
            return returnValue;
        }

        private void deleteTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgTasks.CurrentRow == null)
            {
                ShowError("Please select a row.", Form_Title);
            }
            else
            {
                long taskID = (long)Convert.ToDecimal(this.dgTasks.CurrentRow.Cells[0].Value);
                BLLTask.DeleteTask(taskID);
                initPage();
            }
        }

        private void mnuNormal_Click(object sender, EventArgs e)
        {
            updateStatus(TaskStatuses.Normal);
        }

        private void updateStatus(TaskStatuses sts)
        {
            if (this.dgTasks.CurrentRow == null)
            {
                ShowError("Please select a row.", Form_Title);
            }
            else
            {
                long taskID = (long)Convert.ToDecimal(this.dgTasks.CurrentRow.Cells[0].Value);
                BLLTask.UpdateTaskStatus(taskID, sts);
                initPage();
            }
        }

        private void mnuInProgress_Click(object sender, EventArgs e)
        {
            updateStatus(TaskStatuses.InProgress);
        }

        private void mnuCompleted_Click(object sender, EventArgs e)
        {
            updateStatus(TaskStatuses.Completed);
        }

        private void mnuForwarded_Click(object sender, EventArgs e)
        {
            if (this.dgTasks.CurrentRow == null)
            {
                ShowError("Please select a row.", Form_Title);
            }
            else
            {
                frmEditTask childform = new frmEditTask(CurrentUser, PageMode.Forward, CurrentDate);
                childform.ItemID = (long)Convert.ToDecimal(this.dgTasks.CurrentRow.Cells[0].Value);
                childform.ShowDialog();
                initPage();
            }
        }

        private void mnuDelegated_Click(object sender, EventArgs e)
        {
            updateStatus(TaskStatuses.Delegated);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (this.dgTasks.CurrentRow == null)
            {
                this.editTaskToolStripMenuItem.Enabled = false;
                this.deleteTaskToolStripMenuItem.Enabled = false;
                this.forwardTaskToolStripMenuItem.Enabled = false;
            }
            else
            {
                this.editTaskToolStripMenuItem.Enabled = true;
                this.deleteTaskToolStripMenuItem.Enabled = true;
                this.forwardTaskToolStripMenuItem.Enabled = true;
            }
            if (ShowStatus)
            {
                this.showStatusToolStripMenuItem.Text = "Hide Status";
            }
            else
            {
                this.showStatusToolStripMenuItem.Text = "Show Status";
            }
            if (ShowPriority)
            {
                this.showPriorityToolStripMenuItem.Text = "Hide Priority";
            }
            else
            {
                this.showPriorityToolStripMenuItem.Text = "Show Priority";
            }
        }

        private void forwardTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mnuForwarded_Click(null, null);
        }

        private void showStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowStatus = !ShowStatus;
            LoadTasks();
        }

        private void showPriorityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPriority = !ShowPriority;
            LoadTasks();
        }

    }
}
