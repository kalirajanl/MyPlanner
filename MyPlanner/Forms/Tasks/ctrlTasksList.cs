using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyPlanner.BLL;
using MyPlanner.Common;
using MyPlanner.Models;

namespace MyPlanner
{
    public partial class CtrlTasksList : BaseUserControl
    {

        private bool _showStatus = true;
        private bool _showPriority = true;
        private bool _showOverDueTasks = false;

        public CtrlTasksList()
        {
            InitializeComponent();
            _showOverDueTasks = false;
        }

        public CtrlTasksList(AppUser usr, DateTime forDate, bool IsDailyView)
        {
            InitializeComponent();
            CurrentUser = usr;
            CurrentDate = forDate;
            _showStatus = true;
            _showPriority = true;
            _showOverDueTasks = IsDailyView;
         }

        public CtrlTasksList(AppUser usr, DateTime forDate, bool showStatus, bool showPriority, bool IsDailyView)
        {
            InitializeComponent();
            CurrentUser = usr;
            CurrentDate = forDate;
            _showStatus = showStatus;
            _showPriority = showPriority;
            _showOverDueTasks = IsDailyView;
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

        public bool ShowOverDueTasks
        {
            get
            {
                return _showOverDueTasks;
            }
            set
            {
                _showOverDueTasks = value;
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
                this.dgTasks.DataSource = BLLTask.GetTasks(CurrentUser.UserID, null, Convert.ToDateTime(this.lblCurrentDate.Text), _showOverDueTasks, false);
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
            if (!ShowOverDueTasks)
            {
                this.showOverdueTasksToolStripMenuItem.Text = "Show Overdue Tasks";
            }
            else
            {
                this.showOverdueTasksToolStripMenuItem.Text = "Hide Overdue Tasks";
            }
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

        private void dgTasks_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgTasks.Rows[e.RowIndex].Cells[1] != null)
            {
                Font tn = e.CellStyle.Font;
                if (tn == null)
                {
                    tn = this.dgTasks.Font;
                }
                if (tn == null)
                {
                    tn = new Font("Arial", 12);
                }
                List<Task> tasks = (List<Task>)this.dgTasks.DataSource;
                if (tasks[e.RowIndex].TaskDate < CurrentDate)
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Blue;
                }
                switch (tasks[e.RowIndex].Status)
                {
                    case TaskStatuses.Completed:
                    case TaskStatuses.Forwarded:
                    case TaskStatuses.Deleted:
                    case TaskStatuses.Cancelled:
                        {
                            tn = new Font(tn.FontFamily, tn.SizeInPoints, FontStyle.Strikeout);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                e.CellStyle.Font = tn;
            }
        }

        private void showOverdueTasksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOverDueTasks = !ShowOverDueTasks;
            LoadTasks();
        }

        private void cancelledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateStatus(TaskStatuses.Cancelled);
        }

        private void completeForwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgTasks.CurrentRow == null)
            {
                ShowError("Please select a row.", Form_Title);
            }
            else
            {
                showTaskForward(TaskStatuses.Completed);
            }
        }

        private void cancelForwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgTasks.CurrentRow == null)
            {
                ShowError("Please select a row.", Form_Title);
            }
            else
            {
                showTaskForward(TaskStatuses.Cancelled);
            }
        }

       

        private void deleteForwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgTasks.CurrentRow == null)
            {
                ShowError("Please select a row.", Form_Title);
            }
            else
            {
                showTaskForward(TaskStatuses.Deleted);
            }
        }

        private void forwardOnlyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.dgTasks.CurrentRow == null)
            {
                ShowError("Please select a row.", Form_Title);
            }
            else
            {
                showTaskForward(TaskStatuses.Forwarded);
            }
        }

        private void cancelForwardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cancelForwardToolStripMenuItem_Click(null, null);
        }

        private void completeForwardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            completeForwardToolStripMenuItem_Click(null, null);
        }

        private void deleteForwardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            deleteForwardToolStripMenuItem_Click(null, null);
        }

        private void forwardOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forwardOnlyToolStripMenuItem1_Click(null, null);
        }

        private void showTaskForward(TaskStatuses currentTaskStatus)
        {
            frmEditTask childform = new frmEditTask(CurrentUser, PageMode.Forward, CurrentDate, currentTaskStatus);
            childform.ItemID = (long)Convert.ToDecimal(this.dgTasks.CurrentRow.Cells[0].Value);
            childform.ShowDialog();
            initPage();
        }
    }
}
