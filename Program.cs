using CodeWars;
using static CodeWars.LeetCodeMethods;

var _LeetCodeMethods = new LeetCodeMethods();

Console.WriteLine("Hello, Challenge War!");
int[] x = { 7, 1, 5, 3, 6, 4 };

var val = _LeetCodeMethods.MaxProfit(x);
Console.WriteLine(string.Join(",", val)); 