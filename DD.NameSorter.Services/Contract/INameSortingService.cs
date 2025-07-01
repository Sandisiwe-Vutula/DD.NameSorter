namespace DD.NameSorter.Services.Contract
{
    public interface INameSortingService
    {
        List<string> SortNames(IEnumerable<string> names);
    }
}
