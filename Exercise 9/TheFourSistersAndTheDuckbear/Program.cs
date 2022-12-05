namespace TheFourSistersAndTheDuckbear
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Four sisters own a chocolate farm and collect chocolate eggs laid by chocolate chickens every day. But more often than not, the number of eggs is not evenly divisible
             * among the sisters, and everybody knows you cannot split a chocolate egg into pieces without ruining it. The arguments have grown more heated over time.
             * The town is tired of hearing the four sisters complain, and Chandra, the town's Arbiter, has finally come up with a plan everybody can agree to. All four sisters
             * get an equal number of chocolate eggs ever day, and the remainder is fed to their pet duckbear. All that is left is to have some skilled Programmer build a program
             * to tell them how much each sister and the duckbear should get.
             * 
             * Objectives:
             * Create a program that lets the user enter the number of chocolate eggs gathered that day.
             * Using / and %, compute how many eggs each sister should get and how many are left over for the duckbear.
             */

            /* The following code was commented out and left in place to show my original code and my new code after implementing a new method to reflect my learning history.
            //ask user for the count.
            Console.WriteLine("How many chocolate eggs were collected today?");

            // save users response
            string collectedEggs = Console.ReadLine()!;

            // convert to an int for math operations.
            int numberOfEggs = Convert.ToInt32(collectedEggs);
            */

            int numberOfEggs = AskForNumber("How many chocolate eggs were collected today?");
            // perform normal division knowing the program will ignore the remainder using basic division.
            int forSisters = numberOfEggs / 4;

            // perform math with the modulas operater to determine if the duckbear gets any eggs (remaider of eggs).
            int forDuckbear = numberOfEggs % 4;

            // display answers for the user.
            Console.WriteLine($"Each Sister Gets {forSisters}");
            Console.WriteLine($"The duckbear gets {forDuckbear}");

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

        }
    }
}