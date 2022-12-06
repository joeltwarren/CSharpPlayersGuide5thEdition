namespace SimulasTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * AS you move through the village of Enumerant, you notice a short, cloaked figure following you. Not being one to enjoy a mysterious figure tailing you, you seize a
             * moment to confront the figure."Don't be alarmed!" She says. "I am Simula. They are saying you're a Programmer. Is this true?" You answer in the affirmative, and Simula's
             * eyes widen. "If you are truly a Programmer, you will be able to help me. Follow me." She leads you to a backstreet and into a dimly lit hovel. She hands you a small,
             * locked chest. "We haven't seen any Programmers in these lands in a long time. And especially not ones that can craft types. If you are a True Programmer, you will 
             * want what is in that chest. And if you are a True Programmer, I will gladly give it to you to aid you in your quest.
             * 
             * The chest is a small box you can hold in your hand. The lid can be open, closed (but unlocked), or locked. You'd normally be able to go between these states, 
             * open, closing, locking, and unlocking the box, but the box is broken. You need to create a program with an enumeration to recreate this locking mechanism.
             * 
             * Open to Closed, closed to locked, locked to closed, closed to open | those are accepted order of changes one cannot go from locked to open for example.
             * 
             * Nothing happens if you attempt an impossible action in the current state, like opening a locked box.
             * 
             * Sample:
             * The chest is locked. What do you want to do? unlock
             * The chest is unlocked. What do you want to do? open
             * The chest is open. What do you want to do? close
             * The chest is unlocked. What do you want to do?
             * 
             * Objective:
             * Define an enumeration for the state of the chest.
             * Make a variable whose type is this new enumeration.
             * Write code to allow you to manipulate the chest with the lock, unlock, open, and close commands, but ensure that you don't transition between states that don't support it
             * Loop forever, asking for the next command.
             */

            string[] states = new string[4] { "unlock", "open", "close", "lock" };
            Console.WriteLine("Welcome to Simula's Test you have been handed a small locked box.");
            Chest currentState = Chest.Locked;
            while (true)
            {
                Console.WriteLine($"The box is currently: {currentState}"); // inform user of current state of the box
                Console.WriteLine("Choose which number option you wish to perform:"); // instructions to the user

                for (int index = 0; index < states.Length; index++) // loop through the array of possible options for the user to choose from
                {
                    Console.WriteLine($"{index + 1}.) {states[index]} the box."); // display options for the user                        
                }

                int userChoice = Convert.ToInt32(Console.ReadLine()); // gather users input
                if (currentState == Chest.Locked && userChoice == 1) // if the chest is locked and the user wants to unlock it
                {
                    currentState = Chest.Closed; // unlocked but not open state
                    Console.WriteLine("You have unlocked the box!\n"); // user feedback
                }
                else if (currentState == Chest.Closed && userChoice == 2) // if the chest is closed and the user wants to open it
                {
                    currentState = Chest.Open; // open state
                    Console.WriteLine("You have opened the box!\n"); // user feedback
                }
                else if (currentState == Chest.Open && userChoice == 3) // if the chest is open and the user wants to close it
                {
                    currentState = Chest.Closed; // closed state but not locked
                    Console.WriteLine("You have closed the box!\n"); // user feedback
                }
                else if (currentState == Chest.Closed && userChoice == 4) // if the chest is closed and the user wants to lock it
                {
                    currentState = Chest.Locked; // locked state
                    Console.WriteLine("You have locked the box!\n"); // user feedback
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"You cannot change the box from it's current state {currentState} to {states[userChoice - 1]} try again!\n"); // user tried an invalid state change try again.
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
       
        }
            enum Chest {Open, Closed, Locked } // enumerated type created to control the state of the box.
    }
}