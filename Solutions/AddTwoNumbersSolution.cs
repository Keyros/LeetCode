namespace Solutions;

public class ListNode
{
    public int Value { get; set; } 
    public ListNode Next { get; set; }

    public ListNode(int value = 0, ListNode next = null)
    {
        Value = value;
        Next = next;
    }

    public override string ToString()
        => Next == null ? Value.ToString() : $"{Value}{Next}";
}


public static class SolutionAddTwoNumbers
{
    public static ListNode AddTwoNumbersSimple(ListNode left, ListNode right)
    {
        var stack = new Stack<ulong>();
        do
        {
            stack.Push((ulong) left.Value);
            left = left.Next;
        } while (left != null);

        ulong firstNumber = 0;
        while (stack.Count != 0)
        {
            firstNumber = firstNumber * 10 + stack.Pop();
        }

        do
        {
            stack.Push((ulong) right.Value);
            right = right.Next;
        } while (right != null);

        ulong secondNumber = 0;
        while (stack.Count != 0)
        {
            secondNumber = secondNumber * 10 + stack.Pop();
        }

        var result = firstNumber + secondNumber;

        var resultNode = new ListNode();
        var last = resultNode;

        while (result != 0)
        {
            var remainder = result % 10;
            last.Value = (int) remainder;
            result /= 10;
            if (result != 0)
            {
                last.Next = new ListNode();
                last = last.Next;
            }
        }


        return resultNode;
    }

    public static ListNode AddTwoNumbersSimpleRefactored(ListNode left, ListNode right)
    {
        var firstNumber = GetNumber(left);
        var secondNumber = GetNumber(right);
        var result = firstNumber + secondNumber;
        return ToLinkedNode(result);

        ulong GetNumber(ListNode input)
        {
            var stack = new Stack<ulong>();
            do
            {
                stack.Push((ulong) input.Value);
                input = input.Next;
            } while (input != null);

            ulong number = 0;
            while (stack.Count != 0)
            {
                number = number * 10 + stack.Pop();
            }

            return number;
        }

        ListNode ToLinkedNode(ulong input)
        {
            var resultNode = new ListNode();
            var last = resultNode;

            while (input != 0)
            {
                var remainder = input % 10;
                last.Value = (int) remainder;
                input /= 10;
                if (input != 0)
                {
                    last.Next = new ListNode();
                    last = last.Next;
                }
            }

            return resultNode;
        }
    }

    public static ListNode AddTwoNumbersLinqWithReverse(ListNode left, ListNode right)
    {
        var firstNumber = GetNumber(left);
        var secondNumber = GetNumber(right);
        var result = firstNumber + secondNumber;
        return ToLinkedNode(result);


        ulong GetNumber(ListNode input)
            => GetDigitsFromNode(input).Reverse().Aggregate((x, y) => x * 10 + y);

        IEnumerable<ulong> GetDigitsFromNode(ListNode input)
        {
            do
            {
                yield return (ulong) input.Value;
                input = input.Next;
            } while (input != null);
        }

        ListNode ToLinkedNode(ulong input) //123
            => GetDigitsFromNumber(input) //321
                .Reverse() //123
                .Select(x => new ListNode(x))
                .Aggregate((prev, current) =>
                {
                    current.Next = prev;
                    return current;
                });

        IEnumerable<int> GetDigitsFromNumber(ulong input)
        {
            while (input != 0)
            {
                var remainder = input % 10;
                input /= 10;
                yield return (int) remainder;
            }
        }
    }

    public static ListNode AddTwoNumbersLinq(ListNode left, ListNode right)
    {
        var firstNumber = GetNumber(left);
        var secondNumber = GetNumber(right);
        var result = firstNumber + secondNumber;
        return ToLinkedNode(result);

        ulong GetNumber(ListNode input)
            => GetDigitsFromNode(input).Reverse().Aggregate((x, y) => x * 10 + y);

        IEnumerable<ulong> GetDigitsFromNode(ListNode input)
        {
            do
            {
                yield return (ulong) input.Value;
                input = input.Next;
            } while (input != null);
        }

        ListNode ToLinkedNode(ulong input) //123
            => GetDigitsFromNumber(input) //321
                .Select(x => new ListNode(x))
                .Aggregate((prev, current) =>
                {
                    var tmp = prev;
                    while (tmp.Next != null)
                    {
                        tmp = tmp.Next;
                    }

                    tmp.Next = current;
                    return prev;
                });

        IEnumerable<int> GetDigitsFromNumber(ulong input)
        {
            while (input != 0)
            {
                var remainder = input % 10;
                input /= 10;
                yield return (int) remainder;
            }
        }
    }

    public static ListNode AddTwoNumbersManualSumLinq(ListNode left, ListNode right)
    {
        return ManualSum(GetDigitsFromNode(left), GetDigitsFromNode(right))
            .Select(x => new ListNode(x))
            .Reverse()
            .Aggregate((prev, current) =>
            {
                current.Next = prev;
                return current;
            });


        IEnumerable<int> ManualSum(IEnumerable<int> firstInput, IEnumerable<int> secondInput)
        {
            using var first = firstInput.GetEnumerator();
            using var second = secondInput.GetEnumerator();
            var sum = 0;
            var firstHasItems = first.MoveNext();
            var secondHasItems = second.MoveNext();
            while (firstHasItems || secondHasItems)
            {
                sum = (firstHasItems ? first.Current : 0) + (secondHasItems ? second.Current : 0) + sum;
                yield return sum % 10;
                sum /= 10;
                firstHasItems = first.MoveNext();
                secondHasItems = second.MoveNext();
            }

            if (sum != 0)
            {
                yield return sum;
            }
        }

        IEnumerable<int> GetDigitsFromNode(ListNode input)
        {
            do
            {
                yield return input.Value;
                input = input.Next;
            } while (input != null);
        }
    }

    public static ListNode AddTwoNumbersManualSum(ListNode left, ListNode right)
    {
        var head = new ListNode();
        var sum = 0;
        var next = head;
        while (left != null || right != null)
        {
            sum = (left?.Value ?? 0) + (right?.Value ?? 0) + sum;
            next.Next = new ListNode(sum % 10);
            next = next.Next;
            sum /= 10;
            left = left?.Next;
            right = right?.Next;
        }

        if (sum != 0)
        {
            next.Next = new ListNode(sum);
        }

        return head.Next;
    }
}