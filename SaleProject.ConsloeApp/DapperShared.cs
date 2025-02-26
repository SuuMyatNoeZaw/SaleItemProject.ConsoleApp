using SaleProject.ConsloeApp.Model;
using ShareExample;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace SaleProject.ConsloeApp
{
    internal class DapperShared
    {
        public readonly string ConnectionString= "Data Source=WINDOWS-1ISKG05\\SQLEXPRESS;Initial Catalog=F9DB;Trusted_Connection=True;";
        public readonly DapperService service;
       public DapperShared()
        {
            service=new DapperService(ConnectionString);
        }
        public void Read()
        {
            string query = "Select * from Tbl_Sale";
            var list = service.Query<SaleModel>(query);
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
        public void Edit()
        {
            Console.WriteLine("Enter Sale ID");
            int id = Int32.Parse(Console.ReadLine());
           
                string query = $"Select * from Tbl_Sale where SaleID=@SaleId";
                var item = service.QueryFOD<SaleModel>(query, new SaleModel()
                {
                    SaleId = id
                });
                if (item is null)
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
                int result = service.Execute(query, new SaleModel()
                {
                    Item = item,
                    CustomerId = Cid,
                    Price = price,
                    Qty = qty,
                    TotalPrice = totalprice
                });

                Console.WriteLine(result == 1 ? "Your task is succeed." : "Your task is failed.");
            
        }
    }
}
