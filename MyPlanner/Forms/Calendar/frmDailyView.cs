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
    public partial class frmDailyView : BaseForm
    {
        public frmDailyView(AppUser usr)
        {
            InitializeComponent();
            this.Left = 0;
            this.Top = 0;
            this.Height = 583;
            this.Width = 1274;
            CurrentUser = usr;
            this.dtpCurrentDate.Value = DateTime.Today;
            this.Text = "Calendar - Daily View";
            Form_Title = "Daily View";
        }

        private void initPage()
        {
            this.ctrlTasksList1.CurrentUser = CurrentUser;
            this.ctrlTasksList1.Top = 40;
            this.ctrlTasksList1.Left = 5;
            this.ctrlTasksList1.Height = this.Height - 70;
            this.ctrlTasksList1.Width = 350;
            this.ctrlTasksList1.CurrentDate = this.dtpCurrentDate.Value;
            if (this.dtpCurrentDate.Value > DateTime.Today)
            {
                this.ctrlTasksList1.ShowOverDueTasks = false;
            }
            else
            {
                this.ctrlTasksList1.ShowOverDueTasks = true;
            }
            this.ctrlTasksList1.LoadTasks();

            this.ctrlDailyNotes1.CurrentUser = CurrentUser;
            this.ctrlDailyNotes1.Top = 40;
            this.ctrlDailyNotes1.Left = 5 + this.ctrlTasksList1.Width + 5;
            this.ctrlDailyNotes1.Height = this.Height - 70;
            this.ctrlDailyNotes1.Width = this.Width - this.ctrlTasksList1.Width - 20;
            this.ctrlDailyNotes1.CurrentDate = this.dtpCurrentDate.Value;
            this.ctrlDailyNotes1.LoadNotes();

        }

        private void dtpCurrentDate_ValueChanged(object sender, EventArgs e)
        {
            initPage();
        }
    }
}
