namespace TakingANumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Many previous tasks have required getting a number from a user. To save time writing this code repeatedly, you have decided to make a method to do this common task.
             * 
             * Objective:
             * Make a method with the signature int AskForNumber(string text). Display the text parameter in the console window, get a response from the user, convert it to an int,
             * and return it. This might look like this:
             * int result = AskForNumber("What is the airspeed velocity of an unladen swallow?");.
             * Make a method with the signature int AskForNumberInRange(string text, int min, int max). Only return if the entered number is between the min and max values. Otherwise
             * ask again. 
             * Place these methods in at least one of your previous programs to improve it
             */
            Console.WriteLine("Welcome to the Taking a number method, I am updating my programming skills.");

            int result = AskForNumber("Please give me a number."); // calls the AskForNumber method with the supplied text as a parameter and stores it in the result variable
            Console.WriteLine(result);

            int result2 = AskForNumberInRange("How fast does the arrow travel after shot from your bow?", 75, 150);
            Console.WriteLine($"You chose the number. {result2}");


            /*------------------------------------------------------ Start of Methods ------------------------------------------------------ */

            /// <summary>
            /// Asks the user for a number, converts it to an int and returns it.
            /// </summary>
            int AskForNumber(string text)
            {
                Console.Write(text + " "); // displays parmater text and adds " " a blank space
                int number = Convert.ToInt32(Console.ReadLine()); // one liner convert using the Console.ReadLine Method
                return number; // the method has to have a return since it is not of the type void.
            }

            /// <summary>
            /// Asks the user for a number within a range of numbers, if the entered number is out of the range it will ask until its not and then return the number.
            /// </summary>

            int AskForNumberInRange(string text, int min, int max)
            {
                Console.Write($"{text} Choose a number between {min} and {max}. ");
                int userResponse = Convert.ToInt32(Console.ReadLine());
                while (userResponse < min || userResponse > max)
                {
                    Console.WriteLine($"Choose a number between {min} and {max}.");
                    userResponse = Convert.ToInt32(Console.ReadLine());
                }
                return userResponse;
                
            }
        }
    }
}