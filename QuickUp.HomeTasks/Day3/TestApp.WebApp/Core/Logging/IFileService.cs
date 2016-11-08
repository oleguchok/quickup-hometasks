namespace TestApp.WebApp.Core.Logging
{
    public interface IFileService
    {
        void WriteMessage(string filePath, string message);
    }
}
