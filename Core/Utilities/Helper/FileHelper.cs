using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helper
{
    public class FileHelper
    {
        public static string directory = Directory.GetCurrentDirectory() + @"\wwwroot\";
        public static string path = @"Images\";
        public static string Add(IFormFile file)
        {
            string fileName = NewFileName(file);
            if (!Directory.Exists(directory+path))
            {
                Directory.CreateDirectory(directory + path);
            }
            using (FileStream fileStream=File.Create(directory+path+fileName))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            return (path + fileName).Replace("\\", "/");
        }
        public static void Delete(string path)
        {
            if (File.Exists(directory + path.Replace("/", "\\")) && Path.GetFileName(path) != "default.jpg")
            {
                File.Delete(directory + path.Replace("/", "\\"));
            }
        }
        public static string Update(string ImagePath, IFormFile file)
        {
            Delete(ImagePath);
            return Add(file);
        }
        public static string NewFileName(IFormFile file)
        {
            string fileExtension = Path.GetExtension(file.FileName);
            var newFileName = Guid.NewGuid().ToString() + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Year + fileExtension;
            return newFileName;
        }
    }
}
