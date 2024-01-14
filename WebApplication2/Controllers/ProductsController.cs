using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using WebApplication2.Models.EFModels;
using WebApplication2.Models.ViewModels;
using System.Data.Entity;
using WebApplication2.Models.Repositories;
using WebApplication2.Models.Services;
using WebApplication2.Models.Dtos;

namespace WebApplication2.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            List<ProductIndexVm> data = GetAll();
            return View(data);
        }

        private List<ProductIndexVm> GetAll()
        {
            var db = new AppDbContext();

            var products = db.Products.AsNoTracking() //只要抓資料沒有異動，不需追蹤
                .Include(p => p.Category) //不寫也會對，但跑起來效能會很差
                .OrderBy(p => p.Category.DisplayOrder)
                .Select(p => new ProductIndexVm {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    CategoryName = p.Category.Name
                })
                .ToList();

            return products;
        }

        #region Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductVm model)
        {
            // todo 欄位驗證
            if (!ModelState.IsValid) return View(model);
            try
            {
                CreateProduct(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            //新增紀錄
            CreateProduct(model);
            //轉向到index
            return RedirectToAction("Index");
        }

        private void CreateProduct(ProductVm model)
        {
            var repo = new ProductRepository();
            var service = new ProductService(repo);

            ProductDto dto = new ProductDto()
            {
                Name = model.Name,
                CategoryId = model.CategoryId,
                Description = model.Description,
                Price = model.Price,
                Status = model.Status,
                ProductImage = model.ProductImage,
                Stock = model.Stock
            };

            service.Create(dto);
        }
        #endregion

        #region Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            DeleteProduct(id);
            return RedirectToAction("Index");
        }
        
        private void DeleteProduct(int id)
        {
            var repo = new ProductRepository();
            var service = new ProductService(repo);
            service.Delete(id);
        }

        #endregion
       


        #region Edit
        public ActionResult Edit(int id)
        {
            ProductVm model = LoadProduct(id);
            return View(model);
        }

        //取得db的一筆紀錄
        private ProductVm LoadProduct(int id)
        {
            var model = new AppDbContext().Products.Find(id);
            return new ProductVm
            {
                Id = model.Id,
                Name = model.Name,
                CategoryId = model.CategoryId,
                Description = model.Description,
                Price = model.Price,
                Status = model.Status,
                ProductImage = model.ProductImage,
                Stock = model.Stock
            };
        }

        [HttpPost]
        public ActionResult Edit(ProductVm model)
        {
            if (!ModelState.IsValid) return View(model);
            try
            {
                UpdateProduct(model);
                return RedirectToAction("Index");
            }catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(model);
        }


        //更新一筆紀錄
        private void UpdateProduct(ProductVm model)
        {
            //直接叫用EF，或者叫用Service Object
            var repo = new ProductRepository();
            var service = new ProductService(repo);

            ProductDto dto = new ProductDto()
            {
                Name = model.Name,
                CategoryId = model.CategoryId,
                Description = model.Description,
                Price = model.Price,
                Status = model.Status,
                ProductImage = model.ProductImage,
                Stock = model.Stock
            };

            service.Update(dto);
        }


        

        #endregion
    }
}