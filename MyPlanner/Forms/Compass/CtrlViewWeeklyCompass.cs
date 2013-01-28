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
    public partial class CtrlViewWeeklyCompass : BaseUserControl
    {
        public CtrlViewWeeklyCompass()
        {
            InitializeComponent();
            this.dgWeeklyCompass.Top = 5;
            this.dgWeeklyCompass.Left = 5;
            this.dgWeeklyCompass.Height = this.Height - 10;
            this.dgWeeklyCompass.Width = this.Width -10;
            this.dgWeeklyCompass.AutoGenerateColumns = false;
            CurrentUser = null;
            CurrentDate = MyPlannerValidators.StartOfWeek(DateTime.Today, DayOfWeek.Monday);
        }

        public DateTime CurrentDate { get; set; }

        public void LoadCompass()
        {
            if (CurrentUser != null)
            {
                this.dgWeeklyCompass.DataSource = BLLCompassItem.GetCompassItems(CurrentUser.UserID, CurrentDate, false);
                this.dgWeeklyCompass.ClearSelection();
                this.dgWeeklyCompass.Refresh();
            }
        }

        private void dgWeeklyCompass_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgWeeklyCompass.Rows[e.RowIndex].Cells[0] != null)
            {
                if (this.dgWeeklyCompass.Rows[e.RowIndex].Cells[0].Value.ToString().ToUpper().StartsWith("CR"))
                {
                    e.CellStyle.BackColor = Color.AliceBlue;
                    Font tn = e.CellStyle.Font;
                    if (tn == null)
                    {
                        tn = this.dgWeeklyCompass.Font;
                    }
                    if (tn == null)
                    {
                        tn = new Font("Arial", 12);
                    }
                    e.CellStyle.Font = new Font(tn, FontStyle.Bold);
                }
                else if (this.dgWeeklyCompass.Rows[e.RowIndex].Cells[0].Value.ToString().ToUpper().StartsWith("BR"))
                {
                    e.Value = "    " + e.Value;
                }
            }
        }
    }
}
