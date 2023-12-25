using AdventOfCode2023.Day6.Day6Console;
using System.CommandLine;

var rootCommand = new RootCommand("Advent of Code 2023 - Day 6");

var getWinningCombinationsOption = new Option<FileInfo>(
    name: "--get-winning-combinations",
    description: "The file with the times and distances.");
rootCommand.AddOption(getWinningCombinationsOption);
rootCommand.SetHandler(GetWinningCombinations, getWinningCombinationsOption);

var getWinningTimesCountOption = new Option<FileInfo>(
    name: "--get-winning-times-count",
    description: "The file with the time and distance.");
rootCommand.AddOption(getWinningTimesCountOption);
rootCommand.SetHandler(GetWinningTimesCount, getWinningTimesCountOption);

return await rootCommand.InvokeAsync(args);

static void GetWinningCombinations(FileInfo file)
{
    var winningCombinationCount = Race.GetNumberOfWinningCombinations(file);
    Console.WriteLine($"Number of Winning Combinations: {winningCombinationCount}");
    Console.ReadLine();
}

static void GetWinningTimesCount(FileInfo file)
{
    var winningTimesCount = Race.GetNumberOfWinningTimes(file);
    Console.WriteLine($"Winning Times Count: {winningTimesCount}");
    Console.ReadLine();
}
