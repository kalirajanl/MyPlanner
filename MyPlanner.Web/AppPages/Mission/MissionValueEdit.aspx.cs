using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyPlanner.Models;
using MyPlanner.BLL;

namespace MyPlanner.AppPages
{
    public partial class MissionValueEdit : PopupBasePage
    {

        protected string PageType
        {
            get
            {
                string pageType = "";
                if (Request.QueryString["type"] != null)
                {
                    pageType = Request.QueryString["type"].ToString();
                }
                else
                {
                    pageType = "Mission";
                }
                return pageType;
            }
            set { }
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            switch (CurrentPageMode)
            {
                case PageMode.Add: { this.Title = Constants.APP_TITLE + " - Add " + PageType; break; }
                case PageMode.Edit: { this.Title = Constants.APP_TITLE + " - Edit " + PageType; break; }
                case PageMode.View: { this.Title = Constants.APP_TITLE + " - View " + PageType; break; }
                default: { this.Title = Constants.APP_TITLE; break; }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                processQueryStrings();
                initPage();
            }
            this.lblErrorText.Text = "&nbsp;";
        }

        private void initPage()
        {
            initControls();
            if (!this.txtItemID.Text.Trim().Equals(""))
            {
                loadControls();
            }
            this.txtTitle.Focus();
        }

        private void initControls()
        {
            this.lblErrorText.Text = "";
            this.txtTitle.Text = "";
            this.txtNotes.Text = "";

            this.chklstCategory.DataSource = BLLCategory.GetCategoriesByUserID(1);
            this.chklstCategory.DataTextField = "CategoryName";
            this.chklstCategory.DataValueField = "CategoryID";
            this.chklstCategory.DataBind();

            this.btnCancel.Attributes.Add("onclick", "window.returnValue = 0;window.close();return false;");
        }

        private void loadControls()
        {

            switch (PageType)
            {
                case "Mission":
                    {
                        int missionID = Convert.ToInt32(this.txtItemID.Text);
                        Mission mission = BLLMission.GetMissionByID(missionID);
                        if (mission != null)
                        {
                            this.txtItemID.Text = missionID.ToString();
                            this.txtTitle.Text = mission.MissionTitle;
                            this.txtNotes.Text = mission.MissionNotes;

                            this.chklstCategory.ClearSelection();
                            for (int i = 0; i <= mission.Categories.Count - 1; i++)
                            {
                                if (this.chklstCategory.Items.FindByValue(mission.Categories[i].CategoryID.ToString()) != null)
                                {
                                    this.chklstCategory.Items.FindByValue(mission.Categories[i].CategoryID.ToString()).Selected = true;
                                }
                            }
                        }
                        break;
                    }
                case "Value":
                    {
                        int valueID = Convert.ToInt32(this.txtItemID.Text);
                        Value value = BLLValue.GetValueByID(valueID);
                        if (value != null)
                        {
                            this.txtItemID.Text = valueID.ToString();
                            this.txtTitle.Text = value.ValueTitle;
                            this.txtNotes.Text = value.ValueNotes;

                            this.chklstCategory.ClearSelection();
                            for (int i = 0; i <= value.Categories.Count - 1; i++)
                            {
                                if (this.chklstCategory.Items.FindByValue(value.Categories[i].CategoryID.ToString()) != null)
                                {
                                    this.chklstCategory.Items.FindByValue(value.Categories[i].CategoryID.ToString()).Selected = true;
                                }
                            }
                        }
                        break;
                    }
            }

        }

        private void processQueryStrings()
        {
            string taskID = "0";
            if (Request.QueryString["itemid"] != null)
            {
                taskID = Request.QueryString["itemid"].ToString();
            }
            this.txtItemID.Text = taskID;

        }

        private bool isValidData()
        {
            bool returnValue = true;
            string errMessage = "";
            if (this.txtTitle.Text.Trim().Equals(""))
            {
                returnValue = false;
                errMessage = "Please enter " + PageType + " Title.";
                this.txtTitle.Focus();
            }
            this.lblErrorText.Text = errMessage;
            return returnValue;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (isValidData())
            {
                switch (PageType)
                {
                    case "Mission":
                        {
                            try
                            {
                                Mission mission = new Mission();
                                if (CurrentPageMode != PageMode.Add)
                                {
                                    mission = BLLMission.GetMissionByID(Convert.ToInt32(this.txtItemID.Text));
                                }
                                mission.MissionTitle = this.txtTitle.Text;
                                mission.MissionNotes = this.txtNotes.Text;
                                mission.ForUser = CurrentUser;
                                mission.Categories = new List<Category>();
                                for (int i = 0; i <= chklstCategory.Items.Count - 1; i++)
                                {
                                    if (chklstCategory.Items[i].Selected)
                                    {
                                        Category cate = BLLCategory.GetCategoryByID(Convert.ToInt32(chklstCategory.Items[i].Value));
                                        mission.Categories.Add(cate);
                                        cate = null;
                                    }
                                }

                                if (CurrentPageMode == PageMode.Add)
                                {
                                    BLLMission.AddMission(mission);
                                    this.lblErrorText.Text = "Completed";
                                }
                                else if (CurrentPageMode == PageMode.Edit)
                                {

                                    mission.MissionID = Convert.ToInt32(this.txtItemID.Text);
                                    BLLMission.UpdateMission(mission);
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
                                this.txtTitle.Focus();
                            }

                            break;
                        }
                    case "Value":
                        {
                            try
                            {
                                Value value = new Value();
                                if (CurrentPageMode != PageMode.Add)
                                {
                                    value = BLLValue.GetValueByID(Convert.ToInt32(this.txtItemID.Text));
                                }
                                value.ValueTitle = this.txtTitle.Text;
                                value.ValueNotes = this.txtNotes.Text;
                                value.ForUser = CurrentUser;
                                value.Categories = new List<Category>();
                                for (int i = 0; i <= chklstCategory.Items.Count - 1; i++)
                                {
                                    if (chklstCategory.Items[i].Selected)
                                    {
                                        Category cate = BLLCategory.GetCategoryByID(Convert.ToInt32(chklstCategory.Items[i].Value));
                                        value.Categories.Add(cate);
                                        cate = null;
                                    }
                                }

                                if (CurrentPageMode == PageMode.Add)
                                {
                                    BLLValue.AddValue(value);
                                    this.lblErrorText.Text = "Completed";
                                }
                                else if (CurrentPageMode == PageMode.Edit)
                                {

                                    BLLValue.UpdateValue(value);
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
                                this.txtTitle.Focus();
                            }

                            break;
                        }
                }
            }
        }

    }
}