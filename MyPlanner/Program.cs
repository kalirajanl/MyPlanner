using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using MyPlanner.Models;
using MyPlanner.BLL;

namespace MyPlanner
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Diagnostics.Process[] obj = System.Diagnostics.Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
            if (obj.Length != 1)
            {
                MessageBox.Show("Another instance is running", "MyPlanner", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
               Application.Run(new AppLogin());
               // AppUser usr = BLLAppUser.GetUserByID(1);
                //AppMDI appMDI = new AppMDI(usr);
                //Application.Run(appMDI);
            }
        }

    }
}
