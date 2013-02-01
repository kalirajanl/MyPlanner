using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyPlanner.BLL;
using MyPlanner.Common;
using MyPlanner.Models;

namespace MyPlanner
{
    public partial class EditCompassRole : PopupForm
    {

        public EditCompassRole(AppUser usr, PageMode pageMode)
        {
            InitializeComponent();
            CurrentUser = usr;
            CurrentPageMode = pageMode;
        }

        private void EditCompassRole_Load(object sender, EventArgs e)
        {
            initPage();
        }

        private void initPage()
        {
            this.txtCompassRoleName.Text = "";
            this.txtNotes.Text = "";
            switch (this.CurrentPageMode)
            {
                case PageMode.Add:
                    {
                        this.Text = ApplicationTitle + " - Add Compass Role";
                        Form_Title = "Add Compass Role";
                        this.lblItemID.Text = "0";
                        break;
                    }
                case PageMode.Edit:
                    {
                        this.Text = ApplicationTitle + " - Edit Compass Role";
                        Form_Title = "Edit Compass Role";
                        loadData();
                        break;
                    }
            }
            this.IsPageDirty = false;
        }

        public int ItemID
        {
            get
            {
                return Convert.ToInt32(this.lblItemID.Text);
            }
            set
            {
                this.lblItemID.Text = value.ToString();
            }
        }

        private void loadData()
        {
            CompassRole compassRole = BLLCompassRole.GetCompassRoleByID(Convert.ToInt32(this.lblItemID.Text));
            if (compassRole != null)
            {
                this.txtCompassRoleName.Text = compassRole.CompassRoleName;
                this.txtNotes.Text = compassRole.Notes;
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
                    CompassRole compassRole = null;
                    switch (this.CurrentPageMode)
                    {
                        case PageMode.Add:
                            {
                                compassRole = new CompassRole();
                                break;
                            }
                        case PageMode.Edit:
                            {
                                compassRole = BLLCompassRole.GetCompassRoleByID(Convert.ToInt32(this.lblItemID.Text));
                                break;
                            }
                    }

                    compassRole.CompassRoleName = this.txtCompassRoleName.Text;
                    compassRole.Notes = this.txtNotes.Text;
                    compassRole.ForUser = this.CurrentUser;
                    switch (this.CurrentPageMode)
                    {
                        case PageMode.Add:
                            {
                                returnValue = BLLCompassRole.AddCompassRole(compassRole);
                                break;
                            }
                        case PageMode.Edit:
                            {
                                returnValue = BLLCompassRole.UpdateCompassRole(compassRole);
                                break;
                            }
                    }
                    compassRole = null;
                }
                this.Hide();
                this.Close();
            }
        }

        private bool isValidData(bool showMessage)
        {
            bool returnValue = true;
            if (this.txtCompassRoleName.Text.Trim().Equals(""))
            {
                ShowError("Please enter Compass Role.", Form_Title);
                returnValue = false;
                this.txtCompassRoleName.Focus();
            }
            return returnValue;
        }

        private void txtCompassRoleName_TextChanged(object sender, EventArgs e)
        {
            IsPageDirty = true;
        }
    }
}
