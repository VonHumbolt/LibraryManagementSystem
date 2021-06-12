using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile formFile)
        {
            string folderPath = CreateFolderPath();

            if (formFile != null)
            {
                string fileName = formFile.FileName;

                string filePath = Path.Combine(folderPath, fileName);

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
                return filePath;
            }
            else
            {
                
                return Path.Combine(folderPath, "default.jpg");
            }

        }

        public static string Update(string imagePathForUpdate, IFormFile formFile)
        {
            string updatedImageName = formFile.FileName;
            var folderPath = CreateFolderPath();

            string filePath = Path.Combine(folderPath, updatedImageName);

            if (File.Exists(imagePathForUpdate))
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    formFile.CopyTo(fileStream);
                }
                
            }
            return filePath;
        }

        public static void Delete(string imagePath)
        {
            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }
        }

        private static string CreateFolderPath()
        {
            string directory = Environment.CurrentDirectory + @"\wwwroot\";
            string path = Path.Combine(directory, "Images");

            return path;
        }

    }
}
