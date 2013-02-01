using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyPlanner.Logger;
using MyPlanner.Models;
using MyPlanner.BLL;
using MyPlanner.Common;

namespace MyPlanner.Forms
{
    public partial class frmtest : Form
    {
        public frmtest()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string activitymessage1 = "Application Started. ";
            string activitymessage2 = "Logged In. ";
            AppUser usr = BLLAppUser.GetUserByID(1);
            int maxCounter= Convert.ToInt32(this.txtCounter.Text);
            this.txtLog.Text = "";
            this.txtLog.Text += "Synchronous Started at " + DateTime.Now.ToString(Constants.DATETIME_FORMAT_LOG) + Environment.NewLine;
            for (int i=1;i<=maxCounter;i++)
            {
                this.Text = i.ToString() + "/" + maxCounter.ToString();
                CustomLogger.WriteGeneralActivity(activitymessage1);
                CustomLogger.WriteUserActivity(usr, activitymessage2);
            }
            this.txtLog.Text += "Synchronous ended at " + DateTime.Now.ToString(Constants.DATETIME_FORMAT_LOG) + Environment.NewLine;
            this.txtLog.Text += "ASynchronous Started at " + DateTime.Now.ToString(Constants.DATETIME_FORMAT_LOG) + Environment.NewLine;
            for (int i = 1; i <= maxCounter; i++)
            {
                this.Text = i.ToString() + "/" + maxCounter.ToString();
                CustomLogger.WriteGeneralActivity(activitymessage1,true);
                CustomLogger.WriteUserActivity(usr, activitymessage2, true);
            }
            this.txtLog.Text += "ASynchronous ended at " + DateTime.Now.ToString(Constants.DATETIME_FORMAT_LOG) + Environment.NewLine;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
