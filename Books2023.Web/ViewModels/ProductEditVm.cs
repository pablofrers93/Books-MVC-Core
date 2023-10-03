using Books2023.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Books2023.Web.ViewModels
{
    public class ProductEditVm
    {
        public Product Product { get; set; }
        public IEnumerable<SelectListItem> CategoriesList { get; set; }
        public IEnumerable<SelectListItem> CoverTypesList { get; set; }
    }
}
