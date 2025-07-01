namespace DD.NameSorter.Services.Implementation
{
    public class FileService : IFileService
    {
        public async Task<IEnumerable<string>> ReadNamesAsync(string path)
        {
            var lines = await File.ReadAllLinesAsync(path);
            return lines.Where(line => !string.IsNullOrWhiteSpace(line));
        }

        public async Task WriteNamesAsync(string path, IEnumerable<string> names)
        {
            await File.WriteAllLinesAsync(path, names);
        }
    }
}
