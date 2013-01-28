using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MyPlanner.Models;

namespace MyPlanner.Models
{
    public class ConfigReader
    {
        public static DataSourceMode ActiveDataSourceMode
        {
            get
            {
                DataSourceMode dsm = DataSourceMode.UnKnown;
                string dataSource = AppSettings("DataSource").Trim().ToUpper();
                switch (dataSource)
                {
                    case "SQLSERVER":
                        {
                            dsm = DataSourceMode.MSSQLServer;
                            break;
                        }
                    case "MSACCESS":
                        {
                            dsm = DataSourceMode.MSAccess;
                            break;
                        }
                    default:
                        {
                            dsm = DataSourceMode.UnKnown;
                            break;
                        }
                }
                return dsm;
            }
        }

        //public static string ActiveConnectionString
        //{
        //    get
        //    {
        //        string returnValue = "";
        //        switch (ActiveDataSourceMode)
        //        {
        //            case DataSourceMode.MSSQLServer:
        //                {
        //                    returnValue = ConfigurationManager.ConnectionStrings["MyPlannerConnectionStringSQL"].ConnectionString;
        //                    break;
        //                }
        //            case DataSourceMode.MSAccess:
        //                {
        //                    returnValue =  ConfigurationManager.ConnectionStrings["MyPlannerConnectionStringACCDB"].ConnectionString;
        //                    break;
        //                }
        //        }
        //        return returnValue;
        //    }
        //}

        public static string ActiveConnectionStringKey
        {
            get
            {
                string returnValue = "";
                switch (ActiveDataSourceMode)
                {
                    case DataSourceMode.MSSQLServer:
                        {
                            returnValue = "MyPlannerConnectionStringSQL";
                            break;
                        }
                    case DataSourceMode.MSAccess:
                        {
                            returnValue = "MyPlannerConnectionStringACCDB";
                            break;
                        }
                }
                return returnValue;
            }
        }

        public static string AppSettings(string key)
        {
            string returnValue = "";
            if (ConfigurationManager.AppSettings[key] != null)
            {
                returnValue = ConfigurationManager.AppSettings[key];
            }
            return returnValue;
        }
    }
}
