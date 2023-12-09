using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1.Services;
using System.IO;
using ConsoleApp1.Interfaces;

namespace ConsoleApp1.Tests
{
    [TestClass]
    public class FileServiceTests
    {
        private readonly string testFilePath = "test.txt";

        [TestMethod]
        public void WriteToFile_ShouldCreateFile()
        {
            // Arrange
            var service = new FileService();
            string content = "Test content";

            // Act
            service.WriteToFile(testFilePath, content);

            // Assert
            Assert.IsTrue(File.Exists(testFilePath));

            // Cleanup
            if (File.Exists(testFilePath))
            {
                File.Delete(testFilePath);
            }
        }

        [TestMethod]
        public void ReadFromFile_ShouldReturnContent()
        {
            // Arrange
            var service = new FileService();
            string expectedContent = "Test content";
            File.WriteAllText(testFilePath, expectedContent);

            // Act
            string actualContent = service.ReadFromFile(testFilePath);

            // Assert
            Assert.AreEqual(expectedContent, actualContent);

            // Cleanup
            if (File.Exists(testFilePath))
            {
                File.Delete(testFilePath);
            }
        }
    }
}
