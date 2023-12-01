using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Configuration;
using System.Reflection;

namespace V08ClassLibrary.DatabaseUtil
{
    public class DbUtils : IDbUtils
    {
        private readonly string _connString;
        private SqlConnection _conn;
        public List<Dictionary<string, string>> dict;

        public DbUtils()
        {
            _connString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public void Connect()
        {
            try
            {
                if (_conn == null || _conn.State != ConnectionState.Open)
                {
                    _conn = new SqlConnection(_connString);
                    _conn.Open();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to find the connection string " + ex.Message);
            }
        }
        public void Disconnect()
        {
            if (_conn != null && _conn.State != ConnectionState.Open)
            {
                _conn.Close();
            }
        }
/*        public DataTable GetData(string query)
        {
            DataTable dataTable = new DataTable();
            Connect();
            SqlDataAdapter adapter = new SqlDataAdapter(query,_conn);  
            adapter.Fill(dataTable);
            adapter.Dispose();
            return dataTable;
        }
        public DataTable GetData(string sql, List<SqlParameter> parameters)
        {
            DataTable dataTable = new DataTable();
            Connect();
            using (_conn)
            {
                SqlCommand cmd = new SqlCommand(sql,_conn);
                cmd.Parameters.AddRange(parameters.ToArray());
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);
                return dataTable;
            }
        }*/

        public List<T> ExecuteQuery<T>(string query)
        {
            List<T> objList = new List<T>();
            Connect();
            
                SqlCommand cmd = new SqlCommand(query, _conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    T item = MapData<T>(reader);
                    objList.Add(item);
                }
                reader.Close();
            
            return objList;
        }

        public List<T> ExecuteQuery<T>(string query, List<SqlParameter> parameters)
        {
            List<T> objList = new List<T>();
            Connect();
            using (_conn)
            {
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddRange(parameters.ToArray());
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    T item = MapData<T>(reader);
                    objList.Add(item);
                }
                reader.Close();
            }
            return objList;
        }

        public T MapData<T>(IDataReader reader)
        {
            Type type = typeof(T);
            T obj = Activator.CreateInstance<T>();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                string propertyName = reader.GetName(i).ToString();
                var value = reader[i];
                
                /*                PropertyInfo property = type.GetProperty(propertyName);
                                if (property != null && value != DBNull.Value)
                                {
                                    property.SetValue(obj, value, null);
                                }*/
                PropertyInfo[] properties = type.GetProperties();
                foreach(PropertyInfo property in properties)
                {
                    if (property.Name.ToLower() == propertyName.ToLower())
                    {
                        if (property.PropertyType == typeof(string))
                        {
                            property.SetValue(obj, ConvertFromDBVal<string>(value), null);
                        }
                        if (property.PropertyType == typeof(int))
                        {
                            property.SetValue(obj, ConvertFromDBVal<int>(value), null);
                        }
                    }
                }
            }
            return obj;
        }

        public T ConvertFromDBVal<T>(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return default(T); 
            }
            else
            {
                return (T)obj;
            }
        }

    }
}
