namespace Tests.AddTwoNumbers;

public static class Ex
{
    public class ListNodeComparer : IEqualityComparer<ListNode>
    {
        public bool Equals(ListNode? x, ListNode? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Value == y.Value && Equals(x.Next, y.Next);
        }

        public int GetHashCode(ListNode obj) => HashCode.Combine(obj.Value, obj.Next);
    }

    public static ListNode ToLinkedNode(this int input)
        => input
            .GetDigits()
            .Reverse()
            .Select(x => new ListNode(x)) 
            .Aggregate((x, y) =>
        {
            y.Next = x;
            return y;
        });

    public static ListNode ToLinkedNode(this (int a, int b) input)
    {
        var sum = 0;
        var nodes = new List<ListNode>();
        foreach (var valueTuple in input.ToDigitsPair())
        {
            sum = (valueTuple.a ?? 0) + (valueTuple.b ?? 0) + sum;
            nodes.Add(new ListNode(sum % 10));
            sum /= 10;
        }

        if (sum != 0)
        {
            nodes.Add(new ListNode(sum));
        }

        nodes.Reverse();

        return nodes.Aggregate((x, y) =>
        {
            y.Next = x;
            return y;
        });
    }

    private static IEnumerable<(int? a, int? b)> ToDigitsPair(this (int a, int b) input)
    {
        using var first = input.a.GetDigits().GetEnumerator();
        using var second = input.b.GetDigits().GetEnumerator();
        while (true)
        {
            (int?, int?) result = (first.MoveNext() ? first.Current : null,
                second.MoveNext() ? second.Current : null);
            if (result == default)
            {
                break;
            }

            yield return result;
        }
    }

    private static IEnumerable<int> GetDigits(this int value)
    {
        while (value != 0)
        {
            var remainder = value % 10;
            value /= 10;
            yield return remainder;
        }
    }
}