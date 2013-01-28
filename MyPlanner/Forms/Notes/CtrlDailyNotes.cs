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
    public partial class CtrlDailyNotes : BaseUserControl
    {
        private DateTime _currentDate;
        public CtrlDailyNotes()
        {
            InitializeComponent();
            _currentDate = DateTime.Today;
        }

        public DateTime CurrentDate
        {
            get
            {
                return _currentDate;
            }
            set
            {
                _currentDate = value;
            }
        }


        public void LoadNotes()
        {
            this.txtNotes.Height = this.Height - 5;
            this.txtNotes.Top = 0;
            this.txtNotes.Left = 0;
            this.txtNotes.Width = this.Width - 5;
            this.txtNotes.Text = "";
            if (CurrentUser != null)
            {
                DailyNote dailyNote = BLLDailyNotes.GetDailyNote(CurrentUser.UserID, CurrentDate);
                if (dailyNote != null)
                {
                    this.txtNotes.Text = dailyNote.Notes;
                }
            }
        }

        private void txtNotes_Leave(object sender, EventArgs e)
        {
            if (CurrentUser != null)
            {
                if (!this.txtNotes.Text.Trim().Equals(""))
                {
                    BLLDailyNotes.UpdateDailyNote(new DailyNote { ForDate = CurrentDate, ForUser = CurrentUser, Notes = this.txtNotes.Text.Trim() });
                }
                else
                {
                    BLLDailyNotes.DeleteDailyNote(CurrentUser.UserID, CurrentDate);
                }
            }
        }
            
    }
}
