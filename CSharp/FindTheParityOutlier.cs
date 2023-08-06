namespace CSharp;

public class FindTheParityOutlier
{
    private enum ArrayParity
    {
        Unknown,
        Even,
        Odd
    }
    
    public static int Find(int[] integers)
    {
        int? even = null;
        int? odd = null;
        var arrayParity = ArrayParity.Unknown; 

        foreach (var integer in integers)
        {
            if (integer % 2 == 0)
            {
                if (arrayParity is ArrayParity.Odd)
                    return integer;
                    
                if (even is not null)
                    arrayParity = ArrayParity.Even;
                    
                even = integer;
            }
            else
            {
                if (arrayParity is ArrayParity.Even)
                    return integer;
                
                if (odd is not null)
                    arrayParity = ArrayParity.Odd;
                
                odd = integer;   
            }
        }

        return arrayParity switch
        {
            ArrayParity.Even => odd ?? 0,
            ArrayParity.Odd => even ?? 0,
            _ => 0
        };
    }
}