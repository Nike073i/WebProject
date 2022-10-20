using Microsoft.AspNetCore.Mvc;
using WorldOfPowerToolsTest.Models;

namespace WorldOfPowerToolsTest.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private readonly IProductRepository _repository;

        public NavigationMenuViewComponent(IProductRepository repository)
        {
            _repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(_repository.Products.Select(p => p.Category).Distinct().OrderBy(x => x));
        }
    }
}