using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyPlanner.Models;
using MyPlanner.BLL;
using System.Text;
using Obout.Ajax.UI.TreeView;

namespace MyPlanner.AppPages
{
    public partial class GoalsAndSteps : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string controlID = Page.Request.Params["__EVENTTARGET"];
                if (controlID.Trim().ToLower().Equals("deletegoal"))
                {
                    BLLGoal.DeleteGoal(Convert.ToInt32(this.hdnGoalID.Value));
                }
                else if (controlID.Trim().ToLower().Equals("deletegoalstep"))
                {
                    BLLGoalStep.DeleteGoalStep(Convert.ToInt32(this.hdnGoalStepID.Value));
                }
            }
            loadGoals();
            this.btnSubmit.Attributes.Add("style", "display:none");
        }

        
        private void loadGoals()
        {
            StringBuilder sbGoalScript = new StringBuilder();
            StringBuilder sbGoalStepScript = new StringBuilder();
            Node rootNode;
            Node goalNode;
            Node stepNode;

            ObTree.Nodes.Clear();

            rootNode = new Node()
            {
                Text = "My Goals",
                Expanded = true,
                ClientID = "root",
                Value = "0",
                ImageUrl = Constants.TREEVIEW_ICON_PATH + "ball_greenS.gif"
            };

            List<Goal> goals = BLLGoal.GetGoalsForUser(CurrentUser.UserID, null);

            for (int i = 0; i <= goals.Count - 1; i++)
            {
                goalNode = new Node()
                {
                    Text = "<span style='color:crimson;'>" + goals[i].GoalSubject + "</span>",
                    Expanded = true,
                    ClientID = "G" + goals[i].GoalID,
                    Value = goals[i].GoalID.ToString(),
                    ImageUrl = Constants.TREEVIEW_ICON_PATH + "ball_yellowS.gif"
                };
                sbGoalScript.AppendLine("showGoalMenu('G" + goals[i].GoalID.ToString() + "');");
                for (int j = 0; j <= goals[i].Steps.Count - 1; j++)
                {
                    stepNode = new Node()
                    {
                        Text = "<span st`yle='color:crimson;'>" + goals[i].Steps[j].taskInfo.TaskName + "</span>",
                        Expanded = true,
                        Value = goals[i].GoalID.ToString(),
                        ClientID = "S" + goals[i].Steps[j].GoalStepID.ToString(),
                        ImageUrl = Constants.TREEVIEW_ICON_PATH + "ball_redS.gif"
                    };
                    sbGoalStepScript.AppendLine("showGoalStepMenu('" + goals[i].GoalID.ToString() + "','" + goals[i].Steps[j].GoalStepID.ToString() + "','S" + goals[i].Steps[j].GoalStepID.ToString() + "');");
                    goalNode.ChildNodes.Add(stepNode);
                }

                stepNode = new Node()
                {
                    Text = "<span style='color:crimson;'>Add Step</span>",
                    Expanded = true,
                    ClientID = "G" + goals[i].GoalID,
                    Value = "-2",
                    ImageUrl = Constants.TREEVIEW_ICON_PATH + "ball_redS.gif",
                };
                goalNode.ChildNodes.Add(stepNode);

                rootNode.ChildNodes.Add(goalNode);
            }
            goalNode = new Node()
            {
                Text = "<span style='color:crimson;'>Add Goal</span>",
                Expanded = true,
                ClientID = "G0",
                Value = "-1",
                ImageUrl = Constants.TREEVIEW_ICON_PATH + "ball_yellowS.gif"
            };

            rootNode.ChildNodes.Add(goalNode);
            ObTree.Nodes.Add(rootNode);

            Page.RegisterStartupScript("goalmenus", "<script>" + sbGoalScript.ToString() + "</script>");
            Page.RegisterStartupScript("goalstepmenus", "<script>" + sbGoalStepScript.ToString() + "</script>");

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }
    }
}