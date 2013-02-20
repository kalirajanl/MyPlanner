namespace MyPlanner
{
    partial class frmEditWishListItem
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
            this.lblGoalID = new System.Windows.Forms.Label();
            this.lblItemID = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtItemNotes = new System.Windows.Forms.TextBox();
            this.txtItemDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblCurrentDate);
            this.panel1.Controls.Add(this.lblGoalID);
            this.panel1.Controls.Add(this.lblItemID);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.txtItemNotes);
            this.panel1.Controls.Add(this.txtItemDescription);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(410, 404);
            this.panel1.TabIndex = 0;
            // 
            // lblCurrentDate
            // 
            this.lblCurrentDate.AutoSize = true;
            this.lblCurrentDate.Location = new System.Drawing.Point(77, 377);
            this.lblCurrentDate.Name = "lblCurrentDate";
            this.lblCurrentDate.Size = new System.Drawing.Size(13, 13);
            this.lblCurrentDate.TabIndex = 15;
            this.lblCurrentDate.Text = "0";
            this.lblCurrentDate.Visible = false;
            // 
            // lblGoalID
            // 
            this.lblGoalID.AutoSize = true;
            this.lblGoalID.Location = new System.Drawing.Point(58, 377);
            this.lblGoalID.Name = "lblGoalID";
            this.lblGoalID.Size = new System.Drawing.Size(13, 13);
            this.lblGoalID.TabIndex = 11;
            this.lblGoalID.Text = "0";
            this.lblGoalID.Visible = false;
            // 
            // lblItemID
            // 
            this.lblItemID.AutoSize = true;
            this.lblItemID.Location = new System.Drawing.Point(35, 377);
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
            this.btnCancel.Location = new System.Drawing.Point(337, 368);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(63, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Close";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::MyPlanner.Properties.Resources.save_16X16;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(268, 368);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(63, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "&Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtItemNotes
            // 
            this.txtItemNotes.AcceptsReturn = true;
            this.txtItemNotes.AcceptsTab = true;
            this.txtItemNotes.Location = new System.Drawing.Point(89, 39);
            this.txtItemNotes.Multiline = true;
            this.txtItemNotes.Name = "txtItemNotes";
            this.txtItemNotes.Size = new System.Drawing.Size(311, 323);
            this.txtItemNotes.TabIndex = 2;
            this.txtItemNotes.TextChanged += new System.EventHandler(this.txtNotes_TextChanged);
            // 
            // txtItemDescription
            // 
            this.txtItemDescription.Location = new System.Drawing.Point(89, 13);
            this.txtItemDescription.Name = "txtItemDescription";
            this.txtItemDescription.Size = new System.Drawing.Size(311, 20);
            this.txtItemDescription.TabIndex = 1;
            this.txtItemDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Notes : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Description : ";
            // 
            // frmEditWishListItem
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(428, 428);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditWishListItem";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit WishList Item";
            this.Load += new System.EventHandler(this.frmEditWishListItem_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtItemNotes;
        private System.Windows.Forms.TextBox txtItemDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblItemID;
        private System.Windows.Forms.Label lblGoalID;
        private System.Windows.Forms.Label lblCurrentDate;

    }
}