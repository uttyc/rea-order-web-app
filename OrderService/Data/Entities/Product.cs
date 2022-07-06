using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderService.Data.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string? ImageUrl { get; set; }
        public string? Name { get; set; }

    }
}
