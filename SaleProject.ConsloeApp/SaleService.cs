using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareExample;

namespace SaleProject.ConsloeApp
{
    public class SaleService
    {
        private string ConnectionString = "Data Source=WINDOWS-1ISKG05\\SQLEXPRESS;Initial Catalog=F9DB;Trusted_Connection=True;";
        private readonly SaleAdoService adoShare;
        public SaleService()
        {
            adoShare = new SaleAdoService(ConnectionString);
           
        }
        public void Read()
        {
            string query = "Select * from Tbl_Sale";
            DataTable dt=adoShare.Query(query);
            foreach(DataRow dr in dt.Rows)
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
            Console.WriteLine("Enter SaleID");
            int id=Int32.Parse(Console.ReadLine());
            string query = $"Select * from Tbl_Sale Where SaleID=@SaleId";
            DataTable dt = adoShare.Query(query,new Parameters("@SaleId",id));
            if (dt.Rows.Count > 0)
            {
                var dr = dt.Rows[0];
                Console.WriteLine(dr["SaleID"]);
                Console.WriteLine(dr["Item"]);
                Console.WriteLine(dr["CustomerID"]);
                Console.WriteLine(dr["Price"]);
                Console.WriteLine(dr["Qty"]);
                Console.WriteLine(dr["TotalPrice"]);
            }
            else { Console.WriteLine("Something Wrong."); }

          
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
            int result=adoShare.Execute(query,new Parameters("@Item",item),
                new Parameters("@CustomerID", Cid),
                new Parameters("@Price", price),
                new Parameters("@Qty", qty),
                new Parameters("@TotalPrice", totalprice)
                );

            Console.WriteLine(result == 1 ? "Your task is succeed." : "Your task is failed.");

        }
    }
}
