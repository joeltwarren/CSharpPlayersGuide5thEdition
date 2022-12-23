namespace TheLockedDoor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            * You arrive at the Catacombs of the Class, the place that will reveal the path to the Fountain of Objects. The Catacombs lie inside a mountain, with a wide stone 
            * entrance leading you into a series of three chambers. In the first chamber, you find five pedestals with the remnants of a class definition and specific instructions
            * by each. Etched above a sealed doorway at the back of the room is the text, "Only the True Programmer who can remake the Five Prototypes can proceed." Each pedestal
            * appears to have instructions for crafting a class. These are the Five Prototypes that you must reassemble.
            * 
            * The First pedestal asked you to create a Point class to store a point in two dimensions. Each point is represented by an x-coordinate(x), a side-to-side distance from
            * a special central point called the origin, and a y-coordinate(y), an up-and-down distance away from the origin. After completing it you have moved to the
            * second pedestal.
            * 
            * ===============================================================================================================================================================
            * 
            * The second pedestal asked you to create a Color class to represent a color. The pedestal included an etching of this diagram that illustrates it potential usage
            *   -------
            *  |       | R --------------O 255
            *  |       | G ----------O---- 165
            *  |       | B O--------------   0
            *   -------
            * The color consists of three parts or channels: Red, Green, and Blue, which indicate how much those channels are lit up. Each channel can be from 0 to 255. 0
            * means completely off, 255 means completely on.
            * The pedestal also includes some color names, with a set of numbers indicating their specific values for each channel. These are commonly used colors: White (255,255,255),
            * Black (0,0,0), Red (255,0,0) Orange (255,265,0), Yellow (255,255,0), Green (0,128,0), Blue (0,0,255), Purple (128,0,128). After Completing it you have moved on
            * to the third pedestal.
            * 
            * ===============================================================================================================================================================
            * 
            * The digital Realms of C# have playing cards like ours but with some differences. Each card has a color (red, green, blue, yellow) and rank ( the numbers 1 through
            * 10, followed by the symbols $, %, ^, and &). The third pedestal required that you create a class to represent a card of this nature.
            * Having completed the third pedestal you move onto the fourth.
            * 
            * ===============================================================================================================================================================
            * 
            * The fourth pedestal demands constructing a door class with a locking mechanism that requires a unique numeric code to unlock. You have done something similar before
            * without using a class, but the locking mechanism is new. The door should only unlock if the passcode is the right one. The following statement describe how the door works.
            * An open door can always be closed.
            * A closed (but not locked) door can always be opened.
            * A closed door can always be locked.
            * A locked door can be unlocked, but a numeric passcode is needed, and the door will only unlock if the code supplied matches the doors's current passcode.
            * When a door is created, it must be given an initial passcode.
            * Additionally, you should be able to change the passcode by supplying the current code and a new one. The passcode should only change if the correct, current code is given.
            * 
            * Objectives:
            * 
            * Define a Door class that can keep track of whether it is locked, open, or closed.
            * Make it so you can perform the four transitions defined above with methods.
            * Build a constructor that requries the starting numeric passcode.
            * Build a method that will allow you to changed the passcode for an existing door by supplying the current passcode and new passcode. Only change the passcode if the current
            * password is correct when given.
            * Make your main method ask the user for a starting passcode, then create a new Door instance. Allow the user to attempt the four transitions above (open, close, lock, unlock)
            * and change the code by typing in text commands.
            */

            Console.Write("Please enter a door code to create a new door! ");
            int newDoorCode = Convert.ToInt32(Console.ReadLine());
            Door BrandNewDoor = new Door(newDoorCode);
            Console.WriteLine("Your new door has been created what action would you like to perform?");
            Console.WriteLine($"You may use any of the following commands to operate your new door!");
            bool keepRunning = true;
            while (keepRunning) 
            {
                Console.WriteLine("You can type \"Open\", \"Close\", \"Lock\", \"Unlock\", or \"Change Code\" to operate your new door! ");
                Console.WriteLine($"Currently your door is {BrandNewDoor.CurrentDoorStatus}");
                string userInput = Console.ReadLine().ToLower();
                
                if (userInput == "change code")
                {
                    Console.Write("Please enter the current door code! ");
                    int userEnteredDoorCode = Convert.ToInt32(Console.ReadLine());
                    BrandNewDoor.ChangeDoorCode(userEnteredDoorCode);
                }
                else if (userInput == "open" || userInput == "close" || userInput == "lock" || userInput == "unlock")
                {
                    Status usersChoice = userInput switch
                    {
                        "open" => Status.Opened,
                        "close" => Status.Closed,
                        "lock" => Status.Locked,
                        "unlock" => Status.Unlocked
                    };
                    BrandNewDoor.UpdateDoorStatus(usersChoice);
                }
                else Console.WriteLine($"You entered {userInput} which is not a valid option try again!");
                
                Console.WriteLine($"Currently your door is {BrandNewDoor.CurrentDoorStatus}");
                Console.WriteLine("Would you like to continue working with your new door type \"Yes\" or \"No\"? ");
                string keepGoing = Console.ReadLine().ToLower();
                if (keepGoing == "no") { keepRunning = false; }
                if (keepGoing == "yes") { Console.Clear(); }

            }
        }
        public class Door 
        {
            // Auto properties
            public Status CurrentDoorStatus { get; private set; }

            // data backing variable for the door code.
            private int _doorCode;

            // Consturctor creates a new door with a locked status
            public Door(int newDoorCode) 
            {
                _doorCode = newDoorCode;
                CurrentDoorStatus = Status.Locked; // built in security features are a must these days!
            }
            // Class methods
            public void UpdateDoorStatus(Status AttemptedChange) // this method handles all door changes
            {
                if (CurrentDoorStatus == Status.Opened) // an open door can be closed only
                {
                    if (AttemptedChange == Status.Closed) { CurrentDoorStatus = Status.Closed; }
                    else Console.WriteLine($"You cannot {EnumTOErrorStrings(AttemptedChange)} a {CurrentDoorStatus} door!");
                }
                else if (CurrentDoorStatus == Status.Closed) // a closed door can be opened or locked
                {
                    if (AttemptedChange == Status.Opened) { CurrentDoorStatus = Status.Opened; }
                    else if (AttemptedChange == Status.Locked) { CurrentDoorStatus = Status.Locked; }
                    else Console.WriteLine($"You cannot {EnumTOErrorStrings(AttemptedChange)} a {CurrentDoorStatus} door!");
                }
                else if (CurrentDoorStatus == Status.Unlocked) // a unlocked door can be opend or locked
                {
                    if (AttemptedChange == Status.Opened) { CurrentDoorStatus = Status.Opened; }
                    else if (AttemptedChange == Status.Locked) { CurrentDoorStatus = Status.Locked; }
                    else Console.WriteLine($"You cannot {EnumTOErrorStrings(AttemptedChange)} a {CurrentDoorStatus} and Closed door!");
                }
                else if (CurrentDoorStatus == Status.Locked) // a locked door can only be opened with a passcode
                {
                    if (AttemptedChange == Status.Unlocked)
                    {
                        Console.Write("Please enter the door code to unlock the door! ");
                        int userInputcode = Convert.ToInt32(Console.ReadLine());
                        if (_doorCode == userInputcode) { CurrentDoorStatus = Status.Unlocked; }
                        else Console.WriteLine("Invalid Door Code entry!");
                    }
                    else Console.WriteLine($"You cannot {EnumTOErrorStrings(AttemptedChange)} a {CurrentDoorStatus} door!");
                }
            }
            
            public void ChangeDoorCode(int currentDoorCode) // update the door code using the following
            {
                if (currentDoorCode == _doorCode) 
                {
                    Console.Write("Please enter a new door code: "); 
                    int newDoorCode = Convert.ToInt32(Console.ReadLine());
                    _doorCode= newDoorCode;
                    Console.WriteLine("Your door code has been updated!");
                }
                else Console.WriteLine("Incorrect door code, Cannot proceed!");
            }
            private string EnumTOErrorStrings(Status AttemptedChange) // this method simply returns a string for error handling for the user
            {
                string errorWording = AttemptedChange switch 
                {
                    Status.Opened => "Open",
                    Status.Unlocked => "Unlock",
                    Status.Closed => "Close",
                    Status.Locked => "Lock"
                };
                return errorWording;
            }
        
        }
        public enum Status { Opened, Closed, Locked, Unlocked } // enum to handle the door status
    }
}