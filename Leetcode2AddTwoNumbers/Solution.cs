namespace Leetcode2AddTwoNumbers;

public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        int carry = 0;

        ListNode head = null;
        ListNode current = null;
        while(l1 != null || l2 != null || carry != 0) 
        {
            // the below speeds up the process
            if (l1 == null && l2 == null && carry == 1) 
            {
                ListNode last = new ListNode(1, null);
                current.next = last;
                break;
            }
            
            int a = l1?.val ?? 0;
            int b = l2?.val ?? 0;

            int sum = a + b + carry;

            if (sum >= 10) 
            {
                carry = 1;
                sum -= 10;
            }
            else
            {
                carry = 0;
            }

            ListNode tail = new ListNode(sum, null);

            if (current != null) 
            {
                current.next = tail;
            }
            else 
            {
                head = tail;
            }
            current = tail;

            l1 = (l1 != null) ? l1.next : null;
            l2 = (l2 != null) ? l2.next : null;
        }

        return head;
    }
}