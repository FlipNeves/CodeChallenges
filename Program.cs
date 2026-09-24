using CodeChallenges;
using CodeWars;
using static CodeWars.LeetCodeMethods;

var _LeetCodeMethods = new LeetCodeMethods();
var _ConsoleMethods = new ConsoleMethods();
Console.WriteLine("Hello, Challenge War!");
//int[] x = { 3,0,1 };
//TreeNode tree = new TreeNode(1, null, new TreeNode(2));
//ListNode listNode = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5, null))))); //[1,2,3,4,5]
//ListNode listNode = new ListNode(1, new ListNode(0, new ListNode(0, null)));


var val = _LeetCodeMethods.FindDisappearedNumbers([1, 1, 2, 2]);
//var val = _LeetCodeMethods.IsSubsequence("b", "c");
Console.WriteLine(string.Join(",", val));

//_ConsoleMethods.MathOperations(3);