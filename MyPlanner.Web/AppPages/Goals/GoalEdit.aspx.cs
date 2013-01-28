using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using MyPlanner.Models;
using MyPlanner.BLL;

namespace MyPlanner.AppPages
{
    public partial class GoalEdit : PopupBasePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            switch (CurrentPageMode)
            {
                case PageMode.Add: { this.Title = Constants.APP_TITLE + " - Add Goal"; break; }
                case PageMode.Edit: { this.Title = Constants.APP_TITLE + " - Edit Goal"; break; }
                case PageMode.View: { this.Title = Constants.APP_TITLE + " - View Goal"; break; }
                default: { this.Title = Constants.APP_TITLE; break; }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                processQueryStrings();
                initPage();
                this.txtSubject.Focus();
            }

            this.lblErrorText.Text = "&nbsp;";
        }

        private void initPage()
        {
            initControls();
            if (!this.txtGoalID.Text.Trim().Equals(""))
            {
                loadControls();
            }
        }

        private void initControls()
        {
            this.lblErrorText.Text = "";
            //this.txtGoalID.Text = "";
            this.txtSubject.Text = "";
            this.txtGoalNotes.Text = "";

            this.chklstCategory.DataSource = BLLCategory.GetCategoriesByUserID(1);
            this.chklstCategory.DataTextField = "CategoryName";
            this.chklstCategory.DataValueField = "CategoryID";
            this.chklstCategory.DataBind();

            this.btnCancel.Attributes.Add("onclick", "window.returnValue = 0;window.close();return false;");
        }

        private void loadControls()
        {
            int GoalID = Convert.ToInt32(this.txtGoalID.Text);
            Goal Goal = BLLGoal.GetGoalByID(GoalID);
            if (Goal != null)
            {
                this.txtSubject.Text = Goal.GoalSubject;
                this.txtReason.Text = Goal.GoalReason;
                this.txtGoalNotes.Text = Goal.GoalNotes;

                this.chklstCategory.ClearSelection();
                for (int i = 0; i <= Goal.Categories.Count - 1; i++)
                {
                    if (this.chklstCategory.Items.FindByValue(Goal.Categories[i].CategoryID.ToString()) != null)
                    {
                        this.chklstCategory.Items.FindByValue(Goal.Categories[i].CategoryID.ToString()).Selected = true;
                    }
                }
            }
        }

        private void processQueryStrings()
        {
            string GoalID = "0";
            if (Request.QueryString["Goalid"] != null)
            {
                GoalID = Request.QueryString["Goalid"].ToString();
            }
            this.txtGoalID.Text = GoalID;

        }

        private bool isValidData()
        {
            bool returnValue = true;
            string errMessage = "";
            if (this.txtSubject.Text.Trim().Equals(""))
            {
                returnValue = false;
                errMessage = "Please enter Subject.";
                this.txtSubject.Focus();
            }
            this.lblErrorText.Text = errMessage;
            return returnValue;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (isValidData())
            {
                Goal goal = new Goal();
                if (CurrentPageMode != PageMode.Add)
                {
                    goal = BLLGoal.GetGoalByID(Convert.ToInt32(this.txtGoalID.Text));
                }
                try
                {
                    goal.ForUser = new AppUser();
                    goal.ForUser.UserID = 1;
                    goal.GoalNotes = this.txtGoalNotes.Text;
                    goal.GoalReason = this.txtReason.Text;
                    goal.GoalSubject = this.txtSubject.Text;
                    goal.Categories = new List<Category>();
                    for (int i = 0; i <= chklstCategory.Items.Count - 1; i++)
                    {
                        if (chklstCategory.Items[i].Selected)
                        {
                            goal.Categories.Add(BLLCategory.GetCategoryByID(Convert.ToInt32(chklstCategory.Items[i].Value)));
                        }
                    }
                    if (CurrentPageMode == PageMode.Add)
                    {
                        BLLGoal.AddGoal(goal);
                        this.lblErrorText.Text = "Completed";
                    }
                    else if (CurrentPageMode == PageMode.Edit)
                    {
                        BLLGoal.UpdateGoal(goal);
                        this.lblErrorText.Text = "Completed";
                    }
                    else
                    {
                        throw new Exception("Invalid Action");
                    }
                    string script = "<script language='javascript' type='text/javascript'>window.returnValue = 1;;window.close();</script>";
                    Page.RegisterClientScriptBlock("closescript", script);
                }
                catch (Exception ex)
                {
                    this.lblErrorText.Text = ex.Message;
                    this.txtSubject.Focus();
                }

            }
        }

    }
}