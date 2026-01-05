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



    }
}
