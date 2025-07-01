namespace DD.NameSorter.Models
{
    public class PersonName
    {
        public List<string> GivenNames { get; }
        public string LastName { get; }

        public PersonName(List<string> givenNames, string lastName)
        {
            GivenNames = givenNames ?? throw new ArgumentNullException(nameof(givenNames));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        }

        public override string ToString()
        {
            return string.Join(" ", GivenNames.Append(LastName));
        }
    }
}
