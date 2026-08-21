using CodeWars;
using static CodeWars.LeetCodeMethods;

var _LeetCodeMethods = new LeetCodeMethods();

Console.WriteLine("Hello, Challenge War!");
int[] x = { 3,0,1 };
TreeNode tree = new TreeNode(1, null, new TreeNode(2));
ListNode listNode = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5, null))))); //[1,2,3,4,5]
//ListNode listNode = new ListNode(1, new ListNode(0, new ListNode(0, null)));

var val = _LeetCodeMethods.ReverseList(listNode);
Console.WriteLine(string.Join(",", val)); 