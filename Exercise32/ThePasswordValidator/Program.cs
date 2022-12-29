namespace ThePasswordValidator
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
            * The fourth pedestal demanded constructing a door class with a locking mechanism that requires a unique numeric code to unlock. You have done something similar before
            * without using a class, but the locking mechanism is new. The door should only unlock if the passcode is the right one. The following statement describe how the door works.
            * An open door can always be closed.
            * A closed (but not locked) door can always be opened.
            * A closed door can always be locked.
            * A locked door can be unlocked, but a numeric passcode is needed, and the door will only unlock if the code supplied matches the doors's current passcode.
            * When a door is created, it must be given an initial passcode.
            * Additionally, you should be able to change the passcode by supplying the current code and a new one. The passcode should only change if the correct, current code is given.
            * Having completed the fourth pedestal you move onto the final pedestal.
            * 
            * ===============================================================================================================================================================
            * 
            * The fifth and final pedestal describes a class that represents a concept more abstract than the first four: a password validator. You must create a class
            * that can determine if a password is valid (meets the rules defined for a legitmate password). The pedestal initially doesn't describe any rules, but as you brush
            * the dust off the pedestal, it vibrates for a moment, and the following rules appear.
            * 
            * Passwords must be at least 6 characters long and no more than 13 letters long.
            * Passwords must contain at least one uppercase letter, one lowercase letter, and one number.
            * Passwords cannot contain a capital T or an Ampersand (&) because Ingelmar in IT decreed it.
            * 
            * That last rule seems random, and you wonder if the pedestal is just tormenting you with obscure rules.
            * You ponder for a moment about how to decide if a character is uppercase, lowercase, or a number, but while scratching your head, you notice a piece of folded
            * parchment on the ground near your feet. You pick it up, unfold it, and read it:
            * 
            * foreach with a string lets you get its characters!
            * > foreach (char letter in word) {...}
            * char has static methods to categorize letters!
            * > char.IsUpper('A'), char.IsLower('a'), char.IsDigit('0')
            * 
            * That might be useful information! You are grateful to whoever left it behind. It is signed simply "A"
            * 
            * Objectives:
            * 
            * Define a new PasswordValidator class that can be given a password and determine if the password follows the rules above.
            * Make your main method a loop forever, asking for a password and reporting whether the password is allowed using an instance of the PasswordValidator class.
            */
            
            PasswordValidation validator = new PasswordValidation();
            while (true) 
            {
                string password = AskUserForPassword();
                Console.WriteLine($"The password you entered {password}");
                if (validator.IsValid(password) && password != null) { Console.WriteLine("Is Valid"); }
                else 
                {
                    string error = validator.Notification(password);
                    Console.WriteLine("is Invalid for the following reason:");
                    Console.WriteLine(error);
                }
            
            }

            //******************************************************************* Console Methods *******************************************************************

            string AskUserForPassword()
            {
                Console.Write("Please enter a password to test whether it is valid to use in our system! ");
                string? userResponse = Console.ReadLine();
                return userResponse;
            }
        }
        
        //******************************************************************* Classes *******************************************************************
        public class PasswordValidation 
        {
            public bool IsValid(string password)
            {
                // series of checks to determine if the password fails. If it does not fail it passes
                if (password.Length < 6) { return false; }
                if (password.Length > 13) { return false; }
                if (!UpperCase(password)) { return false; }
                if (!Lowercase(password)) { return false; }
                if (!IncludesNumbers(password)) { return false; }
                if (SpecificsCheck(password, 'T')) { return false; }
                if (SpecificsCheck(password, '&')) { return false; }

                return true;
            }
            private bool UpperCase(string password) // checks for uppercase letters
            {
                foreach (char c in password) 
                {
                    if (char.IsUpper(c)) { return true; }
                }
                return false;
            }
            private bool Lowercase(string password) // checks for lowercase letters
            {
                foreach (char c in password)
                {
                    if (char.IsLower(c)) { return true; }
                }
                return false;
            }
            private bool IncludesNumbers(string password) // checks for digits in the password
            {
                foreach (char c in password)
                {
                    if (char.IsDigit(c)) { return true; }
                }
                return false;
            }
            private bool SpecificsCheck(string password, char letterNotAllowed) // method to check the password for specific letters not allowed.
            { 
                foreach(char c in password) 
                {
                    if (c == letterNotAllowed) { return true; }
                }
                return false;
            }

            public string Notification(string password) // provides user with feed back as to why the password is not valid
            {
                string messageToReturn = "The Password ";

                if (password.Length < 6) { messageToReturn += "is less than 6 characters long"; }
                if (password.Length > 13) { messageToReturn += "is more than 13 characters long"; }
                if (!UpperCase(password)) { messageToReturn += "does not contain a Upper Case letter"; }
                if (!Lowercase(password)) { messageToReturn += "does not contain a Lower Case letter"; }
                if (!IncludesNumbers(password)) { messageToReturn += "does not contain a Number"; }
                if (SpecificsCheck(password, 'T')) { messageToReturn += "does contain an invalid \"T\""; }
                if (SpecificsCheck(password, '&')) { messageToReturn += "does contain an invalid \"&\""; }

                return messageToReturn;

            }
        }
    }
}