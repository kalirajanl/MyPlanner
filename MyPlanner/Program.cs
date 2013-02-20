using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using MyPlanner.Models;
using MyPlanner.BLL;
using MyPlanner.Logger;
using MyPlanner.Common;

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

            CustomLogger.WriteGeneralActivity(ConfigReader.APPLICATION_TITLE + " Application started successfully");
            System.Diagnostics.Process[] obj = System.Diagnostics.Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
            if (obj.Length != 1)
            {
                MessageBox.Show("Another instance is running", "MyPlanner", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                CustomLogger.WriteGeneralActivity("Application Stopped as there is a running instance.");
            }
            else
            {

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new AppLogin());
            }
        }

    }
}
