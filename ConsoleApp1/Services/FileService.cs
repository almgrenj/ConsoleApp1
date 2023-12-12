using ConsoleApp1.Interfaces;
using System;
using System.IO;

namespace ConsoleApp1.Services
{
    /// <summary>
    /// Erbjuder tjänster för att läsa från och skriva till filer.
    /// </summary>
    public class FileService : IFileService
    {
        /// <summary>
        /// Skriver en sträng till en angiven fil.
        /// Om filen inte finns skapas den.
        /// Eventuella IO-fel fångas och skrivs ut till konsolen.
        /// </summary>
        /// <param name="filePath">Sökvägen till filen som ska skrivas till.</param>
        /// <param name="content">Innehållet som ska skrivas till filen.</param>
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

        /// <summary>
        /// Läser och returnerar innehållet från en angiven fil.
        /// Eventuella IO-fel fångas och skrivs ut till konsolen, och en tom sträng returneras.
        /// </summary>
        /// <param name="filePath">Sökvägen till filen som ska läsas.</param>
        /// <returns>Innehållet i filen som en sträng, eller en tom sträng om ett fel uppstår.</returns>
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
