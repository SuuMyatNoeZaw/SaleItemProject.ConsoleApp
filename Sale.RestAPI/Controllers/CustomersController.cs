using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaleDatabase.Models;

namespace Sale.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        AppDbContext _db = new AppDbContext();
        [HttpGet]
        public IActionResult Get()
        {
            var list = _db.TblCustomers.ToList();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult GetID(int id)
        {
            var item = _db.TblCustomers.FirstOrDefault(x => x.CustomerId == id);
            if (item is null)
            {
                return BadRequest("No Data Found.");

            }
            return Ok(item);
        }
        [HttpPost]
        public IActionResult Create(TblCustomer customer)
        {
            _db.TblCustomers.Add(customer);
            int result = _db.SaveChanges();
            return Ok(result);
        }
        [HttpPut]
        public IActionResult Update(int id, TblCustomer cus)
        {
            var item = _db.TblCustomers.AsNoTracking().FirstOrDefault(x => x.CustomerId == id);
            if (item is null)
            {
                return BadRequest("No Data Found.");

            }

            item.CustomerName = cus.CustomerName;
            item.SaleId = cus.SaleId;
            item.Address= cus.Address;
            item.Phone = cus.Phone;
            item.DeleteFlag= cus.DeleteFlag;
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
            return Ok(item);
        }
        [HttpPatch]
        public IActionResult UpdatePatch(int id, TblCustomer cus)
        {
            var item = _db.TblCustomers.AsNoTracking().FirstOrDefault(x => x.CustomerId == id);
            if (item is null)
            {
                return BadRequest("No Data Found.");

            }
            if (!string.IsNullOrEmpty(cus.CustomerName))
            {
                item.CustomerName =cus.CustomerName;
            }
            if (cus.SaleId != 0)
            {
                item.SaleId = cus.SaleId;
            }
            if (!string.IsNullOrEmpty(cus.Address))
            {
                item.Address = cus.Address;

            }
            if(!string.IsNullOrEmpty(cus.Phone))
            {
                item.Phone = cus.Phone;
            }
           item.DeleteFlag = cus.DeleteFlag;
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
            return Ok(item);
        }

    }
}

