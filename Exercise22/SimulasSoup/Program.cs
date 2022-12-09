using Microsoft.Win32.SafeHandles;
using System.Reflection;

namespace SimulasSoup
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Simula is impressed with how you reconstructed the box with an enumeration. When the box opened, you saw a glowing emerald gem inside. You don't what it is, but
             * it seems important. Also in the box were three vials of powder labeled HOT, SALTY, and SWEET.
             * 
             * "Finally! I can make soup again!" Simula says. She casually tosses the small glowing gem to you but is wholly focused on the powders."You stick around and help me
             * make soup with your programmings skills, and I'll tell you what that gem does."
             * 
             * She pulls out a cookpot, knocks the clutter off the table with a quick sweep of her arm, and begins cooking. She says, "I'm the best soup maker in town, and you're in
             * for a treat. I've got recipes for soup, stew, and gumbo. I've got mushrooms, chicken, carrots, and potatoes for ingredients. And thanks to you getting that box open
             * , I've got seasonings again! Spicy, salty, and sweet seasoning. Pick a recipe, and ingredient, and a seasoning, and I'll make it. Use your programming skills to help
             * us track what we make."
             * 
             * Objectives:
             * Define enumerations for the three variations on food: type (soup, stew, gumbo), main ingredient (mushrooms, chicken, carrots,potatoes), and seasoning(spicy,salty,sweet).
             * Make a tuple variable to represent a soup composed of the three above enumeration types.
             * Let the user pick a type, main ingredient, and seasoning from the allowed choices and fill the tuple with the results.
             * HINT: You could give the user a menu to pick from or simply the users text input against specific strings to determine which enumeration value to use.
             * HINT: You don't need to convert the enumeration value back to a string. Simply displaying an enumeration value with Write or WriteLine will display the name of the 
             * enumeration value.
             */
            (string type, string ingredient, string seasoning) recipe; // defining a tuple to store the recipe in from the users choices

            Console.WriteLine("Welcome to Simula's soup shop. What can I get you today?");
            bool keepGoing = false;
            do
            {
                recipe.type = enumLooping("We have the following types of soups to choose from:", typeof(SoupChoice)); // calling a method I am using to loop through enums and create the menu to set the type in our tuple
                
                recipe.ingredient = enumLooping($"What would you like in your {recipe.type}?", typeof(Ingredient)); // calling a method I am using to loop through enums and create the menu to set the ingredient in our tuple
                
                recipe.seasoning = enumLooping($"What type of seasoning would you like in your  {recipe.ingredient} {recipe.type}", typeof(Seasoning)); // calling a method I am using to loop through enums and create the menu to set the seasoning in our tuple
                Console.ForegroundColor= ConsoleColor.Cyan;
                Console.WriteLine($"One order of {recipe.seasoning} {recipe.ingredient} {recipe.type} coming up!"); // provide the user with the tuple values
                Console.ForegroundColor= ConsoleColor.White;
                Console.Write("Here you are. Can I get you anything else? Yes or No: ");
                string userKeepsGoing = Console.ReadLine().ToLower(); // capture the yes or no and perform a while loop
                while(userKeepsGoing != "yes" && userKeepsGoing != "no") // if the user doesnt enter yes or no then keep asking
                {
                    Console.Write("Please enter yes or no!: ");
                    userKeepsGoing = Console.ReadLine().ToLower();
                }
                if (userKeepsGoing == "yes")
                {
                    keepGoing = true; // if the user wants to order again he can otherwise the loop closes and the program ends.
                    Console.Clear();
                } else keepGoing= false;
            } while (keepGoing);
            
            
            /*--------------------------------------------- Methods start here ---------------------------------------------*/
            
            /// <summary>
            /// This method passes the Enumerations to it for looping through, creating a menu, creates an array to pass a string back with the chosen enum value for displaying to the user.
            /// </summary>
            
            string enumLooping(string comment,Type enumToLoop) 
            {
                int menu = 0; // variable used to generate the menu system numbering
                int menuItemSelection; // variable to store the users selection in
                string[] enumArray = new string[5]; // I create an array to use the indexing feature of to fill the tuple
                string userChoice; // variable used to return the users selection to the tuple
                Console.WriteLine(comment); // question for the user
                foreach (string i in Enum.GetNames(enumToLoop)) // looping through the Enum names for the menu system
                {
                    menu++; // menu starts at 0 so this makes the first item a 1.
                    Console.WriteLine($"{menu}. {i}"); // displaying the menu
                    enumArray[menu - 1] = i; // adding the strings to the array for returning value
                }
                menuItemSelection = Convert.ToInt32(Console.ReadLine()); // collect user input
                userChoice = enumArray[menuItemSelection -= 1]; // assigning the string to returns value based on the user selection index from the enumArray and subtract 1 for the index to be correct
                return userChoice;

            }

        }
        enum SoupChoice {soup, stew, gumbo}
        enum Ingredient {mushroom, chicken, carrot, potatoe }
        enum Seasoning {spicy, salty, sweet}
    }
}