using Microsoft.Extensions.Configuration;
using POC.Dados.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace POC.Dados.Context
{
    public class DataContext : IDataContext
    {
        private readonly IConfiguration _configuration;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DataContext()
        {

        }

        public async Task<List<T>> ExecuteList<T>(string sql, DynamicParameters Parameters)
        {
            using IDbConnection connection = Create();

            var dados = await connection.QueryAsync<T>(sql, Parameters, commandType: CommandType.StoredProcedure);

            return dados.ToList();
        }

        public async Task<T> ExecuteQuery<T>(string sql, DynamicParameters Parameters)
        {
            using IDbConnection connection = Create();

            var dados = await connection.QueryAsync<T>(sql, Parameters, commandType: CommandType.StoredProcedure);

            return dados.FirstOrDefault();
        }

        public async Task ExecuteSave<T>(string sql, T Parameters)
        {
            using IDbConnection connection = Create();

            await connection.ExecuteAsync(sql, Parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<T>> ExecuteList<T>(string sql)
        {
            using IDbConnection connection = Create();

            var dados = await connection.QueryAsync<T>(sql, null, commandType: CommandType.Text);

            return dados.ToList();
        }

        private SqlConnection Create()
        {
            return new SqlConnection(_configuration.GetConnectionString("ConexaoPrincipal"));
        }
    }
}
