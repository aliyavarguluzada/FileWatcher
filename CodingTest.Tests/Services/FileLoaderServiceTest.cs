using CodingTest.Entities;
using CodingTest.Interfaces;
using CodingTest.Services;
using Moq;

namespace CodingTest.Tests.Services
{
    public class FileLoaderServiceTest
    {
        private readonly Mock<IFileLoader> _csvLoaderMock;
        private readonly Mock<IFileLoader> _xmlLoaderMock;
        private readonly FileLoaderService _fileLoaderService;

        public FileLoaderServiceTest()
        {
            _csvLoaderMock = new Mock<IFileLoader>();
            _xmlLoaderMock = new Mock<IFileLoader>();

            _csvLoaderMock.Setup(l => l.CanLoad(".csv")).Returns(true);
            _xmlLoaderMock.Setup(l => l.CanLoad(".xml")).Returns(true);

            var loaders = new List<IFileLoader> { _csvLoaderMock.Object, _xmlLoaderMock.Object };
            _fileLoaderService = new FileLoaderService(loaders);
        }

        [Fact]
        public async Task LoadFileAsync_WithSupportedFileFormat_ReturnsData()
        {
            // Arrange
            var filePath = "data.csv";
            var expectedData = new List<Data> { new Data() };
            _csvLoaderMock.Setup(l => l.LoadDataAsync(filePath)).ReturnsAsync(expectedData);

            // Act
            var result = await _fileLoaderService.LoadFileAsync(filePath);

            // Assert
            Assert.Equal(expectedData, result);
            _csvLoaderMock.Verify(l => l.LoadDataAsync(filePath), Times.Once);
            _xmlLoaderMock.Verify(l => l.LoadDataAsync(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task LoadFileAsync_WithUnsupportedFileFormat_ThrowsNotSupportedException()
        {
            // Arrange
            var filePath = "data.txt";

            // Act & Assert
            await Assert.ThrowsAsync<NotSupportedException>(() => _fileLoaderService.LoadFileAsync(filePath));
        }
    }
}
