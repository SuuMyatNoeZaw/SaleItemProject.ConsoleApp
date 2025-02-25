using System.Data;
using System.Data.SqlClient;

namespace ShareExample
{
    public class SaleAdoService
    {
        string _connectionString;
        public SaleAdoService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataTable Query(string query,params Parameters[]parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query,connection);
            if(parameters is not null)
            {
                foreach(Parameters param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.Name, param.Value);
                }
            }
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt=new DataTable();
            adapter.Fill(dt);
            connection.Close();
            return dt;
        }
        public int Execute(string query, params Parameters[] parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            if (parameters is not null)
            {
                foreach (Parameters param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.Name, param.Value);
                }
            }
            int result=cmd.ExecuteNonQuery();
            connection.Close();
            return result;
        }
    }
    public class Parameters
    {
        public string Name;
        public object Value;
        public Parameters(string name,object value) 
        {
            Name = name;
            Value = value;
        }
    }

}