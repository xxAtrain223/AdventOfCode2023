using AdventOfCode2023.Day2.Day2Console;
using System.CommandLine;

var fileOption = new Option<FileInfo>(
    name: "--file",
    description: "The games to evaluate");
fileOption.AddAlias("-f");

var rootCommand = new RootCommand("Advent of Code 2023 - Day 2");
rootCommand.AddOption(fileOption);

rootCommand.SetHandler((file) =>
{
    SumPossibleGameIDs(file);
}, fileOption);

return await rootCommand.InvokeAsync(args);

static void SumPossibleGameIDs(FileInfo file)
{
    var bag = new Bag(12, 13, 14);
    var sumOfPossibleGameIDs = bag.SumPossibleGameIDs(file);

    Console.WriteLine($"Sum Of Possible Game IDs: {sumOfPossibleGameIDs}");
    Console.ReadLine();
}
