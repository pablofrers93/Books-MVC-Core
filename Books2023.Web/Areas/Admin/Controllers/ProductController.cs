﻿using Books2023.DataLayer.Repository.Interfaces;
using Books2023.Models.Models;
using Books2023.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Books2023.Web.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult UpSert(int? id)
        {
            var productVm = new ProductEditVm
            {
                Product = new Product(),
                CategoriesList = _unitOfWork.Categories
                     .GetAll()
                     .Select(c => new SelectListItem
                     {
                         Text = c.Name,
                         Value = c.Id.ToString()
                     }),
                CoverTypesList = _unitOfWork.CoverTypes
                     .GetAll()
                     .Select(c => new SelectListItem
                     {
                         Text = c.Name,
                         Value = c.Id.ToString()
                     }),
                
            };

            if (id == null || id == 0)
            {
                return View(productVm);

            }
            else
            {
                var wwwRootPath = _webHostEnvironment.WebRootPath;
                productVm.Product = _unitOfWork.Products.Get(p => p.Id == id.Value);
                if (productVm.Product.ImageUrl != null)
                {
                    string oldImage = Path.Combine(wwwRootPath, productVm.Product.ImageUrl.TrimStart('\\'));
                    if (!System.IO.File.Exists(oldImage))
                    {
                        var noExiste = @"\images\SinImagenDisponible.jpg";
                        productVm.Product.ImageUrl = noExiste;
                    }
                }
                return View(productVm);

            }
        }

        [HttpPost]
        public IActionResult UpSert(ProductEditVm productVm, IFormFile? file)
        {
            if (!ModelState.IsValid)
            {
                productVm.CategoriesList = _unitOfWork.Categories
                     .GetAll()
                     .Select(c => new SelectListItem
                     {
                         Text = c.Name,
                         Value = c.Id.ToString()
                     });
                productVm.CoverTypesList = _unitOfWork.CoverTypes
                     .GetAll()
                     .Select(c => new SelectListItem
                     {
                         Text = c.Name,
                         Value = c.Id.ToString()
                     });

                return View(productVm);
            }
            if (file != null)
            {
                var wwwRootPath = _webHostEnvironment.WebRootPath;
                var fileName = Guid.NewGuid().ToString();
                var extension = Path.GetExtension(file.FileName);

                if(productVm.Product.ImageUrl != null)
                {
                    var oldImage = Path.Combine(wwwRootPath, productVm.Product.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImage))
                    {
                        System.IO.File.Delete(oldImage);
                    }
                }

                var uploadFolder = Path.Combine(wwwRootPath, @"images\products\");
                using (var fileStream = new FileStream(Path.Combine(
                    uploadFolder,fileName+extension), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                productVm.Product.ImageUrl = @"\images\products\"+fileName+extension;
            }
            if (productVm.Product.Id == 0)
            {
                _unitOfWork.Products.Add(productVm.Product);
            }
            else
            {
                _unitOfWork.Products.Update(productVm.Product);
            }
            _unitOfWork.Save();
            return RedirectToAction("Index");

        }


        #region API CALL 
        [HttpGet]
        public IActionResult GetAll()
        {
            var productList = _unitOfWork.Products.GetAll();
            List<ProductListVm> productsListVm = new List<ProductListVm>();
            foreach (var product in productList)
            {
                var productVm = new ProductListVm
                {
                    Id = product.Id,
                    ISBN = product.ISBN,
                    Title = product.Title,
                    Author = product.Author,
                    ListPrice = product.ListPrice,
                };
                productsListVm.Add(productVm);
            };
            return Json(new {data=productsListVm});
        }

        [HttpDelete]
        public IActionResult Delete (int? id)
        {
            if (id == null || id == 0)
            {
                return Json(new {success=false, message="Not Found"});
            }
            var productDelete = _unitOfWork.Products.Get(p=> p.Id == id);
            if (productDelete == null) 
            {
                return Json(new { success = false, message = "Product Not Found" });
            }
            try
            {
                _unitOfWork.Products.Delete(productDelete);
                _unitOfWork.Save();
                var wwwRothPath = _webHostEnvironment.ContentRootPath;
                if (productDelete.ImageUrl != null)
                {
                    var imageToDelete = Path.Combine(wwwRothPath, productDelete.ImageUrl);
                    if (System.IO.File.Exists(imageToDelete))
                    {
                        System.IO.File.Delete(imageToDelete);
                    }
                }
                return Json(new { success = true, message = "Product removed succesfully" });

            }
            catch (Exception ex)
            {
                return Json(new {success=false, message=ex.Message});   
            }
        }
        #endregion
    }
}
