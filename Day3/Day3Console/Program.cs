using AdventOfCode2023.Day3.Day3Console;
using System.CommandLine;

var sumAllPartNumbersOption = new Option<FileInfo>(
    name: "--sum-part-numbers",
    description: "The schematic file to find and sum all part numbers.");

var sumGearRatiosOption = new Option<FileInfo>(
    name: "--sum-gear-ratios",
    description: "The schematic file to find and sum the gear ratios.");

var rootCommand = new RootCommand("Advent of Code 2023 - Day 3");
rootCommand.AddOption(sumAllPartNumbersOption);
rootCommand.AddOption(sumGearRatiosOption);

rootCommand.SetHandler(SumAllPartNumbers, sumAllPartNumbersOption);
rootCommand.SetHandler(SumGearRatios, sumGearRatiosOption);

return await rootCommand.InvokeAsync(args);

static void SumAllPartNumbers(FileInfo file)
{
    var schematic = new Schematic();
    schematic.MapFile(file);
    var sumOfPartNumbers = schematic.SumAllPartNumbersAroundSymbols();

    Console.WriteLine($"Sum Of Part Numbers: {sumOfPartNumbers}");
    Console.ReadLine();
}

static void SumGearRatios(FileInfo file)
{
    var schematic = new Schematic();
    schematic.MapFile(file);
    var sumOfGearRatios = schematic.SumGearRatios();

    Console.WriteLine($"Sum Of Gear Ratios: {sumOfGearRatios}");
    Console.ReadLine();
}
