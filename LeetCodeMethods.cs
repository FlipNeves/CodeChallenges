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
            for(int i = 0; i < nums.Length; i++)
            {
                var missingPart = target - nums[i];
                if (result.ContainsKey(missingPart))
                    return new int[] { result[missingPart], i };

                result[ nums[i] ] = i;
            }
            return Array.Empty<int>();
        }
    }
}
