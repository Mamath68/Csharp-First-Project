using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_App.Models;

namespace MVC_App.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewData["Message"] = "Welcome";
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult About()
    {
        ViewData["Message"] = "Your application description page.";

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}