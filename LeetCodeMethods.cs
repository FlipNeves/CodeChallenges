namespace CodeWars
{
    public class LeetCodeMethods
    {
        /*Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

You may assume that each input would have exactly one solution, and you may not use the same element twice.

You can return the answer in any order.*/
        public int[] TwoSum(int[] nums, int target)
        {
            var result = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var missingPart = target - nums[i];
                if (result.ContainsKey(missingPart))
                    return new int[] { result[missingPart], i };

                result[nums[i]] = i;
            }
            return Array.Empty<int>();
        }


        /*A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.

Given a string s, return true if it is a palindrome, or false otherwise.

 

Example 1:

Input: s = "A man, a plan, a canal: Panama"
Output: true
Explanation: "amanaplanacanalpanama" is a palindrome.
Example 2:

Input: s = "race a car"
Output: false
Explanation: "raceacar" is not a palindrome.
Example 3:

Input: s = " "
Output: true
Explanation: s is an empty string "" after removing non-alphanumeric characters.
Since an empty string reads the same forward and backward, it is a palindrome.
 

Constraints:

1 <= s.length <= 2 * 105
s consists only of printable ASCII characters.*/
        public bool IsPalindrome(string s)
        {
            var normalized = new string(s.Where(c => char.IsLetterOrDigit(c)).ToArray()).ToLower();
            return normalized.SequenceEqual(normalized.Reverse().ToArray());
        }


        /*Given a string s, partition s such that every substring of the partition is a palindrome. Return all possible palindrome partitioning of s.

Example 1:

Input: s = "aab"
Output: [["a","a","b"],["aa","b"]]
Example 2:

Input: s = "a"
Output: [["a"]]
 

Constraints:

1 <= s.length <= 16
s contains only lowercase English letters.*/
        public IList<IList<string>> Partition(string s)
        {
            var result = new List<IList<string>>();
            Backtrack(s, 0, new List<string>(), result);
            return result;
        }
        private void Backtrack(string s, int v, List<string> list, List<IList<string>> result)
        {
            if (v == s.Length)
            {
                result.Add(new List<string>(list));
                return;
            }
            for (int i = v; i < s.Length; i++)
            {
                var substring = s[v..(i + 1)];
                if (IsPalindrome(substring))
                {
                    list.Add(substring);
                    Backtrack(s, i + 1, list, result);
                    list.RemoveAt(list.Count - 1);
                }
            }
        }


        /*You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.

You may assume the two numbers do not contain any leading zero, except the number 0 itself.
        
Input: l1 = [2,4,3], l2 = [5,6,4]
Output: [7,0,8]
Explanation: 342 + 465 = 807.
Example 2:

Input: l1 = [0], l2 = [0]
Output: [0]
Example 3:

Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
Output: [8,9,9,9,0,0,0,1]
         */
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
        //It`s valid, but it`s not optimal solution due to Int128 usage.
        public ListNode AddTwoNumbersBadSolve(ListNode l1, ListNode l2)
        {
            var n1 = ParseToReverseIntBadSolve(l1);
            var n2 = ParseToReverseIntBadSolve(l2);

            Int128 sum = n1 + n2;
            var sumArray = sum.ToString().Select(c => int.Parse(c.ToString())).Reverse().ToArray();

            ListNode head = null;
            ListNode current = null;

            foreach (var number in sumArray)
            {
                var newNode = new ListNode(number);
                if (head == null)
                {
                    head = newNode;
                    current = newNode;
                }
                else
                {
                    current.next = newNode;
                    current = newNode;
                }
            }

            return head;
        }
        private static Int128 ParseToReverseIntBadSolve(ListNode listNode)
        {
            var values = new List<int>();
            while (listNode != null)
            {
                values.Add(listNode.val);
                listNode = listNode.next;
            }
            values.Reverse();
            return Int128.Parse(string.Concat(values));
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var answerNode = new ListNode(0);
            var current = answerNode;
            var carry = 0;
            while (l1 != null || l2 != null)
            {
                var n1 = l1?.val ?? 0;
                var n2 = l2?.val ?? 0;

                var sum = n1 + n2 + carry;
                var valueToAdd = sum % 10;
                carry = (sum - valueToAdd) / 10;
                current.val += valueToAdd;

                l1 = l1?.next;
                l2 = l2?.next;
                if (l1 == null && l2 == null && carry == 0)
                    break;

                current.next = new ListNode(0);
                current = current.next;
            }

            return answerNode;
        }
    }
}
