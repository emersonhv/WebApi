using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace ApiWeb.Repositories
{
    public static class DataBases
    {
        private const string ApiCrudDBKey = "ApiCRUDDb";

        public static Database GetConnection(string key)
        {
            return new Database { Key = key };
        }
        public static Database CrudDb
        {
            get { return GetConnection(ApiCrudDBKey); }
        }
    }


    public class Database : IDisposable
    {
        public void Dispose()
        {
            if (Connection != null)
                Connection.Dispose();
        }

        public string Key { get; set; }
        public string ConnectionString
        {
            get
            {
                var connectionString = ConfigurationManager.ConnectionStrings[this.Key];
                return connectionString == null ? string.Empty : connectionString.ConnectionString;
            }
        }
        public IDbConnection Connection { get; set; }
    }
}