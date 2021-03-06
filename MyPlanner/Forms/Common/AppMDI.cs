﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyPlanner.Models;
using MyPlanner.BLL;
using MyPlanner.Logger;
using MyPlanner.Common;

namespace MyPlanner
{
    public partial class AppMDI : BaseForm
    {
        About wndAbout;
        frmMaster wndMission;
        frmMaster wndValue;
        frmMaster wndGoalsAndSteps;
        frmDailyView wndDayView;
        frmPlanOfWeek wndPlanOfWeek;
        frmWeeklyView wndWeekView;
        frmMaster wndWishList;

        private AppMDI()
        {
            InitializeComponent();
            this.Text = ApplicationTitle + " " + AssemblyVersion;
            this.CategoryFilter = new List<Category>();
            Form_Title = ApplicationTitle;
        }

        public AppMDI(AppUser usr)
        {
            InitializeComponent();
            this.Height = 697;
            this.Width = 1295;
            CurrentUser = usr;
            this.CategoryFilter = new List<Category>();
            Form_Title = ApplicationTitle;
            this.Text = ApplicationTitle + " Licensed for " + usr.UserName.FileAs;
            this.toolStripStatusLabel.Text = "Welcome to " + ApplicationTitle;
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomLogger.WriteUserActivity(CurrentUser, "User logged off successfully.");
            this.Close();
            Application.Exit();
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wndAbout != null)
            {
                wndAbout.Close();
            }
            wndAbout = new About();
            wndAbout.MdiParent = this;
            wndAbout.BringToFront();
            wndAbout.Show();
        }

        private void missionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wndMission != null)
            {
                wndMission.Close();
            }
            wndMission = new frmMaster(CurrentUser, MasterPageMode.Mission);
            wndMission.MdiParent = this;
            wndMission.BringToFront();
            wndMission.Show();
        }

        private void valueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wndValue != null)
            {
                wndValue.Close();
            }
            wndValue = new frmMaster(CurrentUser, MasterPageMode.Value);
            wndValue.MdiParent = this;
            wndValue.BringToFront();
            wndValue.Show();
        }

        private void goalsStepsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wndGoalsAndSteps != null)
            {
                wndGoalsAndSteps.Close();
            }
            wndGoalsAndSteps = new frmMaster(CurrentUser, MasterPageMode.GoalsAndSteps);
            wndGoalsAndSteps.MdiParent = this;
            wndGoalsAndSteps.BringToFront();
            wndGoalsAndSteps.Show();
        }

        private void dayViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showDailyView();
        }

        private void showDailyView()
        {
            if (wndDayView != null)
            {
                wndDayView.Close();
            }
            wndDayView = new frmDailyView(CurrentUser);
            wndDayView.MdiParent = this;
            wndDayView.BringToFront();
            wndDayView.Show();
        }

        private void showWeeklyPlanning()
        {
            if (wndPlanOfWeek != null)
            {
                wndPlanOfWeek.Close();
            }
            wndPlanOfWeek = new frmPlanOfWeek(CurrentUser);
            //wndPlanOfWeek.MdiParent = this;
            wndPlanOfWeek.ShowInTaskbar = false;
            wndPlanOfWeek.StartPosition = FormStartPosition.CenterParent;
            wndPlanOfWeek.BringToFront();
            DialogResult rslt = wndPlanOfWeek.ShowDialog();
            if (rslt == System.Windows.Forms.DialogResult.OK)
            {
                showWeeklyView(wndPlanOfWeek.CurrentDate, false);
            }
            wndPlanOfWeek.Close();
        }

        public void showWeeklyView(DateTime forDate, bool workWeekOnly)
        {
            if (wndWeekView != null)
            {
                wndWeekView.Close();
            }
            wndWeekView = new frmWeeklyView();
            wndWeekView.CurrentUser = CurrentUser;
            wndWeekView.ShowInTaskbar = false;
            wndWeekView.MdiParent = this;
            wndWeekView.ShowWorkWeekOnly = workWeekOnly;
            wndWeekView.CurrentDate = forDate;
            wndWeekView.BringToFront();
            wndWeekView.Show();
        }

        private void toolWeeklyPlanning_Click(object sender, EventArgs e)
        {
            showWeeklyPlanning();
        }

        private void toolDayView_Click(object sender, EventArgs e)
        {
            showDailyView();
        }

        private void toolWorkWeekView_Click(object sender, EventArgs e)
        {
            showWeeklyView(DateTime.Today, true);
        }

        private void toolWeekView_Click(object sender, EventArgs e)
        {
            showWeeklyView(DateTime.Today, false);
        }

        private void workWeekViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showWeeklyView(DateTime.Today, true);
        }

        private void weekViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showWeeklyView(DateTime.Today, false);
        }
     
        private void btnExit_Click(object sender, EventArgs e)
        {
            ExitToolsStripMenuItem_Click(null, null);
        }

        private void weeklyplanning_Click(object sender, EventArgs e)
        {
            showWeeklyPlanning();
        }

        private void AppMDI_FormClosed(object sender, FormClosedEventArgs e)
        {
            CustomLogger.WriteGeneralActivity(ConfigReader.APPLICATION_TITLE + " Application stopped successfully.");
        }

        private void wishListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wndWishList != null)
            {
                wndWishList.Close();
            }
            wndWishList = new frmMaster(CurrentUser, MasterPageMode.WishList);
            wndWishList.MdiParent = this;
            wndWishList.BringToFront();
            wndWishList.Show();
        }

        private void AppMDI_Load(object sender, EventArgs e)
        {
            showDailyView();
        }
    }
}
