using Tests.AddTwoNumbers;

namespace Tests.Palindrome;

public class PalindromeWithLinkedSolutionTests
{
    [Theory]
    [InlineData(123, false)]
    [InlineData(121, true)]
    [InlineData(1, true)]
    [InlineData(1221, true)]
    public void IsPalindromeLinked(int number, bool isPalindrome)
    {
        var result = PalindromeSolutionWithLinked.IsPalindrome(number.ToLinkedNode());
        Assert.Equal(isPalindrome, result);
    }


    [Theory]
    [InlineData(123, false)]
    [InlineData(121, true)]
    [InlineData(1, true)]
    [InlineData(1221, true)]
    [InlineData(123321, true)]
    [InlineData(12, false)]
    [InlineData(1121, false)]
    [InlineData(112331, false)]
    public void IsPalindromeLinkedRecursive(int number, bool isPalindrome)
    {
        var result = PalindromeSolutionWithLinkedRecursive.IsPalindromeRecursive(number.ToLinkedNode());
        Assert.Equal(isPalindrome, result);
    }
}