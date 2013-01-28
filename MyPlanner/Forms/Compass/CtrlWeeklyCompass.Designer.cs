namespace MyPlanner
{
    partial class CtrlWeeklyCompass
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
            this.dgCompass = new System.Windows.Forms.DataGridView();
            this.BigRockID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AsCompassRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BigRock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddBigRock = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteBigRock = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuAddCompassRole = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditCompassRole = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteCompassRole = new System.Windows.Forms.ToolStripMenuItem();
            this.tvCompassRoles = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.dgCompass)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgCompass
            // 
            this.dgCompass.AllowUserToResizeColumns = false;
            this.dgCompass.AllowUserToResizeRows = false;
            this.dgCompass.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCompass.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BigRockID,
            this.AsCompassRole,
            this.BigRock});
            this.dgCompass.ContextMenuStrip = this.contextMenuStrip1;
            this.dgCompass.Location = new System.Drawing.Point(305, 15);
            this.dgCompass.MultiSelect = false;
            this.dgCompass.Name = "dgCompass";
            this.dgCompass.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgCompass.Size = new System.Drawing.Size(425, 279);
            this.dgCompass.TabIndex = 0;
            this.dgCompass.VirtualMode = true;
            this.dgCompass.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCompass_RowLeave);
            // 
            // BigRockID
            // 
            this.BigRockID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.BigRockID.DataPropertyName = "BigRockID";
            this.BigRockID.HeaderText = "BigRockID";
            this.BigRockID.Name = "BigRockID";
            this.BigRockID.ReadOnly = true;
            this.BigRockID.Visible = false;
            // 
            // AsCompassRole
            // 
            this.AsCompassRole.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.AsCompassRole.DataPropertyName = "AsCompassRole.CompassRoleID";
            this.AsCompassRole.HeaderText = "Compass Role ID";
            this.AsCompassRole.Name = "AsCompassRole";
            this.AsCompassRole.ReadOnly = true;
            this.AsCompassRole.Visible = false;
            // 
            // BigRock
            // 
            this.BigRock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BigRock.DataPropertyName = "BigRockName";
            this.BigRock.HeaderText = "Big Rock";
            this.BigRock.Name = "BigRock";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddBigRock,
            this.mnuDeleteBigRock,
            this.toolStripSeparator1,
            this.mnuAddCompassRole,
            this.mnuEditCompassRole,
            this.mnuDeleteCompassRole});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(186, 142);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // mnuAddBigRock
            // 
            this.mnuAddBigRock.Name = "mnuAddBigRock";
            this.mnuAddBigRock.Size = new System.Drawing.Size(185, 22);
            this.mnuAddBigRock.Text = "Add Big Rock";
            this.mnuAddBigRock.Click += new System.EventHandler(this.mnuAddBigRock_Click);
            // 
            // mnuDeleteBigRock
            // 
            this.mnuDeleteBigRock.Name = "mnuDeleteBigRock";
            this.mnuDeleteBigRock.Size = new System.Drawing.Size(185, 22);
            this.mnuDeleteBigRock.Text = "Delete Big Rock";
            this.mnuDeleteBigRock.Click += new System.EventHandler(this.mnuDeleteBigRock_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(182, 6);
            // 
            // mnuAddCompassRole
            // 
            this.mnuAddCompassRole.Name = "mnuAddCompassRole";
            this.mnuAddCompassRole.Size = new System.Drawing.Size(185, 22);
            this.mnuAddCompassRole.Text = "Add Compass Role";
            this.mnuAddCompassRole.Click += new System.EventHandler(this.mnuAddCompassRole_Click);
            // 
            // mnuEditCompassRole
            // 
            this.mnuEditCompassRole.Name = "mnuEditCompassRole";
            this.mnuEditCompassRole.Size = new System.Drawing.Size(185, 22);
            this.mnuEditCompassRole.Text = "Edit Compass Role";
            this.mnuEditCompassRole.Click += new System.EventHandler(this.mnuEditCompassRole_Click);
            // 
            // mnuDeleteCompassRole
            // 
            this.mnuDeleteCompassRole.Name = "mnuDeleteCompassRole";
            this.mnuDeleteCompassRole.Size = new System.Drawing.Size(185, 22);
            this.mnuDeleteCompassRole.Text = "Delete Compass Role";
            this.mnuDeleteCompassRole.Click += new System.EventHandler(this.mnuDeleteCompassRole_Click);
            // 
            // tvCompassRoles
            // 
            this.tvCompassRoles.ContextMenuStrip = this.contextMenuStrip1;
            this.tvCompassRoles.HideSelection = false;
            this.tvCompassRoles.HotTracking = true;
            this.tvCompassRoles.Location = new System.Drawing.Point(15, 15);
            this.tvCompassRoles.Name = "tvCompassRoles";
            this.tvCompassRoles.Size = new System.Drawing.Size(254, 279);
            this.tvCompassRoles.TabIndex = 1;
            this.tvCompassRoles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvCompassRoles_AfterSelect);
            this.tvCompassRoles.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvCompassRoles_NodeMouseClick);
            // 
            // CtrlWeeklyCompass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tvCompassRoles);
            this.Controls.Add(this.dgCompass);
            this.Name = "CtrlWeeklyCompass";
            this.Size = new System.Drawing.Size(800, 309);
            ((System.ComponentModel.ISupportInitialize)(this.dgCompass)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgCompass;
        private System.Windows.Forms.TreeView tvCompassRoles;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuAddBigRock;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteBigRock;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuAddCompassRole;
        private System.Windows.Forms.ToolStripMenuItem mnuEditCompassRole;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteCompassRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn BigRockID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AsCompassRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn BigRock;
    }
}
