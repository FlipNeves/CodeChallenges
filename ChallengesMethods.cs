namespace CodeWars
{
    public static class ChallengesMethods
    {


        /*Write a function, which takes a non-negative integer (seconds) as input and returns the time in a human-readable format (HH:MM:SS)

        HH = hours, padded to 2 digits, range: 00 - 99
        MM = minutes, padded to 2 digits, range: 00 - 59
        SS = seconds, padded to 2 digits, range: 00 - 59
        The maximum time never exceeds 359999 (99:59:59)

        You can find some examples in the test fixtures.*/

        public static string GetReadableTime(int seconds)
        {
            var horas = 0;
            var minutos = 0;
            var segundos = 0;

            var data = DateTime.MinValue;
            var readableTime = data.AddSeconds(seconds);
            segundos = readableTime.Second;
            minutos = readableTime.Minute;
            horas = readableTime.Hour;
            if (readableTime.Day != data.Day)
            {
                var extraHours = (readableTime - data).Days * 24;
                horas += extraHours;
            }
            return $"{horas}:{minutos}:{segundos}";
        }
        public static string GetReadableTime2(int seconds)
        {
            var horas = 0;
            var minutos = 0;
            var segundos = 0;

            while (seconds > 0)
            {
                if (seconds > 3600)
                {
                    horas++;
                    seconds -= 3600;
                }
                if (seconds >= 60 && seconds < 3600)
                {
                    minutos++;
                    seconds -= 60;
                }
                if (seconds < 60)
                {
                    segundos = seconds;
                    seconds = 0;
                }
            }

            return $"{horas.ToString("00")}:{minutos.ToString("00")}:{segundos.ToString("00")}";
        }


        /*Você recebe um nó que é o início de uma lista vinculada. Esta lista contém uma peça pendurada e um loop. Seu objetivo é determinar o comprimento do loop.

        Por exemplo, na imagem a seguir, o tamanho da peça pendurada é 3 e o tamanho do laço é 12*/
        public class Node
        {
            public int Value { get; }
            public Node Next { get; set; }

            public Node(int value)
            {
                Value = value;
                Next = null;
            }
        }
        public static int getLoopSize(Node startNode)
        {
            Node slow = startNode;
            Node fast = startNode;

            do
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }
            while (slow != fast);

            int loopSize = 1;
            Node current = slow.Next;

            while (current != slow)
            {
                loopSize++;
                current = current.Next;
            }

            return loopSize;
        }


        /* Once upon a time, on a way through the old wild mountainous west,…
… a man was given directions to go from one point to another. The directions were "NORTH", "SOUTH", "WEST", "EAST". Clearly "NORTH" and "SOUTH" are opposite, "WEST" and "EAST" too.

Going to one direction and coming back the opposite direction right away is a needless effort. Since this is the wild west, with dreadful weather and not much water, it's important to save yourself some energy, otherwise you might die of thirst!

How I crossed a mountainous desert the smart way.
The directions given to the man are, for example, the following (depending on the language):

["NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "WEST"].
or
{ "NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "WEST" };
or
[North, South, South, East, West, North, West]
You can immediately see that going "NORTH" and immediately "SOUTH" is not reasonable, better stay to the same place! So the task is to give to the man a simplified version of the plan. A better plan in this case is simply:

["WEST"]
or
{ "WEST" }
or
[West]
Other examples:
In ["NORTH", "SOUTH", "EAST", "WEST"], the direction "NORTH" + "SOUTH" is going north and coming back right away.

The path becomes ["EAST", "WEST"], now "EAST" and "WEST" annihilate each other, therefore, the final result is [] (nil in Clojure).

In ["NORTH", "EAST", "WEST", "SOUTH", "WEST", "WEST"], "NORTH" and "SOUTH" are not directly opposite but they become directly opposite after the reduction of "EAST" and "WEST" so the whole path is reducible to ["WEST", "WEST"].

Task
Write a function dirReduc which will take an array of strings and returns an array of strings with the needless directions removed (W<->E or S<->N side by side).

The Haskell version takes a list of directions with data Direction = North | East | West | South.
The Clojure version returns nil when the path is reduced to nothing.
The Rust version takes a slice of enum Direction {North, East, West, South}.
The OCaml version takes a list of type direction = | North | South | East | West.
See more examples in "Sample Tests:"
Notes
Not all paths can be made simpler. The path ["NORTH", "WEST", "SOUTH", "EAST"] is not reducible. "NORTH" and "WEST", "WEST" and "SOUTH", "SOUTH" and "EAST" are not directly opposite of each other and can't become such. Hence the result path is itself : ["NORTH", "WEST", "SOUTH", "EAST"]. */
        public static string[] DirReduc(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                var currDir = arr[i];
                var lastDir = string.Empty;
                if (i != 0)
                    lastDir = arr[i - 1];

                bool opposite = currDir switch
                {
                    "NORTH" => lastDir == "SOUTH",
                    "SOUTH" => lastDir == "NORTH",
                    "WEST" => lastDir == "EAST",
                    "EAST" => lastDir == "WEST",
                    _ => false
                };
                if (opposite)
                {
                    arr = arr.Where((source, index) => index != i && index != i - 1).ToArray();
                    i = 0;
                }
            }

            return arr;
        }


        /*In this kata we want to convert a string into an integer. The strings simply represent the numbers in words.

Examples:

"one" => 1
"twenty" => 20
"two hundred forty-six" => 246
"seven hundred eighty-three thousand nine hundred and nineteen" => 783919
Additional Notes:

The minimum number is "zero" (inclusively)
The maximum number, which must be supported is 1 million (inclusively)
The "and" in e.g. "one hundred and twenty-four" is optional, in some cases it's present and in others it's not
All tested numbers are valid, you don't need to validate them*/
        private static readonly Dictionary<string, int> Values = new()
        {
            // units
            ["zero"] = 0,
            ["one"] = 1,
            ["two"] = 2,
            ["three"] = 3,
            ["four"] = 4,
            ["five"] = 5,
            ["six"] = 6,
            ["seven"] = 7,
            ["eight"] = 8,
            ["nine"] = 9,

            // 10–19
            ["ten"] = 10,
            ["eleven"] = 11,
            ["twelve"] = 12,
            ["thirteen"] = 13,
            ["fourteen"] = 14,
            ["fifteen"] = 15,
            ["sixteen"] = 16,
            ["seventeen"] = 17,
            ["eighteen"] = 18,
            ["nineteen"] = 19,

            // tens
            ["twenty"] = 20,
            ["thirty"] = 30,
            ["forty"] = 40,
            ["fifty"] = 50,
            ["sixty"] = 60,
            ["seventy"] = 70,
            ["eighty"] = 80,
            ["ninety"] = 90
        };
        private static readonly Dictionary<string, int> Multipliers = new()
        {
            ["hundred"] = 100,
            ["thousand"] = 1000,
            ["million"] = 1000000
        };
        public static int ParseInt(string s)
        {
            var words = s.Replace("-", " ").Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int total = 0;
            int current = 0;
            foreach (var word in words)
            {
                if (word == "and")
                    continue;

                if (Multipliers.TryGetValue(word, out int multiplier))
                {
                    current *= multiplier;
                    if (multiplier >= 1000)
                    {
                        total += current;
                        current = 0;
                    }
                }
                else if (Values.TryGetValue(word, out int value))
                    current += value;
            }
            return total + current;
        }


        /*Implement a function that receives two IPv4 addresses, and returns the number of addresses between them (including the first one, excluding the last one).

All inputs will be valid IPv4 addresses in the form of strings. The last address will always be greater than the first one.

Examples
* With input "10.0.0.0", "10.0.0.50"  => return   50 
* With input "10.0.0.0", "10.0.1.0"   => return  256 
* With input "20.0.0.10", "20.0.1.0"  => return  246*/
        //public static long IpsBetween(string start, string end)
        //{
        //    long IpToLong(string ip)
        //    {
        //        var segments = ip.Split('.').Select(byte.Parse).ToArray();
        //        long result = 0;
        //        for (int i = 0; i < segments.Length; i++)
        //        {
        //            result = (result << 8) + segments[i];
        //        }
        //        return result;
        //    }
        //    return IpToLong(end) - IpToLong(start);
        //}

        public static long IpsBetween(string start, string end)
        {
            var ip = IpToLong(start);
            var ip2 = IpToLong(end);

            return ip2 - ip;

            static long IpToLong(string ip)
            {
                var values = ip.Split('.').Select(int.Parse).ToArray();
                var ipLong = 0L;
                for (int pos = 0; pos < values.Length; pos++)
                {
                    ipLong = (ipLong << 8) + values[pos];
                }
                return ipLong;
            }
        }


    }
}
