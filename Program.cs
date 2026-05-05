using CodeWars;
using static CodeWars.LeetCodeMethods;

var _LeetCodeMethods = new LeetCodeMethods();

Console.WriteLine("Hello, Challenge War!");
var x = new int[] {6, 9, 3}; 
var val = _LeetCodeMethods.TwoSum_2(x, 12);
Console.WriteLine(string.Join(",", val)); 