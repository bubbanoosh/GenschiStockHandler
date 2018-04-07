using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;


namespace GenschiStockHandler.Repository
{
    public class BaseRepository : IDisposable
    {
        private readonly IConfiguration _config;
        protected MySqlConnection _connection;

        public BaseRepository(IConfiguration config)
        {
            _config = config;
        }

        public MySqlConnection GetOpenConnection()
        {
            MySqlConnection connection = new MySqlConnection(
                _config.GetConnectionString("DefaultConnection"));
            
            connection.Open();
            return connection;
        }

        public void Dispose()
        {
            //_connection.Close();
        }
    }
}