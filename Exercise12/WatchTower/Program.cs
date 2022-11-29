namespace WatchTower
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * There are watchtowers in the region around Consolas that can alert you when an enemy is spotted. With some help from you, they can tell you which direction
             * the enemy from the watch tower.
             * 
             *       x<0 x=0  x>0
             *      ____ ___ ____
             * Y>0 | NW | N | NE |
             * Y=0 | W  | ! |  E |
             * y<0 | SW | S | SE |
             *      ---- --- ----
             *      
             * Objective:
             * 
             * Ask the user for an X value and a Y value. These are coordinates of the enemy relative to the watchtower's location.
             * Using the image above, If statements, and relational operations, display a message about what direction the enemy is coming from.
             * For Example, "The enemy is to the northwest!" or "The enemy is here!"
             * 
             */

            // asking the watchtower sentinel for the coordinates
            Console.Write("Sentinel please report the X coordinates of the enemy! ");
            string xCoord = Console.ReadLine()!;
            Console.Write("Sentinel please report the Y coordinates of the enemy! ");
            string yCoord = Console.ReadLine()!;

            Console.Write("\n"); // creating a blank line.

            // converting the Coordinates into Intergers for comparison using my IF statements
            int xCoordinates = Convert.ToInt32(xCoord);
            int yCoordinates = Convert.ToInt32(yCoord);

            Console.ForegroundColor = ConsoleColor.Yellow; // Making the response of the system a little more noticeable

            if (xCoordinates == 0 && yCoordinates == 0) // center of the X,Y coordinate system
            {
                Console.WriteLine("Commander our watchtower sentinel is reporting the enemy is right on top of them!");
            }

            if (xCoordinates < 0 && yCoordinates > 0) // upper left area of the X,Y coordinate system
            { 
            Console.WriteLine("Commander our watchtower sentinel is reporting the enemy is to the NorthWest of them!");
            }

            if (xCoordinates < 0 && yCoordinates == 0) // left area of the X,Y coordinate system
            {
                Console.WriteLine("Commander our watchtower sentinel is reporting the enemy is to the West of them!");
            }

            if (xCoordinates < 0 && yCoordinates < 0) // lower left area of the X,Y coordinate system
            {
                Console.WriteLine("Commander our watchtower sentinel is reporting the enemy is to the SouthWest of them!");
            }

            if (xCoordinates == 0 && yCoordinates > 0) // upper area of the X,Y coordinate system
            {
                Console.WriteLine("Commander our watchtower sentinel is reporting the enemy is to the North of them!");
            }

            if (xCoordinates == 0 && yCoordinates < 0) // lower area of the X,Y coordinate system
            {
                Console.WriteLine("Commander our watchtower sentinel is reporting the enemy is to the South of them!");
            }

            if (xCoordinates > 0 && yCoordinates > 0) // upper right area of the X,Y coordinate system
            {
                Console.WriteLine("Commander our watchtower sentinel is reporting the enemy is to the NorthEast of them!");
            }

            if (xCoordinates > 0 && yCoordinates == 0) // right area of the X,Y coordinate system
            {
                Console.WriteLine("Commander our watchtower sentinel is reporting the enemy is to the East of them!");
            }

            if (xCoordinates > 0 && yCoordinates < 0)// lower right area of the X,Y coordinate system
            {
                Console.WriteLine("Commander our watchtower sentinel is reporting the enemy is to the SouthEast of them!");
            }
            Console.WriteLine("Prepare our defenses an attack is imminent, Sir!");
        }
    }
}