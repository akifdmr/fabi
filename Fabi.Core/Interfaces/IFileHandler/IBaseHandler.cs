namespace Fabi.Core.Interfaces;
public interface IBaseHandler
{
    Task<string> Upload(IFormFile file, string path);
    void Delete(string path);
}
