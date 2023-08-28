namespace Tests.Palindrome;

public class PalindromeSolutionTests
{
    [Theory]
    [InlineData(123, false)]
    [InlineData(121, true)]
    [InlineData(1, true)]
    [InlineData(-1, false)]
    [InlineData(1221, true)]
    public void IsPalindrome(int number, bool isPalindrome)
    {
        var result = PalindromeSolution.IsPalindrome(number);
        Assert.Equal(isPalindrome, result);
    }
}