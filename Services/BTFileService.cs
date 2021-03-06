using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using TheBugTracker.Services.Interfaces;

namespace TheBugTracker.Services
{
    public class BTFileService : IBTFileService
    {
        private readonly string[] suffixes = { "Bytes", "KB", "MB", "GB", "TB", "PB" };

        public string ConvertByteArrayToFile(byte[] fileData, string extension)
        {
            try
            {
                string imageBase64Data = Convert.ToBase64String(fileData);
                return string.Format($"data:{extension};base64,{imageBase64Data}");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<byte[]> ConvertFileToByteArrayAsync(IFormFile file)
        {
            try
            {
                MemoryStream memorystream = new();   // open memory stream
                await file.CopyToAsync(memorystream); // copy the file to this memory stream
                byte[] byteFile = memorystream.ToArray(); // make an array
                memorystream.Close();
                memorystream.Dispose();  

                return byteFile;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string FormatFileSize(long bytes)
        {
            //int counter = 0;
            //decimal fileSize = bytes;
            //while (Math.Round(fileSize / 1024) >= 1)
            //{
            //    fileSize /= bytes;
            //    counter++;
            //}
            //return String.Format("{0:n1}{1}",fileSize, suffixes[counter]);

            int counter = 0;
            decimal number = bytes;
            while (Math.Round(number / 1024) >= 1)
            {
                number /= 1024;
                counter++;
            }
            return string.Format("{0:n1}{1}", number, suffixes[counter]);
        }

        public string GetFileIcon(string file)
        {
            string fileImage = "default";

            if (!string.IsNullOrWhiteSpace(file))
            {
                fileImage = Path.GetExtension(file).Replace(".", "");
                return $"/img/contenttype/png/{fileImage}.png";
            }
            return fileImage;

            //string ext = Path.GetExtension(file).Replace(".", "");
            //return $"/img/contenttype/{ext}.png";
        }
    }
}
