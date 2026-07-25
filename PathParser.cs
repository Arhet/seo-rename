using System.Text.RegularExpressions;

namespace SeoRename;

public static class PathParser
{
    public static List<string> Parse(string input)
    {
        List<string> paths = new();

        MatchCollection matches = Regex.Matches(input, "\"([^\"]+)\"");

        if (matches.Count > 0)
        {
            foreach (Match match in matches)
            {
                paths.Add(match.Groups[1].Value);
            }
        }
        else
        {
            paths.Add(input.Trim());
        }

        return paths;
    }
}