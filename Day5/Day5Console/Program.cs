using AdventOfCode2023.Day5.Day5Console;
using System.CommandLine;

var rootCommand = new RootCommand("Advent of Code 2023 - Day 5");

var findClosestLocationOption = new Option<FileInfo>(
    name: "--find-closest-location",
    description: "The file with the seeds and mappings.");
rootCommand.AddOption(findClosestLocationOption);
rootCommand.SetHandler(FindClosestLocation, findClosestLocationOption);

return await rootCommand.InvokeAsync(args);

static void FindClosestLocation(FileInfo file)
{
    var seedMapper = new SeedMapper(file, true);
    long minimumLocation = 0;
    try
    {
        minimumLocation = seedMapper.FindMinimumLocationForward();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
    }

    Console.WriteLine($"Minimum Location: {minimumLocation}");
    Console.ReadLine();
}
