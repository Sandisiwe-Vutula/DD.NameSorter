namespace DD.NameSorter.Services.Implementation
{
    public class NameSortingService : INameSortingService
    {
        private readonly INameParser _parser;

        public NameSortingService(INameParser parser)
        {
            _parser = parser;
        }

        public List<string> SortNames(IEnumerable<string> names)
        {
            return names
                .Select(_parser.Parse)
                .OrderBy(n => n.LastName)
                .ThenBy(n => string.Join(" ", n.GivenNames))
                .Select(n => n.ToString())
                .ToList();
        }
    }
}
