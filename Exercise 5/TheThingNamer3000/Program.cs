namespace TheThingNamer3000
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * As you walk through the city of Commenton, admiring its forward-slash based architectural building, a young man approaches you in a panic. "I dropped my Thing Namer
             * 3000 and broke it. I think it's mostly working, but all my variable names got reset! I don't understand what they do!" He shows you the following program:
             * 
             * Console.WriteLine("What kind of thing are we talking about?");
             * string a = Console.ReadLine();
             * Console.WriteLine("How would you describe it? Big? Azure? Tattered?");
             * string b = Console.ReadLine();
             * string c = "of Doom";
             * string d = "3000";
             * Console.WriteLine("The " + b +" " +a+ " " of " " +c+ " " +d+ "!");
             * 
             * "You gotta help me figure it out!"
             * 
             * Objectives:
             * Rebuild the program above
             * Add comments near each of the four variables that descrive what they store. You must use at least one of each comment type(// and /*).
             * Find the bug in the text displayed and fix it.
             */

            Console.WriteLine("What kind of thing are we talking about?");

            // Thing type
            string a = Console.ReadLine()!;

            Console.WriteLine("How would you describe it? Big? Azure? Tattered?");

            // Description
            string b = Console.ReadLine()!;

            // "of Doom" text.
            string c = "of Doom";

            /* The number. */
            string d = "3000";

            // removed the word "of" out of the concatenation strings to fix the of of error.
            Console.WriteLine("The " + b + " " + a + " " + c + " " + d + "!");

        }
    }
}