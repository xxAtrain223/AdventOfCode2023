namespace AdventOfCode2023.Day8.Day8Tests;

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
