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
    public partial class CtrlMission : BaseUserControl 
    {
        public CtrlMission()
        {
            InitializeComponent();
            this.dgMission.Top = 5;
            this.dgMission.Left = 5;
            this.dgMission.Height = this.Height - 10;
            this.dgMission.Width = this.Width - 10;
        }

        private void bindGrid(bool addNewRow = false)
        {
            if (CurrentUser != null)
            {
                List<Mission> myMission = BLLMission.GetMissions(CurrentUser.UserID, null, false);
                if (addNewRow)
                {
                    myMission.Add(new Mission());
                }
                this.dgMission.AutoGenerateColumns = false;

                dgMission.EditMode = DataGridViewEditMode.EditOnEnter;
                dgMission.VirtualMode = true;

                this.dgMission.DataSource = myMission;
                if (addNewRow)
                {
                    dgMission.Rows[myMission.Count - 1].Cells[1].ReadOnly = false;

                    dgMission.CurrentCell = dgMission[1, myMission.Count - 1];

                    this.dgMission.BeginEdit(true);
                }
            }
        }

        private bool addupdateRow(DataGridViewCellEventArgs e)
        {
            bool returnValue = false;
            if (validateCurrentRowData(false))
            {
                int missionID = Convert.ToInt32(this.dgMission.CurrentRow.Cells[0].Value);
                Mission mission;
                if (missionID <= 0)
                {
                    mission = new Mission { MissionID = -1, ForUser = CurrentUser, MissionTitle = "", MissionNotes = "" };
                }
                else
                {
                    mission = BLLMission.GetMissionByID(missionID);
                }
                mission.ForUser = CurrentUser;
                mission.MissionNotes = this.dgMission.CurrentRow.Cells[2].EditedFormattedValue.ToString();
                mission.MissionTitle = this.dgMission.CurrentRow.Cells[1].EditedFormattedValue.ToString();
                if (missionID <= 0)
                {
                    BLLMission.AddMission(mission);
                }
                else
                {
                    BLLMission.UpdateMission(mission);
                }
                returnValue = true;
            }

            return returnValue;
        }

        private bool validateCurrentRowData(bool showMessage)
        {
            bool returnValue = true;
            int colIndex = 1;
            int currentRowIndex = this.dgMission.CurrentRow.Index;
            string errMessage = "";
            if (this.dgMission.CurrentRow != null)
            {
                if (this.dgMission.CurrentRow.Cells[1].EditedFormattedValue.ToString().Trim().Equals(""))
                {
                    errMessage = "Please enter Mission Title";
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
                dgMission.ClearSelection();
                dgMission.Rows[currentRowIndex].Selected = true;
                dgMission.CurrentCell = dgMission[colIndex, currentRowIndex];
                dgMission.CurrentCell.ReadOnly = false;
                this.dgMission.BeginEdit(true);
            }
            return returnValue;
        }

        private void addNewMissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindGrid(true);
        }

        private void deleteMissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgMission.CurrentRow != null)
            {
                int missionID = Convert.ToInt32(this.dgMission.CurrentRow.Cells[0].Value.ToString());

                if (missionID > 0)
                {
                    BLLMission.DeleteMission(missionID);
                }
                else
                {
                    ShowError("No Mission is selected.", Form_Title);
                }
                bindGrid();
            }
        }


        private void dgMission_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            bool returnValue = false;

            if (dgMission.IsCurrentRowDirty)
            {
                returnValue = addupdateRow(e);
            }

            if (!returnValue)
            {

            }
        }

        private void dgMission_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgMission.IsCurrentRowDirty)
            {
                if (!validateCurrentRowData(true))
                {
                    e.Cancel = true;
                }
            }
        }

        private void CtrlMission_Load(object sender, EventArgs e)
        {
            bindGrid();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            this.deleteMissionToolStripMenuItem.Enabled = (this.dgMission.CurrentRow != null);
        }
    }
}
