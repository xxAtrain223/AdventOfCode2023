using AdventOfCode2023.Day1.Puzzle1Console;
using System.CommandLine;

var fileOption = new Option<FileInfo>(
    name: "--file",
    description: "The calibration file to read.");
fileOption.AddAlias("-f");

var rootCommand = new RootCommand("Advent of Code 2023 - Day 1 - Puzzle 1");
rootCommand.AddOption(fileOption);

rootCommand.SetHandler((file) =>
{
    GetAndPrintCalibrationValue(file);
}, fileOption);

return await rootCommand.InvokeAsync(args);

static void GetAndPrintCalibrationValue(FileInfo file)
{
    var calibrationValue = Puzzle1.GetCalibrationValue(file);

    Console.WriteLine($"Calibration Value: {calibrationValue}");
    Console.ReadLine();
}