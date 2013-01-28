using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyPlanner.Models;
using MyPlanner.BLL;

namespace MyPlanner
{
    public partial class CtrlWeeklyCompass : BaseUserControl
    {
        private DateTime _currentDate;

        private int colIDXForEditCell = 2;

        public CtrlWeeklyCompass()
        {
            InitializeComponent();
            _currentDate = DateTime.Now;
            this.dgCompass.AutoGenerateColumns = false;
        }

        public DateTime CurrentDate
        {
            get
            {
                return _currentDate;
            }
            set
            {
                _currentDate = value;
                initPage();
            }
        }

        private void initPage()
        {
            if (CurrentUser != null)
            {
                this.dgCompass.Width = this.Width - (this.tvCompassRoles.Width + 25);

                this.tvCompassRoles.Nodes.Clear();

                TreeNode tnRoot = new TreeNode();
                tnRoot.Text = "My Compass Roles";
                tnRoot.Tag = "0";

                List<CompassRole> compassRoles = BLLCompassRole.GetCompassRoles(CurrentUser.UserID, false);
                for (int i = 0; i <= compassRoles.Count - 1; i++)
                {
                    TreeNode tnCompassRole = new TreeNode();
                    tnCompassRole.Text = compassRoles[i].CompassRoleName;
                    tnCompassRole.Tag = compassRoles[i].CompassRoleID.ToString();
                    tnRoot.Nodes.Add(tnCompassRole);
                    tnCompassRole = null;
                }

                tvCompassRoles.Nodes.Add(tnRoot);
                if (tnRoot.Nodes.Count > 0)
                {
                    tvCompassRoles.SelectedNode = tvCompassRoles.Nodes[0].Nodes[0];
                }
                else
                {
                    tvCompassRoles.SelectedNode = tvCompassRoles.Nodes[0];
                }
                bindBigRocks(Convert.ToInt32(tvCompassRoles.SelectedNode.Tag));

                tvCompassRoles.ExpandAll();

            }
        }

        private void tvCompassRoles_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            bindBigRocks(Convert.ToInt32(e.Node.Tag));
        }

