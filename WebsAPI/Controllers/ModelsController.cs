using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class ModelsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}