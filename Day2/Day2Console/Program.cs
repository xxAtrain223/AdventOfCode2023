using AdventOfCode2023.Day2.Day2Console;
using System.CommandLine;

var sumPossibleGameIDsOption = new Option<FileInfo>(
    name: "--sum-possible-game-ids",
    description: "The games to sum the possible game IDs.");

var sumGamePowerOption = new Option<FileInfo>(
    name: "--sum-game-powers",
    description: "The games to sum the powers of.");

var rootCommand = new RootCommand("Advent of Code 2023 - Day 2");
rootCommand.AddOption(sumPossibleGameIDsOption);
rootCommand.AddOption(sumGamePowerOption);

rootCommand.SetHandler(SumPossibleGameIDs, sumPossibleGameIDsOption);
rootCommand.SetHandler(SumGamePowers, sumGamePowerOption);

return await rootCommand.InvokeAsync(args);

static void SumPossibleGameIDs(FileInfo file)
{
    var bag = new Bag(12, 13, 14);
    var sumOfPossibleGameIDs = bag.SumPossibleGameIDs(file);

    Console.WriteLine($"Sum Of Possible Game IDs: {sumOfPossibleGameIDs}");
    Console.ReadLine();
}

static void SumGamePowers(FileInfo file)
{
    var gamePowers = Bag.SumGamePowers(file);

    Console.WriteLine($"Sum of Game Powers: {gamePowers}");
    Console.ReadLine();
}
