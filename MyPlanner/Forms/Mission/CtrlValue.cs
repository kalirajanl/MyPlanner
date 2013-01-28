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
    public partial class CtrlValue : BaseUserControl 
    {
        public CtrlValue()
        {
            InitializeComponent();
            this.dgValue.Top = 5;
            this.dgValue.Left = 5;
            this.dgValue.Height = this.Height - 10;
            this.dgValue.Width = this.Width - 10;
        }

        private void CtrlValue_Load(object sender, EventArgs e)
        {
            bindGrid();
        }

        private void bindGrid(bool addNewRow = false)
        {
            if (CurrentUser != null)
            {
                List<Value> myValue = BLLValue.GetValues(CurrentUser.UserID, null, false);
                if (addNewRow)
                {
                    myValue.Add(new Value());
                }
                this.dgValue.AutoGenerateColumns = false;

                dgValue.EditMode = DataGridViewEditMode.EditOnEnter;
                dgValue.VirtualMode = true;

                this.dgValue.DataSource = myValue;
                if (addNewRow)
                {
                    dgValue.Rows[myValue.Count - 1].Cells[1].ReadOnly = false;

                    dgValue.CurrentCell = dgValue[1, myValue.Count - 1];

                    this.dgValue.BeginEdit(true);
                }
            }
        }

        private bool addupdateRow(DataGridViewCellEventArgs e)
        {
            bool returnValue = false;
            if (validateCurrentRowData(false))
            {
                int ValueID = Convert.ToInt32(this.dgValue.CurrentRow.Cells[0].Value);
                Value value;
                if (ValueID <= 0)
                {
                    value = new Value { ValueID = -1, ForUser = CurrentUser, ValueTitle = "", ValueNotes = "" };
                }
                else
                {
                    value = BLLValue.GetValueByID(ValueID);
                }
                value.ForUser = CurrentUser;
                value.ValueNotes = this.dgValue.CurrentRow.Cells[2].EditedFormattedValue.ToString();
                value.ValueTitle = this.dgValue.CurrentRow.Cells[1].EditedFormattedValue.ToString();
                if (ValueID <= 0)
                {
                    BLLValue.AddValue(value);
                }
                else
                {
                    BLLValue.UpdateValue(value);
                }
                returnValue = true;
            }

            return returnValue;
        }

        private bool validateCurrentRowData(bool showMessage)
        {
            bool returnValue = true;
            int colIndex = 1;
            int currentRowIndex = this.dgValue.CurrentRow.Index;
            string errMessage = "";
            if (this.dgValue.CurrentRow != null)
            {
                if (this.dgValue.CurrentRow.Cells[1].EditedFormattedValue.ToString().Trim().Equals(""))
                {
                    errMessage = "Please enter Value Title";
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
                dgValue.ClearSelection();
                dgValue.Rows[currentRowIndex].Selected = true;
                dgValue.CurrentCell = dgValue[colIndex, currentRowIndex];
                dgValue.CurrentCell.ReadOnly = false;
                this.dgValue.BeginEdit(true);
            }
            return returnValue;
        }

        private void addNewValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindGrid(true);
        }

        private void deleteValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgValue.CurrentRow != null)
            {
                int ValueID = Convert.ToInt32(this.dgValue.CurrentRow.Cells[0].Value.ToString());

                if (ValueID > 0)
                {
                    BLLValue.DeleteValue(ValueID);
                }
                else
                {
                    ShowError("No Value is selected.", Form_Title);
                }
                bindGrid();
            }
        }


        private void dgValue_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            bool returnValue = false;

            if (dgValue.IsCurrentRowDirty)
            {
                returnValue = addupdateRow(e);
            }

            if (!returnValue)
            {

            }
        }

        private void dgValue_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgValue.IsCurrentRowDirty)
            {
                if (!validateCurrentRowData(true))
                {
                    e.Cancel = true;
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            this.deleteValueToolStripMenuItem.Enabled = (this.dgValue.CurrentRow != null);
        }

        
    }
}
