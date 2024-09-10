using Microsoft.AspNetCore.Mvc;

namespace PhotoLibrary.Web.Controllers;

public abstract class AppController : Controller
{
    protected string GetUploadFolder()
    {
        var webhostEnvironment = HttpContext.RequestServices.GetService<IWebHostEnvironment>();
        var uploadFolder = Path.Combine(webhostEnvironment.WebRootPath, "uploads");

        return uploadFolder;
    }
}