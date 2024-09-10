namespace PhotoLibrary.Web.Models;

public record ImageUploadOutput
{
   public bool IsSuccess { get; set; }
   public List<string> Errors { get; set; } 
}