namespace MyPlanner
{
    partial class frmEditTask
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCurrentDate = new System.Windows.Forms.Label();
            this.chklstCategory = new System.Windows.Forms.CheckedListBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboPriority = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblGoalID = new System.Windows.Forms.Label();
            this.dtpDueOn = new System.Windows.Forms.DateTimePicker();
            this.lblItemID = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtTaskNotes = new System.Windows.Forms.TextBox();
            this.txtTaskName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblCurrentDate);
            this.panel1.Controls.Add(this.chklstCategory);
            this.panel1.Controls.Add(this.cboStatus);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cboPriority);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblGoalID);
            this.panel1.Controls.Add(this.dtpDueOn);
            this.panel1.Controls.Add(this.lblItemID);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.txtTaskNotes);
            this.panel1.Controls.Add(this.txtTaskName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(416, 479);
            this.panel1.TabIndex = 0;
            // 
            // lblCurrentDate
            // 
            this.lblCurrentDate.AutoSize = true;
            this.lblCurrentDate.Location = new System.Drawing.Point(77, 452);
            this.lblCurrentDate.Name = "lblCurrentDate";
            this.lblCurrentDate.Size = new System.Drawing.Size(13, 13);
            this.lblCurrentDate.TabIndex = 15;
            this.lblCurrentDate.Text = "0";
            this.lblCurrentDate.Visible = false;
            // 
            // chklstCategory
            // 
            this.chklstCategory.FormattingEnabled = true;
            this.chklstCategory.Location = new System.Drawing.Point(201, 52);
            this.chklstCategory.Name = "chklstCategory";
            this.chklstCategory.Size = new System.Drawing.Size(199, 64);
            this.chklstCategory.TabIndex = 5;
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(89, 94);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(103, 21);
            this.cboStatus.TabIndex = 4;
            this.cboStatus.SelectedIndexChanged += new System.EventHandler(this.cboStatus_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(198, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Categories : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Status : ";
            // 
            // cboPriority
            // 
            this.cboPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPriority.FormattingEnabled = true;
            this.cboPriority.Location = new System.Drawing.Point(89, 66);
            this.cboPriority.Name = "cboPriority";
            this.cboPriority.Size = new System.Drawing.Size(103, 21);
            this.cboPriority.TabIndex = 3;
            this.cboPriority.SelectedIndexChanged += new System.EventHandler(this.cboPriority_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Priority : ";
            // 
            // lblGoalID
            // 
            this.lblGoalID.AutoSize = true;
            this.lblGoalID.Location = new System.Drawing.Point(58, 452);
            this.lblGoalID.Name = "lblGoalID";
            this.lblGoalID.Size = new System.Drawing.Size(13, 13);
            this.lblGoalID.TabIndex = 11;
            this.lblGoalID.Text = "0";
            this.lblGoalID.Visible = false;
            // 
            // dtpDueOn
            // 
            this.dtpDueOn.CustomFormat = "dd/MMM/yyyy";
            this.dtpDueOn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDueOn.Location = new System.Drawing.Point(89, 40);
            this.dtpDueOn.Name = "dtpDueOn";
            this.dtpDueOn.Size = new System.Drawing.Size(103, 20);
            this.dtpDueOn.TabIndex = 2;
            this.dtpDueOn.ValueChanged += new System.EventHandler(this.dtpDueOn_ValueChanged);
            // 
            // lblItemID
            // 
            this.lblItemID.AutoSize = true;
            this.lblItemID.Location = new System.Drawing.Point(35, 452);
            this.lblItemID.Name = "lblItemID";
            this.lblItemID.Size = new System.Drawing.Size(13, 13);
            this.lblItemID.TabIndex = 10;
            this.lblItemID.Text = "0";
            this.lblItemID.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::MyPlanner.Properties.Resources.close_16X16;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(337, 443);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(63, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "&Close";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::MyPlanner.Properties.Resources.save_16X16;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(268, 443);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(63, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "&Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtTaskNotes
            // 
            this.txtTaskNotes.AcceptsReturn = true;
            this.txtTaskNotes.AcceptsTab = true;
            this.txtTaskNotes.Location = new System.Drawing.Point(89, 121);
            this.txtTaskNotes.Multiline = true;
            this.txtTaskNotes.Name = "txtTaskNotes";
            this.txtTaskNotes.Size = new System.Drawing.Size(311, 316);
            this.txtTaskNotes.TabIndex = 6;
            this.txtTaskNotes.TextChanged += new System.EventHandler(this.txtNotes_TextChanged);
            // 
            // txtTaskName
            // 
            this.txtTaskName.Location = new System.Drawing.Point(89, 13);
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.Size = new System.Drawing.Size(311, 20);
            this.txtTaskName.TabIndex = 1;
            this.txtTaskName.TextChanged += new System.EventHandler(this.txtSubject_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Notes : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Due On : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Task : ";
            // 
            // frmEditTask
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(438, 497);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditTask";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditTask";
            this.Load += new System.EventHandler(this.frmEditTask_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTaskNotes;
        private System.Windows.Forms.TextBox txtTaskName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblItemID;
        private System.Windows.Forms.DateTimePicker dtpDueOn;
        private System.Windows.Forms.Label lblGoalID;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboPriority;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox chklstCategory;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCurrentDate;

    }
}