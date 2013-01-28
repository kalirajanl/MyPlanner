using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using MyPlanner.Models;

namespace MyPlanner.DAL
{
    public class AccessHelper
    {

        private OleDbConnection connection = null;
        //public const string ACCESS_CONNECTIONSTRING_TEMPLATE = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};";

        enum AccessConnectionActionType
        {
            None = 0,
            AutoDetection = 1,
            Open = 2
        }

        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

        #region ExecuteNonQuery

        public int ExecuteNonQuery(OleDbCommand cmd)
        {
            return cmd.ExecuteNonQuery();
        }

        public static int ExecuteNonQuery(CommandType cmdType, string cmdText, params OleDbParameter[] cmdParms)
        {
            OleDbCommand cmd = new OleDbCommand();

            using (OleDbConnection conn = new OleDbConnection(ConfigReader.ActiveConnectionString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms, AccessConnectionActionType.Open);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public static int ExecuteNonQuery(OleDbConnection conn, CommandType cmdType, string cmdText, params OleDbParameter[] cmdParms)
        {
            OleDbCommand cmd = new OleDbCommand();
            PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms, AccessConnectionActionType.AutoDetection);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        public static int ExecuteNonQuery(OleDbTransaction trans, CommandType cmdType, string cmdText, params OleDbParameter[] cmdParms)
        {
            OleDbCommand cmd = new OleDbCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, cmdParms, AccessConnectionActionType.None);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        #endregion

        #region ExecuteReader

        public static OleDbDataReader ExecuteReader(CommandType cmdType, string cmdText, params OleDbParameter[] cmdParms)
        {
            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection conn = new OleDbConnection( );
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms, AccessConnectionActionType.Open);
                OleDbDataReader rdr = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }
  
        public static OleDbDataReader ExecuteReader(OleDbConnection conn, CommandType cmdType, string cmdText, params OleDbParameter[] cmdParms)
        {
            OleDbCommand cmd = new OleDbCommand();
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms, AccessConnectionActionType.AutoDetection);
                OleDbDataReader rdr = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        #endregion

        #region ExecuteScalar

        public static object ExecuteScalar(CommandType cmdType, string cmdText, params OleDbParameter[] cmdParms)
        {
            OleDbCommand cmd = new OleDbCommand();
            using (OleDbConnection conn = new OleDbConnection(ConfigReader.ActiveConnectionString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms, AccessConnectionActionType.Open);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public static object ExecuteScalar(OleDbConnection conn, CommandType cmdType, string cmdText, params OleDbParameter[] cmdParms)
        {
            OleDbCommand cmd = new OleDbCommand();
            PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms, AccessConnectionActionType.AutoDetection);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }

        #endregion

        #region ExecuteDataSet

        public static DataSet ExecuteDataset( CommandType cmdType, string cmdText, params OleDbParameter[] cmdParms)
        {
            OleDbCommand cmd = new OleDbCommand();
            using (OleDbConnection conn = new OleDbConnection(ConfigReader.ActiveConnectionString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms, AccessConnectionActionType.Open);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                cmd.Parameters.Clear();
                return ds;
            }
        }


        public static DataSet ExecuteDataset(OleDbConnection conn, CommandType cmdType, string cmdText, params OleDbParameter[] cmdParms)
        {
            OleDbCommand cmd = new OleDbCommand();
            PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms, AccessConnectionActionType.AutoDetection);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.Parameters.Clear();
            return ds;
        }

        #endregion

        #region PrepareCommand

        public OleDbCommand GetOleDbQueryCommand(string query)
        {
            return PrepareCommand(CommandType.Text, query);
        }

        public OleDbCommand GetOleDbQueryCommand(string query, OleDbTransaction trans)
        {
            return PrepareCommand(CommandType.Text, query, trans);
        }

        public static void CacheParameters(string cacheKey, params OleDbParameter[] cmdParms)
        {
            parmCache[cacheKey] = cmdParms;
        }

        public static OleDbParameter[] GetCachedParameters(string cacheKey)
        {
            OleDbParameter[] cachedParms = (OleDbParameter[])parmCache[cacheKey];

            if (cachedParms == null)
                return null;

            OleDbParameter[] clonedParms = new OleDbParameter[cachedParms.Length];
            for (int i = 0, j = cachedParms.Length; i < j; i++)
                clonedParms[i] = (OleDbParameter)((ICloneable)cachedParms[i]).Clone();

            return clonedParms;
        }

        private OleDbCommand PrepareCommand(CommandType commandType, string commandText)
        {
            OleDbCommand command = null;
            if (connection == null)
            {
                connection = new OleDbConnection(ConfigReader.ActiveConnectionString);
            }
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            command = new OleDbCommand(commandText, connection);
            command.CommandType = commandType;
            connection.Close();
            connection = null;
            return command;
        }

        private OleDbCommand PrepareCommand(CommandType commandType, string commandText, OleDbTransaction trans)
        {
            OleDbCommand command = null;
            command = new OleDbCommand(commandText, connection,trans );
            command.CommandType = commandType;
            return command;
        }


        private static void PrepareCommand(OleDbCommand cmd, OleDbConnection conn, OleDbTransaction trans, CommandType cmdType, string cmdText, OleDbParameter[] cmdParms, AccessConnectionActionType connActionType)
        {
            if (connActionType == AccessConnectionActionType.Open)
            {
                conn.Open();
            }
            else
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
            }

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (OleDbParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

        #endregion

        #region Access Specific

        public static DataTable ExecutePager(int pageIndex, int pageSize, string fileds, string table, string where, string order, out int pageCount, out int recordCount, string id)
        {
            if (pageIndex < 1) pageIndex = 1;
            if (pageSize < 1) pageSize = 10;
            if (string.IsNullOrEmpty(fileds)) fileds = "*";
            if (string.IsNullOrEmpty(order)) order = "ID desc";
            using (OleDbConnection conn = new OleDbConnection(ConfigReader.ActiveConnectionString))
            {
                string myVw = string.Format(" {0} ", table);
                string sqlText = string.Format(" select count(0) as recordCount from {0} {1}", myVw, where);
                OleDbCommand cmdCount = new OleDbCommand(sqlText, conn);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                recordCount = Convert.ToInt32(cmdCount.ExecuteScalar());

                if ((recordCount % pageSize) > 0)
                    pageCount = recordCount / pageSize + 1;
                else
                    pageCount = recordCount / pageSize;
                OleDbCommand cmdRecord;
                if (pageIndex == 1)
                {
                    cmdRecord = new OleDbCommand(string.Format("select top {0} {1} from {2} {3} order by {4} ", pageSize, fileds, myVw, where, order), conn);
                }
                else if (pageIndex > pageCount)
                {
                    cmdRecord = new OleDbCommand(string.Format("select top {0} {1} from {2} {3} order by {4} ", pageSize, fileds, myVw, "where 1=2", order), conn);
                }
                else
                {
                    int pageLowerBound = pageSize * pageIndex;
                    int pageUpperBound = pageLowerBound - pageSize;
                    string recordIDs = RecordID(string.Format("select top {0} {1} from {2} {3} order by {4} ", pageLowerBound, id, myVw, where, order), pageUpperBound, conn);
                    cmdRecord = new OleDbCommand(string.Format("select {0} from {1} where {4} in ({2}) order by {3} ", fileds, myVw, recordIDs, order, id), conn);

                }
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmdRecord);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                return dt;
            }
        }

        private static string RecordID(string query, int passCount, OleDbConnection conn)
        {
            OleDbCommand cmd = new OleDbCommand(query, conn);
            string result = string.Empty;
            using (IDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    if (passCount < 1)
                    {
                        result += "," + dr.GetInt32(0);
                    }
                    passCount--;
                }
            }
            return result.Substring(1);
        }


