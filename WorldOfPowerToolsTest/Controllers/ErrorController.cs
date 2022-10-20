using Microsoft.AspNetCore.Mvc;

namespace WorldOfPowerToolsTest.Controllers
{
    public class ErrorController : Controller
    {
        public ViewResult Error() => View();
    }
}