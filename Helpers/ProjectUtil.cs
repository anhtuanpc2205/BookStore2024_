namespace BookStore2024.Helpers
{
    public class ProjectUtil
    {
        public static string UploadImage(IFormFile img, string folder) //upload file vao thu muc duoc chi dinh wwwroot/{folder}
        {
            try
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", folder);
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var newFileName = Guid.NewGuid().ToString() + "_" + img.FileName;

                var filePath = Path.Combine(uploadsFolder, newFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    img.CopyTo(fileStream);
                }

                string result = "../images/" + folder + "/" + newFileName.ToString();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return string.Empty;
            }
        }
    }
}
