using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyPlanner.Models;
using MyPlanner.BLL;

namespace MyPlanner
{

    public enum MasterPageMode
    {
        Mission = 1,
        Value = 2, 
        GoalsAndSteps = 3,
        WishList
    }

    public partial class frmMaster : BaseForm
    {
        public frmMaster(AppUser usr, MasterPageMode masterPageMode)
        {
            InitializeComponent();
            currentMasterPageMode = masterPageMode;
            switch (currentMasterPageMode)
            {
                case MasterPageMode.Mission:
                    {
                        this.Text = "Missions";
                        Form_Title = "Missions";
                        break;
                    }
                case MasterPageMode.Value:
                    {
                        this.Text = "Values";
                        Form_Title = "Values";
                        break;
                    }
                case MasterPageMode.GoalsAndSteps:
                    {
                        this.Text = "Goals & Steps";
                        Form_Title = "Goals & Steps";
                        break;
                    }
                case MasterPageMode.WishList:
                    {
                        this.Text = "WishList";
                        Form_Title = "WishList";
                        break;
                    }
            }
            CurrentUser = usr;
        }

        public MasterPageMode currentMasterPageMode { get; set; }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
        }

        private void frmMission_Load(object sender, EventArgs e)
        {
            switch (currentMasterPageMode)
            {
                case MasterPageMode.Mission:
                    {
                        CtrlMission ctrlMission = new CtrlMission();
                        ctrlMission.Form_Title = Form_Title;
                        ctrlMission.CurrentUser = CurrentUser;
                        this.Controls.Add(ctrlMission);
                        break;
                    }
                case MasterPageMode.Value:
                    {
                        CtrlValue ctrlValue = new CtrlValue();
                        ctrlValue.Form_Title = Form_Title;
                        ctrlValue.CurrentUser = CurrentUser;
                        this.Controls.Add(ctrlValue);
                        break;
                    }
                case MasterPageMode.GoalsAndSteps:
                    {
                        CtrlGoalsAndSteps ctrlGoalsAndSteps = new CtrlGoalsAndSteps();
                        ctrlGoalsAndSteps.Form_Title = Form_Title;
                        ctrlGoalsAndSteps.CurrentUser = CurrentUser;
                        this.Controls.Add(ctrlGoalsAndSteps);
                        this.btnClose.Left = 160;
                        this.btnClose.Top = 373;
                        this.Height = 430;
                        this.Width = 360;
                        this.StartPosition = FormStartPosition.CenterScreen;
                        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                        break;
                    }
                case MasterPageMode.WishList:
                    {
                        CtrlWishList ctrlWishList = new CtrlWishList();
                        ctrlWishList.Form_Title = Form_Title;
                        ctrlWishList.CurrentUser = CurrentUser;
                        this.StartPosition = FormStartPosition.CenterScreen;
                        this.VerticalScroll.Enabled = true;
                        ctrlWishList.Height = 370;
                        ctrlWishList.Width = 435;
                        this.Height = 390;
                        this.Width = 440;
                        ctrlWishList.LoadWishList();
                        this.Controls.Add(ctrlWishList);
                        break;
                    }
            }
        }
       
    }
}
