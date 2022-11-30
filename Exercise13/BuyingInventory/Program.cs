namespace BuyingInventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * It is time to resupply. A nearby outfitter shop has the supplies you need but it is so disorganized that they cannot sell things to you.
             * "Can't sell if i can't find the price list," Tortuga, the owner, tells you as he turns over and attempts to go back to sleep in his reclining chair in the corner.
             * There's a simple solution: use your programming powers to build something to report the prices of various pieces of equipment, based on the users's selection:
             * 
             * Example:
             * The following items are available:
             * 1 - Rope
             * 2 - Torches
             * 3 - Climbing Equipment
             * 4 - Clean Water
             * 5 - Machete
             * 6 - Canoe
             * 7 - Food Supplies
             * What number do you want to see the price of? 2
             * Torches cost 15 gold.
             * 
             * You search around the shop and find ledgers that show the following prices for these items: Rope: 10 gold, Torches: 15 Gold, Climbing Equipment: 25 gold,
             * Clean Water: 1 gold, Machete: 20 gold, Canoe: 200 gold, Food Supplies: 1 gold.
             * 
             * Objectives:
             * Build a program that will show the menu illustrated above.
             * Ask the user to enter a number from the menu.
             * Using the information above, use a switch ( either type ) to show the item's cost.
             */

            Console.WriteLine("Good day adventure welcome to Tortuga's where we have the supplies you need for any job! What can I help you with today?");
            Console.WriteLine("The following items are available:");
            Console.WriteLine("1 - Rope");
            Console.WriteLine("2 - Torches");
            Console.WriteLine("3 - Climbing Equipment");
            Console.WriteLine("4 - Clean Water");
            Console.WriteLine("5 - Machete");
            Console.WriteLine("6 - Canoe");
            Console.WriteLine("7 - Food Supplies");
            Console.Write("Which number would you like to see the price of? ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Rope will cost you 10 gold.");
                    break;
                case 2:
                    Console.WriteLine("Torches will cost you 15 gold.");
                    break;
                case 3:
                    Console.WriteLine("Climbing equipment will cost you 25 gold.");
                    break;
                case 4:
                    Console.WriteLine("Clean water will cost you 1 gold.");
                    break;
                case 5:
                    Console.WriteLine("Machete will cost you 20 gold.");
                    break;
                case 6:
                    Console.WriteLine("Canoe will cost you 200 gold.");
                    break;
                case 7:
                    Console.WriteLine("Food supplies will cost you 1 gold.");
                    break;
                default:
                    Console.WriteLine("My appologies I didn't quite understand you please enter a number again!");
                    break;
            }
        }
    }
}