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
    public partial class ReviewMission : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string controlID = Page.Request.Params["__EVENTTARGET"];
                if (controlID.Trim().ToLower().Equals("deletemission"))
                {
                    BLLMission.DeleteMission(Convert.ToInt32(this.hdnMissionID.Value));
                }
                else if (controlID.Trim().ToLower().Equals("deletevalue"))
                {
                    BLLValue.DeleteValue(Convert.ToInt32(this.hdnValueID.Value));
                }
            }
            initPage();
        }

        private void initPage()
        {
            List<Mission> MyMission = BLLMission.GetMissions(1, null,false );

            this.gvMyMission.DataSource = MyMission;
            this.gvMyMission.DataBind();

            //this.imgbtnAddMission.Attributes.Add("OnClick", "return fnAddMission()");

            List<Value> MyValues = BLLValue.GetValues(1, null, false);

            this.gvMyValues.DataSource = MyValues;
            this.gvMyValues.DataBind();
            //this.imgbtnAddValue.Attributes.Add("OnClick", "return fnAddValue()");

        }

        protected void OnMissionRowCreated(object sender, GridViewRowEventArgs e)
        {

        }

        protected void OnMissionRowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    if (!e.Row.Cells[2].Text.Trim().Equals(""))
            //    {
            //        int missionID = Convert.ToInt32(e.Row.Cells[2].Text);
            //        e.Row.Cells[2].Text = "";
            //        if (missionID >= 0)
            //        {
            //            string script = "<img src='/App_Themes/treetops/images/edit_icon.jpg' style='cursor:hand' alt='Edit Mission' width='16px' height='16px' onclick='fnEditMission(" + missionID.ToString() + ");'/>&nbsp;";
            //            script += "<img src='/App_Themes/treetops/images/delete_icon.jpg' style='cursor:hand' alt='Delete Mission' width='16px' height='16px' onclick='fnDeleteMission(" + missionID.ToString() + ");'/>";
            //            e.Row.Cells[2].Text = script;
            //        }
            //    }
            //}
        }

        protected void OnValueRowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    if (!e.Row.Cells[2].Text.Trim().Equals(""))
            //    {
            //        int valueID = Convert.ToInt32(e.Row.Cells[2].Text);
            //        e.Row.Cells[2].Text = "";
            //        if (valueID >= 0)
            //        {
            //            string script = "<img src='/App_Themes/treetops/images/edit_icon.jpg' style='cursor:hand' alt='Edit Mission' width='16px' height='16px' onclick='fnEditValue(" + valueID.ToString() + ")';/>&nbsp;";
            //            script += "<img src='/App_Themes/treetops/images/delete_icon.jpg' style='cursor:hand' alt='Delete Mission' width='16px' height='16px' onclick='fnDeleteValue(" + valueID.ToString() + ")';/>";
            //            e.Row.Cells[2].Text = script;
            //        }
            //    }
            //}
        }
    }
}