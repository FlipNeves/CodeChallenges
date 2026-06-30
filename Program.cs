using CodeWars;
using static CodeWars.LeetCodeMethods;

var _LeetCodeMethods = new LeetCodeMethods();

Console.WriteLine("Hello, Challenge War!");
var x = new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15, new TreeNode(7))));
var y = new TreeNode(val: 2, left: null, right: new TreeNode(3, null, new TreeNode(4, null, new TreeNode(5, null, new TreeNode(6)))));

var val = _LeetCodeMethods.MinDepth(x);
Console.WriteLine(string.Join(",", val)); 