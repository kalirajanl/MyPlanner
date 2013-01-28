using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyPlanner.BLL;
using MyPlanner.Models;

namespace MyPlanner.AppPages
{
    public partial class PlanWeek : DefaultBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            wzPlanWeek.PreRender += new EventHandler(Wizard1_PreRender);
            if (!IsPostBack)
            {
                processQueryStrings();
                initPageForToday();
            }
        }

        private void processQueryStrings()
        {
            if (Request.QueryString["swwo"] != null)
            {
                this.hdnShowWorkWeekOnly.Value = true.ToString();
            }
            else
            {
                this.hdnShowWorkWeekOnly.Value = false.ToString();
            }
        }

        private void initPageForToday()
        {
            initPage(DateTime.Today);
        }

        protected void Wizard1_PreRender(object sender, EventArgs e)
        {
            Repeater SideBarList = wzPlanWeek.FindControl("HeaderContainer").FindControl("SideBarList") as Repeater;
            SideBarList.DataSource = wzPlanWeek.WizardSteps;
            SideBarList.DataBind();
        }

        private void initPage(DateTime fortheDate)
        {
            DateTime forDate = MyPlannerValidators.StartOfWeek(fortheDate, DayOfWeek.Monday);
            this.hdnCurrentDate.Value = forDate.ToString(Constants.DATE_FORMAT_STRING);
            this.calForDate.SelectedDate = forDate;

            this.lblDay.Attributes.Add("onclick", "return showCalendar()");
            if (ShowWorkWeekOnly)
            {
                this.lblDay.Text = forDate.ToString(Constants.DATE_FORMAT_STRING) + " - " + forDate.AddDays(4).ToString(Constants.DATE_FORMAT_STRING);
            }
            else
            {
                this.lblDay.Text = forDate.ToString(Constants.DATE_FORMAT_STRING) + " - " + forDate.AddDays(6).ToString(Constants.DATE_FORMAT_STRING);
            }
           this.WeeklyCompass1.CurrentDate = this.calForDate.SelectedDate;
            this.WeekView1.CurrentDate = this.calForDate.SelectedDate;
            this.wzPlanWeek.ActiveStepIndex = 0;
        }

        public bool ShowWorkWeekOnly
        {
            get
            {
                if (this.hdnShowWorkWeekOnly.Value.Trim().Equals(""))
                {
                    this.hdnShowWorkWeekOnly.Value = false.ToString();
                    return false;
                }
                else
                {
                    return Convert.ToBoolean(this.hdnShowWorkWeekOnly.Value);
                }
            }
            set
            {
                this.hdnShowWorkWeekOnly.Value = value.ToString();
                initPage(this.calForDate.SelectedDate);
            }
        }

        protected string GetClassForWizardStep(object wizardStep)
        {
            WizardStep step = wizardStep as WizardStep;

            if (step == null)
            {
                return "";
            }
            int stepIndex = wzPlanWeek.WizardSteps.IndexOf(step);

            if (stepIndex < wzPlanWeek.ActiveStepIndex)
            {
                return "prevStep";
            }
            else if (stepIndex > wzPlanWeek.ActiveStepIndex)
            {
                return "nextStep";
            }
            else
            {
                return "currentStep";
            }
        }

        protected void calForDate_OnDateChanged(object sender, EventArgs e)
        {
            initPage(this.calForDate.SelectedDate);
        }

        protected void wzPlanWeek_Click(object sender, WizardNavigationEventArgs e)
        {
            Response.Redirect("/AppPages/Calendar/WeeklyView.aspx?currentdate=" + this.hdnCurrentDate.Value);
        }

    }
}