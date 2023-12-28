using AdventOfCode2023.Day8.Day8Console;
using System;
using System.CommandLine;

var rootCommand = new RootCommand("Advent of Code 2023 - Day 8");

var followInstructionsOption = new Option<FileInfo>(
    name: "--follow-instructions",
    description: "The file with the instructions and nodes.");
rootCommand.AddOption(followInstructionsOption);
rootCommand.SetHandler(FollowInstructions, followInstructionsOption);

return await rootCommand.InvokeAsync(args);

static void FollowInstructions(FileInfo file)
{
    var graph = NodeGraph.Parse(file);
    var stepsCount = graph.FollowInstructions();
    Console.WriteLine($"Steps: {stepsCount}");
    Console.ReadLine();
}
