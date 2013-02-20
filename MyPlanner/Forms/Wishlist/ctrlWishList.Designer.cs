namespace MyPlanner
{
    partial class CtrlWishList
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
            this.dgWishList = new System.Windows.Forms.DataGridView();
            this.WishListItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SetStatusAsCompletedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.showCompletedItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblCurrentDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgWishList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgWishList
            // 
            this.dgWishList.AllowUserToResizeColumns = false;
            this.dgWishList.AllowUserToResizeRows = false;
            this.dgWishList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgWishList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgWishList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WishListItemID,
            this.ItemDescription});
            this.dgWishList.ContextMenuStrip = this.contextMenuStrip1;
            this.dgWishList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgWishList.Location = new System.Drawing.Point(3, 3);
            this.dgWishList.MultiSelect = false;
            this.dgWishList.Name = "dgWishList";
            this.dgWishList.ReadOnly = true;
            this.dgWishList.RowHeadersWidth = 15;
            this.dgWishList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgWishList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgWishList.Size = new System.Drawing.Size(418, 478);
            this.dgWishList.TabIndex = 0;
            this.dgWishList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgWishList_CellFormatting);
            // 
            // WishListItemID
            // 
            this.WishListItemID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.WishListItemID.DataPropertyName = "WishListItemID";
            this.WishListItemID.HeaderText = "WishList Item ID";
            this.WishListItemID.Name = "WishListItemID";
            this.WishListItemID.ReadOnly = true;
            this.WishListItemID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.WishListItemID.Visible = false;
            // 
            // ItemDescription
            // 
            this.ItemDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemDescription.DataPropertyName = "ItemDescription";
            this.ItemDescription.HeaderText = "Item Description";
            this.ItemDescription.MinimumWidth = 150;
            this.ItemDescription.Name = "ItemDescription";
            this.ItemDescription.ReadOnly = true;
            this.ItemDescription.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addItemToolStripMenuItem,
            this.editItemToolStripMenuItem,
            this.deleteItemToolStripMenuItem,
            this.toolStripSeparator1,
            this.SetStatusAsCompletedToolStripMenuItem,
            this.toolStripMenuItem1,
            this.showCompletedItemsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(198, 126);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // addItemToolStripMenuItem
            // 
            this.addItemToolStripMenuItem.Name = "addItemToolStripMenuItem";
            this.addItemToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.addItemToolStripMenuItem.Text = "Add Item";
            this.addItemToolStripMenuItem.Click += new System.EventHandler(this.addWishListToolStripMenuItem_Click);
            // 
            // editItemToolStripMenuItem
            // 
            this.editItemToolStripMenuItem.Name = "editItemToolStripMenuItem";
            this.editItemToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.editItemToolStripMenuItem.Text = "Edit Item";
            this.editItemToolStripMenuItem.Click += new System.EventHandler(this.editWishListToolStripMenuItem_Click);
            // 
            // deleteItemToolStripMenuItem
            // 
            this.deleteItemToolStripMenuItem.Name = "deleteItemToolStripMenuItem";
            this.deleteItemToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.deleteItemToolStripMenuItem.Text = "Delete Item";
            this.deleteItemToolStripMenuItem.Click += new System.EventHandler(this.deleteWishListToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(194, 6);
            // 
            // SetStatusAsCompletedToolStripMenuItem
            // 
            this.SetStatusAsCompletedToolStripMenuItem.Name = "SetStatusAsCompletedToolStripMenuItem";
            this.SetStatusAsCompletedToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.SetStatusAsCompletedToolStripMenuItem.Text = "Mark As Completed";
            this.SetStatusAsCompletedToolStripMenuItem.Click += new System.EventHandler(this.SetStatusAsCompletedToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(194, 6);
            // 
            // showCompletedItemsToolStripMenuItem
            // 
            this.showCompletedItemsToolStripMenuItem.Name = "showCompletedItemsToolStripMenuItem";
            this.showCompletedItemsToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.showCompletedItemsToolStripMenuItem.Text = "Show Completed Items";
            this.showCompletedItemsToolStripMenuItem.Click += new System.EventHandler(this.showCompletedItemsToolStripMenuItem_Click);
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
            // CtrlWishList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCurrentDate);
            this.Controls.Add(this.dgWishList);
            this.Name = "CtrlWishList";
            this.Size = new System.Drawing.Size(418, 478);
            ((System.ComponentModel.ISupportInitialize)(this.dgWishList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgWishList;
        private System.Windows.Forms.Label lblCurrentDate;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem SetStatusAsCompletedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem showCompletedItemsToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn WishListItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemDescription;
    }
}
