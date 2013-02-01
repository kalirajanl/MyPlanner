using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyPlanner.BLL;
using MyPlanner.Common;
using MyPlanner.Models;

namespace MyPlanner
{
    public partial class CtrlGoalsAndSteps : BaseUserControl
    {
        public CtrlGoalsAndSteps()
        {
            InitializeComponent();
        }

        private void GoalsAndSteps_Load(object sender, EventArgs e)
        {
            loadTree();
            this.tvGoalsAndSteps.Height = this.Height - 5;
            this.tvGoalsAndSteps.Width = this.Width - 5;
        }

        private void loadTree()
        {
            this.tvGoalsAndSteps.Nodes.Clear();

            TreeNode tvnRoot = new TreeNode("My Goals");
            tvnRoot.Tag = "R";
            tvnRoot.ContextMenuStrip = this.cmRoot;
            if (CurrentUser != null)
            {
                List<Goal> goals = BLLGoal.GetGoalsForUser(CurrentUser.UserID, null);
                for (int i = 0; i <= goals.Count - 1; i++)
                {
                    TreeNode tvnGoal = new TreeNode(goals[i].GoalSubject);
                    tvnGoal.Tag = "G" + goals[i].GoalID.ToString();
                    if (goals[i].DueOn < DateTime.Today)
                    {
                        tvnGoal.ForeColor = Color.Red;
                    }
                    else
                    {
                        tvnGoal.ForeColor = Color.Blue;
                    }
                    for (int j = 0; j <= goals[i].Steps.Count - 1; j++)
                    {
                        TreeNode tvnStep = new TreeNode(goals[i].Steps[j].taskInfo.TaskName);
                        tvnStep.Tag = "S" + goals[i].Steps[j].GoalStepID.ToString();
                        tvnStep.ContextMenuStrip = this.cmGoalStep;
                        if (goals[i].Steps[j].taskInfo.TaskDate < DateTime.Today)
                        {
                            tvnStep.ForeColor = Color.Red;
                        }
                        else
                        {
                            tvnStep.ForeColor = Color.Blue;
                        }
                        if (goals[i].Steps[j].taskInfo.Status == TaskStatuses.Completed)
                        {
                            tvnStep.ForeColor = Color.Black;
                            Font tn = tvnStep.NodeFont;
                            if (tn == null)
                            {
                                tn = this.tvGoalsAndSteps.Font;
                            }
                            if (tn == null)
                            {
                                tn = new Font("Arial", 12);
                            }
                            tvnStep.NodeFont = new Font(tn.FontFamily, tn.SizeInPoints, FontStyle.Strikeout);
                        }
                        tvnGoal.Nodes.Add(tvnStep);
                        tvnStep = null;
                    }
                    tvnGoal.ContextMenuStrip = this.cmGoal;
                    if (goals[i].IsCompleted)
                    {
                        tvnGoal.ForeColor = Color.Black;
                        Font tn = tvnGoal.NodeFont;
                        if (tn == null)
                        {
                            tn = this.tvGoalsAndSteps.Font;
                        }
                        if (tn == null)
                        {
                            tn = new Font("Arial", 12);
                        }
                        tvnGoal.NodeFont = new Font(tn.FontFamily, tn.SizeInPoints, FontStyle.Strikeout);
                    }
                    tvnRoot.Nodes.Add(tvnGoal);
                    tvnGoal = null;
                }
                this.tvGoalsAndSteps.Nodes.Add(tvnRoot);
                tvnRoot = null;
                this.tvGoalsAndSteps.SelectedNode = this.tvGoalsAndSteps.Nodes[0];
            }
            this.tvGoalsAndSteps.ExpandAll();
        }

        private void addGoal()
        {
            EditGoal childForm = new EditGoal(CurrentUser, PageMode.Add);
            childForm.CurrentPageMode = PageMode.Add;
            childForm.ShowDialog();
            loadTree();
        }

        private void addGoalStep()
        {

            TreeNode tvn = this.tvGoalsAndSteps.SelectedNode;
            if (tvn.Tag.ToString().StartsWith("G"))
            {
                int goalID = Convert.ToInt32(tvn.Tag.ToString().Substring(1));
                EditGoalStep childForm = new EditGoalStep(CurrentUser, PageMode.Add, goalID);
                childForm.CurrentPageMode = PageMode.Add;
                childForm.ShowDialog();
                loadTree();
            }
            else
            {
                ShowError("Please select a Goal first.", Form_Title);
            }
        }

        private void editNodeContent()
        {
            TreeNode tvn = this.tvGoalsAndSteps.SelectedNode;
            if (tvn.Tag.ToString().StartsWith("G"))
            {
                EditGoal childForm = new EditGoal(CurrentUser, PageMode.Add);
                childForm.CurrentPageMode = PageMode.Edit;
                childForm.ItemID = Convert.ToInt32(tvn.Tag.ToString().Substring(1));
                childForm.ShowDialog();
                loadTree();
            }
            else if (tvn.Tag.ToString().StartsWith("S"))
            {
                int goalID = Convert.ToInt32(tvn.Parent.Tag.ToString().Substring(1));
                EditGoalStep childForm = new EditGoalStep(CurrentUser, PageMode.Add, goalID);
                childForm.CurrentPageMode = PageMode.Edit;
                childForm.ItemID = Convert.ToInt32(tvn.Tag.ToString().Substring(1));
                childForm.ShowDialog();
                loadTree();
            }
        }

        private void deleteNodeContent()
        {
            TreeNode tvn = this.tvGoalsAndSteps.SelectedNode;
            if (tvn.Tag.ToString().StartsWith("G"))
            {
                int goalID = Convert.ToInt32(tvn.Tag.ToString().Substring(1));
                BLLGoal.DeleteGoal(goalID);
                loadTree();
            }
            else if (tvn.Tag.ToString().StartsWith("S"))
            {
                int goalStepID = Convert.ToInt32(tvn.Tag.ToString().Substring(1));
                BLLGoalStep.DeleteGoalStep(goalStepID);
                loadTree();
            }
        }

        private void markNodeContentAsCompleted()
        {
            TreeNode tvn = this.tvGoalsAndSteps.SelectedNode;
            if (tvn.Tag.ToString().StartsWith("G"))
            {
                int goalID = Convert.ToInt32(tvn.Tag.ToString().Substring(1));
                BLLGoal.SetGoalAsCompleted(goalID);
                loadTree();
            }
            else if (tvn.Tag.ToString().StartsWith("S"))
            {
                int goalID = Convert.ToInt32(tvn.Parent.Tag.ToString().Substring(1));
                int goalStepID = Convert.ToInt32(tvn.Tag.ToString().Substring(1));
                BLLGoalStep.SetGoalStepAsCompleted(goalID, goalStepID);
                loadTree();
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            editNodeContent();
        }

        private void addGoalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addGoal();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            addGoal();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            editNodeContent();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            deleteNodeContent();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            addGoalStep();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            editNodeContent();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            deleteNodeContent();
        }

        private void markGoalAsCompletedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            markNodeContentAsCompleted();
        }

        private void markGoalStepAsCompleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            markNodeContentAsCompleted();
        }

    }
}
