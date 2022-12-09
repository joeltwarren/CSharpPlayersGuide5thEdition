namespace VinFletchersArrows
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Vin Fletcher is a skilled arrow maker. He asks for your help building a new class to represent arrows and determine how much he should sell them for.
             * "A tiny fragment of my soul goes into each arrow; I care not for the money; I just need to be able to recoup my costs and get food on the table," he says.
             * Each arrow has three parts: the arrowhead (steel, wood, or obsidian), the shaft ( a length between 60 and 100 cm long), and the fletching (plastic, turkey
             * feathers, or goose feathers).
             * His costs are as follows: For arrowheads, steel cost 10 gold, wood costs 3 gold, and obsidian costs 5 gold. For fletching, plastic costs 10 gold, turkey feathers
             * cost 5 gold, and goose feathers cost 3 gold. For the shaft, the price depends on the length: .05 gold per centimeter.
             * 
             * Objectives:
             * Define a new Arrow class with fields for arrowhead type, fletching type, and lenght. (HINT: arrowhead types and fletching types might be good enumerations)
             * Allow a user to pick the arrowhead, fletching type, and length and then create a new Arrow instance.
             * Add a GetCost method that returns its cost as a float based on the numbers above, and use this to display the arrow's cost.
             */

            Console.WriteLine("Welcome to Vin Fletchers Arrow Shop."); // introduction
            string arrowHeadMaterial = MenuBuilder("Please choose an arrow head material:", (typeof (ArrowHead))); // calls the menu builder and stores the response in a string to be used building a new class instance
            string fletchingMaterial = MenuBuilder("Please choose a fletching material:", (typeof (Fletching))); // calls the menu builder and stores the response in a string to be used building a new class instance
            
            int arrowLenght = 0; // specified a number to make the while loop run
            while (arrowLenght < 60 || arrowLenght > 100) // won't exit until the lenght requirments are met
            {
                Console.Write("Please specify a lenght for the arrow between 60 and 100 cm long: ");
                arrowLenght = Convert.ToInt32(Console.ReadLine());
            }
            Console.Clear();
            Arrow currentArrowConfig = new Arrow(arrowHeadMaterial, fletchingMaterial, arrowLenght); // initilzation of the Arrow object
            Console.WriteLine($"Your arrow configuration consists of a {currentArrowConfig._arrowHead} head, a {currentArrowConfig._fletching} fletching, and will be {currentArrowConfig._length} cm long."); // breakdown of the whole arrow composition
            double finalPrice = currentArrowConfig.GetCost(); // variable to store the price in
            Console.Write($"Your arrows will cost a total of {finalPrice} gold each."); // displays the current pricing.

            /// <summary>
            /// I use this method to iterate over the Enumerations and build out an automatic menu system.
            /// </summary>
            /*------------------------------------- Main Methods -------------------------------------*/
            string MenuBuilder(string comment, Type enumToEvaluate) // method used to build the users menu options
            {
                int menuNumberOptions = 0; // varialbe to start the menu numbering from
                int menuItemSelection; // stores the users numeric menu choice
                string[] selectedText = new string[3]; // an array I use to return the string values of the users input back to the main program
                string usersChoice;
                Console.WriteLine(comment); // passed question to the user through the parameter 'comment'
                foreach (string item in Enum.GetNames(enumToEvaluate)) // looping through the enumerations for display and building the string array
                {
                    menuNumberOptions++; // starts the menu number at number 1.
                    Console.WriteLine($"{menuNumberOptions}. {item}"); // displays the menu through looping
                    selectedText[menuNumberOptions - 1] = item; // adds the strings to the array for passing to the main program
                }
                menuItemSelection = Convert.ToInt32(Console.ReadLine()); // grabs the users selected option
                usersChoice = selectedText[menuItemSelection -1]; // sets the users choice variable via the selected text array and deducts 1 for the index offset
                return usersChoice;
            }

        }
        /*------------------------------------- Classes -------------------------------------*/
        class Arrow 
        {
            public string _arrowHead; // class variable for arrowhead type
            public string _fletching; // class variable for fletching type
            public int _length; // class variable for arrow length

            public Arrow(string arrowHead, string fletching, int lenght) // Arrow class constructor
            {
                _arrowHead= arrowHead;
                _fletching= fletching;
                _length= lenght;
            }
            /*------------------------------------- Arrow Class Methods ------------------------------------- */
            /// <summary>
            /// I use this method to calculate the cost of an arrow based on its composition
            /// </summary>
            public double GetCost () // method of arrowclass to return cost
            {
                int arrowHeadPrice;
                int fletchingPrice;
                double overallLenghtPrice;
                double finalArrowPrice;

                arrowHeadPrice = _arrowHead switch // switch for pricing the head cost
                {
                    "steel" => 10, // sets the price of the arrowhead for steel
                    "wood" => 3, // sets the price of the arrowhead for wood
                    "obsidian" => 5, // sets the price of the arrowhead for obsidian
                    _ => 0
                };

                fletchingPrice = _fletching switch //switch for pricing the fletching
                {
                    "plastic" => 10, // sets the price of the fletching if plastic
                    "turkey" => 5, // sets the price of the fletching if turkey
                    "goose" => 3, // sets the price of the fletching if goose
                    _ => 0
                };
                overallLenghtPrice = _length * .05; // calculates the price of the arrow lenght

                finalArrowPrice = arrowHeadPrice + fletchingPrice + overallLenghtPrice; // adds up all the prices together and stores them in a double
                return finalArrowPrice; // returns the double final price
            }
        }
        /*------------------------------------- Enumerations -------------------------------------*/
        enum ArrowHead { steel, wood, obsidian } // arrowhead type options
        enum Fletching { plastic, turkey, goose} // fletching type options
    }
}