// See https://aka.ms/new-console-template for more information
using CodeWars;
using Interval = System.ValueTuple<int, int>;

var _LeetCodeMethods = new LeetCodeMethods();

Console.WriteLine("Hello, Challenge War!");
var result = _LeetCodeMethods.IsPalindrome("A man, a plan, a canal: Panama");
Console.WriteLine(result);