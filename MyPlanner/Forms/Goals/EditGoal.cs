using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyPlanner.BLL;
using MyPlanner.Common;
using MyPlanner.Models;

namespace MyPlanner
{
    public partial class EditGoal : PopupForm
    {

        public EditGoal(AppUser usr, PageMode pageMode)
        {
            InitializeComponent();
            CurrentUser = usr;
            CurrentPageMode = pageMode;
        }

        private void EditGoal_Load(object sender, EventArgs e)
        {
            initPage();
        }

        private void initPage()
        {
            this.txtSubject.Text = "";
            this.txtReason.Text = "";
            this.txtNotes.Text = "";
            this.chklstCategory.DataSource = BLLCategory.GetCategoriesByUserID(CurrentUser.UserID);
            this.chklstCategory.DisplayMember = "CategoryName";
            this.chklstCategory.ValueMember = "CategoryID";
            this.chklstCategory.ClearSelected();
            switch (this.CurrentPageMode)
            {
                case PageMode.Add:
                    {
                        this.Text = ApplicationTitle + " - Add Goal";
                        Form_Title = "Add Goal";
                        this.lblItemID.Text = "0";
                        this.btnMarkCompleted.Visible = false;
                        break;
                    }
                case PageMode.Edit:
                    {
                        this.Text = ApplicationTitle + " - Edit Goal";
                        Form_Title = "Edit Goal";
                        loadData();
                        break;
                    }
            }
            this.IsPageDirty = false;
        }

        public int ItemID
        {
            get
            {
                return Convert.ToInt32(this.lblItemID.Text);
            }
            set
            {
                this.lblItemID.Text = value.ToString();
            }
        }

        private void loadData()
        {
            Goal goal = BLLGoal.GetGoalByID(Convert.ToInt32(this.lblItemID.Text));
            if (goal != null)
            {
                this.txtNotes.Text = goal.GoalNotes;
                this.txtReason.Text = goal.GoalReason;
                this.txtSubject.Text = goal.GoalSubject;
                for (int i = 0; i <= goal.Categories.Count - 1; i++)
                {
                    int idx = getIndexOfCategory(goal.Categories[i]);
                    if (idx >= 0)
                    {
                        this.chklstCategory.SetItemChecked(idx, true);
                    }
                }
                this.btnMarkCompleted.Visible = !goal.IsCompleted;
            }
        }

        private int getIndexOfCategory(Category category)
        {
            int returnData = -1;
            for (int i = 0; i <= chklstCategory.Items.Count - 1; i++)
            {
                Category cat = (Category)chklstCategory.Items[i];
                if (cat.CategoryID == category.CategoryID)
                {
                    returnData = i;
                    break;
                }
            }
            return returnData;
        }

        private void txtSubject_TextChanged(object sender, EventArgs e)
        {
            IsPageDirty = true;
        }

        private void txtReason_TextChanged(object sender, EventArgs e)
        {
            IsPageDirty = true;
        }

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {
            IsPageDirty = true;
        }

        private void chklstCategory_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            IsPageDirty = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (IsPageDirty)
            {
                DialogResult rslt = ShowConfirmation("Do you want to save changes?", Form_Title, MessageBoxButtons.YesNo);
                if (rslt == System.Windows.Forms.DialogResult.Yes)
                {
                    btnSave_Click(null, null);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool returnValue = false;
            if (isValidData(true))
            {
                if (IsPageDirty)
                {
                    Goal goal = null;
                    switch (this.CurrentPageMode)
                    {
                        case PageMode.Add:
                            {
                                goal = new Goal();
                                break;
                            }
                        case PageMode.Edit:
                            {
                                goal = BLLGoal.GetGoalByID(Convert.ToInt32(this.lblItemID.Text));
                                break;
                            }
                    }
                    goal.GoalSubject = this.txtSubject.Text;
                    goal.GoalReason = this.txtReason.Text;
                    goal.GoalNotes = this.txtNotes.Text;
                    goal.ForUser = this.CurrentUser;
                    goal.DueOn = DateTime.Today.AddYears(1);
                    goal.Categories.Clear();
                    foreach (object itemChecked in chklstCategory.CheckedItems)
                    {
                        Category category = itemChecked as Category;
                        goal.Categories.Add(BLLCategory.GetCategoryByID(category.CategoryID));
                    }
                    switch (this.CurrentPageMode)
                    {
                        case PageMode.Add:
                            {
                                returnValue = BLLGoal.AddGoal(goal);
                                break;
                            }
                        case PageMode.Edit:
                            {
                                returnValue = BLLGoal.UpdateGoal(goal);
                                break;
                            }
                    }
                    goal = null;
                }
                this.Hide();
                this.Close();
            }
        }

        private bool isValidData(bool showMessage)
        {
            bool returnValue = true;
            if (this.txtSubject.Text.Trim().Equals(""))
            {
                ShowError("Please enter subject.", Form_Title);
                returnValue = false;
                this.txtSubject.Focus();
            }
            return returnValue;
        }

        private void btnMarkCompleted_Click(object sender, EventArgs e)
        {
            BLLGoal.SetGoalAsCompleted(Convert.ToInt32(this.lblItemID.Text));
            this.Hide();
            this.Close();
        }
    }
}
