using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public async Task<IActionResult> ProductIndex()
        {
            var products = await _productService.FindAllAsync();
            return View(products);
        }
        public async Task<IActionResult> ProductCreate() => View();

        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.CreateAsync(productModel);

                if (response != null)
                    return RedirectToAction(nameof(ProductIndex));
            }
            
            return View(productModel);
        }

        public async Task<IActionResult> ProductUpdate(long id)
        {
            var productModel = await _productService.FindByIdAsync(id);

            if (productModel != null) 
                return View(productModel);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductUpdate(ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.UpdateAsync(productModel);

                if (response != null)
                    return RedirectToAction(nameof(ProductIndex));
            }

            return View(productModel);
        }

        public async Task<IActionResult> ProductDelete(long id)
        {
            var productModel = await _productService.FindByIdAsync(id);

            if (productModel != null)
                return View(productModel);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductDelete(ProductModel productModel)
        {
            var response = await _productService.DeleteAsync(productModel.Id);

            if (response)
                return RedirectToAction(nameof(ProductIndex));

            return View(productModel);
        }
    }
}
