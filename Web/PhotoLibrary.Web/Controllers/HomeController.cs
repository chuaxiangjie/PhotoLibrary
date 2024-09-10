using Microsoft.AspNetCore.Mvc;
using PhotoLibrary.Service;

namespace PhotoLibrary.Web.Controllers;

public class HomeController(IImageService imageService) : AppController()
{
    [HttpGet]
    public IActionResult Index()
    {
        var allImagePaths = imageService.GetAll(GetUploadFolder());

        return View(allImagePaths);
    }
}