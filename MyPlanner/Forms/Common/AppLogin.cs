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
using MyPlanner.Logger;

namespace MyPlanner
{
    public partial class AppLogin : BaseForm 
    {
        public AppLogin()
        {
            InitializeComponent();
            Form_Title = "Sign In";
            this.Text = ApplicationTitle + " - " + Form_Title;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CustomLogger.WriteGeneralActivity("Application Stopped normally.");
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (this.txtUserName.Text.Trim().Equals(""))
            {
                ShowError("Please enter your user name.", Form_Title);
                this.txtUserName.Focus();
            }
            else if (this.txtPassword.Text.Trim().Equals(""))
            {
                ShowError("Please enter your password.", Form_Title);
                this.txtPassword.Focus();
            }
            else
            {
                AppUser usr = BLLAppUser.ValidateUser(this.txtUserName.Text, this.txtPassword.Text);
                if (usr == null)
                {
                    CustomLogger.WriteGeneralActivity("Application login failed with credentials [" + this.txtUserName.Text.Trim() + "," + this.txtPassword.Text.Trim() + "].");
                    ShowError("Invalid credentials", Form_Title);
                }
                else
                {
                    CustomLogger.WriteUserActivity(usr,"User logged in successfully.");
                    this.Hide();
                    AppMDI appMDI = new AppMDI(usr);
                    appMDI.Show();
                }
            }
        }

    }
}
