using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SimpleWeb.Models;

namespace SimpleWeb.Controllers;

public class HomeController : Controller
{
    public HomeController()
    {
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
    [HttpGet("delay")]
    public async Task<IActionResult> Delay()
    {
        await Task.Delay(2000); // Simulate a delay of 2 seconds
        return Content("This response was delayed by 2 seconds.");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
