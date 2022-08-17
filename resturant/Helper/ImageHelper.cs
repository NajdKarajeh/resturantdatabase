using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;

using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace resturant.Helper
{
    public class ImageHelper
    {
        public static string SaveImage(IFormFile ImageFile, IWebHostEnvironment Environment)
        {
            if (!Directory.Exists(Environment.WebRootPath + "/uploads/images/"))
            {
                Directory.CreateDirectory(Environment.WebRootPath + "/uploads/images/");
            }
            string FileName = generateUniqeId() + Path.GetExtension(ImageFile.FileName).ToLower();
            string magePath = "/uploads/images/" + FileName;
            using (FileStream filestream = File.Create(Environment.WebRootPath + magePath))
            {
                ImageFile.CopyTo(filestream);
                filestream.Flush();
                var fileExtention = Path.GetExtension(ImageFile.FileName).ToLower();
            }
         
            return magePath;
        }


        public static string generateUniqeId()
        {
            return Guid.NewGuid().ToString().Replace("-", string.Empty).Replace("+", string.Empty);
        }

    }
}
