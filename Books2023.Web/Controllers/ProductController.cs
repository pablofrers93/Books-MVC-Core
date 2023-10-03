using Books2023.DataLayer.Repository.Interfaces;
using Books2023.Models.Models;
using Books2023.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Books2023.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
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
            return View(productsListVm);
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
                     })
            };

            if (id == null || id == 0)
            {
                return View(productVm);

            }
            else
            {
                productVm.Product = _unitOfWork.Products.Get(p => p.Id == id.Value);
                return View(productVm);


            }
        }
    }
}
