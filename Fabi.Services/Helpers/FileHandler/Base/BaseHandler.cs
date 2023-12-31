﻿global using Microsoft.AspNetCore.Http;
using Fabi.Core.Interfaces;
using Fabi.Services.Interfaces;

namespace Fabi.Services.Helpers.FilesHnadler
{
    public  class BaseHandler : IBaseHandler
    {
        protected  string[] allowedExtensions;
        protected   long maxAllowedSize;
        protected long megabyte;

        //global method
        public async Task<string> Upload(IFormFile file, string path)
        {
            var name = Guid.NewGuid().ToString();
            var extension = Path.GetExtension(file.FileName).ToLower();

            if (!allowedExtensions.Contains(extension))
                return $"Only [{string.Join(", ", allowedExtensions)}] files are allowed.";

            if (file.Length > maxAllowedSize)
                return $"Max allowed size for image is {maxAllowedSize / megabyte}MB.";

            using var fileStream = new FileStream(Path.Combine(path, name + extension), FileMode.Create);
            await file.CopyToAsync(fileStream);

            return @$"{path}\{name + extension}";
        }
        public void Delete(string path)
        {
            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);
        }
    }
}