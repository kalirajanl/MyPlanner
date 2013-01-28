using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using MyPlanner.BLL;

namespace MyPlanner.AppPages.UserControls
{
    public partial class Menu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BuildTabs();
        }

        private void BuildTabs()
        {
            int SelectedTabID = Tabs.GetTabIDForPage(GetCurrentPageName());

            List<Tab> MyTabs = Tabs.GetTabsForUser(1);
            StringBuilder sbMenu = new StringBuilder();
            for (int i = 0; i <= MyTabs.Count - 1; i++)
            {
                sbMenu.Append("<li");
                if (MyTabs[i].TabID == SelectedTabID)
                {
                    sbMenu.Append(" class='tab_selected'");
                }
                sbMenu.Append("><a href=");
                sbMenu.Append(MyTabs[i].TargetURL);
                sbMenu.Append(">");
                sbMenu.Append(MyTabs[i].TabName);
                sbMenu.Append("</a>");
            }
            this.ltrlMenu.Text = sbMenu.ToString();
            sbMenu.Clear();
            sbMenu = null;
        }

        private string GetCurrentPageName()
        {
            string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
            string sRet = oInfo.Name;
            return sRet;
        } 

    }
}