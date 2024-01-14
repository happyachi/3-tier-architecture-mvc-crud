using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication2.Models.Core;
using WebApplication2.Models.Dtos;
using WebApplication2.Models.Repositories;

namespace WebApplication2.Models.Services
{
    public class ProductService
    {
        private readonly ProductRepository _repo;
        public ProductService(ProductRepository repo)
        {
            _repo = repo;
        }
        public void Create (ProductDto dto)
        {
            //todo 進行必要的業務邏輯檢查

            //叫用 repository 存檔
            ProductEntity entity = new ProductEntity
            {
                Name = dto.Name,
                CategoryId = dto.CategoryId,
                Description = dto.Description,
                Price = dto.Price,
                Status = dto.Status,
                ProductImage = dto.ProductImage,
                Stock = dto.Stock
            };

            _repo.Create(entity);

        }



        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public void Update(ProductDto dto)
        {
            ProductEntity entity = new ProductEntity
            {
            Name = dto.Name,
            CategoryId = dto.CategoryId,
            Description = dto.Description,
            Price = dto.Price,
            Status = dto.Status,
            ProductImage = dto.ProductImage,
            Stock = dto.Stock
            };

            _repo.Update(entity);
        }
    }
}