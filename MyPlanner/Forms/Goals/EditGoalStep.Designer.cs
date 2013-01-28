namespace MyPlanner
{
    partial class EditGoalStep
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
            this.btnMarkCompleted = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMarkCompleted);
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
            this.panel1.Size = new System.Drawing.Size(416, 193);
            this.panel1.TabIndex = 0;
            // 
            // lblGoalID
            // 
            this.lblGoalID.AutoSize = true;
            this.lblGoalID.Location = new System.Drawing.Point(51, 172);
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
            this.lblItemID.Location = new System.Drawing.Point(28, 172);
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
            this.btnCancel.Location = new System.Drawing.Point(330, 163);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(63, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "&Close";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::MyPlanner.Properties.Resources.save_16X16;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(261, 163);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(63, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "&Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtTaskNotes
            // 
            this.txtTaskNotes.Location = new System.Drawing.Point(89, 66);
            this.txtTaskNotes.Multiline = true;
            this.txtTaskNotes.Name = "txtTaskNotes";
            this.txtTaskNotes.Size = new System.Drawing.Size(311, 90);
            this.txtTaskNotes.TabIndex = 3;
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
            this.label4.Location = new System.Drawing.Point(20, 66);
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
            // btnMarkCompleted
            // 
            this.btnMarkCompleted.Image = global::MyPlanner.Properties.Resources.tick_16X161;
            this.btnMarkCompleted.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMarkCompleted.Location = new System.Drawing.Point(145, 162);
            this.btnMarkCompleted.Name = "btnMarkCompleted";
            this.btnMarkCompleted.Size = new System.Drawing.Size(110, 23);
            this.btnMarkCompleted.TabIndex = 12;
            this.btnMarkCompleted.Text = "Mark C&ompleted";
            this.btnMarkCompleted.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMarkCompleted.UseVisualStyleBackColor = true;
            this.btnMarkCompleted.Click += new System.EventHandler(this.btnMarkCompleted_Click);
            // 
            // EditGoalStep
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(440, 213);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditGoalStep";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditGoalStep";
            this.Load += new System.EventHandler(this.EditGoalStep_Load);
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
        private System.Windows.Forms.Button btnMarkCompleted;

    }
}