using FluentAssertions;
using System.Text.RegularExpressions;

namespace Day8Tests;

public class NodeGraphTests
{
    [Theory]
    [ClassData(typeof(ParseNodeTestData))]
    public void ShouldParseNode(string line, Node expectedNode)
    {
        Node.Parse(line).Should().BeEquivalentTo(expectedNode);
    }

    public class ParseNodeTestData : TheoryData<string, Node>
    {
        public ParseNodeTestData()
        {
            Add("AAA = (BBB, CCC)", new Node("AAA", "BBB", "CCC"));
            Add("BBB = (DDD, EEE)", new Node("BBB", "DDD", "EEE"));
            Add("CCC = (ZZZ, GGG)", new Node("CCC", "ZZZ", "GGG"));
            Add("DDD = (DDD, DDD)", new Node("DDD", "DDD", "DDD"));
            Add("EEE = (EEE, EEE)", new Node("EEE", "EEE", "EEE"));
            Add("GGG = (GGG, GGG)", new Node("GGG", "GGG", "GGG"));
            Add("ZZZ = (ZZZ, ZZZ)", new Node("ZZZ", "ZZZ", "ZZZ"));
        }
    }

    [Fact]
    public void ShouldParseGraph()
    {
        var graph = NodeGraph.Parse([
            "RL",
            "",
            "AAA = (BBB, CCC)",
            "BBB = (DDD, EEE)",
            "CCC = (ZZZ, GGG)",
            "DDD = (DDD, DDD)",
            "EEE = (EEE, EEE)",
            "GGG = (GGG, GGG)",
            "ZZZ = (ZZZ, ZZZ)"
        ]);

        graph.Instructions.Should().Be("RL");
        graph.Nodes.Should().BeEquivalentTo(new Dictionary<string, Node>
        {
            { "AAA", new Node("AAA", "BBB", "CCC") },
            { "BBB", new Node("BBB", "DDD", "EEE") },
            { "CCC", new Node("CCC", "ZZZ", "GGG") },
            { "DDD", new Node("DDD", "DDD", "DDD") },
            { "EEE", new Node("EEE", "EEE", "EEE") },
            { "GGG", new Node("GGG", "GGG", "GGG") },
            { "ZZZ", new Node("ZZZ", "ZZZ", "ZZZ") }
        });
    }

    [Fact]
    public void ShouldFollowInstructions1()
    {
        var graph = NodeGraph.Parse([
            "RL",
            "",
            "AAA = (BBB, CCC)",
            "BBB = (DDD, EEE)",
            "CCC = (ZZZ, GGG)",
            "DDD = (DDD, DDD)",
            "EEE = (EEE, EEE)",
            "GGG = (GGG, GGG)",
            "ZZZ = (ZZZ, ZZZ)"
        ]);

        graph.FollowInstructions().Should().Be(2);
    }

    [Fact]
    public void ShouldFollowInstructions2()
    {
        var graph = NodeGraph.Parse([
            "LLR",
            "",
            "AAA = (BBB, BBB)",
            "BBB = (AAA, ZZZ)",
            "ZZZ = (ZZZ, ZZZ)"
        ]);

        graph.FollowInstructions().Should().Be(6);
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
