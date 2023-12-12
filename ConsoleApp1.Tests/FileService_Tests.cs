using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1.Services;
using System.IO;
using ConsoleApp1.Interfaces;

namespace ConsoleApp1.Tests
{
    /// <summary>
    /// Testklass för FileService.
    /// Testerna verifierar att läsning och skrivning till filer fungerar som förväntat.
    /// </summary>
    [TestClass]
    public class FileServiceTests
    {
        private readonly string testFilePath = "test.txt";

        /// <summary>
        /// Testar om metoden WriteToFile skapar en fil med önskat innehåll.
        /// </summary>
        [TestMethod]
        public void WriteToFile_ShouldCreateFile()
        {
            // Arrange - Skapar en FileService-instans och definierar testinnehåll.
            var service = new FileService();
            string content = "Test content";

            // Act - Använder WriteToFile för att skapa en fil med det definierade innehållet.
            service.WriteToFile(testFilePath, content);

            // Assert - Kontrollerar att filen skapats.
            Assert.IsTrue(File.Exists(testFilePath));

            // Cleanup - Raderar testfilen efter testet.
            if (File.Exists(testFilePath))
            {
                File.Delete(testFilePath);
            }
        }

        /// <summary>
        /// Testar om metoden ReadFromFile returnerar det korrekta innehållet från en fil.
        /// </summary>
        [TestMethod]
        public void ReadFromFile_ShouldReturnContent()
        {
            // Arrange - Skapar en FileService-instans, en testfil och definierar förväntat innehåll.
            var service = new FileService();
            string expectedContent = "Test content";
            File.WriteAllText(testFilePath, expectedContent);

            // Act - Läser innehållet från filen med ReadFromFile.
            string actualContent = service.ReadFromFile(testFilePath);

            // Assert - Kontrollerar att innehållet stämmer överens med det förväntade.
            Assert.AreEqual(expectedContent, actualContent);

            // Cleanup - Raderar testfilen efter testet.
            if (File.Exists(testFilePath))
            {
                File.Delete(testFilePath);
            }
        }
    }
}
