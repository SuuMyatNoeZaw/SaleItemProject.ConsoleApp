using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaleDatabase.Models;

namespace Sale.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        AppDbContext _db=new AppDbContext();
        [HttpGet]
        public IActionResult Get()
        {
            var list=_db.TblSales.ToList();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult GetID(int id)
        {
            var item = _db.TblSales.FirstOrDefault(x=>x.SaleId==id);
            if (item is null)
            {
                return BadRequest("No Data Found.");
                
            }
            return Ok(item);
        }
        [HttpPost]
        public IActionResult Create(TblSale sale)
        {
           _db.TblSales.Add(sale); 
            int result=_db.SaveChanges();
            return Ok(result);
        }
        [HttpPut]
        public IActionResult Update(int id,TblSale sale)
        {
            var item = _db.TblSales.AsNoTracking().FirstOrDefault(x => x.SaleId == id);
            if (item is null)
            {
                return BadRequest("No Data Found.");

            }
            
            item.Item = sale.Item;
            item.Price = sale.Price;
            item.Qty = sale.Qty;
            item.TotalPrice = sale.TotalPrice;
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
            return Ok(item);
        }
        [HttpPatch]
        public IActionResult UpdatePatch(int id, TblSale sale)
        {
            var item = _db.TblSales.AsNoTracking().FirstOrDefault(x => x.SaleId == id);
            if (item is null)
            {
                return BadRequest("No Data Found.");

            }
            if(sale.Item is not null)
            {
              item.Item = sale.Item;
            }
            if (sale.Price != 0)
            {
                item.Price = sale.Price;
            }
            if(sale.Qty != 0)
            {
                item.Qty = sale.Qty;
                
            }
            if(sale.TotalPrice != 0)
            {
                item.TotalPrice = sale.TotalPrice;
            }
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
            return Ok(item);
        }

    }
}
