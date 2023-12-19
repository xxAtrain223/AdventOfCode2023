using AdventOfCode2023.Day5.Day5Console;
using System.CommandLine;
using System.Diagnostics;

var rootCommand = new RootCommand("Advent of Code 2023 - Day 5");

var findClosestLocationOption = new Option<FileInfo>(
    name: "--find-closest-location-by-iterating",
    description: "The file with the seeds and mappings. By Iterating.");
rootCommand.AddOption(findClosestLocationOption);
rootCommand.SetHandler(FindClosestLocation, findClosestLocationOption);

var findClosestLocationByRangesOption = new Option<FileInfo>(
    name: "--find-closest-location-by-ranges",
    description: "The file with the seeds and mappings. By Ranges.");
rootCommand.AddOption(findClosestLocationByRangesOption);
rootCommand.SetHandler(FindClosestLocationByRanges, findClosestLocationByRangesOption);

return await rootCommand.InvokeAsync(args);

static void FindClosestLocation(FileInfo file)
{
    var seedMapper = new SeedMapper(file, false);
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

static void FindClosestLocationByRanges(FileInfo file)
{
    var seedMapper = new SeedMapper(file, true);
    long minimumLocation = 0;
    try
    {
        minimumLocation = seedMapper.FindMinimumLocationForwardRange();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
    }

    Console.WriteLine($"Minimum Location (Range): {minimumLocation}");
    Console.ReadLine();
}
