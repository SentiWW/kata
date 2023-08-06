using System.Text;

namespace CSharp;

public class BreakCamelCase
{
    public static string Break(string @string)
    {
        var brokenStringBuilder = new StringBuilder();

        foreach (var @char in @string)
        {
            if (char.IsUpper(@char))
                brokenStringBuilder.Append(' ');
                
            brokenStringBuilder.Append(@char);
        }
        
        return brokenStringBuilder.ToString();
    }
}