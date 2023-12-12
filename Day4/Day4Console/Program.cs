using AdventOfCode2023.Day4.Day4Console;
using System.CommandLine;

var sumCardScoresOption = new Option<FileInfo>(
    name: "--sum-card-scores",
    description: "The file with scratchcards to sum the scores.");

var rootCommand = new RootCommand("Advent of Code 2023 - Day 4");
rootCommand.AddOption(sumCardScoresOption);

rootCommand.SetHandler(SumCardScores, sumCardScoresOption);

return await rootCommand.InvokeAsync(args);

static void SumCardScores(FileInfo file)
{
    var sumOfCardScores = Card.SumCardScores(file);

    Console.WriteLine($"Sum Of Card Scores: {sumOfCardScores}");
    Console.ReadLine();
}
