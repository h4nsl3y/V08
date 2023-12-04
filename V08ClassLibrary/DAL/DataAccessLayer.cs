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
using V08ClassLibrary.Log;

namespace V08ClassLibrary.DAL
{
    public class DataAccessLayer : IDataAcessLayer
    {
        private readonly string _connString;
        private SqlConnection _connection;
        private ILogger _logger;
        public DataAccessLayer(ILogger logger)
        {
            _logger = logger;
            _connString = ConfigurationManager.AppSettings["ConnectionString"];
        }
        public void Connect()
        {
            if (_connection == null || _connection.State != ConnectionState.Open)
            {
                _connection = new SqlConnection(_connString);
                _connection.Open();
            }
        }
        public void Disconnect()
        {
            if (_connection != null && _connection.State != ConnectionState.Open)
            {
                _connection.Close();
            }
        }
        public List<T> ExecuteQuery<T>(string query)
        {
            List<T> objectList = new List<T>();
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(query, _connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    T item = MapObject<T>(reader);
                    objectList.Add(item);
                }
                reader.Close();
                Disconnect();
            }
            catch (Exception error)
            {
                Disconnect();
                _logger.Log(error);
                throw;
            }

            return objectList;
        }
        public List<T> ExecuteQuery<T>(string query, List<SqlParameter> parameters)
        {
            List<T> objectList = new List<T>();
            try
            {
                Connect();
                using (SqlCommand sqlCommand = new SqlCommand(query, _connection))
                {
                    sqlCommand.Parameters.AddRange(parameters.ToArray());
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        T item = MapObject<T>(reader);
                        objectList.Add(item);
                    }
                    reader.Close();
            }
            Disconnect();
            }
            catch (Exception error)
            {
                Disconnect();
                _logger.Log(error);
                throw;
            }


            return objectList;
        }
        private T MapObject<T>(IDataReader reader)
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
            return (obj == null || obj == DBNull.Value) ? default(T) : (T)obj;
        }
    }
}
