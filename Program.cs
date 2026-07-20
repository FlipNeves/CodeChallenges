using CodeWars;
using static CodeWars.LeetCodeMethods;

var _LeetCodeMethods = new LeetCodeMethods();

Console.WriteLine("Hello, Challenge War!")
int[] x = { 0,1 };
TreeNode tree = new TreeNode(1, null, new TreeNode(2));

var val = _LeetCodeMethods.MissingNumber(x);
Console.WriteLine(string.Join(",", val)); 