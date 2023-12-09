using ConsoleApp1.Interfaces;
using System.IO;

namespace ConsoleApp1.Services
{
    public class FileService : IFileService
    {
        public void WriteToFile(string filePath, string content)
        {
            try
            {
                File.WriteAllText(filePath, content);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Ett fel uppstod vid skrivning till fil: {ex.Message}");
            }
        }

        public string ReadFromFile(string filePath)
        {
            try
            {
                return File.ReadAllText(filePath);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Ett fel uppstod vid läsning av fil: {ex.Message}");
                return string.Empty;
            }
        }
    }
}
