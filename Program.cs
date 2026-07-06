using CodeWars;
using static CodeWars.LeetCodeMethods;

var _LeetCodeMethods = new LeetCodeMethods();

Console.WriteLine("Hello, Challenge War!");
int[] x = { 7, 1, 5, 3, 6, 4 };
TreeNode tree = new TreeNode(1, null, new TreeNode(2));

var val = _LeetCodeMethods.HasPathSum(tree, 1);
Console.WriteLine(string.Join(",", val)); 