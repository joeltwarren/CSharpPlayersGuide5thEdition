namespace TheDefenseOfConsolas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * The Uncoded One has begun an assault on the city of Consolas; the situation is dire. From a moving airship called the Manticore, massive fireballs
             * capable of destroying city blocks are being catapulted into the city.
             * The city is arranged in blocks, numbered like a chessboard.
             *  _______________
             * |8|_|_|_|_|_|_|_|
             * |7|_|_|_|*|_|_|_|
             * |6|_|_|*|_|*|_|_|
             * |5|_|_|_|*|_|_|_|
             * |4|_|_|_|_|_|_|_|
             * |3|_|_|_|_|_|_|_|
             * |2|_|_|_|_|_|_|_|
             * |1|2|3|4|5|6|7|8|
             *  ---------------
             *  The city's only defense is a movable magical barrier, operated by a squad of four that can protect a singlice city block by putting themselves in each of the 
             *  targets four adjacent block, as shown in the picture above.
             *  For example, to protect the city block at (Row 6, Column 5), the crew deploys themselves to (Row 6, Column 4),(Row 5, Column 5),(Row 6, Column 6),
             *  and (Row 7, Column 5).
             *  
             *  The good news is that if we can compute the deployment locations fast enough, the crew can be deployed around the target in time to prevent the catastrophic damage
             *  for as long as the siege lasts. The City of Consolas needs a program to tell the squad where to deploy, given the anticipated target.
             *  Sample Below
             *  Target Row? 6
             *  Target Column? 5
             *  Deploy to:
             *  (6, 4)
             *  (5, 5)
             *  (6, 6)
             *  (7, 5)
             *  
             *  Objective: 
             *  Ask the user for the target row and column
             *  Compute the neighboring rows and columns to where to deploy the squad
             *  Display the deployment instructions in a different color of your choosing
             *  Change the window title to be "Defense of Consolas"
             *  Play a sound with Console.Beep when the results have been computed and displayed.
             */

            // Title Change
            Console.Title = "Defense of Consolas";

            // ask user for cordinates and store those as string variables
            Console.WriteLine("Hello Commander what coordinates are being threatened?");
            Console.Write("Target Row? ");
            string targetRow = Console.ReadLine()!;
            int targetR = Convert.ToInt32(targetRow); // convert the users input to a int
            Console.Write("Target Column? ");
            string targetColumn = Console.ReadLine()!;
            int targetC = Convert.ToInt32(targetColumn); // convert the users input to a int
            Console.WriteLine("Deploy to the following coordinates commander:");

            Console.ForegroundColor = ConsoleColor.Red; // color modification of the text
            
            // calculation of coordinates using basic -1 and +1 operations on the int converted user coordinates
            Console.WriteLine($"(Row {targetR}, Column {targetC -1})");
            Console.WriteLine($"(Row {targetR -1}, Column {targetC})");
            Console.WriteLine($"(Row {targetR}, Column {targetC +1})");
            Console.WriteLine($"(Row {targetR +1}, Column {targetC})");

            Console.Beep(); // I have included the beep code as requested. I was unable to find a suitable replacement for a 64 bit os without writing my own class - later chapters.
        }
    }
}