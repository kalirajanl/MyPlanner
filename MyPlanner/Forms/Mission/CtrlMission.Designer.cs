namespace MyPlanner
{
    partial class CtrlMission
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
            this.dgMission = new System.Windows.Forms.DataGridView();
            this.MissionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MissionTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MissionNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewMissionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMissionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgMission)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgMission
            // 
            this.dgMission.AllowUserToResizeColumns = false;
            this.dgMission.AllowUserToResizeRows = false;
            this.dgMission.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgMission.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMission.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MissionID,
            this.MissionTitle,
            this.MissionNotes});
            this.dgMission.ContextMenuStrip = this.contextMenuStrip1;
            this.dgMission.Location = new System.Drawing.Point(12, 13);
            this.dgMission.Name = "dgMission";
            this.dgMission.Size = new System.Drawing.Size(748, 305);
            this.dgMission.TabIndex = 1;
            this.dgMission.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMission_RowLeave);
            this.dgMission.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgMission_RowValidating);
            // 
            // MissionID
            // 
            this.MissionID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MissionID.DataPropertyName = "MissionID";
            this.MissionID.HeaderText = "Mission ID";
            this.MissionID.Name = "MissionID";
            this.MissionID.Visible = false;
            // 
            // MissionTitle
            // 
            this.MissionTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MissionTitle.DataPropertyName = "MissionTitle";
            this.MissionTitle.HeaderText = "Mission Title";
            this.MissionTitle.Name = "MissionTitle";
            this.MissionTitle.Width = 150;
            // 
            // MissionNotes
            // 
            this.MissionNotes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MissionNotes.DataPropertyName = "MissionNotes";
            this.MissionNotes.HeaderText = "Notes";
            this.MissionNotes.Name = "MissionNotes";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewMissionToolStripMenuItem,
            this.deleteMissionToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(168, 70);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // addNewMissionToolStripMenuItem
            // 
            this.addNewMissionToolStripMenuItem.Name = "addNewMissionToolStripMenuItem";
            this.addNewMissionToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.addNewMissionToolStripMenuItem.Text = "Add New Mission";
            this.addNewMissionToolStripMenuItem.Click += new System.EventHandler(this.addNewMissionToolStripMenuItem_Click);
            // 
            // deleteMissionToolStripMenuItem
            // 
            this.deleteMissionToolStripMenuItem.Name = "deleteMissionToolStripMenuItem";
            this.deleteMissionToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.deleteMissionToolStripMenuItem.Text = "Delete Mission";
            this.deleteMissionToolStripMenuItem.Click += new System.EventHandler(this.deleteMissionToolStripMenuItem_Click);
            // 
            // CtrlMission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgMission);
            this.Name = "CtrlMission";
            this.Size = new System.Drawing.Size(774, 331);
            this.Load += new System.EventHandler(this.CtrlMission_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgMission)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgMission;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addNewMissionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteMissionToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn MissionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MissionTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn MissionNotes;

    }
}
