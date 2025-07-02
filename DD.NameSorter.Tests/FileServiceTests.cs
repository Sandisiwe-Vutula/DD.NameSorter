namespace DD.NameSorter.Tests
{
    public class FileServiceTests
    {
        private readonly FileService _fileService;

        public FileServiceTests()
        {
            _fileService = new FileService();
        }

        [Fact]
        public async Task ReadNamesAsync_ThenReadsValidFile()
        {
            var path = "unsorted-names-list";
            var expected = new List<string> { "Janet Parsons", "Vaughn Lewis" };
            await File.WriteAllLinesAsync(path, expected);

            var result = (await _fileService.ReadNamesAsync(path)).ToList();

            Assert.Equal(expected.Count, result.Count);
            Assert.Contains("Janet Parsons", result);
            Assert.Contains("Vaughn Lewis", result);

            File.Delete(path);
        }

        [Fact]
        public async Task ReadNamesAsync_ThenIgnoresBlankLines()
        {
            var path = "test-blank-lines.txt";
            var content = new[] { "Sandi Vutula", "", "   ", "Tshiamo Tlhapi" };
            await File.WriteAllLinesAsync(path, content);

            var result = (await _fileService.ReadNamesAsync(path)).ToList();

            Assert.Equal(2, result.Count);
            Assert.Contains("Sandi Vutula", result);
            Assert.Contains("Tshiamo Tlhapi", result);

            File.Delete(path);
        }

        [Fact]
        public async Task WriteNamesAsync_ThenWritesCorrectly()
        {
            var path = "test-write-output.txt";
            var names = new List<string> { "Charlie Brown", "Sally May" };

            await _fileService.WriteNamesAsync(path, names);

            var result = await File.ReadAllLinesAsync(path);
            Assert.Equal(names.Count, result.Length);
            Assert.Equal(names[0], result[0]);
            Assert.Equal(names[1], result[1]);

            File.Delete(path);
        }

        [Fact]
        public async Task ReadNamesAsync_ThenFileNotFound_Throws()
        {
            var path = "nonexistent-file.txt";
            await Assert.ThrowsAsync<FileNotFoundException>(() => _fileService.ReadNamesAsync(path));
        }
    }
}

