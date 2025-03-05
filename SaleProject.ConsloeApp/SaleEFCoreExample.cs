using Microsoft.EntityFrameworkCore;
using SaleProject.ConsloeApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleProject.ConsloeApp
{
    public class SaleEFCoreExample
    {
        AppDBContext db=new AppDBContext();
        public void Read()
        {
            var list=db.Sales.ToList();
            foreach(var item in list)
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
            Console.WriteLine("Enter 1 for SaleID (or) 2 for Customer ID");
            int id=Int32.Parse(Console.ReadLine());
            if(id==1)
            {
                Console.WriteLine("Enter Sale ID");
                int sid = Int32.Parse(Console.ReadLine());
                var item = db.Sales.Where(x => x.SaleId == sid).FirstOrDefault();
                Console.WriteLine(item.SaleId);
                Console.WriteLine(item.Item);
                Console.WriteLine(item.CustomerId);
                Console.WriteLine(item.Price);
                Console.WriteLine(item.Qty);
                Console.WriteLine(item.TotalPrice);
            }
            else if(id==2)
            {
                Console.WriteLine("Enter Cusotmer ID");
                int cid = Int32.Parse(Console.ReadLine());
                var list = db.Sales.Where(x => x.CustomerId == cid).ToList();
                foreach(var item in list)
                {
                    Console.WriteLine(item.SaleId);
                    Console.WriteLine(item.Item);
                    Console.WriteLine(item.CustomerId);
                    Console.WriteLine(item.Price);
                    Console.WriteLine(item.Qty);
                    Console.WriteLine(item.TotalPrice);
                }
               
            }
            else { Console.WriteLine("Something wrong."); }
           

           
        }
        public void Create() 
        {
            Console.WriteLine("Enter Item Name.");
            string name=Console.ReadLine();
            Console.WriteLine("Enter CustomerID.");
            int cid=Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter Price");
            decimal price=Decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter Qty");
            int qty=Int32.Parse(Console.ReadLine());
            decimal totalprice = price * qty;
            SaleEFCoreModel model = new SaleEFCoreModel
            {
                Item = name,
                CustomerId = cid,
                Price = price,
                Qty = qty,
                TotalPrice = totalprice
            };
            db.Sales.Add(model);
            int result=db.SaveChanges();
            Console.WriteLine(result==1?"Your Task is Succeed.":"Your Task is Failed.");
        }
        public void Update()
        {
            Console.WriteLine("Enter Sale ID");
            int id=Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter Item Name.");
            string name = Console.ReadLine();
            Console.WriteLine("Enter CustomerID.");
            int cid = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter Price");
            decimal price = Decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter Qty");
            int qty = Int32.Parse(Console.ReadLine());
           
            var item=db.Sales.AsNoTracking().FirstOrDefault(x=>x.SaleId==id);
            if(item is null)
            {
                Console.WriteLine("No Data Found.");
            }

            if (!string.IsNullOrEmpty(name))
            {
                item.Item = name;
            }
            if (cid!=null && cid!=0)
            {
                item.CustomerId = cid;
            }
            if (price != null && price != 0)
            {
                item.Price = price;
            }
            if (qty != null && qty != 0)
            {
                item.Qty = qty;
                decimal totalprice = price * qty;
            }
            db.Entry(item).State=EntityState.Modified;
            int result = db.SaveChanges();
            Console.WriteLine(result == 1 ? "Your Task is Succeed." : "Your Task is Failed.");
        }
    }
}
