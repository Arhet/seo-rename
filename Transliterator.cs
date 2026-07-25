using System.Text;
using System.Text.RegularExpressions;

namespace SeoRename;

public static class Transliterator
{
    private static readonly Dictionary<char, string> Map = new()
    {
        ['а'] = "a",
        ['б'] = "b",
        ['в'] = "v",
        ['г'] = "g",
        ['д'] = "d",
        ['е'] = "e",
        ['ё'] = "yo",
        ['ж'] = "zh",
        ['з'] = "z",
        ['и'] = "i",
        ['й'] = "y",
        ['к'] = "k",
        ['л'] = "l",
        ['м'] = "m",
        ['н'] = "n",
        ['о'] = "o",
        ['п'] = "p",
        ['р'] = "r",
        ['с'] = "s",
        ['т'] = "t",
        ['у'] = "u",
        ['ф'] = "f",
        ['х'] = "kh",
        ['ц'] = "ts",
        ['ч'] = "ch",
        ['ш'] = "sh",
        ['щ'] = "shch",
        ['ъ'] = "",
        ['ы'] = "y",
        ['ь'] = "",
        ['э'] = "e",
        ['ю'] = "yu",
        ['я'] = "ya"
    };

    public static string SeoName(string fileName)
    {
        string extension = Path.GetExtension(fileName).ToLower();
        string name = Path.GetFileNameWithoutExtension(fileName).ToLower();

        var sb = new StringBuilder();

        foreach (char c in name)
        {
            if (Map.TryGetValue(c, out string? value))
            {
                sb.Append(value);
            }
            else if (char.IsLetterOrDigit(c))
            {
                sb.Append(c);
            }
            else
            {
                sb.Append('-');
            }
        }

        string result = sb.ToString();

        result = Regex.Replace(result, "-{2,}", "-");
        result = result.Trim('-');

        return result + extension;
    }
}