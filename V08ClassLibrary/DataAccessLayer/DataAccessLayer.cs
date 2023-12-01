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
using System.Collections;
using System.Diagnostics.Eventing.Reader;

namespace V08ClassLibrary.DatabaseUtil
{
    public class DataAccessLayer : IDataAcessLayer
    {
        private readonly string _connString;
        private SqlConnection _conn;

        public DataAccessLayer()
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
            catch (Exception error)
            {
                // TO DO : create a logger
                throw;
            }
        }
        public void Disconnect()
        {
            if (_conn != null && _conn.State != ConnectionState.Open)
            {
                _conn.Close();
            }
        }

        public List<T> ExecuteQuery<T>(string query)
        {
            List<T> objList = new List<T>();
            Connect();
            
                SqlCommand cmd = new SqlCommand(query, _conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    T item = MapObject<T>(reader);
                    objList.Add(item);
                }
                reader.Close();
            
            return objList;
        }

        public List<T> ExecuteQuery<T>(string query, List<SqlParameter> parameters)
        {
            List<T> objList = new List<T>();
            Connect();
            using (SqlCommand sqlCommand = new SqlCommand(query, _conn))
            {
                sqlCommand.Parameters.AddRange(parameters.ToArray());
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    T item = MapObject<T>(reader);
                    objList.Add(item);
                }
                reader.Close();
            }
            Disconnect();
            return objList;
        }

        public T MapObject<T>(IDataReader reader)
        {
            Type type = typeof(T);
            T obj = Activator.CreateInstance<T>();
            string propertyName;
            PropertyInfo[] properties;

            for (int i = 0; i < reader.FieldCount; i++)
            {
                propertyName = reader.GetName(i).ToString();
                var value = reader[i];
                
                properties = type.GetProperties();
                foreach(PropertyInfo property in properties)
                {
                    if (property.Name.ToLower() == propertyName.ToLower())
                    {
                        if(property.PropertyType == typeof(string))
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
            return (obj == null || obj == DBNull.Value) ?   default(T) : (T)obj;
        }
    }
}
