using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day8.Day8Tests;

public class NodeGraph
{
    public string Instructions { get; private set; } = default!;
    public Dictionary<string, Node> Nodes { get; private set; } = [];

    public static NodeGraph Parse(IEnumerable<string> lines)
    {
        var graph = new NodeGraph
        {
            Instructions = lines.First()
        };

        foreach (var line in lines)
        {
            var node = Node.Parse(line);
            if (node is not null)
            {
                graph.Nodes.Add(node.NodeID, node);
            }
        }

        return graph;
    }

    public int FollowInstructions()
    {
        var stepsCounter = 0;
        var instructionIndex = 0;
        var currentNode = Nodes["AAA"];

        while (currentNode.NodeID != "ZZZ")
        {
            if (Instructions[instructionIndex] == 'L')
            {
                currentNode = Nodes[currentNode.LeftID];
            }
            else if (Instructions[instructionIndex] == 'R')
            {
                currentNode = Nodes[currentNode.RightID];
            }
            else
            {
                throw new Exception($"Invalid instruction at index {instructionIndex}");
            }

            instructionIndex = (instructionIndex + 1) % Instructions.Length;
            stepsCounter++;
        }

        return stepsCounter;
    }
}

public partial record Node(string NodeID, string LeftID, string RightID)
{
    public static Node? Parse(string line)
    {
        var match = NodeRegex().Match(line);

        if (match.Success == false)
        {
            return null;
        }

        return new Node(
            match.Groups[1].Value,
            match.Groups[2].Value,
            match.Groups[3].Value);
    }

    [GeneratedRegex(@"(\w+) = \((\w+), (\w+)\)")]
    private static partial Regex NodeRegex();
}
