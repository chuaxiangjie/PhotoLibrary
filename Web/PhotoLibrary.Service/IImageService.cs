namespace PhotoLibrary.Service;

public interface IImageService
{
    List<string> GetAll(string folderPath);
    Task<ImageSaveResult> SaveAsync(string name, byte[] content, string destinationPath);
}