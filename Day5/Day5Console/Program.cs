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
    throw new NotImplementedException();
}
