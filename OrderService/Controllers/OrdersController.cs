using Microsoft.AspNetCore.Mvc;
using OrderService.Data;
using OrderService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderDbContext _db;

        public OrdersController(OrderDbContext dbContext)
        {
            _db = dbContext;
        }
        [HttpPost]
        public Guid Post(Order order)
        {
            if (order == null)
            {
                return Guid.Empty;
            }
            order.Id = Guid.NewGuid();
            _db.Add(order);
            _db.SaveChanges();
            return order.Id;
        }

        [HttpPut]
        public bool Put(Order order)
        {
            var orderInDb = _db.Orders.FirstOrDefault(c => c.Id == order.Id);
            if (orderInDb == null)
            {
                return false;
            }
            orderInDb.UpdatedAt = DateTime.Now;
            orderInDb.AddressId = order.AddressId;
            orderInDb.ProductId = order.ProductId;
            orderInDb.Quantity = order.Quantity;
            orderInDb.Price = order.Price; 
            orderInDb.CustomerId = order.CustomerId;
            _db.SaveChanges();
            return true;
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            var orderInDb = _db.Orders.FirstOrDefault(c => c.Id == id);
            if (orderInDb == null)
                return false;
            _db.Orders.Remove(orderInDb);
            _db.SaveChanges();
            return true;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public List<Order> Get()
        {
            var customers = _db.Orders.ToList();
            return customers;
        }

        [HttpGet("bycustomer/{customerid}")]
        public List<Order> GetByCustomer(Guid customerid)
        {
            var orderInDb = _db.Orders.Where(c => c.CustomerId == customerid).ToList();
            return orderInDb;
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public Order? Get(Guid id)
        {
            var orderInDb = _db.Orders.FirstOrDefault(c => c.Id == id);
            return orderInDb;
        }
        [HttpPut("changestatus/{id}")]
        public bool ChangeStatus(Guid id, string status)
        {
            var orderInDb = _db.Orders.FirstOrDefault(c => c.Id == id);
            if (orderInDb == null)
                return false;
            orderInDb.Status = status;
            _db.SaveChanges();
            return true;
        }
    }
}
