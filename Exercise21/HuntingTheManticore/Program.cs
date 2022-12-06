using System.Security.Cryptography.X509Certificates;

namespace HuntingTheManticore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Boss Battle Hunting the Manticore
             * 
             * The Uncoded One's airship, the manticore, has begun an all-out attack on the city of Consolas. It must be destroyed, or the city will fall. Only by combining
             * Mylara's prototype, Skorin's cannon, and your programming skills will you have a chance to win this fight. You must build a program that allows one user - 
             * the pilot of the Manticore - to enter the airship's range from the city and a second user - the city's defenses - to attempt to find what distance the airship is
             * at and destroy it before it can lay waste to the town.
             * 
             * The first user begins by secretly establishing how far the Manticore is from the city, in the range of 0 to 100. The program then allows a second player to repeatedly
             * attempt to destory the airship by picking the range to the target until either the city of Consolas or the Manticore is destroyed. In each attempt, the player is told
             * if they overshot (to far), fell short (not far enough), or hit the Manticore. The damage dealt to the Manticore depends on the turn number. For most turns, 1 point
             * of damage is dealt. But if the turn number is a multiple of 3, a fire blast deals 3 points of damage; a multiple of 5; an electric blast deals 3 points points of damage,
             * and if it is a multiple of both 3 and 5, a mighty fire-electric attack deals 10 points of damage. The Manticore is destoryed after 10 points of damage.
             * 
             * However, if the Manticore survives a turn, it will deal a guaranteed 1 point of damage to the city of Consolas. The city can only take 15 points of damage before being
             * annihilated.
             * 
             * Before a round begins, the user should see the current status: the current round number, the city's health, and the Manticore's health.
             * A sample run of the program is shown below. The first player gets a chance to place the Manticore:
             * Player 1, how far away from the city do you want to station the Manticore? 32
             * 
             * At this point, the display is cleared, and the second player gets their chance:
             * Player 2, it is your turn.
             * -------------------------------------------------------------------------------
             * Status: Round: 1 City: 15/15 Manticore: 10/10
             * The cannon is expected to deal 1 damage this round.
             * Enter desired cannon range: 50
             * That round OVERSHOT the target
             * -------------------------------------------------------------------------------
             * Status: Round: 2 City: 14/15 Manticore: 10/10
             * The cannon is expected to deal 1 damage this round.
             * Enter desired cannon range: 25
             * That round FELL SHORT of the target
             * -------------------------------------------------------------------------------
             * Status: Round: 3 City: 13/15 Manticore: 10/10
             * The cannon is expected to deal 3 damage this round.
             * Enter desired cannon range: 32
             * That round was a DIRECT HIT!
             * -------------------------------------------------------------------------------
             * ETC... until either the City or the Manticory has fallen.
             * 
             * Objectives:
             * Establish the game's starting state: The Manticore begins with 10 health points and the city with 15. The game starts at round 1.
             * Ask the first player to choose the Manticore's distance from the city (0 to 100). Clear the screen afterward.
             * Run the game in a loop until until either the Manticor's or city's health reaches 0.
             * Before the second player's turn, display the round number, the city's health, and the Manticore's health.
             * Compute how much damage the cannon will deal this round: 10 points if the round number is a multiple of both 3 and 5, 3 if it is a multiple of 3 or 5 (not both), and
             * 1 otherwise. Display this to the player each turn.
             * Get a target range from the second player, and resolve its effect. Tell the user if they overshot (too far), fell short, or hit the Manticore. If it was hit, reduce the
             * Manticore's health by the expected amount.
             * If the Manticore is still alive, reduce the city's health by 1.
             * Advance to the next round.
             * When the Manticore or the city's health reaches 0, end the game and display the outcome.
             * Use different colors for different types of messages.
             * NOTE:
             * This is the largest program you have made so far. Expect it to take some time! Use methods to focus on solving one problem at a time.
             * This version requires two players, but in the future, we will modify it to allow the computer to randomly place the Manticore so that it can be a single-player game.
             * 
             */

            // some variables up top to utilize in the code below.
            int round = 1;
            int currentCityHealth = 15;
            int maxCityHealth = 15;
            int currentManticoreHealth = 10;
            int maxManticoreHealth = 10;
            int manticoreLocation = 0;
            int shotFired = 0;
            int currentCannonDamage = 0;

            // some static text to start the match with.
            Console.WriteLine("Welcome to Hunting the Manticore!");
            Console.WriteLine("The Manticore starts with 10 health and the City starts with 15 health.");
            Console.WriteLine("To begin the game we will have our pilot enter the distance from the city for the Manticore's placement.");
            Console.WriteLine("The hunter should not be allowed to watch this step.");

            // pilot placement of the manticore
            manticoreLocation = NumberInARange("Pilot where would you like to place the Manticore?", 0, 100);
            Console.Clear();

            // hunters turn begins here
            Console.WriteLine("Hunter, it is now your turn.");
            while(currentCityHealth > 0 && currentManticoreHealth > 0) 
            {
                Status();
                CannonDamageGuide();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"The cannon is expected to deal {currentCannonDamage} damage this round.");
                
                shotFired = NumberInARange("Hunter Enter the desired cannon range: ", 0, 100);
                CombatReport();
                
                if(currentManticoreHealth > 0) currentCityHealth -= 1;
                round++;
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            if (currentCityHealth <= 0) Console.WriteLine("The city of Consolas has fallen hunter!");
            if (currentManticoreHealth <= 0) Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved hunter!");

            /*------------------------------------------------------------- Methods Begin Here -------------------------------------------------------------*/

            /// <summary>
            /// Asks the user a question with a min and max range using a do while loop to ensure the loop runs once and keep going until they get it correct. questions are in green.
            /// </summary>
            int NumberInARange(string text, int min, int max)
            {
                int number;
                do
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{text} Choose a number between {min} and {max}: ");
                    number = Convert.ToInt32(Console.ReadLine());
                } while (number < min || number > max);
                Console.ForegroundColor = ConsoleColor.White;
                return number;
            }

            /// <summary>
            /// Updates the status of the game for the use each turn
            /// </summary>
            void Status()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("---------------------------------------------------------------------------------------------");
                Console.WriteLine($"Status: Round: {round} City: {currentCityHealth}/{maxCityHealth} Manticore: {currentManticoreHealth}/{maxManticoreHealth}");
                                
            }

            /// <summary>
            /// Provides the current amount of damage to be expected by the city cannon
            /// </summary>
            void CannonDamageGuide() 
            {
                
                if (round % 3 == 0 && round % 5 == 0) currentCannonDamage = 10;
                else if (round % 3 == 0 || round % 5 == 0) currentCannonDamage = 3;
                else currentCannonDamage = 1;
            }

            /// <summary>
            /// Provides a summary of the cannon shot being fired and updates the damage to the Manticore if it is hit.
            /// </summary>
            void CombatReport()
            { 
                Console.ForegroundColor= ConsoleColor.Red;
                if(shotFired == manticoreLocation)
                {
                    Console.WriteLine("Hunter that was a DIRECT HIT!");
                    currentManticoreHealth -= currentCannonDamage;
                }
                if(shotFired != manticoreLocation) 
                {
                    if (shotFired > manticoreLocation) Console.WriteLine("Hunter that round OVERSHOT the target.");
                    if (shotFired < manticoreLocation) Console.WriteLine("Hunter that round FELL SHORT of the target.");
                }

            }

        }
    }
}