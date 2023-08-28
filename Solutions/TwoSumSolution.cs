namespace Solutions;

public static class TwoSumSolution
{
    public static IEnumerable<int> TwoSumSimple(int[] array, int target)
    {
        for (var i = 0; i < array.Length; i++)
        {
            for (var j = 0; j < array.Length; j++)
            {
                if (array[i] + array[j] == target)
                {
                    return new[] {i, j};
                }
            }
        }

        return Array.Empty<int>();
    }

    public static IEnumerable<int> TwoSumOnePath(int[] array, int target)
    {
        var dictionary = new Dictionary<int, int>(array.Length);
        for (var i = 0; i < array.Length; i++)
        {
            if (dictionary.TryGetValue(target - array[i], out var item))
            {
                return new[] {i, item};
            }

            dictionary[array[i]] = i;
        }

        return Array.Empty<int>();
    }
}