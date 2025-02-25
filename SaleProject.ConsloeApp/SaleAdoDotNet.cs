using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleProject.ConsloeApp
{
    public class SaleAdoDotNet
    {
        string _connectionString = "Data Source=WINDOWS-1ISKG05\\SQLEXPRESS;Initial Catalog=F9DB;Trusted_Connection=True;";
        public void Read()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string query = "Select * from Tbl_Sale";
            SqlCommand cmd=new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt=new DataTable();
            adapter.Fill(dt);   
            connection.Close();
            foreach (DataRow dr in dt.Rows )
            {
                Console.WriteLine(dr["SaleID"]);
                Console.WriteLine(dr["Item"]);
                Console.WriteLine(dr["CustomerID"]);
                Console.WriteLine(dr["Price"]);
                Console.WriteLine(dr["Qty"]);
                Console.WriteLine(dr["TotalPrice"]);
            }
        }
        public void Edit()
        {
            Console.WriteLine("Enter id");
            int id=Int32.Parse(Console.ReadLine());
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string query = "Select * from Tbl_Sale where CustomerID=@CustomerID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@CustomerID", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();
            if(dt.Rows.Count == 0)
            {
                Console.WriteLine("No Data Found.");
                return;
            }
            var dr = dt.Rows[0];
                Console.WriteLine(dr["SaleID"]);
                Console.WriteLine(dr["Item"]);
                Console.WriteLine(dr["CustomerID"]);
                Console.WriteLine(dr["Price"]);
                Console.WriteLine(dr["Qty"]);
                Console.WriteLine(dr["TotalPrice"]);
            
        }
        public void Create()
        {
            Console.WriteLine("Enter Item Name.");
            string item=Console.ReadLine();
            Console.WriteLine("Enter Customer ID.");
            int Cid = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter Price.");
            decimal price =Convert.ToDecimal( Console.ReadLine());
            Console.WriteLine("Enter Quantity.");
            int qty =Int32.Parse( Console.ReadLine());
            decimal totalprice=price * qty;
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string query = $@"INSERT INTO [dbo].[Tbl_Sale]
           ([Item]
           ,[CustomerID]
           ,[Price]
           ,[Qty]
           ,[TotalPrice])
     VALUES
           (@Item
           ,@CustomerID
           ,@Price
           ,@Qty
           ,@TotalPrice)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Item", item);
            cmd.Parameters.AddWithValue("@CustomerID",Cid );
            cmd.Parameters.AddWithValue("@Price",price );
            cmd.Parameters.AddWithValue("@Qty",qty );
            cmd.Parameters.AddWithValue("@TotalPrice",totalprice );
           var result=cmd.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine(result==1?"Your task is succeed.":"Your task is failed.");

        }
    }
}
