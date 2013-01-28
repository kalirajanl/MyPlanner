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
    public partial class frmWeeklyView : BaseForm 
    {

        private bool _workweekonly;

        public frmWeeklyView()
        {
            InitializeComponent();
            this.Left = 0;
            this.Top = 0;
            this.Height = 583;
            this.Width = 1274;
            this.Text = "Calendar - Weekly View";
            Form_Title = "Weekly View";
            this.dtpCurrentDate.Value = MyPlannerValidators.StartOfWeek(DateTime.Today, DayOfWeek.Monday);
        }

        public DateTime CurrentDate
        {
            get
            {
                return this.dtpCurrentDate.Value;
            }
            set
            {
                this.dtpCurrentDate.Value = value;
            }
        }

        public bool ShowWorkWeekOnly
        {
            get
            {
                return _workweekonly;
            }
            set
            {
                _workweekonly = value;
                if (value)
                {
                    this.Text = "Calendar - Work Week View";
                }
                else
                {
                    this.Text = "Calendar - Week View";
                }
            }
        }

        private void dtpCurrentDate_ValueChanged(object sender, EventArgs e)
        {
            this.dtpCurrentDate.Value = MyPlannerValidators.StartOfWeek(this.dtpCurrentDate.Value, DayOfWeek.Monday);
            initPage();
        }

        private void initPage()
        {
            this.ctrlWeeklyView1.CurrentUser = CurrentUser;
            this.ctrlWeeklyView1.ShowWorkWeekOnly = ShowWorkWeekOnly;
            this.ctrlWeeklyView1.CurrentDate = this.dtpCurrentDate.Value;
            this.ctrlWeeklyView1.LoadTasks();
        }

        public void LoadTasks()
        {
            initPage();
        }

    }
}
