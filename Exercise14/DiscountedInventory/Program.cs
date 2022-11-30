namespace DiscountedInventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * After sorting through Tortuga's outfitter shop and making it viable again, Tortuga realizes you've put him back in business. He wants to repay you
             * the favor by giving you a 50% discount on anything you buy from him, and he wants you to modify your program to reflect that.
             * After asking the user for a number, the program should ask for thier name. If the name supplied is your name (Joel), cut the price in half before reporting it to the user.
             * 
             * Objectives:
             * Modify your program from before to also ask the user for their name.
             * If their name equals your name, divide the cost in half.
             */

            Console.WriteLine("Good day adventurer welcome to Tortuga's where we have the supplies you need for any job! What can I help you with today?");
            Console.WriteLine("The following items are available:");
            Console.WriteLine("1 - Rope");
            Console.WriteLine("2 - Torches");
            Console.WriteLine("3 - Climbing Equipment");
            Console.WriteLine("4 - Clean Water");
            Console.WriteLine("5 - Machete");
            Console.WriteLine("6 - Canoe");
            Console.WriteLine("7 - Food Supplies");
            Console.Write("Which number would you like to see the price of? ");
            int choice = Convert.ToInt32(Console.ReadLine()); // converting users choice to an int

            // this time I decided to try out the switch expression instead of the switch case statements.
            // they produce a cleaner more streamlined set of code in my opinion.
            string itemChosen = choice switch // creates a string variable called itemChosen from users original int variable choice
            {
                1 => "rope", 
                2 => "torch",
                3 => "climbing equipment",
                4 => "clean water",
                5 => "machete",
                6 => "canoe",
                7 => "food supplies",
                _ => "Please choose a valid item number." // this should catch any invalid input attempted to enter the switch; NOTE: this does not vailidate the initial conversion of the users choice.
            
            };
            double priceOfItem = itemChosen switch // creates a double priceOfItem and uses the itemChosen string to choose a price
            { 
                "rope" => 10, 
                "torch" => 15,
                "climbing equipment" => 25,
                "clean water" => 1,
                "machete" => 20,
                "canoe" => 200,
                "food supplies" => 1,
                _ => 0 // the complier warned of a CS8509-(it is not exhaustive), warning without the default case being covered. It should not cause an issue but I am erroring on the side of caution!
            };
            Console.Write("What is your name sir? ");
            string name = Console.ReadLine()!.ToLower(); // I added the ToLower() method to keep from worrying about Joel, JOel, JOEL, etc.. the compliler makes it joel no matter what.
            if (name == "joel") priceOfItem /= 2; // single line if statment used since I only needed one line of code to test and complete the IF you are joel item is half price.
            Console.WriteLine($"The {itemChosen} will cost you {priceOfItem} gold."); // String Interpolation introduced in C# 6.0 allows embedded expressions in a string.
        }
    }
}