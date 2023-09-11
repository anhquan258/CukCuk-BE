using System;
using Dapper;
using MySqlConnector;

namespace MISA.Infrastructure.Repository
{
	public class BaseRepository<MISAEntity>
    {
        protected readonly string ConnectionString = "Host=127.0.0.1; Port=3306; Database = MISA.NTAQ; User Id = root; Password = 1232456";

        protected MySqlConnection SqlConnection;

        public IEnumerable<MISAEntity> GetAll()
        {
            var className = typeof(MISAEntity).Name;
            using (SqlConnection = new MySqlConnection(ConnectionString))
            { 
                var entities = SqlConnection.Query<MISAEntity>($"SELECT * FROM {className}");
            
                return entities;
            }
        }
         public MISAEntity GetById(Guid entityId)
            {
                var className = typeof(MISAEntity).Name;
                using (SqlConnection = new MySqlConnection(ConnectionString))
                {
                   
                    var sqlCommand = $"SELECT * FROM {className} WHERE {className}Id = @{className}Id";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add($"@{className}Id", entityId);
         
                    var entity = SqlConnection.QueryFirstOrDefault<MISAEntity>(sql: sqlCommand, param: parameters);

                    return entity;
                }
            }

       public int Delete(Guid entityId)
        {
            var className = typeof(MISAEntity).Name;
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {
                 
                var sqlCommand = $"Delete FROM {className} WHERE {className}Id = @{className}Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add($"@{className}Id", entityId);
          
                var entity = SqlConnection.Execute(sql: sqlCommand, param: parameters);
                return entity;
            }
        }


    }
}

