using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyPlanner.DAL;
using MyPlanner.Models;

namespace MyPlanner.BLL
{
    public class BLLAppUser
    {
        public static AppUser GetUserByID(int UserID)
        {
            return DALAppUser.GetUserByID(UserID); 
        }

        public static AppUser ValidateUser(string FileAs, string Password)
        {
            return DALAppUser.ValidateUser(FileAs, Password);
        }
    }
}
