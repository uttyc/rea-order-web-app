using CustomerService.Data;
using CustomerService.Data.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerDbContext _db;

        public CustomersController(CustomerDbContext dbContext)
        {
            _db = dbContext;
        }

        [HttpPost]
        public Guid Create(Customer customer)
        {
            if(customer == null)
            {
                return Guid.Empty;
            }
            customer.Id = Guid.NewGuid();
            customer.CreatedAt = DateTime.Now;

            _db.Add(customer);
            _db.SaveChanges();
            return customer.Id;
        }

        [HttpPut]
        public bool Update(Customer customer)
        {
            var customerInDb = _db.Customers.FirstOrDefault(c => c.Id == customer.Id);
            if(customerInDb == null)
            {
                return false;
            }
            customerInDb.Email = customer.Email;
            customerInDb.Name = customer.Name;
            customerInDb.UpdatedAt = DateTime.Now;
            customerInDb.AddressId = customer.AddressId;
            _db.SaveChanges();
            return true;
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            var customerInDb = _db.Customers.FirstOrDefault(c => c.Id == id);
            if (customerInDb == null)
                return false;
            _db.Customers.Remove(customerInDb);
            _db.SaveChanges();
            return true;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public List<Customer> Get()
        {
            var customers = _db.Customers.ToList();
            return customers;
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public Customer? Get(Guid id)
        {
            var customerInDb = _db.Customers.FirstOrDefault(c => c.Id == id);
            return customerInDb;
        }
        [HttpGet("validate/{id}")]
        public bool Validate(Guid id)
        {
            var customerInDb = _db.Customers.FirstOrDefault(c => c.Id==id);
            if (customerInDb == null)
                return false;
            return true;
        }
        // POST api/<CustomersController>
        
        // PUT api/<CustomersController>/5
       

      
    }
}
