namespace Solutions;

public static class PalindromeSolutionWithLinked
{
    public static bool IsPalindrome(ListNode head)
    {
        var input = GetDigitsFromNode(head);
        var output = GetDigitsFromNode(head).Reverse();

        using var inputE = input.GetEnumerator();
        using var outputE = output.GetEnumerator();
        while (inputE.MoveNext() && outputE.MoveNext())
        {
            if (inputE.Current != outputE.Current)
            {
                return false;
            }
        }

        return true;

        IEnumerable<ulong> GetDigitsFromNode(ListNode node)
        {
            do
            {
                yield return (ulong) node.Value;
                node = node.Next;
            } while (node != null);
        }
    }
}