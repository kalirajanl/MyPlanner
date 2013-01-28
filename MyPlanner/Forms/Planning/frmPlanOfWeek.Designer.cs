namespace MyPlanner
{
    partial class frmPlanOfWeek
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnScheduleTasks = new System.Windows.Forms.Button();
            this.btnScheduleCompass = new System.Windows.Forms.Button();
            this.btnReviewGoals = new System.Windows.Forms.Button();
            this.btnReviewMission = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblCurrentStep = new System.Windows.Forms.Label();
            this.ctrlMission1 = new MyPlanner.CtrlMission();
            this.ctrlValue1 = new MyPlanner.CtrlValue();
            this.ctrlGoalsAndSteps1 = new MyPlanner.CtrlGoalsAndSteps();
            this.ctrlWeeklyCompass1 = new MyPlanner.CtrlWeeklyCompass();
            this.ctrlWeeklyView1 = new MyPlanner.CtrlWeeklyView();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlViewWeeklyCompass1 = new MyPlanner.CtrlViewWeeklyCompass();
            this.SuspendLayout();
            // 
            // dtpCurrentDate
            // 
            this.dtpCurrentDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpCurrentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCurrentDate.Location = new System.Drawing.Point(128, 19);
            this.dtpCurrentDate.Name = "dtpCurrentDate";
            this.dtpCurrentDate.Size = new System.Drawing.Size(105, 20);
            this.dtpCurrentDate.TabIndex = 2;
            this.dtpCurrentDate.ValueChanged += new System.EventHandler(this.dtpCurrentDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Week Starting From";
            // 
            // btnScheduleTasks
            // 
            this.btnScheduleTasks.Font = new System.Drawing.Font("MS Outlook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScheduleTasks.Image = global::MyPlanner.Properties.Resources.orange_arrow_small;
            this.btnScheduleTasks.Location = new System.Drawing.Point(901, 56);
            this.btnScheduleTasks.Name = "btnScheduleTasks";
            this.btnScheduleTasks.Size = new System.Drawing.Size(234, 60);
            this.btnScheduleTasks.TabIndex = 7;
            this.btnScheduleTasks.Text = "Schedule Tasks";
            this.btnScheduleTasks.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnScheduleTasks.UseVisualStyleBackColor = true;
            this.btnScheduleTasks.Click += new System.EventHandler(this.btnScheduleTasks_Click);
            // 
            // btnScheduleCompass
            // 
            this.btnScheduleCompass.Font = new System.Drawing.Font("MS Outlook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScheduleCompass.Image = global::MyPlanner.Properties.Resources.orange_arrow_small;
            this.btnScheduleCompass.Location = new System.Drawing.Point(605, 56);
            this.btnScheduleCompass.Name = "btnScheduleCompass";
            this.btnScheduleCompass.Size = new System.Drawing.Size(234, 60);
            this.btnScheduleCompass.TabIndex = 6;
            this.btnScheduleCompass.Text = "Schedule Compass";
            this.btnScheduleCompass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnScheduleCompass.UseVisualStyleBackColor = true;
            this.btnScheduleCompass.Click += new System.EventHandler(this.btnScheduleCompass_Click);
            // 
            // btnReviewGoals
            // 
            this.btnReviewGoals.Font = new System.Drawing.Font("MS Outlook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReviewGoals.Image = global::MyPlanner.Properties.Resources.orange_arrow_small;
            this.btnReviewGoals.Location = new System.Drawing.Point(309, 56);
            this.btnReviewGoals.Name = "btnReviewGoals";
            this.btnReviewGoals.Size = new System.Drawing.Size(234, 60);
            this.btnReviewGoals.TabIndex = 5;
            this.btnReviewGoals.Text = "Review Goals";
            this.btnReviewGoals.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReviewGoals.UseVisualStyleBackColor = true;
            this.btnReviewGoals.Click += new System.EventHandler(this.btnReviewGoals_Click);
            // 
            // btnReviewMission
            // 
            this.btnReviewMission.Font = new System.Drawing.Font("MS Outlook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReviewMission.Image = global::MyPlanner.Properties.Resources.green_arrow_small;
            this.btnReviewMission.Location = new System.Drawing.Point(13, 56);
            this.btnReviewMission.Name = "btnReviewMission";
            this.btnReviewMission.Size = new System.Drawing.Size(234, 60);
            this.btnReviewMission.TabIndex = 4;
            this.btnReviewMission.Text = "Review Mission";
            this.btnReviewMission.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReviewMission.UseVisualStyleBackColor = true;
            this.btnReviewMission.Click += new System.EventHandler(this.btnReviewMission_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(1163, 506);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 11;
            this.btnNext.Text = "&Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblCurrentStep
            // 
            this.lblCurrentStep.AutoSize = true;
            this.lblCurrentStep.Location = new System.Drawing.Point(1066, 362);
            this.lblCurrentStep.Name = "lblCurrentStep";
            this.lblCurrentStep.Size = new System.Drawing.Size(13, 13);
            this.lblCurrentStep.TabIndex = 12;
            this.lblCurrentStep.Text = "0";
            this.lblCurrentStep.Visible = false;
            // 
            // ctrlMission1
            // 
            this.ctrlMission1.CurrentUser = null;
            this.ctrlMission1.Form_Title = null;
            this.ctrlMission1.Location = new System.Drawing.Point(13, 112);
            this.ctrlMission1.Name = "ctrlMission1";
            this.ctrlMission1.Size = new System.Drawing.Size(530, 288);
            this.ctrlMission1.TabIndex = 13;
            // 
            // ctrlValue1
            // 
            this.ctrlValue1.CurrentUser = null;
            this.ctrlValue1.Form_Title = null;
            this.ctrlValue1.Location = new System.Drawing.Point(588, 112);
            this.ctrlValue1.Name = "ctrlValue1";
            this.ctrlValue1.Size = new System.Drawing.Size(650, 288);
            this.ctrlValue1.TabIndex = 14;
            // 
            // ctrlGoalsAndSteps1
            // 
            this.ctrlGoalsAndSteps1.AccessibleName = "";
            this.ctrlGoalsAndSteps1.CurrentUser = null;
            this.ctrlGoalsAndSteps1.Form_Title = null;
            this.ctrlGoalsAndSteps1.Location = new System.Drawing.Point(24, 194);
            this.ctrlGoalsAndSteps1.Name = "ctrlGoalsAndSteps1";
            this.ctrlGoalsAndSteps1.Size = new System.Drawing.Size(1214, 278);
            this.ctrlGoalsAndSteps1.TabIndex = 15;
            // 
            // ctrlWeeklyCompass1
            // 
            this.ctrlWeeklyCompass1.CurrentDate = new System.DateTime(2013, 1, 16, 12, 59, 29, 894);
            this.ctrlWeeklyCompass1.CurrentUser = null;
            this.ctrlWeeklyCompass1.Form_Title = null;
            this.ctrlWeeklyCompass1.Location = new System.Drawing.Point(309, 347);
            this.ctrlWeeklyCompass1.Name = "ctrlWeeklyCompass1";
            this.ctrlWeeklyCompass1.Size = new System.Drawing.Size(929, 288);
            this.ctrlWeeklyCompass1.TabIndex = 16;
            // 
            // ctrlWeeklyView1
            // 
            this.ctrlWeeklyView1.CurrentDate = new System.DateTime(2013, 1, 14, 0, 0, 0, 0);
            this.ctrlWeeklyView1.CurrentUser = null;
            this.ctrlWeeklyView1.Form_Title = null;
            this.ctrlWeeklyView1.Location = new System.Drawing.Point(24, 194);
            this.ctrlWeeklyView1.Name = "ctrlWeeklyView1";
            this.ctrlWeeklyView1.ShowWorkWeekOnly = false;
            this.ctrlWeeklyView1.Size = new System.Drawing.Size(1214, 278);
            this.ctrlWeeklyView1.TabIndex = 17;
            this.ctrlWeeklyView1.TaskWidth = 170;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(1082, 506);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlViewWeeklyCompass1
            // 
            this.ctrlViewWeeklyCompass1.CurrentDate = new System.DateTime(2013, 1, 14, 0, 0, 0, 0);
            this.ctrlViewWeeklyCompass1.CurrentUser = null;
            this.ctrlViewWeeklyCompass1.Form_Title = null;
            this.ctrlViewWeeklyCompass1.Location = new System.Drawing.Point(24, 347);
            this.ctrlViewWeeklyCompass1.Name = "ctrlViewWeeklyCompass1";
            this.ctrlViewWeeklyCompass1.Size = new System.Drawing.Size(279, 288);
            this.ctrlViewWeeklyCompass1.TabIndex = 19;
            // 
            // frmPlanOfWeek
            // 
            this.AcceptButton = this.btnNext;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1323, 553);
            this.Controls.Add(this.ctrlViewWeeklyCompass1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.ctrlWeeklyCompass1);
            this.Controls.Add(this.ctrlGoalsAndSteps1);
            this.Controls.Add(this.ctrlMission1);
            this.Controls.Add(this.lblCurrentStep);
            this.Controls.Add(this.btnScheduleTasks);
            this.Controls.Add(this.btnScheduleCompass);
            this.Controls.Add(this.btnReviewGoals);
            this.Controls.Add(this.btnReviewMission);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpCurrentDate);
            this.Controls.Add(this.ctrlWeeklyView1);
            this.Controls.Add(this.ctrlValue1);
            this.Name = "frmPlanOfWeek";
            this.Text = "PlanOfWeek";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpCurrentDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReviewMission;
        private System.Windows.Forms.Button btnReviewGoals;
        private System.Windows.Forms.Button btnScheduleCompass;
        private System.Windows.Forms.Button btnScheduleTasks;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblCurrentStep;
        private CtrlMission ctrlMission1;
        private CtrlValue ctrlValue1;
        private CtrlGoalsAndSteps ctrlGoalsAndSteps1;
        private CtrlWeeklyCompass ctrlWeeklyCompass1;
        private CtrlWeeklyView ctrlWeeklyView1;
        private System.Windows.Forms.Button btnClose;
        private CtrlViewWeeklyCompass ctrlViewWeeklyCompass1;
    }
}