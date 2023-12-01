using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V08ClassLibrary.DatabaseUtil
{
    public interface IDataAcessLayer
    {
        void Connect();
        void Disconnect();
        List<T> ExecuteQuery<T>(string query, List<SqlParameter> parameters);
        List<T> ExecuteQuery<T>(string query);
        T MapObject<T>(IDataReader reader);
    }
}
