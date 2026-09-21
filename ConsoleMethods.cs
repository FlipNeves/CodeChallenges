using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenges
{
    public class ConsoleMethods
    {
        /** 
        The software should: 
        ask the user for a number of iterations (n) and then ask the user to input n integer numbers.
        should then display the sum, average, largest number, smallest number, and how many of the numbers are even and how many are odd.
        **/
        public void MathOperations(int iterations)
        {
            var output = new StringBuilder();
            var numbers = new List<int>();

            Console.WriteLine("==================================================");
            Console.WriteLine("||            OPERAÇÕES MATEMÁTICAS             ||");
            Console.WriteLine("==================================================");

            for (int i = 0; i < iterations; i++)
            {
                string message = $"|| Digite o {i + 1}º número: ";

                Console.Write(message);

                string input = Console.ReadLine() ?? string.Empty;
                int.TryParse(input, out int result);

                numbers.Add(result);

                Console.SetCursorPosition(0, Console.CursorTop - 1);

                Console.WriteLine($"{message}{input,-25}||");
            }

            Console.WriteLine("==================================================");

            var sum = SumOperations(numbers);
            var average = AverageOperations(sum, iterations);
            var bigger = BiggerNumber(numbers);
            var smaller = SmallerNumber(numbers);
            var (even, odd) = EvenOddCounter(numbers);

            output.AppendLine();
            output.AppendLine("==================================================");
            output.AppendLine("||                 RESULTADOS                   ||");
            output.AppendLine("==================================================");
            output.AppendLine("|| Operação               || Valor              ||");
            output.AppendLine("==================================================");
            output.AppendLine($"|| Soma                   || {sum,-19}||");
            output.AppendLine($"|| Média                  || {average,-19}||");
            output.AppendLine($"|| Menor número           || {smaller,-19}||");
            output.AppendLine($"|| Maior número           || {bigger,-19}||");
            output.AppendLine($"|| Números pares          || {even,-19}||");
            output.AppendLine($"|| Números ímpares        || {odd,-19}||");
            output.AppendLine("==================================================");

            Console.WriteLine(output.ToString());
        }

        private (int even, int odd) EvenOddCounter(List<int> numbers)
            => (numbers.Count(n => n % 2 == 0),
                numbers.Count(n => n % 2 != 0));

        private int SmallerNumber(List<int> numbers)
        {
            if (numbers.Count() == 0)
                return 0;
            return numbers.OrderByDescending(x => x).LastOrDefault();
        }

        private int BiggerNumber(List<int> numbers)
        {
            if (numbers.Count() == 0)
                return 0;
            return numbers.OrderByDescending(x => x).FirstOrDefault();
        }

        private decimal AverageOperations(int sum, int interations)
        {
            if (interations == 0)
                return 0;
            return sum / interations;
        }

        private int SumOperations(List<int> numbers) => numbers.Sum();
    }
}
