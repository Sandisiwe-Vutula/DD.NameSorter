namespace DD.NameSorter.Services.Contract
{
    public interface IFileService
    {
        Task<IEnumerable<string>> ReadNamesAsync(string path);
        Task WriteNamesAsync(string path, IEnumerable<string> names);
    }
}
