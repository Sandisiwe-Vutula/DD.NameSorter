class Program
{
    public static async Task Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddLogging(configure => configure.AddConsole())
            .AddSingleton<INameSortingService, NameSortingService>()
            .AddSingleton<IFileService, FileService>()
            .AddSingleton<INameParser, NameParser>()
            .BuildServiceProvider();

        var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
        var fileService = serviceProvider.GetRequiredService<IFileService>();
        var sorter = serviceProvider.GetRequiredService<INameSortingService>();

        if (args.Length != 1)
        {
            logger.LogError("Usage: name-sorter <input-file-path>");
            return;
        }

        var inputPath = Path.GetFullPath(args[0]);
        var outputPath = Path.Combine(Directory.GetCurrentDirectory(), "sorted-names-list.txt");


        if (!File.Exists(inputPath))
        {
            logger.LogError("Input file not found: {InputPath}", inputPath);
            return;
        }

        try
        {
            Console.WriteLine("************** Dye & Durham Name Sorter ******************");

            var names = await fileService.ReadNamesAsync(inputPath);
            var sortedNames = sorter.SortNames(names);

            foreach (var name in sortedNames)
                Console.WriteLine(name);

            await fileService.WriteNamesAsync(outputPath, sortedNames);
            logger.LogInformation("Sorted names written to: {File}", outputPath);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred during execution.");
        }
    }
}
