using System.Collections;

namespace Tests.AddTwoNumbers;

public class AddTwoNumbersGenerator : IEnumerable<object[]>
{
    private readonly Random _random = new(404);
    public static readonly IEqualityComparer<ListNode> Comparer = new Ex.ListNodeComparer();

    public IEnumerator<object[]> GetEnumerator()
    {
        for (var i = 0; i < 99; i++)
        {
            yield return GetData();
        }

        yield return new object[]
        {
            int.MaxValue.ToLinkedNode(),
            int.MaxValue.ToLinkedNode(),
            (int.MaxValue, int.MaxValue).ToLinkedNode()
        };
    }

    private object[] GetData()
    {
        var a = _random.Next();
        var b = _random.Next();
        return new object[] {a.ToLinkedNode(), b.ToLinkedNode(), (a, b).ToLinkedNode()};
    }


    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}