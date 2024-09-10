using Microsoft.AspNetCore.Mvc;
using PhotoLibrary.Service;
using PhotoLibrary.Web.Models;

namespace PhotoLibrary.Web.Controllers;

[ApiController]
[Route("api/file")]
public class ImageUploadController(IImageService imageService) : AppController()
{
    private readonly List<string> _allowedExtensions = [".jpg", ".jpeg", ".gif", ".bmp", ".png"];
    private const int MaxFilenameLength = 255;

    [HttpPost("upload")]
    public async Task<IActionResult> UploadImage(IFormFile file)
    {
        // Set the path where the images will be stored
        var content = await GetBytes(file);

        var result = await imageService.SaveAsync(file.FileName, content, GetUploadFolder());

        if (!result.IsSuccess)
        {
            return BadRequest(new ImageUploadOutput
            {
                IsSuccess = false,
                Errors = result.ErrorMessages
            });
        }

        return Ok(new ImageUploadOutput
        {
            IsSuccess = true
        });
    }

    private static async Task<byte[]> GetBytes(IFormFile formFile)
    {
        await using var memoryStream = new MemoryStream();
        await formFile.CopyToAsync(memoryStream);
        return memoryStream.ToArray();
    }
}