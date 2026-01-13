// See https://aka.ms/new-console-template for more information
using CodeWars;
using Interval = System.ValueTuple<int, int>;

var _LeetCodeMethods = new LeetCodeMethods();

Console.WriteLine("Hello, Challenge War!");
var result = _LeetCodeMethods.TwoSum(new int[] { 2, 7, 11, 15 }, 9);
Console.WriteLine($"[{string.Join(", ", result)}]");