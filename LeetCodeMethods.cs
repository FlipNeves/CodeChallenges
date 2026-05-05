using System.Globalization;

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

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2) //good solve
        {
            var answerNode = new ListNode(0);
            var current = answerNode;
            var carry = 0;
            while (l1 != null || l2 != null || carry > 0)
            {
                var n1 = l1?.val ?? 0;
                var n2 = l2?.val ?? 0;

                var sum = n1 + n2 + carry;
                var valueToAdd = sum % 10;
                carry = (sum - valueToAdd) / 10;
                current.val = valueToAdd;

                l1 = l1?.next;
                l2 = l2?.next;
                if (l1 == null && l2 == null && carry == 0)
                    break;

                current.next = new ListNode(0);
                current = current.next;
            }

            return answerNode;
        }

        public decimal ParseBudgetTotalValue(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return 0m;

            if (decimal.TryParse(
                value,
                NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign,
                CultureInfo.InvariantCulture,
                out var result))
                return result / 100;

            return 0m;
        }



        /*Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.

Symbol       Value
I             1
V             5
X             10
L             50
C             100
D             500
M             1000
For example, 2 is written as II in Roman numeral, just two ones added together. 12 is written as XII, which is simply X + II. The number 27 is written as XXVII, which is XX + V + II.

Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII. Instead, the number four is written as IV. Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as IX. There are six instances where subtraction is used:

I can be placed before V (5) and X (10) to make 4 and 9. 
X can be placed before L (50) and C (100) to make 40 and 90. 
C can be placed before D (500) and M (1000) to make 400 and 900.
Given a roman numeral, convert it to an integer.
        */

        public int RomanToInt(string s)
        {
            var romanMap = new Dictionary<char, int> { { 'I', 1 }, { 'V', 5 }, { 'X', 10 }, { 'L', 50 }, { 'C', 100 }, { 'D', 500 }, { 'M', 1000 } };
            ReadOnlySpan<char> romanSpan = s.AsSpan();
            var total = 0;
            for (int i = 0; i < romanSpan.Length; i++)
            {
                var currentValue = romanMap[romanSpan[i]];
                var nextValue = (i + 1 < romanSpan.Length) ? romanMap[romanSpan[i + 1]] : 0;
                if (currentValue < nextValue)
                    total -= currentValue;
                else
                    total += currentValue;
            }
            return total;
        }



        /* Write a function to find the longest common prefix string amongst an array of strings.

If there is no common prefix, return an empty string "".

 

Example 1:

Input: strs = ["flower","flow","flight"]
Output: "fl"
Example 2:

Input: strs = ["dog","racecar","car"]
Output: ""
Explanation: There is no common prefix among the input strings.
        */
        public string LongestCommonPrefix(string[] strs)
        {
            var longestPrefix = string.Empty;

            for (int i = 0; i < strs[0].Length; i++)
            {
                char currentChar = strs[0][i];
                if (strs.All(s => s.Length > i && s[i] == currentChar))
                    longestPrefix += currentChar;
                else
                    break;
            }
            return longestPrefix;
        }


        /* Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

An input string is valid if:

Open brackets must be closed by the same type of brackets.
Open brackets must be closed in the correct order.
Every close bracket has a corresponding open bracket of the same type.
        */
        public bool IsValid(string simbols)
        {
            Stack<char> stack = new Stack<char>();
            
            foreach (var simbol in simbols)
            {
                if (simbol == '(' || simbol == '[' || simbol == '{')
                    stack.Push(simbol);
                else
                {
                    if (stack.Count == 0) return false;

                    char top = stack.Pop();

                    if (simbol == ')' && top != '(') return false;
                    if (simbol == ']' && top != '[') return false;
                    if (simbol == '}' && top != '{') return false;
                }
            }
            return stack.Count == 0;
        }


        /*Given an integer x, return true if x is a palindrome, and false otherwise.
         */
        public bool IsPalindrome(int x)
        {
            if (x < 0)
                return false;

            var format = x.ToString().Reverse();
            return format.SequenceEqual(x.ToString());
        }

        public int[] PlusOne(int[] digits)
        {
            var num = int.Parse(string.Join("", digits));
            num++; //core
            var result = new List<int>();
            foreach (var number in num.ToString())
            {
                result.Add(int.Parse(number.ToString()));
            }
            return result.ToArray();
        }
    }
}