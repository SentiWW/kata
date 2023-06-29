namespace CSharp;

public class DecimalTimeConversion
{
    public static float ToIndustrial(dynamic time) =>
        time switch
        {
            string timeString => ToIndustrialFromString(timeString),
            int timeInt => ToIndustrialFromInt(timeInt),
            _ => throw new ArgumentOutOfRangeException()
        };
    
    private static float ToIndustrialFromString(ReadOnlySpan<char> time)
    {
        var separatorIndex = time.IndexOf(':');
        var hourPartOpt = time.Slice(0, separatorIndex);
        var minutePartOpt = time.Slice(separatorIndex + 1, time.Length - separatorIndex - 1);
        
        var hourPart = int.Parse(hourPartOpt);
        var minutePart = int.Parse(minutePartOpt);

        var decimalMinutes = Math.Round(minutePart / 60f, 2);
        
        return (float)(hourPart + decimalMinutes);
    }
    
    private static float ToIndustrialFromInt(int timeInt)
    {
        var hours = Math.Floor(timeInt / 60f);
        var minutes = timeInt - hours * 60;

        var decimalMinutes = Math.Round(minutes / 60f, 2);

        return (float)(hours + decimalMinutes);
    }
    
    public static string ToNormal(float time)
    {
        var hours = Math.Floor(time);
        var decimalMinutes = time - hours;

        var minutes = Math.Round(60 * decimalMinutes, 0);  
            
        return $"{hours}:{minutes:00}";
    }
}