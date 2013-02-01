using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;

namespace MyPlanner.Common
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
                    case "SQLSERVERCE":
                        {
                            dsm = DataSourceMode.MSSQLServerCE;
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
                    case DataSourceMode.MSSQLServerCE:
                        {
                            returnValue = "MyPlannerConnectionStringSQLCE";
                            break;
                        }
                    default:
                        {
                            throw new NotImplementedException();
                            break;
                        }
                }
                return returnValue;
            }
        }

         public static string APPLICATION_TITLE
        {
            get
            {
                return AppSettings("APPLICATION_TITLE");
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
