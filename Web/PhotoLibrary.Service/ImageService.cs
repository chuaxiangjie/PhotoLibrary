namespace PhotoLibrary.Service;

public class ImageService : IImageService
{
    private readonly string[] allowedExtensions = { ".jpg", ".jpeg", ".gif", ".bmp", ".png" };
    private const int MaxFileSize = 5 * 1024 * 1024; // 5MB limit

    public List<string> GetAll(string folderPath)
    {
        var allImagePaths = Directory.GetFiles(folderPath)
            .Select(Path.GetFileName)
            .ToList();

        return allImagePaths;
    }

    public async Task<ImageSaveResult> SaveAsync(string name, byte[] content, string destinationPath)
    {
        var validationErrors = ValidateImage(name, content);
        if (validationErrors.Any())
        {
            return new ImageSaveResult
            {
                IsSuccess = false,
                ErrorMessages = validationErrors
            };
        }

        if (!Directory.Exists(destinationPath))
            Directory.CreateDirectory(destinationPath);

        var uniqueFileName = $"{Path.GetFileNameWithoutExtension(name)}_{Guid.NewGuid()}{Path.GetExtension(name)}";
        var filePath = Path.Combine(destinationPath, uniqueFileName);

        try
        {
            await File.WriteAllBytesAsync(filePath, content);
            return new ImageSaveResult
            {
                IsSuccess = true,
                UpdatedFileName = uniqueFileName,
                FilePath = filePath
            };
        }
        catch (Exception ex)
        {
            return new ImageSaveResult
            {
                IsSuccess = false,
                ErrorMessages = [$"Error saving file: {ex.Message}"]
            };
        }
    }

    private List<string> ValidateImage(string name, byte[] content)
    {
        var errors = new List<string>();

        if (content.Length > MaxFileSize)
        {
            errors.Add("File size exceeds the limit of 5MB.");
        }

        var extension = Path.GetExtension(name).ToLowerInvariant();
        if (!allowedExtensions.Contains(extension))
        {
            errors.Add("Invalid file type. Only .jpg, .jpeg, .gif, .bmp, and .png files are allowed.");
        }

        if (name.Length > 255)
        {
            errors.Add("File name length must be less than or equal to 255");
        }

        return errors;
    }
}