namespace MyPlanner
{
    partial class frmDailyView
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
            this.dtpCurrentDate = new System.Windows.Forms.DateTimePicker();
            this.ctrlTasksList1 = new MyPlanner.CtrlTasksList();
            this.ctrlDailyNotes1 = new MyPlanner.CtrlDailyNotes();
            this.SuspendLayout();
            // 
            // dtpCurrentDate
            // 
            this.dtpCurrentDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpCurrentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCurrentDate.Location = new System.Drawing.Point(13, 13);
            this.dtpCurrentDate.Name = "dtpCurrentDate";
            this.dtpCurrentDate.Size = new System.Drawing.Size(105, 20);
            this.dtpCurrentDate.TabIndex = 1;
            this.dtpCurrentDate.ValueChanged += new System.EventHandler(this.dtpCurrentDate_ValueChanged);
            // 
            // ctrlTasksList1
            // 
            this.ctrlTasksList1.CurrentUser = null;
            this.ctrlTasksList1.Form_Title = null;
            this.ctrlTasksList1.Location = new System.Drawing.Point(13, 40);
            this.ctrlTasksList1.Name = "ctrlTasksList1";
            this.ctrlTasksList1.ShowPriority = true;
            this.ctrlTasksList1.ShowStatus = true;
            this.ctrlTasksList1.Size = new System.Drawing.Size(418, 478);
            this.ctrlTasksList1.TabIndex = 2;
            // 
            // ctrlDailyNotes1
            // 
            this.ctrlDailyNotes1.CurrentDate = new System.DateTime(2013, 1, 16, 0, 0, 0, 0);
            this.ctrlDailyNotes1.CurrentUser = null;
            this.ctrlDailyNotes1.Form_Title = null;
            this.ctrlDailyNotes1.Location = new System.Drawing.Point(429, 52);
            this.ctrlDailyNotes1.Name = "ctrlDailyNotes1";
            this.ctrlDailyNotes1.Size = new System.Drawing.Size(726, 478);
            this.ctrlDailyNotes1.TabIndex = 3;
            // 
            // frmDailyView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 422);
            this.Controls.Add(this.ctrlDailyNotes1);
            this.Controls.Add(this.ctrlTasksList1);
            this.Controls.Add(this.dtpCurrentDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDailyView";
            this.ShowInTaskbar = false;
            this.Text = "DailyView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpCurrentDate;
        private CtrlTasksList ctrlTasksList1;
        private CtrlDailyNotes ctrlDailyNotes1;
    }
}