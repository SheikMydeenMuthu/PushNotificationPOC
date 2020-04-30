using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushNotificationPOC
{
    public class DatabaseContext : IDisposable
    {
        public DatabaseContext()
        {

        }
        private IDbConnection _connection;
        public IDbConnection Connection
        {
            get { return _connection ?? (_connection = CreateConnection()); }
        }

        private IDbConnection CreateConnection()
        {

            var connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());
            //LogIt.WriteErrorLog("Connection Initize: " + connection.State.ToString());
            return connection;

        }

        #region IDisposable Implementation
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {

                // free managed resources
                if (_connection != null)
                {
                    //LogIt.WriteErrorLog("Dispose :" + Connection.State.ToString());
                    _connection.Dispose();
                    _connection = null;
                }
            }
        }

        #endregion

    }
}
