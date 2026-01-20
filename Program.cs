using CodeWars;
using static CodeWars.LeetCodeMethods;

var _LeetCodeMethods = new LeetCodeMethods();

Console.WriteLine("Hello, Challenge War!");
var l1 = new ListNode(9);

var l2 = new ListNode(1,
         new ListNode(9,
         new ListNode(9,
         new ListNode(9,
         new ListNode(9,
         new ListNode(9,
         new ListNode(9,
         new ListNode(9,
         new ListNode(9,
         new ListNode(9))))))))));

Console.WriteLine(_LeetCodeMethods.AddTwoNumbers(l1, l2));