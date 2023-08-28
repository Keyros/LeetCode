namespace Solutions;

public static class PalindromeSolution
{
    public static bool IsPalindrome(int x)
    {
        switch (x)
        {
            case < 0:
                return false;
            case < 10:
                return true;
        }

        var value = x;
        var reversed = 0;
        while (value != 0)
        {
            reversed = reversed * 10 + value % 10;
            value /= 10;
        }

        return reversed == x;
    }
    
}