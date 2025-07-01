namespace DD.NameSorter.Infrastructure.Utilities.Implementation
{
    public class NameParser : INameParser
    {
        public PersonName Parse(string fullName)
        {
            var parts = fullName.Trim().Split(' ');
            if (parts.Length < 2)
                throw new ArgumentException("Each name must have at least a given name and a last name.");

            return new PersonName(parts.Take(parts.Length - 1).ToList(), parts.Last());
        }
    }
}
