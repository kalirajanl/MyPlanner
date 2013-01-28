namespace MyPlanner
{
    partial class CtrlValue
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
            this.dgValue = new System.Windows.Forms.DataGridView();
            this.ValueID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgValue)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgValue
            // 
            this.dgValue.AllowUserToResizeColumns = false;
            this.dgValue.AllowUserToResizeRows = false;
            this.dgValue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgValue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgValue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ValueID,
            this.ValueTitle,
            this.ValueNotes});
            this.dgValue.ContextMenuStrip = this.contextMenuStrip1;
            this.dgValue.Location = new System.Drawing.Point(12, 13);
            this.dgValue.Name = "dgValue";
            this.dgValue.Size = new System.Drawing.Size(748, 305);
            this.dgValue.TabIndex = 1;
            this.dgValue.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgValue_RowLeave);
            this.dgValue.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgValue_RowValidating);
            // 
            // ValueID
            // 
            this.ValueID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ValueID.DataPropertyName = "ValueID";
            this.ValueID.HeaderText = "Value ID";
            this.ValueID.Name = "ValueID";
            this.ValueID.Visible = false;
            // 
            // ValueTitle
            // 
            this.ValueTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ValueTitle.DataPropertyName = "ValueTitle";
            this.ValueTitle.HeaderText = "Value Title";
            this.ValueTitle.Name = "ValueTitle";
            this.ValueTitle.Width = 150;
            // 
            // ValueNotes
            // 
            this.ValueNotes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ValueNotes.DataPropertyName = "ValueNotes";
            this.ValueNotes.HeaderText = "Notes";
            this.ValueNotes.Name = "ValueNotes";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewValueToolStripMenuItem,
            this.deleteValueToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(156, 70);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // addNewValueToolStripMenuItem
            // 
            this.addNewValueToolStripMenuItem.Name = "addNewValueToolStripMenuItem";
            this.addNewValueToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.addNewValueToolStripMenuItem.Text = "Add New Value";
            this.addNewValueToolStripMenuItem.Click += new System.EventHandler(this.addNewValueToolStripMenuItem_Click);
            // 
            // deleteValueToolStripMenuItem
            // 
            this.deleteValueToolStripMenuItem.Name = "deleteValueToolStripMenuItem";
            this.deleteValueToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.deleteValueToolStripMenuItem.Text = "Delete Value";
            this.deleteValueToolStripMenuItem.Click += new System.EventHandler(this.deleteValueToolStripMenuItem_Click);
            // 
            // CtrlValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgValue);
            this.Name = "CtrlValue";
            this.Size = new System.Drawing.Size(774, 331);
            this.Load += new System.EventHandler(this.CtrlValue_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgValue)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgValue;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addNewValueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteValueToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueNotes;

    }
}
