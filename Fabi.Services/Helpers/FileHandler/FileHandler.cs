global using Microsoft.AspNetCore.Http;
using Fabi.Core.Interfaces;
using Fabi.Services.Interfaces;

namespace Fabi.Services.Helpers.FilesHnadler
{
    public class FileHandler : IFileHandler
    {

        public FileHandler()
        {
            //Initialize 
            Image = new ImageHandler();
        }
        public IBaseHandler Image { get; private set; }
    }
}
