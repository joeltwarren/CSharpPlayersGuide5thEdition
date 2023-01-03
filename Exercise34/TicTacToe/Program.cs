namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            Game CurrentGame = new Game(); // new game object
            ConsoleInput AskUser = new ConsoleInput(); // askUser object
            ScoreBoard CurrentScoreboard = new ScoreBoard(AskUser.BestOf()); // new scoreboard object
            Player Player1 = new Player(AskUser.GetPlayerName(), AskUser.SetPiece()); // player 1 object
            Player Player2 = new Player(AskUser.GetPlayerName(), AskUser.SetPiece()); // player 2 object
            int rounds = 1;
            while (!CurrentScoreboard.Winner(Player1) && !CurrentScoreboard.Winner(Player2)) // loop until someone wins the best of game requirement
            {

                Console.Clear();
                Console.WriteLine(CurrentScoreboard.CurrentLeader(Player1, Player2));
                Console.WriteLine($"Number of Wins required to win the game: {CurrentScoreboard.WinsRequired}");
                CurrentGame.DisplayGameBoard();
                if (rounds%2 != 0) { CurrentGame.UpdateGameBoard(AskUser.PlaceAPiece(CurrentGame, Player1), Player1); }
                else if(rounds%2 == 0) { CurrentGame.UpdateGameBoard(AskUser.PlaceAPiece(CurrentGame, Player2), Player2); }
                rounds++;
                Console.Clear();
                CurrentGame.DisplayGameBoard();

                if (CurrentGame.CheckForWinningCondition(Player1) || CurrentGame.CheckForWinningCondition(Player2) || CurrentGame.CheckforTiedConditions()) // if player one or player two  wins a round or the board is tied reset the game
                {
                    rounds = 1;
                    CurrentGame = new Game(); 
                }
    
            }
            Console.Clear();
            if (CurrentScoreboard.Winner(Player1))
            {
                Console.WriteLine($"{Player1.Name} is the Winner!");
            }
            else { Console.WriteLine($"{Player2.Name} is the Winner!"); }
            





        }
        /// <summary>
        /// The Game class tracks the current board arrangment and required wins to be the victor
        /// </summary>
        public class Game
        {
            // the private array is used to track the game positions of X's and O's or open slots
            private string[] _boardLocations = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            
           
            public void DisplayGameBoard() 
            {
                
                Console.WriteLine();
                Console.Write(" ");
                ColorSelector(0);
                Console.Write(" ");
                Console.ForegroundColor= ConsoleColor.Yellow;
                Console.Write("|");
                Console.Write(" ");
                ColorSelector(1);
                Console.Write(" ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("|");
                Console.Write(" ");
                ColorSelector(2);
                Console.Write(" ");
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("---+---+---");
                

                Console.Write(" ");
                ColorSelector(3);
                Console.Write(" ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("|");
                Console.Write(" ");
                ColorSelector(4);
                Console.Write(" ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("|");
                Console.Write(" ");
                ColorSelector(5);
                Console.Write(" ");
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("---+---+---");
                

                Console.Write(" ");
                ColorSelector(6);
                Console.Write(" ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("|");
                Console.Write(" ");
                ColorSelector(7);
                Console.Write(" ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("|");
                Console.Write(" ");
                ColorSelector(8);
                Console.Write(" ");
                Console.WriteLine();
            }

            public void UpdateGameBoard(int index, Player currentPlayer) 
            {
                _boardLocations[index] = currentPlayer.Piece;
            }

            public int[] GetValidPositionsLeft()
            {
                int validOptionsLeft = 0;
                foreach (string locations in _boardLocations)
                {
                    if (locations != "X" && locations != "O") { validOptionsLeft++; }
                }
                int[] validPositions = new int[validOptionsLeft];
                int index = 0;
                foreach (string locations in _boardLocations)
                {
                    int validInt;
                    if (int.TryParse(locations, out validInt))
                    {
                        
                        validPositions[index] = validInt;
                        index++;
                    }
                }
                return validPositions;



            }
            private void ColorSelector(int index) 
            {
                if (_boardLocations[index].ToUpper() == "X")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("X");
                    Console.ForegroundColor = ConsoleColor.White;

                }
                else if (_boardLocations[index].ToUpper() == "O")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("O");
                    Console.ForegroundColor = ConsoleColor.White;

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{_boardLocations[index]}");
                    
                }
            }

            public bool CheckForWinningCondition(Player player) 
            {
                if (_boardLocations[0] == player.Piece && _boardLocations[1] == player.Piece && _boardLocations[2] == player.Piece) // Three X's or O's across the top
                {
                    player.Wins++;
                    Console.WriteLine($"{player.Name} Wins this round!");
                    Console.Write("Press any key to continue: ");
                    Console.ReadKey();
                    return true;
                }
                if (_boardLocations[3] == player.Piece && _boardLocations[4] == player.Piece && _boardLocations[5] == player.Piece) // Three X's or O's across the center
                {
                    player.Wins++;
                    Console.WriteLine($"{player.Name} Wins this round!");
                    Console.Write("Press any key to continue: ");
                    Console.ReadKey();
                    return true;
                }
                if (_boardLocations[6] == player.Piece && _boardLocations[7] == player.Piece && _boardLocations[8] == player.Piece) // Three X's or O's across the bottom
                {
                    player.Wins++;
                    Console.WriteLine($"{player.Name} Wins this round!");
                    Console.Write("Press any key to continue: ");
                    Console.ReadKey();
                    return true;
                }
                if (_boardLocations[0] == player.Piece && _boardLocations[3] == player.Piece && _boardLocations[6] == player.Piece) // Three X's or O's in the left column
                {
                    player.Wins++;
                    Console.WriteLine($"{player.Name} Wins this round!");
                    Console.Write("Press any key to continue: ");
                    Console.ReadKey();
                    return true;
                }
                if (_boardLocations[1] == player.Piece && _boardLocations[4] == player.Piece && _boardLocations[7] == player.Piece) // Three X's or O's in the center column
                {
                    player.Wins++;
                    Console.WriteLine($"{player.Name} Wins this round!");
                    Console.Write("Press any key to continue: ");
                    Console.ReadKey();
                    return true;
                }
                if (_boardLocations[2] == player.Piece && _boardLocations[5] == player.Piece && _boardLocations[8] == player.Piece) // Three X's or O's in the right column
                {
                    player.Wins++;
                    Console.WriteLine($"{player.Name} Wins this round!");
                    Console.Write("Press any key to continue: ");
                    Console.ReadKey();
                    return true;
                }
                if (_boardLocations[0] == player.Piece && _boardLocations[4] == player.Piece && _boardLocations[8] == player.Piece) // Three X's or O's from top left to bottom right positions
                {
                    player.Wins++;
                    Console.WriteLine($"{player.Name} Wins this round!");
                    Console.Write("Press any key to continue: ");
                    Console.ReadKey();
                    return true;
                }
                if (_boardLocations[2] == player.Piece && _boardLocations[4] == player.Piece && _boardLocations[6] == player.Piece) // Three X's or O's from top right to bottom left positions
                {
                    player.Wins++;
                    Console.WriteLine($"{player.Name} Wins this round!");
                    Console.Write("Press any key to continue: ");
                    Console.ReadKey();
                    return true;
                }
                return false;
            }
            public bool CheckforTiedConditions() 
            {
                int testingInt;
                foreach (string positions in _boardLocations) 
                {
                    
                    if(int.TryParse(positions, out testingInt)) // if any of the _boardLocations can be parsed to an INT then the game continues
                    {
                        return false; 
                    }
                }
                Console.WriteLine();
                Console.WriteLine("The Game was a Tie! Starting another round.");
                Console.Write("Press any key to continue.");
                Console.ReadKey();
                return true; // only occurs if no position can be parsed to an INT meaning all positions are an X or an O
                
            }
            
        }
        /// <summary>
        /// The player class tracks the users name, chosen piece X or O, and current number of wins
        /// </summary>
        public class Player 
        {
            // auto properties
            public string Name { get; private set; }
            public string Piece { get; private set; }
            public int Wins { get; set; } = 0;

            // constructor
            public Player(string name, string piece) 
            {
                Name = name;
                Piece = piece;
            }
        }
        /// <summary>
        /// The ScoreBoard class keeps track of the current scores and the games overall win status
        /// </summary>
        public class ScoreBoard 
        {
            // properties
            public int WinsRequired { get; private set; } // tracks number of wins required to win the game
            
            // constructor to build the scoreboard
            public ScoreBoard(int numberOfGamesTotal) 
            {
                WinsRequired = (numberOfGamesTotal / 2) + 1;
            }
            // displays the current winner by number of scored wins in the whole game
            public string CurrentLeader(Player player1, Player player2) 
            {
                string leader = "";
                if (player1.Wins > player2.Wins) { leader = $"{player1.Name} is the Current Leader with {player1.Wins} wins."; }
                if (player2.Wins > player1.Wins) { leader = $"{player2.Name} is the Current Leader with {player2.Wins} wins."; }
                if (player1.Wins == player2.Wins && player1.Wins == 0 && player2.Wins == 0) { leader = $"This is a New Game between {player1.Name} and {player2.Name}"; }
                else if (player1.Wins == player2.Wins) { leader = $"Tied Game between {player1.Name} and {player2.Name}"; }
                return leader;
            }
            public bool Winner(Player player) 
            {
                if (player.Wins < WinsRequired) { return false; }
                return true;
            }
            
        }
        /// <summary>
        /// The ConsoleInput class asks for users input and return the needed values to the program to build the game.
        /// </summary>
        public class ConsoleInput
        {
            // list used to track pieces so that the second player knows which one is left to choose from
            private List<string> pieces = new List<string> { "X", "O" };
            public ConsoleInput() { } // paramaterless constructor

            public string GetPlayerName()
            {
                Console.Write("Please enter your name: ");
                string name = Console.ReadLine();
                return name;
            }
            public string SetPiece() // gets the users choice of pieces.. I could expand this but for this exercise I wont auto assign the second players piece
            {
                string usersChoice = ""; // set to nothing
                while (usersChoice != "X" && usersChoice != "O") // until the user picks x or o we keep going
                { 
                    Console.WriteLine("Please choose a Board Piece: ");

                    foreach (string piece in pieces) 
                    {
                        Console.Write(piece + " "); 
                    }
                    usersChoice = Console.ReadLine().ToUpper();

                    if (usersChoice.ToUpper() == "X")
                    {
                        pieces.Remove("X");
                    }
                    else if (usersChoice.ToUpper() == "O") 
                    {
                        pieces.Remove("O");
                    }
                }
                return usersChoice;
            }
            public int PlaceAPiece(Game currentGame, Player player) // asks the user for a number that is a valid placement option
            {
                Console.WriteLine();
                Console.WriteLine($"{player.Name} Please choose a number to replace with your piece.");
                Console.WriteLine("Your options are:");
                foreach (int validPlacement in currentGame.GetValidPositionsLeft()) 
                {
                    Console.WriteLine(validPlacement + ":");    
                }
                Console.Write("Enter your option: ");
                string optionPicked = Console.ReadLine()!;
                int usersChoice;
                while(!int.TryParse(optionPicked,out usersChoice) || !currentGame.GetValidPositionsLeft().Contains(usersChoice))
                {
                    Console.WriteLine("Invalid options please try again.");
                    optionPicked = Console.ReadLine()!;
                }
                int indexToReturn = usersChoice - 1;
                return indexToReturn;

            }
            public int BestOf() 
            {
                Console.Write("Play to the best of? ");
                string input = Console.ReadLine()!;
                int bestOf;
                while (!Int32.TryParse(input, out bestOf)) 
                {
                    Console.WriteLine("Invalid number!");
                    Console.Write("Play to the best of? ");
                    input = Console.ReadLine()!;
                }
                
                return bestOf;
            }
        
        }
    }
}