        private void tvCompassRoles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            bindBigRocks(Convert.ToInt32(e.Node.Tag));
        }

        private void bindBigRocks(int CompassRoleID, bool addNewRow = false)
        {
            List<BigRock> bigRocks = null;
            if (CompassRoleID <= 0)
            {
                bigRocks = BLLBigRock.GetBigRocks(CurrentUser.UserID, CurrentDate, false);
            }
            else
            {
                bigRocks = BLLBigRock.GetBigRocks(CurrentUser.UserID, CurrentDate, CompassRoleID, false);
                if (addNewRow)
                {
                    bigRocks.Add(new BigRock { AsCompassRole = BLLCompassRole.GetCompassRoleByID(CompassRoleID), BigRockID = 0, BigRockName = "", ForUser = CurrentUser, ForWeek = CurrentDate });
                }
            }
            this.dgCompass.Refresh();
            this.dgCompass.DataSource = bigRocks;
            if (addNewRow && CompassRoleID > 0)
            {
                setRowEditable(bigRocks.Count - 1);
            }
            else
            {
                if (bigRocks.Count > 0)
                {
                    setRowSelected(bigRocks.Count - 1);
                }
            }
        }

        private void setRowSelected(int rowNo)
        {
            this.dgCompass.FirstDisplayedScrollingRowIndex = this.dgCompass.Rows[rowNo].Index;
            this.dgCompass.Refresh();
            this.dgCompass.Rows[rowNo].Selected = true;
            this.dgCompass.CurrentCell = this.dgCompass.Rows[rowNo].Cells[colIDXForEditCell];
        }

        private void setRowEditable(int rowNo)
        {
            dgCompass.CurrentCell.ReadOnly = false;
            this.dgCompass.BeginEdit(false);
        }

        private bool addupdateRow(DataGridViewCellEventArgs e)
        {
            bool returnValue = false;
            if (validateCurrentRowData(false))
            {
                int bigRockID = Convert.ToInt32(this.dgCompass.CurrentRow.Cells[0].Value);
                BigRock bigRock;
                if (bigRockID <= 0)
                {
                    bigRock = new BigRock();
                }
                else
                {
                    bigRock = BLLBigRock.GetBigRockByID(bigRockID);
                }
                bigRock.ForWeek = CurrentDate;
                bigRock.ForUser = CurrentUser;
                bigRock.BigRockName = this.dgCompass.CurrentRow.Cells[2].EditedFormattedValue.ToString();
                bigRock.AsCompassRole = BLLCompassRole.GetCompassRoleByID(Convert.ToInt32(this.tvCompassRoles.SelectedNode.Tag));
                if (bigRockID <= 0)
                {
                    BLLBigRock.AddBigRock(bigRock);
                }
                else
                {
                    BLLBigRock.UpdateBigRock(bigRock);
                }
                returnValue = true;
            }

            return returnValue;
        }

        private void mnuAddBigRock_Click(object sender, EventArgs e)
        {
            bindBigRocks(Convert.ToInt32(tvCompassRoles.SelectedNode.Tag), true);
        }

        private void dgCompass_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            bool returnValue = false;

            if (dgCompass.IsCurrentRowDirty)
            {
                returnValue = addupdateRow(e);
            }

            if (returnValue)
            {
                //bindBigRocks(Convert.ToInt32(tvCompassRoles.SelectedNode.Tag), true);
            }
        }

        private bool validateCurrentRowData(bool showMessage)
        {
            bool returnValue = true;
            int currentRowIndex = this.dgCompass.CurrentRow.Index;
            string errMessage = "";
            if (this.dgCompass.CurrentRow != null)
            {
                if (this.dgCompass.CurrentRow.Cells[colIDXForEditCell].EditedFormattedValue.ToString().Trim().Equals(""))
                {
                    errMessage = "Please enter Big Rock";
                    returnValue = false;
                }
            }
            else
            {
                errMessage = "No Active Selection";
                returnValue = false;
            }

            if (!returnValue)
            {
                if (showMessage)
                {
                    ShowError(errMessage, Form_Title);
                }
                setRowEditable(currentRowIndex);
            }
            return returnValue;
        }

        private void mnuEditBigRock_Click(object sender, EventArgs e)
        {

        }

        private void mnuDeleteBigRock_Click(object sender, EventArgs e)
        {
            if (dgCompass.CurrentRow != null)
            {
                int bigRockID = Convert.ToInt32(this.dgCompass.CurrentRow.Cells[0].Value.ToString());

                if (bigRockID > 0)
                {
                    BLLBigRock.DeleteBigRock(bigRockID);
                }
                else
                {
                    ShowError("No Big Rock is selected.", Form_Title);
                }
                bindBigRocks(Convert.ToInt32(this.tvCompassRoles.SelectedNode.Tag), false);
            }
        }

        private void mnuAddCompassRole_Click(object sender, EventArgs e)
        {
            addCompassRole();
        }

        private void addCompassRole()
        {
            EditCompassRole childForm = new EditCompassRole(CurrentUser, PageMode.Add);
            childForm.ShowDialog();
            initPage();
        }

        private void editCompassRole()
        {
            if (!this.tvCompassRoles.SelectedNode.Tag.Equals("0"))
            {
                EditCompassRole childForm = new EditCompassRole(CurrentUser, PageMode.Edit);
                childForm.ItemID = Convert.ToInt32(this.tvCompassRoles.SelectedNode.Tag);
                childForm.ShowDialog();
                initPage();
            }
        }

        private void deleteCompassRole()
        {
            if (!this.tvCompassRoles.SelectedNode.Tag.Equals("0"))
            {
                BLLCompassRole.DeleteCompassRole(Convert.ToInt32(this.tvCompassRoles.SelectedNode.Tag));
                initPage();
            }
        }

        private void mnuEditCompassRole_Click(object sender, EventArgs e)
        {
            editCompassRole();
        }

        private void mnuDeleteCompassRole_Click(object sender, EventArgs e)
        {
            deleteCompassRole();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (this.tvCompassRoles.Nodes[0].Nodes.Count <=0)
            {

                this.mnuDeleteCompassRole.Enabled = false;
                this.mnuEditCompassRole.Enabled = false;
                this.mnuAddBigRock.Enabled = false;
                this.mnuDeleteBigRock.Enabled = false;
            }
            else
            {
                this.mnuDeleteCompassRole.Enabled = true;
                this.mnuEditCompassRole.Enabled = true;
                this.mnuAddBigRock.Enabled = true;
                if (this.dgCompass.CurrentRow == null)
                {
                    this.mnuDeleteBigRock.Enabled = false;
                }
                else
                {
                    this.mnuDeleteBigRock.Enabled = true;
                }
            }
        }
    }
}
