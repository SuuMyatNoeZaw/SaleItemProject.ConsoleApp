using Dapper;
using SaleProject.ConsloeApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleProject.ConsloeApp
{
    public class DapperExample
    {
        string _connectionString = "Data Source=WINDOWS-1ISKG05\\SQLEXPRESS;Initial Catalog=F9DB;Trusted_Connection=True;";
        public void Read()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = "Select * from Tbl_Sale";
                var list=db.Query<SaleModel>(query).ToList();
                foreach (var item in list)
                {
                    Console.WriteLine(item.SaleId);
                    Console.WriteLine(item.Item);
                    Console.WriteLine(item.CustomerId);
                    Console.WriteLine(item.Price);
                    Console.WriteLine(item.Qty);
                    Console.WriteLine(item.TotalPrice);
                }
            }
        }
        public void Edit()
        {
            Console.WriteLine("Enter Sale ID");
            int id=Int32.Parse(Console.ReadLine());
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = $"Select * from Tbl_Sale where SaleID=@SaleId";
                var item = db.Query<SaleModel>(query,new SaleModel()
                {
                    SaleId=id
                }).FirstOrDefault();
                if(item is null)
                {
                    Console.WriteLine("No Data Found.");
                    return;
                }
                    Console.WriteLine(item.SaleId);
                    Console.WriteLine(item.Item);
                    Console.WriteLine(item.CustomerId);
                    Console.WriteLine(item.Price);
                    Console.WriteLine(item.Qty);
                    Console.WriteLine(item.TotalPrice);
                
            }
        }
        public void Create()
        {
            
            Console.WriteLine("Enter Item Name.");
            string item = Console.ReadLine();
            Console.WriteLine("Enter Customer ID.");
            int Cid = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter Price.");
            decimal price = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter Quantity.");
            int qty = Int32.Parse(Console.ReadLine());
            decimal totalprice = price * qty;
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
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
                int result = db.Execute(query, new SaleModel()
                {
                    Item = item,
                    CustomerId = Cid,
                    Price = price,
                    Qty = qty,
                    TotalPrice = totalprice
                }) ;

                Console.WriteLine(result==1?"Your task is succeed.":"Your task is failed.");
            }
        }
    }
}
