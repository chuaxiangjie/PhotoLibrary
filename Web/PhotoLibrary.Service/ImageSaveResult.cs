namespace PhotoLibrary.Service;

public record ImageSaveResult
{
    public bool IsSuccess { get; set; }
    public List<string> ErrorMessages { get; set; }
    public string UpdatedFileName { get; set; }
    public string FilePath { get; set; }
}