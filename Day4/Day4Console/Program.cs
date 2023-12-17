using AdventOfCode2023.Day4.Day4Console;
using System.CommandLine;

var rootCommand = new RootCommand("Advent of Code 2023 - Day 4");

var sumCardScoresOption = new Option<FileInfo>(
    name: "--sum-card-scores",
    description: "The file with scratchcards to sum the scores.");
rootCommand.AddOption(sumCardScoresOption);
rootCommand.SetHandler(SumCardScores, sumCardScoresOption);

var countCardsOption = new Option<FileInfo>(
    name: "--count-cards",
    description: "The file with scratchcards to count.");
rootCommand.AddOption(countCardsOption);
rootCommand.SetHandler(CountCards, countCardsOption);

return await rootCommand.InvokeAsync(args);

static void SumCardScores(FileInfo file)
{
    var sumOfCardScores = Card.SumCardScores(file);

    Console.WriteLine($"Sum Of Card Scores: {sumOfCardScores}");
    Console.ReadLine();
}

static void CountCards(FileInfo file)
{
    var cardCount = Card.Count(file);

    Console.WriteLine($"Number of Cards: {cardCount}");
    Console.ReadLine();
}
