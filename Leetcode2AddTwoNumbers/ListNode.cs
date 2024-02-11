namespace Leetcode2AddTwoNumbers;
public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null) {
        this.val = val;
        this.next = next;
    }

    public static ListNode FromArray(int[] n1)
    {
        ListNode head = null;
        ListNode current = null;
        foreach (var n in n1)
        {
            ListNode tail = new ListNode(n, null);
            if (current != null)
            {
                current.next = tail;
            }
            else
            {
                head = tail;
            }
            current = tail;
        }
        return head;
    }

    public int[] ToArray()
    {
        List<int> result = new();
        ListNode current = this;
        while (current != null)
        {
            result.Add(current.val);
            current = current.next;
        }
        return result.ToArray();
    }
}