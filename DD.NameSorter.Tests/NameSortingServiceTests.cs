namespace DD.NameSorter.Tests
{
    public class NameSortingServiceTests
    {
        [Fact]
        public void SortNames_SortsByLastNameThenGivenNames()
        {
            var mockParser = new Mock<INameParser>();
            mockParser.Setup(p => p.Parse(It.IsAny<string>()))
                .Returns<string>(name =>
                {
                    var parts = name.Split(' ');
                    return new PersonName(parts.Take(parts.Length - 1).ToList(), parts.Last());
                });

            var service = new NameSortingService(mockParser.Object);

            var unsorted = new List<string> {
            "Janet Parsons",
            "Adonis Julius Archer",
            "Shelby Nathan Yoder"
        };

            var sorted = service.SortNames(unsorted);

            Assert.Equal("Adonis Julius Archer", sorted[0]);
            Assert.Equal("Janet Parsons", sorted[1]);
            Assert.Equal("Shelby Nathan Yoder", sorted[2]);
        }

        [Fact]
        public void SortNames_ThenHandlesEmptyList()
        {
            var mockParser = new Mock<INameParser>();
            var service = new NameSortingService(mockParser.Object);

            var result = service.SortNames(new List<string>());

            Assert.Empty(result);
        }

        [Fact]
        public void SortNames_ThenHandlesSingleName()
        {
            var mockParser = new Mock<INameParser>();
            mockParser.Setup(p => p.Parse("Sandisiwe Vutula"))
                .Returns(new PersonName(new List<string> { "Sandisiwe" }, "Vutula"));

            var service = new NameSortingService(mockParser.Object);

            var result = service.SortNames(new List<string> { "Sandisiwe Vutula" });

            Assert.Single(result);
            Assert.Equal("Sandisiwe Vutula", result[0]);
        }

        [Fact]
        public void SortNames_ThenHandlesDuplicateNames()
        {
            var mockParser = new Mock<INameParser>();
            mockParser.Setup(p => p.Parse("Tshiamo Tlhapi"))
                .Returns(new PersonName(new List<string> { "Tshiamo" }, "Tlhapi"));

            var service = new NameSortingService(mockParser.Object);

            var result = service.SortNames(new List<string> { "Tshiamo Tlhapi", "Tshiamo Tlhapi" });

            Assert.Equal(2, result.Count);
            Assert.All(result, name => Assert.Equal("Tshiamo Tlhapi", name));
        }

        [Fact]
        public void SortNames_ThenHandlesSameLastNameThenDifferentGivenNames()
        {
            var mockParser = new Mock<INameParser>();
            mockParser.Setup(p => p.Parse("Alice Smith"))
                .Returns(new PersonName(new List<string> { "Alice" }, "Smith"));
            mockParser.Setup(p => p.Parse("Bob Smith"))
                .Returns(new PersonName(new List<string> { "Bob" }, "Smith"));

            var service = new NameSortingService(mockParser.Object);

            var result = service.SortNames(new List<string> { "Bob Smith", "Alice Smith" });

            Assert.Equal("Alice Smith", result[0]);
            Assert.Equal("Bob Smith", result[1]);
        }

        [Fact]
        public void SortNames_ThenHandlesMultipleSpaces()
        {
            var mockParser = new Mock<INameParser>();
            mockParser.Setup(p => p.Parse("   Alice   Smith   "))
                .Returns(new PersonName(new List<string> { "Alice" }, "Smith"));
            mockParser.Setup(p => p.Parse("Bob   Smith"))
                .Returns(new PersonName(new List<string> { "Bob" }, "Smith"));

            var service = new NameSortingService(mockParser.Object);

            var result = service.SortNames(new List<string> { "   Alice   Smith   ", "Bob   Smith" });

            Assert.Equal("Alice Smith", result[0]);
            Assert.Equal("Bob Smith", result[1]);
        }

    }

}

