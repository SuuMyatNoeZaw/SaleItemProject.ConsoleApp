using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareExample
{
    public class DapperService
    {
      public  string _ConnectionString;
      public  DapperService(string connectionString) 
        { 
            _ConnectionString = connectionString;
        }

        public List<T> Query<T>(string query, object param=null)
        {
            using IDbConnection db = new SqlConnection(_ConnectionString) ;
           var list=db.Query<T>(query, param).ToList();
            return list;
        }
        public T QueryFOD<T>(string query, object param = null)
        {
            using IDbConnection db = new SqlConnection(_ConnectionString);
            var list = db.QueryFirstOrDefault<T>(query, param);
            return list;
        }
        public int Execute(string query, object param = null)
        {
            using IDbConnection db = new SqlConnection(_ConnectionString);
            int result = db.Execute(query, param);
            return result;
        }
    }
}
