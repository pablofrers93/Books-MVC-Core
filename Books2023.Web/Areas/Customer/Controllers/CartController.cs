using Books2023.DataLayer.Repository.Interfaces;
using Books2023.Models.Models;
using Books2023.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Books2023.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class CartController : Controller
    {
		private readonly IUnitOfWork _unitOfWork;
		[BindProperty]
		public ShoppingCartVm shoppingCartVm { get; set; }
		public CartController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public IActionResult Index()
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
			shoppingCartVm = new ShoppingCartVm
			{
				CartList = _unitOfWork.ShoppingCarts
				.GetAll(c => c.ApplicationUserId == userId.Value, propertiesNames: "Product"),
				OrderHeader = new()
			};

			foreach (var itemCart in shoppingCartVm.CartList)
			{
				    itemCart.Price = GetPriceBasedOnQuantity(itemCart.Quantity,
					itemCart.Product.Price,
					itemCart.Product.Price50,
					itemCart.Product.Price100);
				shoppingCartVm.OrderHeader.OrderTotal += itemCart.Quantity * itemCart.Price;
			}

			return View(shoppingCartVm);
		}
		private double GetPriceBasedOnQuantity(int quantity, double price, double price50, double price100)
		{
			if (quantity <= 50)
			{
				return price;
			}
			else if (quantity <= 100)
			{
				return price50;
			}
			else
			{
				return price100;
			}
		}

		public IActionResult Plus(int cartId)
        {
            var cartInDb = _unitOfWork.ShoppingCarts.Get(c => c.Id == cartId);
            _unitOfWork.ShoppingCarts.IncrementQuatity(cartInDb, 1);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
		public IActionResult Minus(int cartId)
		{
			var cartInDb = _unitOfWork.ShoppingCarts.Get(c => c.Id == cartId);
			_unitOfWork.ShoppingCarts.DecrementQuatity(cartInDb, 1);
			_unitOfWork.Save();

			return RedirectToAction("Index");
		}
	}
}
