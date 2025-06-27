namespace Lab03.Models
{
    public class MyTool
    {
        public static string? MoveUploadedFile(IFormFile MyFile, string folderName)
        {
            try
            {
                var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName, MyFile.FileName);
                using (var file = new FileStream(fullPath, FileMode.Create))
                {
                    MyFile.CopyTo(file);
                }
                return MyFile.FileName;
            }
            catch
            {
                return null;
            }
        }
    }
}
