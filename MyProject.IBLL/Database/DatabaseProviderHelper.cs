using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.IBLL.Database
{
    public abstract class DatabaseProviderHelper
    {
        protected DatabaseProviderHelper() { }
        public DbProviderFactory DbProviderFactory { get; private set; }
        public string ConnectionString { get; set; }
        public string DataProvider { get; set; }
        public DbConnection GetConnection()
        {
            DbConnection newConnection = null;
            try
            {
                try
                {
                    DbProviderFactory = DbProviderFactories.GetFactory(this.DataProvider);
                    newConnection = DbProviderFactory.CreateConnection();
                    newConnection.ConnectionString = this.ConnectionString;
                }
                catch
                {
                    throw;
                }
            }
            catch
            {
                if (newConnection != null)
                    newConnection.Close();
                throw;
            }
            return newConnection;
        }
        public DbCommand CreateCommand()
        {
            return DbProviderFactory.CreateCommand();
        }
        public DbCommand CreateCommand(string sQueryString, DbConnection connection)
        {
            try
            {
                DbCommand command = this.CreateCommand();
                command.CommandText = sQueryString;
                command.Connection = connection;
                return command;
            }
            catch
            {
                throw;
            }
        }
        public DbDataAdapter CreateDataAdapter()
        {
            return DbProviderFactory.CreateDataAdapter();
        }
        public DbDataAdapter CreateDataAdapter(string query, DbConnection connection)
        {
            try
            {
                DbCommand command = this.CreateCommand();
                command.CommandText = query;
                command.Connection = connection;

                DbDataAdapter adapter = this.CreateDataAdapter();
                adapter.SelectCommand = command;
                return adapter;
            }
            catch
            {
                throw;
            }
        }
        private DbCommandBuilder CreateCommandBuilder()
        {
            return DbProviderFactory.CreateCommandBuilder();
        }
        public DbCommandBuilder CreateCommandBuilder(DbDataAdapter dbDataAdapter)
        {
            DbCommandBuilder dbCommandBuilder = this.CreateCommandBuilder();
            dbCommandBuilder.DataAdapter = dbDataAdapter;
            return dbCommandBuilder;
        }
    }
}
