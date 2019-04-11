using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsAndCategories.Models
{
    public class Product
    {
        [Key]
        public int  ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public List<Association> Associations {get;set;}

    }

    public class Category
    {
        [Key]
        public int CategorytId { get; set; }
        // MySQL VARCHAR and TEXT types can be represeted by a string
        [Required]
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public List<Association> Associations {get;set;}

    }

    public class Association
    {
        [Key]
        public int AssociationId { get; set; }
        // MySQL VARCHAR and TEXT types can be represeted by a string
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int CategorytId { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.Now;
        public DateTime UpdatedAt { get; set; }= DateTime.Now;

        public Product Product { get; set; }
        public Category Category { get; set; }

    }
}