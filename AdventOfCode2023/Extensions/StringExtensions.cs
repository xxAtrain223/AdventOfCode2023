namespace AdventOfCode2023.Extensions;
public static class StringExtensions
{
    public static IEnumerable<string> SplitByLine(this string input)
    {
        using var stream = new StringReader(input);
        string? line = null;

        while (true)
        {
            line = stream.ReadLine();

            if (line != null)
            {
                yield return line;
            }
            else
            {
                yield break;
            }
        }
    }
}
