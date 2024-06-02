using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Dados.Context
{
    public interface IDataContext
    {
        Task<List<T>> ExecuteList<T>(string sql, DynamicParameters Parameters);
        Task<T> ExecuteQuery<T>(string sql, DynamicParameters Parameters);
        Task ExecuteSave<T>(string sql, T Parameters);
        Task<List<T>> ExecuteList<T>(string sql);
    }
}
