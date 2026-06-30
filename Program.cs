using CodeWars;
using static CodeWars.LeetCodeMethods;

var _LeetCodeMethods = new LeetCodeMethods();

Console.WriteLine("Hello, Challenge War!");
var x = new TreeNode(1, new TreeNode(2));
var y = new TreeNode(1, null, new TreeNode(2));

var val = _LeetCodeMethods.MaxDepth(y);
Console.WriteLine(string.Join(",", val)); 