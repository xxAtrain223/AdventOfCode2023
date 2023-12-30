using AdventOfCode2023.Day8.Day8Console;
using System;
using System.CommandLine;

var rootCommand = new RootCommand("Advent of Code 2023 - Day 8");

var followInstructionsOption = new Option<FileInfo>(
    name: "--follow-instructions",
    description: "The file with the instructions and nodes.");
rootCommand.AddOption(followInstructionsOption);
rootCommand.SetHandler(FollowInstructions, followInstructionsOption);

var followInstructionsGhostModeOption = new Option<FileInfo>(
    name: "--follow-instructions-ghost-mode",
    description: "The file with the instructions and nodes. GHOST MODE!!!");
rootCommand.AddOption(followInstructionsGhostModeOption);
rootCommand.SetHandler(FollowInstructionsGhostMode, followInstructionsGhostModeOption);

return await rootCommand.InvokeAsync(args);

static void FollowInstructions(FileInfo file)
{
    var graph = NodeGraph.Parse(file);
    var stepsCount = graph.FollowInstructions("AAA", n => n.NodeID != "ZZZ");
    Console.WriteLine($"Steps: {stepsCount}");
    Console.ReadLine();
}

static void FollowInstructionsGhostMode(FileInfo file)
{
    var graph = NodeGraph.Parse(file);
    var stepsCount = graph.FollowInstructionsGhostMode();
    Console.WriteLine($"Steps: {stepsCount}");
    Console.ReadLine();
}
