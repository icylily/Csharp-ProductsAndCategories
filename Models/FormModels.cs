using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsAndCategories.Models
{
    public class NewProductForm
    {
        public int ProductId{get;set;}
        [Required]
        [MinLength(2)]
        [Display(Name = "Product Name:")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Product Price:")]
        public Decimal Price { get; set; }
        [Display(Name = "Description:")]
        public string Description { get; set; }
        public List<Product> CurrentProducts{get;set;}
    }

    public class NewCategoryForm
    {
        public int CategoryId{get;set;}
        [Required]
        [MinLength(2)]
        [Display(Name = "Category Name:")]
        public string Name { get; set; }
        public List<Category> CurrentCatogories {get;set;}
        
    }

    public class newAssociationFromProduct
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Don't allow empty Product!")]
        public int ProductId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Don't allow empty Category!")]
        public int CategorytId { get; set; }
        public Product ThisProduct{get;set;}
        public List<Category> ListCatogries {get;set;}
        public List<Category> BelonedCatogries { get; set; }

    }

    public class newAssociationFromCategory
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Don't allow empty Product!")]
        public int ProductId { get; set; }
        [Required]
        [Range(1, int.MaxValue,ErrorMessage="Don't allow empty Category!")]
        public int CategorytId { get; set; }
        public Category ThisCategory { get; set; }
        public List<Product> ListProducts { get; set; }
        public List<Product> OwnedProducts { get; set; }

    }
}