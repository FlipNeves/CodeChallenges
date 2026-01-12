// See https://aka.ms/new-console-template for more information
using CodeWars;
using Interval = System.ValueTuple<int, int>;

Console.WriteLine("Hello, Challenge War!");
Console.WriteLine(ChallengesMethods.SumIntervals(new Interval[] { (1, 4), (7, 10), (3, 5) }));