namespace ThePrototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Mylara, the captian of the Guard of Consolas, has approached you with the beginnings of a plan to hunt down The Uncoded One's airship. "If we're going to be able
             * to track this thing down," she says, "we need you to make us a program that can help us home in on a location." She lays out a plan for a program to help with the hunt.
             * One user, representing the airship pilot, picks a number between 0 and 100. Another user, the hunter, will then attempt to guess the number. The program will tell the
             * hunter that they have guessed correctly or that the number was too high or low. The program repeats until the hunter guesses the number correctly. Mylara claims,"If we
             * can build this program, we can use what we learn to build a better version to hunt down the Uncoded One's airship."
             * 
             * Sample Program:
             * User 1, enter a number between 0 and 100: input was 27
             * 
             * After entering this number, the program should clear the screen and continue like this:
             * 
             * User 2, guess the number.
             * What is your next guess? input was 50
             * 50 is too high.
             * What is your next guess? input was 25
             * 25 is too low.
             * What is your next guess? input was 27
             * You guessed the number!
             * 
             * Objectives:
             * Build a program that will allow a user, the pilot, to enter a number.
             * If the number is above 100 or less than 0, keep asking.
             * Clear the screen once the program has collected a good number.
             * Ask a second user, the hunter, to guess numbers.
             * Indicate whether the user guessed too high, too llow, or guessed right.
             * Loop until they get it right, then end the program.
             */

            /* ++++ original code lines removed after updating it with a new method for asking for a range of numbers during exercise 19 taking a number ++++
            Console.WriteLine("Welcome to our Prototype! It's time to start hunter training.");
            Console.Write("Pilot please choose a number between 0 and 100: ");
            int pilotsChoice = Convert.ToInt32(Console.ReadLine()!); // convert users choice
            */

            int pilotsChoice = AskForNumberInRange("Welcome to our Prototype! It's time to start hunter training.\n", 0, 100);
            while (pilotsChoice < 0 || pilotsChoice > 100) // while will not exit until the user picks a number between 0 and 100
            {
                Console.Write("Please choose a number between 0 and 100 pilot.");
                pilotsChoice = Convert.ToInt32(Console.ReadLine()!);
            }
            Console.Clear();

            /* ++++ original code lines removed after updating it with a new method for asking for a range of numbers during exercise 19 taking a number ++++
            Console.WriteLine("Hunter your opponent pilot has picked his number.");
            Console.Write("What is your guess between 0 and 100 to locate him?: ");
            int huntersChoice = Convert.ToInt32(Console.ReadLine()!); // convert users choice
            */

            int huntersChoice = AskForNumberInRange("Hunter your opponent pilot has picked his number.\n", 0, 100);
            while (huntersChoice != pilotsChoice) // while loop will not exit until the hunter finds the pilot
            {
                if (huntersChoice > pilotsChoice) Console.WriteLine("Your guess is to high!");
                if (huntersChoice < pilotsChoice) Console.WriteLine("Your guess is to low!");
                Console.Write("Hunter what is your next guess?: ");
                huntersChoice = Convert.ToInt32(Console.ReadLine()!);
            }
            if (huntersChoice == pilotsChoice) Console.WriteLine("Hunter you have successfully tracked down your target congratulations!"); // game over pilot is located

            /*------------------------------------------------------ Start of Methods ------------------------------------------------------ */

            /// <summary>
            /// Asks the user for a number within a range of numbers, if the entered number is out of the range it will ask until its not and then return the number.
            /// </summary>

            int AskForNumberInRange(string text, int min, int max)
            {
                Console.Write($"{text}Choose a number between {min} and {max}. ");
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