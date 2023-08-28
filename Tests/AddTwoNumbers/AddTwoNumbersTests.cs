namespace Tests.AddTwoNumbers;

public class AddTwoNumbersTests
{
    [Theory]
    [ClassData(typeof(AddTwoNumbersGenerator))]
    public void AddTwoNumbersSimple(ListNode first, ListNode second,
        ListNode excepted)
    {
        var result = SolutionAddTwoNumbers.AddTwoNumbersSimple(first, second);
        Assert.Equal(excepted, result, AddTwoNumbersGenerator.Comparer);
    }
    
    [Theory]
    [ClassData(typeof(AddTwoNumbersGenerator))]
    public void AddTwoNumbersSimpleRefactored(ListNode first, ListNode second,
        ListNode excepted)
    {
        var result = SolutionAddTwoNumbers.AddTwoNumbersSimpleRefactored(first, second);
        Assert.Equal(excepted, result, AddTwoNumbersGenerator.Comparer);
    }

    [Theory]
    [ClassData(typeof(AddTwoNumbersGenerator))]
    public void AddTwoNumbersLinq(ListNode first, ListNode second,
        ListNode excepted)
    {
        var result = SolutionAddTwoNumbers.AddTwoNumbersLinq(first, second);
        Assert.Equal(excepted, result, AddTwoNumbersGenerator.Comparer);
    }

    [Theory]
    [ClassData(typeof(AddTwoNumbersGenerator))]
    public void AddTwoNumbersLinqWithReverse(ListNode first, ListNode second,
        ListNode excepted)
    {
        var result = SolutionAddTwoNumbers.AddTwoNumbersLinqWithReverse(first, second);
        Assert.Equal(excepted, result, AddTwoNumbersGenerator.Comparer);
    }

    [Theory]
    [ClassData(typeof(AddTwoNumbersGenerator))]
    public void AddTwoNumbersManualSumLinq(ListNode first, ListNode second,
        ListNode excepted)
    {
        var result = SolutionAddTwoNumbers.AddTwoNumbersManualSumLinq(first, second);
        Assert.Equal(excepted, result, AddTwoNumbersGenerator.Comparer);
    }

    [Theory]
    [ClassData(typeof(AddTwoNumbersGenerator))]
    public void AddTwoNumbersManualSum(ListNode first, ListNode second,
        ListNode excepted)
    {
        var result = SolutionAddTwoNumbers.AddTwoNumbersManualSum(first, second);
        Assert.Equal(excepted, result, AddTwoNumbersGenerator.Comparer);
    }
}