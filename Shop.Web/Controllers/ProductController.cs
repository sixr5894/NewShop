using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Repository;
using Shop.Repository.ProductRepos;
using Shop.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Shop.Web.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private IRepository<ProductModel> _con;
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var temp =  await _con.AllModelsAsync();
            return Json(temp);
        }
        [HttpPost]
        public async Task<IActionResult> AddProductAsync(ProductModel model)
        {

            await this._con.AddModelAsync(model);
            return Ok($"object with {model.ID} id is added");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProductAsync(ProductModel model)
        {
            await this._con.DeleteAsync(model);
            return Ok($"object with {model.ID} id is deleted");
        }
        [HttpPatch]
        public async Task<IActionResult> EditAsync(ProductModel model)
        {
            await this._con.EditModelAsync(model);
            return Ok($"object with ID {model.ID} edited ");
        }
        public ProductController()
        {

            this._con = ProductRepositoryFactory.CreateProductRepository();
        }
    }
}
