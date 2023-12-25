using AdventOfCode2023.Day7.Day7Console;
using System.CommandLine;

var rootCommand = new RootCommand("Advent of Code 2023 - Day 7");

var getWinningsOption = new Option<FileInfo>(
    name: "--get-winnings",
    description: "The file with the hands and bids.");
rootCommand.AddOption(getWinningsOption);
rootCommand.SetHandler(GetWinnings, getWinningsOption);

return await rootCommand.InvokeAsync(args);

static void GetWinnings(FileInfo file)
{
    var hands = Hand.ParseHands(file);
    var winnings = Hand.GetWinnings(hands);
    Console.WriteLine($"Winnings: {winnings}");
    Console.ReadLine();
}
