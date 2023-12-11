using AdventOfCode2023.Day3.Day3Console;
using System.CommandLine;

var sumAllPartNumbersOption = new Option<FileInfo>(
    name: "--sum-part-numbers",
    description: "The schematic file to find and sum all part numbers.");

var rootCommand = new RootCommand("Advent of Code 2023 - Day 3");
rootCommand.AddOption(sumAllPartNumbersOption);

rootCommand.SetHandler(SumAllPartNumbers, sumAllPartNumbersOption);

return await rootCommand.InvokeAsync(args);

static void SumAllPartNumbers(FileInfo file)
{
    var schematic = new Schematic();
    schematic.MapFile(file);
    var sumOfPartNumbers = schematic.SumAllPartNumbersAroundSymbols();

    Console.WriteLine($"Sum Of Part Numbers: {sumOfPartNumbers}");
    Console.ReadLine();
}
