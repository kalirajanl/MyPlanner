using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using MyPlanner.BLL;
using MyPlanner.Common;
using MyPlanner.Models;

namespace MyPlanner
{
    public partial class frmEditWishListItem : PopupForm
    {

        public frmEditWishListItem(AppUser usr, PageMode pageMode)
        {
            InitializeComponent();
            CurrentUser = usr;
            CurrentPageMode = pageMode;
        }

        private void frmEditWishListItem_Load(object sender, EventArgs e)
        {
            initPage();
        }

        private void initPage()
        {
            this.txtItemDescription.Text = "";
            this.txtItemNotes.Text = "";
            switch (this.CurrentPageMode)
            {
                case PageMode.Add:
                    {
                        this.Text = ApplicationTitle + " - Add Item";
                        Form_Title = "Add Wish List Item";
                        this.lblItemID.Text = "0";
                        break;
                    }
                case PageMode.Edit:
                    {
                        this.Text = ApplicationTitle + " - Edit Item";
                        Form_Title = "Edit Wish List Item";
                        loadData();
                        break;
                    }
            }
            this.IsPageDirty = false;
        }

        public long ItemID
        {
            get
            {
                return (long)Convert.ToDecimal(this.lblItemID.Text);
            }
            set
            {
                this.lblItemID.Text = value.ToString();
            }
        }

        private void loadData()
        {
            WishListItem wishListItem = BLLWishList.GetWishListItemByID((long)Convert.ToDecimal(this.lblItemID.Text));
            if (wishListItem != null)
            {
                this.txtItemNotes.Text = wishListItem.ItemNotes;
                this.txtItemDescription.Text = wishListItem.ItemDescription;
            }
        }

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {
            IsPageDirty = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (IsPageDirty)
            {
                DialogResult rslt = ShowConfirmation("Do you want to save changes?", Form_Title, MessageBoxButtons.YesNo);
                if (rslt == System.Windows.Forms.DialogResult.Yes)
                {
                    btnSave_Click(null, null);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool returnValue = false;
            if (isValidData(true))
            {
                if (IsPageDirty)
                {
                    WishListItem wishListItem = null;
                    switch (this.CurrentPageMode)
                    {
                        case PageMode.Add:
                            {
                                wishListItem = new WishListItem();
                                break;
                            }
                        case PageMode.Edit:
                            {
                                wishListItem = BLLWishList.GetWishListItemByID((long)Convert.ToDecimal(this.lblItemID.Text));
                                break;
                            }
                    }
                    wishListItem.ForUser = CurrentUser;
                    wishListItem.ItemDescription = this.txtItemDescription.Text;
                    wishListItem.ItemNotes = this.txtItemNotes.Text;
                    switch (this.CurrentPageMode)
                    {
                        case PageMode.Add:
                            {
                                returnValue = BLLWishList.AddWishListItem(wishListItem);
                                break;
                            }
                        case PageMode.Edit:
                            {
                                returnValue = BLLWishList.UpdateWishListItem(wishListItem);
                                break;
                            }
                    }
                    wishListItem = null;
                }
                this.Hide();
                this.Close();
            }
        }

        private bool isValidData(bool showMessage)
        {
            bool returnValue = true;
            if (this.txtItemDescription.Text.Trim().Equals(""))
            {
                ShowError("Please enter Description.", Form_Title);
                returnValue = false;
                this.txtItemDescription.Focus();
            }
            return returnValue;
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            IsPageDirty = true;
        }
    }
}
