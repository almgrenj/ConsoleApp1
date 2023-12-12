namespace ConsoleApp1.Interfaces
{
    /// <summary>
    /// Gränssnitt för tjänster som hanterar filoperationer.
    /// Definierar metoder för att skriva till och läsa från filer.
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// Skriver en sträng till en specificerad fil.
        /// Om filen inte finns, skapas den.
        /// </summary>
        /// <param name="filePath">Sökväg till filen som ska skrivas till.</param>
        /// <param name="content">Innehållet som ska skrivas till filen.</param>
        void WriteToFile(string filePath, string content);

        /// <summary>
        /// Läser och returnerar innehållet från en specificerad fil.
        /// </summary>
        /// <param name="filePath">Sökväg till filen som ska läsas.</param>
        /// <returns>Innehållet i filen som en sträng.</returns>
        string ReadFromFile(string filePath);
    }
}
