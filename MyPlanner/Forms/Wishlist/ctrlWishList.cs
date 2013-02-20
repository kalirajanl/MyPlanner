using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyPlanner.BLL;
using MyPlanner.Common;
using MyPlanner.Models;

namespace MyPlanner
{
    public partial class CtrlWishList : BaseUserControl
    {

        private bool _showCompletedItems = false;

        public CtrlWishList()
        {
            InitializeComponent();
            _showCompletedItems = false;
        }

        public CtrlWishList(AppUser usr, bool showCompletedItems = false)
        {
            InitializeComponent();
            CurrentUser = usr;
            _showCompletedItems = showCompletedItems;
        }

        public bool ShowCompletedItems
        {
            get
            {
                return _showCompletedItems;
            }
            set
            {
                _showCompletedItems = value;
            }
        }

        public void LoadWishList()
        {
            this.dgWishList.Left = 3;
            this.dgWishList.Top = 3;
            this.dgWishList.Height = this.Height - 55;
            this.dgWishList.Width = this.Width - 5;
            this.dgWishList.AutoGenerateColumns = false;
            this.dgWishList.Columns[1].Width = 70;
            Form_Title = "Wish List";
            initPage();
        }

        private void initPage()
        {
            if (CurrentUser != null)
            {
                this.dgWishList.DataSource = BLLWishList.GetWishListForUser(CurrentUser.UserID, _showCompletedItems);
            }
        }

        private void addWishListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditWishListItem childform = new frmEditWishListItem(CurrentUser, PageMode.Add);
            childform.ShowDialog();
            initPage();
        }

        private void editWishListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgWishList.CurrentRow == null)
            {
                ShowError("Please select a row.", Form_Title);
            }
            else
            {
                frmEditWishListItem childform = new frmEditWishListItem(CurrentUser, PageMode.Edit);
                childform.ItemID = (long)Convert.ToDecimal(this.dgWishList.CurrentRow.Cells[0].Value);
                childform.ShowDialog();
                initPage();
            }
        }

        private void deleteWishListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgWishList.CurrentRow == null)
            {
                ShowError("Please select a row.", Form_Title);
            }
            else
            {
                long wishListItemID = (long)Convert.ToDecimal(this.dgWishList.CurrentRow.Cells[0].Value);
                BLLWishList.DeleteWishListItem(wishListItemID);
                initPage();
            }
        }

        private void setWishListItemAsCompleted()
        {
            if (this.dgWishList.CurrentRow == null)
            {
                ShowError("Please select a row.", Form_Title);
            }
            else
            {
                long wishListItemID = (long)Convert.ToDecimal(this.dgWishList.CurrentRow.Cells[0].Value);
                BLLWishList.SetWishListItemAsCompleted(wishListItemID);
                initPage();
            }
        }


        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            this.editItemToolStripMenuItem.Enabled = false;
            this.deleteItemToolStripMenuItem.Enabled = false;
            this.SetStatusAsCompletedToolStripMenuItem.Enabled = false;
            if (this.dgWishList.CurrentRow != null)
            {
                this.editItemToolStripMenuItem.Enabled = true;
                this.deleteItemToolStripMenuItem.Enabled = true;
                List<WishListItem> wishList = (List<WishListItem>)this.dgWishList.DataSource;
                if (wishList != null)
                {
                    if (!wishList[this.dgWishList.CurrentRow.Index].IsCompleted)
                    {
                        this.SetStatusAsCompletedToolStripMenuItem.Enabled = true;
                    }
                }
            }
            if (ShowCompletedItems)
            {
                this.showCompletedItemsToolStripMenuItem.Text = "Hide Completed Items";
            }
            else
            {
                this.showCompletedItemsToolStripMenuItem.Text = "Show Completed Items";
            }
        }

        private void dgWishList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgWishList.Rows[e.RowIndex].Cells[1] != null)
            {
                Font tn = e.CellStyle.Font;
                if (tn == null)
                {
                    tn = this.dgWishList.Font;
                }
                if (tn == null)
                {
                    tn = new Font("Arial", 12);
                }
                List<WishListItem> wishList = (List<WishListItem>)this.dgWishList.DataSource;
                if (wishList != null)
                {
                    if (wishList[e.RowIndex].IsCompleted)
                    {
                        tn = new Font(tn.FontFamily, tn.SizeInPoints, FontStyle.Strikeout);
                    }
                }
                e.CellStyle.Font = tn;
                DataGridViewCell cell = this.dgWishList.Rows[e.RowIndex].Cells[1];
                cell.ToolTipText = wishList[e.RowIndex].ItemNotes;
            }
        }

        private void showCompletedItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCompletedItems = !ShowCompletedItems;
            LoadWishList();
        }

        private void SetStatusAsCompletedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgWishList.CurrentRow == null)
            {
                ShowError("Please select a row.", Form_Title);
            }
            else
            {
                long wishListItemID = (long)Convert.ToDecimal(this.dgWishList.CurrentRow.Cells[0].Value);
                BLLWishList.SetWishListItemAsCompleted(wishListItemID);
                LoadWishList();
            }
        }
    }
}
