using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyPlanner
{
    public partial class CtrlWeeklyView : BaseUserControl
    {

        private DateTime _currentDate;
        private bool _workweekonly;
        private int _basectrlWidth;

        public CtrlWeeklyView()
        {
            InitializeComponent();
            _workweekonly = false;
            _currentDate = DateTime.Today;
            _basectrlWidth = 170;
        }

        public DateTime CurrentDate
        {
            get
            {
                return _currentDate;
            }
            set
            {
                _currentDate = MyPlannerValidators.StartOfWeek(value, DayOfWeek.Monday);
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
            }
        }

        public int TaskWidth
        {
            get
            {
                return _basectrlWidth;
            }
            set
            {
                _basectrlWidth = value;
            }
        }

        private void initPage()
        {
            this.Controls.Clear();

            int ctrlWidth = _basectrlWidth;
            if (_workweekonly)
            {
                ctrlWidth = _basectrlWidth  + Convert.ToInt32(Math.Ceiling((double)(_basectrlWidth * 2) / 5));

            }

            for (int i = 0; i < 7; i++)
            {
                if ((i < 5) || (!_workweekonly))
                {
                    CtrlTasksList task = new CtrlTasksList(CurrentUser, CurrentDate.AddDays(i), false, false);
                    task.LoadTasks();
                    task.Top = 3;
                    task.Left = (i * (ctrlWidth+3)) + ((i) * 3) + 3;
                    task.Width = ctrlWidth;
                    this.Controls.Add(task);
                }
            }
        }

        public void LoadTasks()
        {
            initPage();
        }
    }
}
