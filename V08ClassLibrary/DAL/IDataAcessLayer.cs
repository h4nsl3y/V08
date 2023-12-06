using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V08DataAccessLayer.DAL
{
    public interface IDataAcessLayer
    {
        void Connect();
        void Disconnect();
        List<T> ExecuteQuery<T>(string query, List<SqlParameter> parameters = null);
        bool AffectedRows(string query, List<SqlParameter> parameters = null);
    }
}
