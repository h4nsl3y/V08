using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V08ClassLibrary.DatabaseUtil
{
    public interface IDbUtils
    {
        void Connect();
        void Disconnect();
        /*        DataTable GetData(string sql);
                DataTable GetData(string sql, List<SqlParameter> parameters);*/
        List<T> ExecuteQuery<T>(string query, List<SqlParameter> parameters);
        List<T> ExecuteQuery<T>(string query);
        T MapData<T>(IDataReader reader);
    }
}
