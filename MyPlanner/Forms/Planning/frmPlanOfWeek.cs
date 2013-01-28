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
    public partial class frmPlanOfWeek : BaseForm 
    {
        private const int LAST_STEP_NO = 4;

        public frmPlanOfWeek(AppUser usr)
        {
            InitializeComponent();
            this.Left = 0;
            this.Top = 0;
            this.Height = 583;
            this.Width = 1274;
            CurrentUser = usr;
            this.dtpCurrentDate.Value = MyPlannerValidators.StartOfWeek(DateTime.Today, DayOfWeek.Monday);
            this.Text = "Plan your week";
            Form_Title = "Plan your week";
        }

        private void dtpCurrentDate_ValueChanged(object sender, EventArgs e)
        {
            this.dtpCurrentDate.Value  = MyPlannerValidators.StartOfWeek(this.dtpCurrentDate.Value, DayOfWeek.Monday);
            initPage();
        }

        public DateTime CurrentDate
        {
            get
            {
                return this.dtpCurrentDate.Value;
            }
            set
            {
                this.dtpCurrentDate.Value = CurrentDate;
            }
        }

        private void initPage()
        {
            this.btnReviewMission.Image = MyPlanner.Properties.Resources.orange_arrow_small;
            this.btnReviewGoals.Image = MyPlanner.Properties.Resources.gray_arrow_small;
            this.btnScheduleCompass.Image = MyPlanner.Properties.Resources.gray_arrow_small;
            this.btnScheduleTasks.Image = MyPlanner.Properties.Resources.gray_arrow_small;

            int topLocation = 120;
            int height = 380;

            this.ctrlMission1.Top = topLocation;
            this.ctrlValue1.Top = topLocation;
            this.ctrlGoalsAndSteps1.Top = topLocation;
            this.ctrlWeeklyCompass1.Top = topLocation;
            this.ctrlViewWeeklyCompass1.Top = topLocation;
            this.ctrlWeeklyView1.Top = topLocation;

            this.ctrlMission1.Height = height;
            this.ctrlValue1.Height = height;
            this.ctrlGoalsAndSteps1.Height = height;
            this.ctrlWeeklyCompass1.Height = height;
            this.ctrlViewWeeklyCompass1.Height = height;
            this.ctrlWeeklyView1.Height = height;

            this.ctrlMission1.Left = 0;
            this.ctrlValue1.Left = this.ctrlMission1.Width + 45;
            this.ctrlGoalsAndSteps1.Left = 0;
            this.ctrlWeeklyCompass1.Left = 0;
            this.ctrlViewWeeklyCompass1.Left = 0;
            this.ctrlWeeklyView1.Left = this.ctrlViewWeeklyCompass1.Width + 5;
           
            this.ctrlMission1.CurrentUser = CurrentUser;
            this.ctrlValue1.CurrentUser = CurrentUser;
            this.ctrlGoalsAndSteps1.CurrentUser = CurrentUser;
            this.ctrlWeeklyCompass1.CurrentUser = CurrentUser;
            this.ctrlWeeklyCompass1.CurrentDate = this.dtpCurrentDate.Value;
            this.ctrlWeeklyView1.CurrentUser = CurrentUser;
            this.ctrlWeeklyView1.CurrentDate = this.dtpCurrentDate.Value;
            this.ctrlWeeklyView1.TaskWidth = 130;
            this.ctrlWeeklyView1.LoadTasks();
            this.ctrlViewWeeklyCompass1.CurrentUser = CurrentUser;
            this.ctrlViewWeeklyCompass1.CurrentDate = this.dtpCurrentDate.Value;
            this.ctrlViewWeeklyCompass1.LoadCompass();

            setCurrentStepTo(1);
        }

        private void setCurrentStepTo(int stepNo)
        {
            this.btnReviewMission.Image = MyPlanner.Properties.Resources.gray_arrow_small;
            this.btnReviewGoals.Image = MyPlanner.Properties.Resources.gray_arrow_small;
            this.btnScheduleCompass.Image = MyPlanner.Properties.Resources.gray_arrow_small;
            this.btnScheduleTasks.Image = MyPlanner.Properties.Resources.gray_arrow_small;
            this.ctrlMission1.Visible = false;
            this.ctrlValue1.Visible = false;
            this.ctrlGoalsAndSteps1.Visible = false;
            this.ctrlWeeklyCompass1.Visible = false;
            this.ctrlWeeklyView1.Visible = false;
            this.ctrlViewWeeklyCompass1.Visible = false;
            this.lblCurrentStep.Text = stepNo.ToString();
            this.btnNext.Text = "&Next";
            switch (stepNo)
            {
                case 1:
                    {
                        this.btnReviewMission.Image = MyPlanner.Properties.Resources.orange_arrow_small;
                        this.ctrlMission1.Visible = true;
                        this.ctrlValue1.Visible = true;
                        break;
                    }
                case 2:
                    {
                        this.btnReviewMission.Image = MyPlanner.Properties.Resources.green_arrow_small;
                        this.btnReviewGoals.Image = MyPlanner.Properties.Resources.orange_arrow_small;
                        this.ctrlGoalsAndSteps1.Visible = true;
                        break;
                    }
                case 3:
                    {
                        this.btnReviewMission.Image = MyPlanner.Properties.Resources.green_arrow_small;
                        this.btnReviewGoals.Image = MyPlanner.Properties.Resources.green_arrow_small;
                        this.btnScheduleCompass.Image = MyPlanner.Properties.Resources.orange_arrow_small;
                        this.ctrlWeeklyCompass1.Visible = true;
                        break;
                    }
                case 4:
                    {
                        this.ctrlViewWeeklyCompass1.CurrentDate = this.dtpCurrentDate.Value;
                        this.ctrlViewWeeklyCompass1.LoadCompass();
                        this.btnReviewMission.Image = MyPlanner.Properties.Resources.green_arrow_small;
                        this.btnReviewGoals.Image = MyPlanner.Properties.Resources.green_arrow_small;
                        this.btnScheduleCompass.Image = MyPlanner.Properties.Resources.green_arrow_small;
                        this.btnScheduleTasks.Image = MyPlanner.Properties.Resources.green_arrow_small;
                        this.btnNext.Text = "Fi&nish";
                        this.ctrlViewWeeklyCompass1.Visible = true;
                        this.ctrlWeeklyView1.Visible = true;
                        break;
                    }
            }

        }

        private void btnReviewMission_Click(object sender, EventArgs e)
        {
            setCurrentStepTo(1);            
        }

        private void btnReviewGoals_Click(object sender, EventArgs e)
        {
            setCurrentStepTo(2);
        }

        private void btnScheduleCompass_Click(object sender, EventArgs e)
        {
            setCurrentStepTo(3);
        }

        private void btnScheduleTasks_Click(object sender, EventArgs e)
        {
            setCurrentStepTo(4);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int stepNo = Convert.ToInt32(this.lblCurrentStep.Text);
            if (stepNo != LAST_STEP_NO)
            {
                setCurrentStepTo(stepNo+1);
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

    }
}
