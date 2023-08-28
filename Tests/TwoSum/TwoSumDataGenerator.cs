using System.Collections;

namespace Tests.TwoSum;

public class TwoSumDataGenerator : IEnumerable<object[]>
{
    private readonly Random _random = new(404);

    public IEnumerator<object[]> GetEnumerator()
    {
        for (var i = 0; i < 5; i++)
        {
            yield return GetData(i + 1);
        }
    }

    private object[] GetData(int run)
    {
        var array = CreateArray(run);
        var target = GetTarget(array);
        return new object[] {array, target};
    }

    private int GetTarget(IReadOnlyList<int> array)
    {
        var size = array.Count;
        var firstIndex = _random.Next(0, size);

        var secondIndex = _random.Next(0, size);
        while (secondIndex == firstIndex)
        {
            secondIndex = _random.Next(0, size);
        }

        return array[firstIndex] + array[secondIndex];
    }

    private int[] CreateArray(int run)
    {
        var size = GetSize(run);
        var array = new int[size];
        for (var i = 0; i < array.Length; i++)
        {
            array[i] = i;
        }

        return Shuffle(array);
    }

    private int[] Shuffle(int[] array)
    {
        var size = array.Length;
        for (var i = 0; i < size; i++)
        {
            var j = _random.Next(0, size);
            (array[i], array[j]) = (array[j], array[i]);
        }

        return array;
    }

    private static int GetSize(int run) => run * 100;

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}