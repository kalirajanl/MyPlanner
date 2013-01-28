namespace MyPlanner
{
    partial class CtrlViewWeeklyCompass
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgWeeklyCompass = new System.Windows.Forms.DataGridView();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgWeeklyCompass)).BeginInit();
            this.SuspendLayout();
            // 
            // dgWeeklyCompass
            // 
            this.dgWeeklyCompass.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgWeeklyCompass.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.RowData});
            this.dgWeeklyCompass.Location = new System.Drawing.Point(4, 4);
            this.dgWeeklyCompass.Name = "dgWeeklyCompass";
            this.dgWeeklyCompass.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgWeeklyCompass.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgWeeklyCompass.RowHeadersVisible = false;
            this.dgWeeklyCompass.Size = new System.Drawing.Size(481, 433);
            this.dgWeeklyCompass.TabIndex = 0;
            this.dgWeeklyCompass.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgWeeklyCompass_CellFormatting);
            // 
            // RowID
            // 
            this.RowID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.RowID.DataPropertyName = "CompassItemID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // RowData
            // 
            this.RowData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RowData.DataPropertyName = "CompassItemName";
            this.RowData.HeaderText = "Roles And Big Rocks";
            this.RowData.Name = "RowData";
            this.RowData.ReadOnly = true;
            // 
            // CtrlViewWeeklyCompass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgWeeklyCompass);
            this.Name = "CtrlViewWeeklyCompass";
            this.Size = new System.Drawing.Size(488, 449);
            ((System.ComponentModel.ISupportInitialize)(this.dgWeeklyCompass)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgWeeklyCompass;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowData;
    }
}
