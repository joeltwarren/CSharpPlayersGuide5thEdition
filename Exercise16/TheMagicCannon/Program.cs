namespace TheMagicCannon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Skorin, a member of Consolas's wall guard, has constructed a magic cannon that draws power from two gems: a fire gem and an electric gem. Every third turn of a crank,
             * the fire gem activates, and the cannon produces a fire blast. The electric gem activates every fifth turn of the crank, and the cannon makes an electric blast. When
             * the two line up, it generates a potent combined blast. Skorin would linke your help to produce a program that can warn the crew about which turns of the crank
             * will produce the different blasts before they do it.
             * 
             * A partial output of the desired program looks like this:
             * 1: Normal
             * 2: Normal
             * 3: Fire
             * 4: Normal
             * 5: Electric
             * 6: Fire
             * 7: Normal
             *
             * Objectives:
             * Write a program that will loop through the values between 1 and 100 and display what kind of blast the crew should expect. (The % operator may be of use.)
             * Change the color of the output based on the type of blast. (For example, red for fire, yellow for electric, blue for electric and fire combined).
             */

            Console.WriteLine("Cannon operations guide:"); // something to let the user know this is a guide
            for (int i = 1; i <= 100; i++) // loops through from 0 to 100
            {
                if (i % 3 != 0 && i % 5 != 0) // if the number is not divisible by 3 or 5
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"{i : 000.}: Normal"); // adding 3 digit formatting just because it looks better to me
                }
                if (i % 3 == 0 && i % 5 != 0) // if the number is divisible by 3 and not 5
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{i : 000.}: Fire"); // adding 3 digit formatting
                }
                if (i % 3 != 0 && i % 5 == 0) // if the number is not divisible 3 and is divisible by 5
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{i : 000.}: Electric"); // adding 3 digit formatting
                }
                if (i % 3 == 0 && i % 5 == 0) // if the number is divisible by both 3 and 5
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"{i : 000.}: Combined Blast"); // adding 3 digit formatting
                }
            }
        }
    }
}