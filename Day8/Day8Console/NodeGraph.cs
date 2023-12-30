using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day8.Day8Console;

public class NodeGraph
{
    public string Instructions { get; private set; } = default!;
    public Dictionary<string, Node> Nodes { get; private set; } = [];

    public static NodeGraph Parse(FileInfo file) =>
        Parse(File.ReadLines(file.FullName));

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

    public long FollowInstructions(string startNodeID, Func<Node, bool> shouldLoop)
    {
        long stepsCounter = 0;
        var instructionIndex = 0;
        var currentNode = Nodes[startNodeID];

        while (shouldLoop(currentNode) == true)
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

    public IEnumerable<Node> GetStartNodes() => Nodes.Values.Where(n => n.NodeID.EndsWith('A'));

    public long GetCycleLength(string nodeID) => FollowInstructions(nodeID, n => n.NodeID.EndsWith('Z') == false);

    public long FollowInstructionsGhostMode() =>
        LeastCommonMultiple(GetStartNodes().Select(n => GetCycleLength(n.NodeID)));

    // https://stackoverflow.com/questions/147515/least-common-multiple-for-3-or-more-numbers
    private static long LeastCommonMultiple(IEnumerable<long> numbers) =>
        numbers.Aggregate(LeastCommonMultiple);

    private static long LeastCommonMultiple(long a, long b) =>
        (a / GreatestCommonDivisor(a, b)) * b;

    private static long GreatestCommonDivisor(long a, long b) =>
        b == 0 ? a : GreatestCommonDivisor(b, a % b);
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
