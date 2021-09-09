using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
namespace Core.Utilities.Helpers.FileHelpers
{
    public static class ImageFileHelper
    {
        private static string carImageFolderName = "Images/";
        private static string root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", carImageFolderName);
        private static string defaultCarImage = "defaultCar.png";
        public static string Upload(IFormFile formFile)
        {
            if(formFile.Length > 0)
            {
                string fileName = Path.GetFileName(formFile.FileName);
                string guid = Guid.NewGuid().ToString();
                string fileExtension = Path.GetExtension(fileName);
                string newFileName = guid + fileExtension;
                string filePath = root + $@"\{newFileName}";
                
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
                return "/" + carImageFolderName + newFileName;
                //return filePath;
            }
            return "";
        }

        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
                return new SuccessResult();
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }
        }


        public static string GetDefaultCarImagePath()
        {
            return "/" + carImageFolderName + defaultCarImage;
        }
    }
}
