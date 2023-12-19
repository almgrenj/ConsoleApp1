namespace ConsoleApp1.Interfaces
{
    public interface IFileService
    {
        void WriteToFile(string filePath, string content);
        string ReadFromFile(string filePath);
    }
}