        #endregion

        #region LoadDataTable

        public DataTable LoadDataTable(string cmdText)
        {
            OleDbCommand command = PrepareCommand(CommandType.Text, cmdText);
            return LoadDataTable(command, "");
        }

        public DataTable LoadDataTable(OleDbCommand command, string tableName)
        {
            if (tableName.Equals(""))
            {
                tableName = "table1";
            }
            using (OleDbDataAdapter da = new OleDbDataAdapter(command))
            {
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection = new OleDbConnection(ConfigReader.ActiveConnectionString);
                    command.Connection.Open();
                }
                DataTable dt = new DataTable(tableName);
                da.Fill(dt);
                command.Connection.Close();
                command.Connection = null;
                return dt;
            }
        }

        #endregion

        #region Transaction Specific

        private OleDbTransaction PrepareTransaction(IsolationLevel isolationLevel)
        {
            if (connection == null)
            {
                connection = new OleDbConnection(ConfigReader.ActiveConnectionString);
            }
            if (connection.State == ConnectionState.Closed || connection.State == ConnectionState.Broken)
            {
                connection.Open();
            }
            return connection.BeginTransaction(isolationLevel);
        }

        public OleDbTransaction BeginTransaction()
        {
            return PrepareTransaction(IsolationLevel.ReadCommitted);
        }

        public OleDbTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            return PrepareTransaction(isolationLevel);
        }

        public void Commit(OleDbTransaction transaction)
        {
            if (transaction != null)
                transaction.Commit();
        }

        public void RollBack(OleDbTransaction transaction)
        {
            if (transaction != null)
                transaction.Rollback();
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
