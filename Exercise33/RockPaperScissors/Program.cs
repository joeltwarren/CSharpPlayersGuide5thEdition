namespace RockPaperScissors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Rock, Paper, Scissors where players battle it out old school!");

            GameStats CurrentGame = new GameStats(); // begins stat tracking

            Console.Write("Player 1 please enter your name: ");
            string player1Name = Console.ReadLine()!;
            Console.Write("Player 2 please enter your name: ");
            string player2Name = Console.ReadLine()!;

            Player Player1 = new Player(player1Name); // created player one
            Player Player2 = new Player(player2Name); // created player two
            Battle CurrentBattle = new Battle(); // object to handle the round battles

            bool keepPlaying = true;

            while (keepPlaying)
            {

                Console.WriteLine($"Current Winner is: {CurrentGame.CurrentLeader(Player1, Player2).ToString()}");
                Console.WriteLine($"Player: {Player1.Name.ToString()} has won: {Player1.Wins.ToString()}");
                Console.WriteLine($"Player: {Player2.Name.ToString()} has won: {Player2.Wins.ToString()}");
                Console.Write($"{Player1.Name} please choose (1) for Rock, (2) for paper, or (3) for Scissors!: ");
                string player1Choice = Console.ReadLine()!;
                Player1.ChosenWeapon = player1Choice switch
                {
                    "1" => Weapon.Rock,
                    "2" => Weapon.Paper,
                    "3" => Weapon.Scissors
                };

                Console.Clear();

                Console.Write($"{Player2.Name} please choose (1) for Rock, (2) for paper, or (3) for Scissors!: ");
                string player2Choice = Console.ReadLine()!;
                Player2.ChosenWeapon = player2Choice switch
                {
                    "1" => Weapon.Rock,
                    "2" => Weapon.Paper,
                    "3" => Weapon.Scissors
                };

                string winner = CurrentBattle.DetermineWinner(Player1, Player2);
                Console.WriteLine($"{Player1.ToString()} and {Player2.ToString()}");
                Console.WriteLine($"Winner is: {winner}");

                Console.Write("Would you like to go another round? Yes or No: ");
                string keepGoing = Console.ReadLine()!;
                if (keepGoing.ToLower() == "yes") { Console.Clear(); }
                else keepPlaying = false;



            }


        }
        /***************************************** Classes *****************************************/

        /// <summary>
        /// This GameStats class is used to keep track of the current winner
        /// </summary>
        public class GameStats
        {
            public GameStats() { } // parameterless constructor
            public string CurrentLeader(Player player1, Player player2) // tracks the current leader
            {
                if (player1.Wins > player2.Wins) { return player1.Name; }
                else if (player1.Wins < player2.Wins) { return player2.Name; }
                else { return "Tied"; }
            }

        }
        /// <summary>
        /// The player class contains the players name, personal win record, and weapon choice
        /// </summary>
        public class Player
        {

            public string Name { get; private set; } = "player"; // default value to initilaze a name if enter is hit.
            public int Wins { get; set; } = 0; // default value set to zero and can be incremented as needed outside the class.
            public Weapon ChosenWeapon { get; set; } // I left this public so we could change weapons each turn
            public Player(string name) { Name = name; } // constructor that requres a name string
            public override string ToString()
            {
                string name = Name;
                string weapon = ChosenWeapon.ToString();
                return name + " chose " + weapon;
            }

        }
        /// <summary>
        /// This battle class determines the winner of the current round and updates their scores accordingly
        /// </summary>
        public class Battle
        {
            public Battle() { }
            public string DetermineWinner(Player player1, Player player2) // if statements to determine who won the round and increment player stats as needed
            {
                if (player1.ChosenWeapon == Weapon.Rock && player2.ChosenWeapon == Weapon.Scissors)
                {
                    player1.Wins++;
                    return player1.Name;
                }
                if (player1.ChosenWeapon == Weapon.Scissors && player2.ChosenWeapon == Weapon.Paper)
                {
                    player1.Wins++;
                    return player1.Name;
                }
                if (player1.ChosenWeapon == Weapon.Paper && player2.ChosenWeapon == Weapon.Rock)
                {
                    player1.Wins++;
                    return player1.Name;
                }
                if (player1.ChosenWeapon == Weapon.Rock && player2.ChosenWeapon == Weapon.Rock) { return "round tied"; }
                if (player1.ChosenWeapon == Weapon.Scissors && player2.ChosenWeapon == Weapon.Scissors) { return "round tied"; }
                if (player1.ChosenWeapon == Weapon.Paper && player2.ChosenWeapon == Weapon.Paper) { return "round tied"; }

                player2.Wins++;
                return player2.Name;
            }

        }

        /***************************************** Enums *****************************************/
        /// <summary>
        /// This is a short list of enums since we only have three types of weapons to choose from
        /// </summary>
        public enum Weapon { Rock, Paper, Scissors }
    }
    
}