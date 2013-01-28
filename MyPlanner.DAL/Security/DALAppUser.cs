using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPlanner.Models;
using System.Data;
namespace MyPlanner.DAL
{
    public class DALAppUser
    {
        public static List<AppUser> GetUsers()
        {
            List<AppUser> AppUsers = new List<AppUser>();

            return AppUsers;
        }

        public static AppUser ValidateUser(string FileAs, string Password)
        {
            AppUser usr = null;
            DataTable dtUsers = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "CMN_Users", FilterCondition = "FileAs = '" + FileAs.ToString() + "' And Password = '" + Password + "'" });

            if (dtUsers.Rows.Count == 1)
            {
                usr = loadUser(dtUsers, 0);
            }
            return usr;
        }

        public static AppUser GetUserByID(int UserID)
        {
            DataTable dtUsers = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "CMN_Users",  FilterCondition = "UserID = " + UserID.ToString()});
            AppUser usr = loadUser(dtUsers, 0);
            return usr;           
        }

        private static AppUser loadUser(DataTable dtUsers, int RowNo)
        {
            AppUser usr = null;
            if (dtUsers != null)
            {
                if (dtUsers.Rows[RowNo] != null)
                {
                    usr = new AppUser();
                    usr.UserID = Convert.ToInt32(dtUsers.Rows[RowNo]["UserID"]);
                    usr.UserName = new DisplayName();
                    usr.UserName.FileAs = dtUsers.Rows[RowNo]["FileAs"].ToString();
                    usr.UserName.FirstName = dtUsers.Rows[RowNo]["FirstName"].ToString();
                    usr.UserName.LastName = dtUsers.Rows[RowNo]["LastName"].ToString();
                    if (dtUsers.Rows[RowNo]["MiddleInitial"] != DBNull.Value)
                    {
                        usr.UserName.MiddleName = dtUsers.Rows[RowNo]["MiddleInitial"].ToString();
                    }
                    if (dtUsers.Rows[RowNo]["Suffix"] != DBNull.Value)
                    {
                        usr.UserName.Suffix = dtUsers.Rows[RowNo]["Suffix"].ToString();
                    }
                    if (dtUsers.Rows[RowNo]["Title"] != DBNull.Value)
                    {
                        usr.UserName.Title = dtUsers.Rows[RowNo]["Title"].ToString();
                    }
                }
            }
            return usr;
        }
    }
}
