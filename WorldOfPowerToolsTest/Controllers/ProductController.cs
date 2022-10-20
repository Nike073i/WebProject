using Microsoft.AspNetCore.Mvc;
using WorldOfPowerToolsTest.Models;
using WorldOfPowerToolsTest.Models.ViewModels;

namespace WorldOfPowerToolsTest.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;
        public int PageSize { get; set; } = 4;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        public ViewResult List(string category, int productPage = 1)
        {
            var products = _repository.Products.Where(p => category == null || p.Category == category);
            return View(new ProductListViewModel
            {
                Products = products.OrderBy(p => p.Id).Skip((productPage - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    Totalltems = products.Count()
                },
                CurrentCategory = category
            });
        }
    }
}