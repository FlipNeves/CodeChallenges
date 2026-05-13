using CodeWars;
using static CodeWars.LeetCodeMethods;

var _LeetCodeMethods = new LeetCodeMethods();

Console.WriteLine("Hello, Challenge War!");
var x = new int[] {6, 9, 3}; 
var val = _LeetCodeMethods.DeleteDuplicates(new ListNode(1, new ListNode(1, new ListNode(3))));
Console.WriteLine(string.Join(",", val)); 