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
    }
}
