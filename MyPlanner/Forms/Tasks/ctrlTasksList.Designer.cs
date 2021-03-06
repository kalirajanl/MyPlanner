﻿namespace MyPlanner
{
    partial class CtrlTasksList
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgTasks = new System.Windows.Forms.DataGridView();
            this.TaskID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaskStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuNormal = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInProgress = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCompleted = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuForwarded = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelForwardToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.completeForwardToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteForwardToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.forwardOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelegated = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TaskPriority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaskName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forwardTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelForwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.completeForwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteForwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forwardOnlyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.showStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPriorityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.showOverdueTasksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.reloadListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblCurrentDate = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.copyTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgTasks)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgTasks
            // 
            this.dgTasks.AllowUserToResizeColumns = false;
            this.dgTasks.AllowUserToResizeRows = false;
            this.dgTasks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TaskID,
            this.TaskStatus,
            this.TaskPriority,
            this.TaskName});
            this.dgTasks.ContextMenuStrip = this.contextMenuStrip1;
            this.dgTasks.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgTasks.Location = new System.Drawing.Point(12, 35);
            this.dgTasks.MultiSelect = false;
            this.dgTasks.Name = "dgTasks";
            this.dgTasks.ReadOnly = true;
            this.dgTasks.RowHeadersWidth = 15;
            this.dgTasks.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgTasks.Size = new System.Drawing.Size(393, 427);
            this.dgTasks.TabIndex = 0;
            this.dgTasks.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgTasks_CellFormatting);
            // 
            // TaskID
            // 
            this.TaskID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TaskID.DataPropertyName = "TaskID";
            this.TaskID.HeaderText = "TaskID";
            this.TaskID.Name = "TaskID";
            this.TaskID.ReadOnly = true;
            this.TaskID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TaskID.Visible = false;
            // 
            // TaskStatus
            // 
            this.TaskStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TaskStatus.ContextMenuStrip = this.contextMenuStrip2;
            this.TaskStatus.DataPropertyName = "Status";
            this.TaskStatus.HeaderText = "Status";
            this.TaskStatus.Name = "TaskStatus";
            this.TaskStatus.ReadOnly = true;
            this.TaskStatus.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNormal,
            this.mnuInProgress,
            this.mnuCompleted,
            this.mnuForwarded,
            this.mnuDelegated,
            this.cancelledToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(134, 136);
            // 
            // mnuNormal
            // 
            this.mnuNormal.Name = "mnuNormal";
            this.mnuNormal.Size = new System.Drawing.Size(133, 22);
            this.mnuNormal.Text = "Normal";
            this.mnuNormal.Click += new System.EventHandler(this.mnuNormal_Click);
            // 
            // mnuInProgress
            // 
            this.mnuInProgress.Name = "mnuInProgress";
            this.mnuInProgress.Size = new System.Drawing.Size(133, 22);
            this.mnuInProgress.Text = "In Progress";
            this.mnuInProgress.Click += new System.EventHandler(this.mnuInProgress_Click);
            // 
            // mnuCompleted
            // 
            this.mnuCompleted.Name = "mnuCompleted";
            this.mnuCompleted.Size = new System.Drawing.Size(133, 22);
            this.mnuCompleted.Text = "Completed";
            this.mnuCompleted.Click += new System.EventHandler(this.mnuCompleted_Click);
            // 
            // mnuForwarded
            // 
            this.mnuForwarded.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cancelForwardToolStripMenuItem1,
            this.completeForwardToolStripMenuItem1,
            this.deleteForwardToolStripMenuItem1,
            this.forwardOnlyToolStripMenuItem});
            this.mnuForwarded.Name = "mnuForwarded";
            this.mnuForwarded.Size = new System.Drawing.Size(133, 22);
            this.mnuForwarded.Text = "Forward";
            // 
            // cancelForwardToolStripMenuItem1
            // 
            this.cancelForwardToolStripMenuItem1.Name = "cancelForwardToolStripMenuItem1";
            this.cancelForwardToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.cancelForwardToolStripMenuItem1.Text = "Cancel && Forward";
            this.cancelForwardToolStripMenuItem1.Click += new System.EventHandler(this.cancelForwardToolStripMenuItem1_Click);
            // 
            // completeForwardToolStripMenuItem1
            // 
            this.completeForwardToolStripMenuItem1.Name = "completeForwardToolStripMenuItem1";
            this.completeForwardToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.completeForwardToolStripMenuItem1.Text = "Complete && Forward";
            this.completeForwardToolStripMenuItem1.Click += new System.EventHandler(this.completeForwardToolStripMenuItem1_Click);
            // 
            // deleteForwardToolStripMenuItem1
            // 
            this.deleteForwardToolStripMenuItem1.Name = "deleteForwardToolStripMenuItem1";
            this.deleteForwardToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.deleteForwardToolStripMenuItem1.Text = "Delete && Forward";
            this.deleteForwardToolStripMenuItem1.Click += new System.EventHandler(this.deleteForwardToolStripMenuItem1_Click);
            // 
            // forwardOnlyToolStripMenuItem
            // 
            this.forwardOnlyToolStripMenuItem.Name = "forwardOnlyToolStripMenuItem";
            this.forwardOnlyToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.forwardOnlyToolStripMenuItem.Text = "Forward Only";
            this.forwardOnlyToolStripMenuItem.Click += new System.EventHandler(this.forwardOnlyToolStripMenuItem_Click);
            // 
            // mnuDelegated
            // 
            this.mnuDelegated.Name = "mnuDelegated";
            this.mnuDelegated.Size = new System.Drawing.Size(133, 22);
            this.mnuDelegated.Text = "Delegate";
            this.mnuDelegated.Click += new System.EventHandler(this.mnuDelegated_Click);
            // 
            // cancelledToolStripMenuItem
            // 
            this.cancelledToolStripMenuItem.Name = "cancelledToolStripMenuItem";
            this.cancelledToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.cancelledToolStripMenuItem.Text = "Cancelled";
            this.cancelledToolStripMenuItem.Click += new System.EventHandler(this.cancelledToolStripMenuItem_Click);
            // 
            // TaskPriority
            // 
            this.TaskPriority.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TaskPriority.DataPropertyName = "Priority";
            this.TaskPriority.HeaderText = "ABC";
            this.TaskPriority.Name = "TaskPriority";
            this.TaskPriority.ReadOnly = true;
            this.TaskPriority.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TaskPriority.Width = 40;
            // 
            // TaskName
            // 
            this.TaskName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TaskName.DataPropertyName = "TaskName";
            this.TaskName.HeaderText = "Task";
            this.TaskName.MinimumWidth = 150;
            this.TaskName.Name = "TaskName";
            this.TaskName.ReadOnly = true;
            this.TaskName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTaskToolStripMenuItem,
            this.editTaskToolStripMenuItem,
            this.forwardTaskToolStripMenuItem,
            this.deleteTaskToolStripMenuItem,
            this.copyTaskToolStripMenuItem,
            this.toolStripSeparator1,
            this.showStatusToolStripMenuItem,
            this.showPriorityToolStripMenuItem,
            this.toolStripMenuItem1,
            this.showOverdueTasksToolStripMenuItem,
            this.toolStripSeparator2,
            this.reloadListToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(184, 242);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // addTaskToolStripMenuItem
            // 
            this.addTaskToolStripMenuItem.Name = "addTaskToolStripMenuItem";
            this.addTaskToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.addTaskToolStripMenuItem.Text = "Add Task";
            this.addTaskToolStripMenuItem.Click += new System.EventHandler(this.addTaskToolStripMenuItem_Click);
            // 
            // editTaskToolStripMenuItem
            // 
            this.editTaskToolStripMenuItem.Name = "editTaskToolStripMenuItem";
            this.editTaskToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.editTaskToolStripMenuItem.Text = "Edit Task";
            this.editTaskToolStripMenuItem.Click += new System.EventHandler(this.editTaskToolStripMenuItem_Click);
            // 
            // forwardTaskToolStripMenuItem
            // 
            this.forwardTaskToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cancelForwardToolStripMenuItem,
            this.completeForwardToolStripMenuItem,
            this.deleteForwardToolStripMenuItem,
            this.forwardOnlyToolStripMenuItem1});
            this.forwardTaskToolStripMenuItem.Name = "forwardTaskToolStripMenuItem";
            this.forwardTaskToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.forwardTaskToolStripMenuItem.Text = "Forward Task";
            // 
            // cancelForwardToolStripMenuItem
            // 
            this.cancelForwardToolStripMenuItem.Name = "cancelForwardToolStripMenuItem";
            this.cancelForwardToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.cancelForwardToolStripMenuItem.Text = "Cancel && Forward";
            this.cancelForwardToolStripMenuItem.Click += new System.EventHandler(this.cancelForwardToolStripMenuItem_Click);
            // 
            // completeForwardToolStripMenuItem
            // 
            this.completeForwardToolStripMenuItem.Name = "completeForwardToolStripMenuItem";
            this.completeForwardToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.completeForwardToolStripMenuItem.Text = "Complete && Forward";
            this.completeForwardToolStripMenuItem.Click += new System.EventHandler(this.completeForwardToolStripMenuItem_Click);
            // 
            // deleteForwardToolStripMenuItem
            // 
            this.deleteForwardToolStripMenuItem.Name = "deleteForwardToolStripMenuItem";
            this.deleteForwardToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.deleteForwardToolStripMenuItem.Text = "Delete && Forward";
            this.deleteForwardToolStripMenuItem.Click += new System.EventHandler(this.deleteForwardToolStripMenuItem_Click);
            // 
            // forwardOnlyToolStripMenuItem1
            // 
            this.forwardOnlyToolStripMenuItem1.Name = "forwardOnlyToolStripMenuItem1";
            this.forwardOnlyToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.forwardOnlyToolStripMenuItem1.Text = "Forward Only";
            this.forwardOnlyToolStripMenuItem1.Click += new System.EventHandler(this.forwardOnlyToolStripMenuItem1_Click);
            // 
            // deleteTaskToolStripMenuItem
            // 
            this.deleteTaskToolStripMenuItem.Name = "deleteTaskToolStripMenuItem";
            this.deleteTaskToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.deleteTaskToolStripMenuItem.Text = "Delete Task";
            this.deleteTaskToolStripMenuItem.Click += new System.EventHandler(this.deleteTaskToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(180, 6);
            // 
            // showStatusToolStripMenuItem
            // 
            this.showStatusToolStripMenuItem.Name = "showStatusToolStripMenuItem";
            this.showStatusToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.showStatusToolStripMenuItem.Text = "Show Status";
            this.showStatusToolStripMenuItem.Click += new System.EventHandler(this.showStatusToolStripMenuItem_Click);
            // 
            // showPriorityToolStripMenuItem
            // 
            this.showPriorityToolStripMenuItem.Name = "showPriorityToolStripMenuItem";
            this.showPriorityToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.showPriorityToolStripMenuItem.Text = "Show Priority";
            this.showPriorityToolStripMenuItem.Click += new System.EventHandler(this.showPriorityToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 6);
            // 
            // showOverdueTasksToolStripMenuItem
            // 
            this.showOverdueTasksToolStripMenuItem.Name = "showOverdueTasksToolStripMenuItem";
            this.showOverdueTasksToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.showOverdueTasksToolStripMenuItem.Text = "Show Overdue Tasks";
            this.showOverdueTasksToolStripMenuItem.Click += new System.EventHandler(this.showOverdueTasksToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(180, 6);
            // 
            // reloadListToolStripMenuItem
            // 
            this.reloadListToolStripMenuItem.Name = "reloadListToolStripMenuItem";
            this.reloadListToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.reloadListToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.reloadListToolStripMenuItem.Text = "Refresh Task List";
            this.reloadListToolStripMenuItem.Click += new System.EventHandler(this.reloadListToolStripMenuItem_Click);
            // 
            // lblCurrentDate
            // 
            this.lblCurrentDate.AutoSize = true;
            this.lblCurrentDate.Location = new System.Drawing.Point(59, 464);
            this.lblCurrentDate.Name = "lblCurrentDate";
            this.lblCurrentDate.Size = new System.Drawing.Size(35, 13);
            this.lblCurrentDate.TabIndex = 1;
            this.lblCurrentDate.Text = "label1";
            this.lblCurrentDate.Visible = false;
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDay.Location = new System.Drawing.Point(9, 9);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(71, 20);
            this.lblDay.TabIndex = 2;
            this.lblDay.Text = "Monday";
            // 
            // copyTaskToolStripMenuItem
            // 
            this.copyTaskToolStripMenuItem.Name = "copyTaskToolStripMenuItem";
            this.copyTaskToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.copyTaskToolStripMenuItem.Text = "Copy Task";
            this.copyTaskToolStripMenuItem.Click += new System.EventHandler(this.copyTaskToolStripMenuItem_Click);
            // 
            // CtrlTasksList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblDay);
            this.Controls.Add(this.lblCurrentDate);
            this.Controls.Add(this.dgTasks);
            this.Name = "CtrlTasksList";
            this.Size = new System.Drawing.Size(418, 478);
            ((System.ComponentModel.ISupportInitialize)(this.dgTasks)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgTasks;
        private System.Windows.Forms.Label lblCurrentDate;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forwardTaskToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem mnuNormal;
        private System.Windows.Forms.ToolStripMenuItem mnuInProgress;
        private System.Windows.Forms.ToolStripMenuItem mnuForwarded;
        private System.Windows.Forms.ToolStripMenuItem mnuDelegated;
        private System.Windows.Forms.ToolStripMenuItem mnuCompleted;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskPriority;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskName;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem showStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPriorityToolStripMenuItem;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem showOverdueTasksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelForwardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem completeForwardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteForwardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelForwardToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem completeForwardToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteForwardToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem forwardOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forwardOnlyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem reloadListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyTaskToolStripMenuItem;
    }
}
