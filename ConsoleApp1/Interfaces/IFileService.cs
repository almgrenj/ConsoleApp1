namespace ConsoleApp1.Interfaces
{
    /// <summary>
    /// Definierar en uppsättning operationer för att hantera filer.
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// Skriver innehåll till en fil.
        /// </summary>
        /// <param name="filePath">Sökvägen till filen där innehållet ska skrivas.</param>
        /// <param name="content">Innehållet som ska skrivas till filen.</param>
        void WriteToFile(string filePath, string content);

        /// <summary>
        /// Läser innehåll från en fil.
        /// </summary>
        /// <param name="filePath">Sökvägen till filen som ska läsas.</param>
        /// <returns>En sträng med innehållet i filen.</returns>
        string ReadFromFile(string filePath);
    }
}
