namespace Tests.TwoSum;

public class TwoSumSolutionTests
{
    [Theory]
    [ClassData(typeof(TwoSumDataGenerator))]
    public void TwoSumOnePath(int[] array, int target)
    {
        var indexes = TwoSumSolution.TwoSumOnePath(array, target);
        var result = indexes.Select(x => array[x]).Sum();
        Assert.Equal(result, target);
    }

    [Theory]
    [ClassData(typeof(TwoSumDataGenerator))]
    public void TwoSumSimple(int[] array, int target)
    {
        var indexes = TwoSumSolution.TwoSumSimple(array, target);
        var result = indexes.Select(x => array[x]).Sum();
        Assert.Equal(result, target);
    }
}