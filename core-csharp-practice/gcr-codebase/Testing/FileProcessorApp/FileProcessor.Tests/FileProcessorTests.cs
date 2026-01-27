using NUnit.Framework;
using System.IO;

namespace FileProcessor.Tests
{
    public class FileProcessorTests
    {
        private FileProcessor _fileProcessor;
        private string _testFilePath;

        [SetUp]
        public void Setup()
        {
            _fileProcessor = new FileProcessor();
            _testFilePath = Path.GetTempFileName();
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(_testFilePath))
            {
                File.Delete(_testFilePath);
            }
        }

        [Test]
        public void WriteToFile_ShouldCreateFile()
        {
            _fileProcessor.WriteToFile(_testFilePath, "test content");
            Assert.That(File.Exists(_testFilePath), Is.True);
        }

        [Test]
        public void ReadFromFile_ShouldReadCorrectContent()
        {
            var content = "hello world";
            _fileProcessor.WriteToFile(_testFilePath, content);

            var readContent = _fileProcessor.ReadFromFile(_testFilePath);

            Assert.That(readContent, Is.EqualTo(content));
        }

        [Test]
        public void ReadFromFile_NonExistentFile_ShouldThrowIOException()
        {
            var nonExistentFile = "nonexistent.txt";
            Assert.Throws<System.IO.FileNotFoundException>(() => _fileProcessor.ReadFromFile(nonExistentFile));
        }
    }
}
