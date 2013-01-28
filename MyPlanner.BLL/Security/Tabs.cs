using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlanner.BLL
{
    public class Tab
    {
        
        public int TabID {get;set;}
        public string TabName {get;set;}
        public string TargetURL { get;set;}
    }

    public class Tabs
    {
        public static List<Tab> GetTabsForUser(int currentUserID)
        {
            List<Tab> MyTabs = new List<Tab>();

            MyTabs.Add(new Tab { TabID = 1, TabName = "Home", TargetURL = "/AppPages/Landing/Home.aspx" });
            MyTabs.Add(new Tab { TabID = 2, TabName = "Calendar", TargetURL = "/AppPages/Calendar/DailyView.aspx" });
            MyTabs.Add(new Tab { TabID = 3, TabName = "Contacts", TargetURL = "" });
            MyTabs.Add(new Tab { TabID = 4, TabName = "Mission/Values", TargetURL = "/AppPages/Mission/MissionView.aspx" });
            MyTabs.Add(new Tab { TabID = 5, TabName = "Goals", TargetURL = "/AppPages/Goals/ViewGoals.aspx" });
            MyTabs.Add(new Tab { TabID = 6, TabName = "Weekly Planning", TargetURL = "/AppPages/Planning/PlanWeek.aspx" });
            MyTabs.Add(new Tab { TabID = 7, TabName = "Notes", TargetURL = "" });

            return MyTabs;
        }

        public static int GetTabIDForPage(string pageName)
        {
            pageName = pageName.Trim().ToUpper();
            int tabID = 1;
            switch (pageName.Substring(0, pageName.Length - 5))
            {
                case "HOME":
                    {
                        tabID = 1;
                        break;
                    }
                case "WEEKLYVIEW":
                case "DAILYVIEW":
                    {
                        tabID = 2;
                        break;
                    }
                case "MISSIONVIEW":
                    {
                        tabID = 4;
                        break;
                    }
                case "VIEWGOALS":
                    {
                        tabID = 5;
                        break;
                    }
                case "COMPASSROLES":
                case "PLANWEEK":
                    {
                        tabID = 6;
                        break;
                    }
                default:
                    {
                        tabID = 1;
                        break;
                    }
            }
            return tabID;
        }
    }
}
