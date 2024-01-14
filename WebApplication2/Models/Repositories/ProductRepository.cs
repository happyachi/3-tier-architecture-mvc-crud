using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models.Core;
using WebApplication2.Models.EFModels;

namespace WebApplication2.Models.Repositories
{
    /// <summary>
    /// 比較理想的寫法是他必須實作 IProductRepository
    /// </summary>
    public class ProductRepository 
    {
        public void Create(ProductEntity model)
        { //在此，採用EF，ADO.NET or Dapper 將model各屬性職存放到db
            var db = new AppDbContext();
            Product entity = new Product
            {
                Name = model.Name,
                CategoryId = model.CategoryId,
                Description = model.Description,
                Price = model.Price,
                Status = model.Status,
                ProductImage = model.ProductImage,
                Stock = model.Stock
            };

            db.Products.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var db = new AppDbContext();
            var product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
        }

        public void Update(ProductEntity entity)
        {
            var db = new AppDbContext();
            var product = db.Products.Find(entity.Id);

            product.Name = entity.Name;
            product.CategoryId = entity.CategoryId;
            product.Description = entity.Description;
            product.Price = entity.Price;
            product.Status = entity.Status;
            product.ProductImage = entity.ProductImage;
            product.Stock = entity.Stock;
          
            db.SaveChanges();
        }
    }
}