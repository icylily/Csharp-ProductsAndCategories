using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsAndCategories.Models;

using Microsoft.EntityFrameworkCore;

namespace ProductsAndCategories.Controllers
{
    public class HomeController : Controller
    {
        private ProAndCatContext dbContext;
        public HomeController(ProAndCatContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return Redirect("/products");
        }

        [HttpGet("/products")]
        public IActionResult Products()
        {
            NewProductForm newProduct = new NewProductForm();
            newProduct.CurrentProducts = dbContext.Products.ToList();
            return View(newProduct);
        }
        [HttpGet("/categories")]
        public IActionResult Categories()
        {
            NewCategoryForm newCategory = new NewCategoryForm();
            newCategory.CurrentCatogories = dbContext.Categories.ToList();
            return View(newCategory);
        }

        [HttpGet("/products/{productId}")]
        public IActionResult ShowProduct(int productId)
        {
            Product ThisProduct = dbContext.Products
                .Include(a=>a.Associations)
                .ThenInclude( thisassociation=>thisassociation.Category)
                .FirstOrDefault(product => product.ProductId == productId);
            
            List<Category> BelonedCatogries = ThisProduct.Associations
                .Select( a => a.Category).ToList();
            List<Category> ListCatogries = dbContext.Categories
                .Where(cate => !cate.Associations.Any(c => c.ProductId == productId))
                .ToList();

            newAssociationFromProduct updateProduct = new newAssociationFromProduct();
            updateProduct.ProductId = productId;
            updateProduct.ThisProduct = ThisProduct;
            updateProduct.ListCatogries = ListCatogries;
            updateProduct.BelonedCatogries = BelonedCatogries;
            Console.WriteLine("updateProduct.ProductId",updateProduct.ProductId);
            // Console.WriteLine()
            return View(updateProduct);
        }

        [HttpGet("/categories/{categoryId}")]
        public IActionResult ShowCategory(int categoryId)
        {
            Category ThisCategory = dbContext.Categories
                .Include(a => a.Associations)
                .ThenInclude(thisassociation => thisassociation.Product)
                .FirstOrDefault(category => category.CategorytId == categoryId);


            List<Product> OwnedProducts = ThisCategory.Associations
                .Select(a => a.Product).ToList();
            List<Product> ListProducts = dbContext.Products
                .Where(pro => !pro.Associations.Any(c => c.CategorytId == categoryId))
                .ToList();

            newAssociationFromCategory updateCategory = new newAssociationFromCategory();
            updateCategory.CategorytId = categoryId;
            updateCategory.ThisCategory = ThisCategory;
            updateCategory.ListProducts = ListProducts;
            updateCategory.OwnedProducts = OwnedProducts;
            // Console.WriteLine("updateProduct.ProductId", updateCategory.ProductId);
            // Console.WriteLine()
            return View(updateCategory);
        }

        [HttpPost("NewProduct")]
        public IActionResult NewProduct(NewProductForm returnProduct)
        {
            if ((!ModelState.IsValid) || ((ModelState.IsValid) &&(((dbContext.Products.Any(u => u.Name == returnProduct.Name))||(returnProduct.Price <= 0)))))
            {
                if (returnProduct.Price <= 0)
                {
                    ModelState.AddModelError("Price", "You can not set product price  less or equal 0");
                }
                if(dbContext.Products.Any(u => u.Name == returnProduct.Name))
                {
                    ModelState.AddModelError("Name", "Product already existed!");
                }
                NewProductForm newProduct = new NewProductForm();
                newProduct.CurrentProducts = dbContext.Products.ToList();
                return View("Products",newProduct);
            }

            else
            {
                Product newproduct = new Product();
                newproduct.Name = returnProduct.Name;
                newproduct.Price = returnProduct.Price;
                newproduct.Description = returnProduct.Description;
                dbContext.Products.Add(newproduct);
                dbContext.SaveChanges();
                return Redirect("/products");
                
            }
        }

        [HttpPost("NewCategory")]
        public IActionResult NewCategory(NewCategoryForm returnCategory)
        {
            if ((!ModelState.IsValid)||((ModelState.IsValid)&&(dbContext.Categories.Any(u => u.Name == returnCategory.Name))))
            {
                if(ModelState.IsValid)
                {
                    ModelState.AddModelError("Name", "Category already existed!"); 
                }
                NewCategoryForm newCategory = new NewCategoryForm();
                newCategory.CurrentCatogories = dbContext.Categories.ToList();
                return View("Categories", newCategory);
            }

            else
            {
                Category newcategory = new Category();
                newcategory.Name = returnCategory.Name;
                dbContext.Categories.Add(newcategory);
                dbContext.SaveChanges();
                return Redirect("/categories");
                
            }
        }

        [HttpPost("AddCategory")]
        public IActionResult AddCategory(newAssociationFromProduct returnAsso)
        {
            if (!ModelState.IsValid)
            {
                Product ThisProduct = dbContext.Products
                .Include(a => a.Associations)
                .ThenInclude(thisassociation => thisassociation.Category)
                .FirstOrDefault(product => product.ProductId == returnAsso.ProductId);

                List<Category> BelonedCatogries = ThisProduct.Associations
                    .Select(a => a.Category).ToList();
                List<Category> ListCatogries = dbContext.Categories
                    .Where(cate => !cate.Associations.Any(c => c.ProductId == returnAsso.ProductId))
                    .ToList();

                newAssociationFromProduct updateProduct = new newAssociationFromProduct();
                updateProduct.ProductId = returnAsso.ProductId;
                updateProduct.ThisProduct = ThisProduct;
                updateProduct.ListCatogries = ListCatogries;
                updateProduct.BelonedCatogries = BelonedCatogries;
                return View("ShowProduct", updateProduct);
            }

            else
            {
                Association newAsso = new Association();
                newAsso.CategorytId = returnAsso.CategorytId;
                newAsso.ProductId = returnAsso.ProductId;

                dbContext.Associations.Add(newAsso);
                dbContext.SaveChanges();
                return Redirect("/products/"+returnAsso.ProductId);
            }
        }

        [HttpPost("AddProduct")]
        public IActionResult AddProduct(newAssociationFromCategory returnAsso)
        {
            if (!ModelState.IsValid)
            {
                Category ThisCategory = dbContext.Categories
                 .Include(a => a.Associations)
                 .ThenInclude(thisassociation => thisassociation.Product)
                 .FirstOrDefault(category => category.CategorytId == returnAsso.CategorytId);


                List<Product> OwnedProducts = ThisCategory.Associations
                    .Select(a => a.Product).ToList();
                List<Product> ListProducts = dbContext.Products
                    .Where(pro => !pro.Associations.Any(c => c.CategorytId == returnAsso.CategorytId))
                    .ToList();

                newAssociationFromCategory updateCategory = new newAssociationFromCategory();
                updateCategory.CategorytId = returnAsso.CategorytId;
                updateCategory.ThisCategory = ThisCategory;
                updateCategory.ListProducts = ListProducts;
                updateCategory.OwnedProducts = OwnedProducts;
                // Console.WriteLine("updateProduct.ProductId", updateCategory.ProductId);
                // Console.WriteLine()
                return View("ShowCategory", updateCategory);
            }

            else
            {
                Association newAssosi= new Association();
                newAssosi.CategorytId = returnAsso.CategorytId;
                newAssosi.ProductId = returnAsso.ProductId;

                dbContext.Associations.Add(newAssosi);
                dbContext.SaveChanges();
                return Redirect("/categories/" + returnAsso.CategorytId);
            }
        }

    }
}
