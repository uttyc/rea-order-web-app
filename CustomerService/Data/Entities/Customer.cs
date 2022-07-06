using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerService.Data.Entities
{
    public class Customer
    {

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public Guid? AddressId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
