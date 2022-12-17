namespace PropertiesOfArrows
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Vin Fletcher once again has run to catch up to you for your help with his arrows. "My apologies, Programmer! This will be the last time I bother you.
             * My cousin, Flynn Vetcher, is the only other arrow maker in the area. He doesn't care for his craft and makes widly dangerous and overpriced arrows. But people
             * keep buying them because they think my GetLegth() methods are harder to work with than his public _lenght fields. I don't want to give up the protections we just
             * gave these arrows, but I remembered you saying something about properties. Maybe you could use those to make my arrows easier to work with?"
             * 
             * Objectives:
             * Modify you Arrow class to use properties instead of Getx and Setx methods.
             * Ensure the whole program can still run, and Vin can keep creating arrows with it.
             */

            Console.WriteLine("Welcome back to Vin Flethcers Arrow Shop!");

            Console.WriteLine("What type of arrows are you looking for?");
            Arrow usersGeneratedArrow = new Arrow(UserGeneratedArrowHead(), UserGeneratedFletching(), UserGeneratedLength());
            Console.WriteLine(usersGeneratedArrow.ToString());
            double cost = usersGeneratedArrow.GetArrowPrice();
            Console.WriteLine($"These arrows will cost {cost} Gold!");





            /*------------------------------------------- Methods ------------------------------------------- */
            /// <summary>
            /// This method is used to collect user input for the arrow head type
            /// </summary>
            ArrowHead UserGeneratedArrowHead()
            {
                Console.Write("Enter the arrowhead type: (1 = steel, 2 = wood, 3 = obsidian) ");
                int option = Convert.ToInt32(Console.ReadLine());
                ArrowHead usersArrowHead = option switch // set the arrowhead type
                {
                    1 => ArrowHead.Steel,
                    2 => ArrowHead.Wood,
                    3 => ArrowHead.Obsidian
                };
                return usersArrowHead; // returns for the new arrow to be created this is passed to the constructor
            }

            /// <summary>
            /// This method is used to collect user input for the fletching head type
            /// </summary>
            Fletching UserGeneratedFletching()
            {
                Console.Write("Enter the fletching type: (1 = plastic, 2 = turkey feathers, 3 = goose feathers) ");
                int option = Convert.ToInt32(Console.ReadLine());
                Fletching usersFletching = option switch // set the fletching type
                {
                    1 => Fletching.Plastic,
                    2 => Fletching.Turkey,
                    3 => Fletching.Goose

                };
                return usersFletching; // returns for the new arrow to be created this is passed to the constructor
            }

            /// <summary>
            /// This method is used to collect user input for the arrows length
            /// </summary>
            double UserGeneratedLength()
            {
                Console.Write("Enter a length for your arrow. (60 to 100 cm long): ");
                double option = Convert.ToInt32(Console.ReadLine());
                return option; // returns for the new arrow to be created this is passed to the constructor               
            }


        }
        /*------------------------------------------- Classes ------------------------------------------- */
        /// <summary>
        /// This Class is used to build arrows with a single constructor where you can provide the head type, fletching type, and shaft length
        /// </summary>
        public class Arrow
        {
            // Properties
            public ArrowHead ArrowHead { get; } // properties for the arrowhead
           
            public Fletching Fletching { get; }// properties for the fletching
            public double ArrowLength { get; } // properties for the arrow length

            // Constructor
            public Arrow(ArrowHead arrowHead, Fletching fletching, double shaftLength)
            {
                ArrowHead = arrowHead;
                Fletching = fletching;
                ArrowLength = shaftLength;
            }



            /*------------------------------------------- Class Methods------------------------------------------- */
            /// <summary>
            /// This method is used to determine the price of an arrow
            /// </summary>
            public double GetArrowPrice()
            {
                double arrowHeadPrice;
                double fletchingPrice;
                double shaftPrice;
                double finalArrowPrice;

                arrowHeadPrice = ArrowHead switch // switch for pricing the head cost
                {
                    ArrowHead.Steel => 10, // sets the price of the arrowhead for steel
                    ArrowHead.Wood => 3, // sets the price of the arrowhead for wood
                    ArrowHead.Obsidian => 5, // sets the price of the arrowhead for obsidian
                    _ => 0
                };

                fletchingPrice = Fletching switch //switch for pricing the fletching
                {
                    Fletching.Plastic => 10, // sets the price of the fletching if plastic
                    Fletching.Turkey => 5, // sets the price of the fletching if turkey
                    Fletching.Goose => 3, // sets the price of the fletching if goose
                    _ => 0
                };
                shaftPrice = ArrowLength * .05; // calculates the price of the arrow lenght

                finalArrowPrice = arrowHeadPrice + fletchingPrice + shaftPrice; // adds up all the prices together and stores them in a double
                return finalArrowPrice; // returns the double final price
            }

            /// <summary>
            /// This override is used to provide feedback on all attributes of the arrow that was created.
            /// </summary>
            public override string ToString() // overriding the ToString to control formatting for the returned information.
            {
                string arrowHead;
                string fletching;
                string shaft;

                arrowHead = ArrowHead switch
                {
                    ArrowHead.Steel => "steel",
                    ArrowHead.Wood => "wood",
                    ArrowHead.Obsidian => "obsidian"
                };

                fletching = Fletching switch
                {
                    Fletching.Plastic => "plastic",
                    Fletching.Turkey => "turkey feather",
                    Fletching.Goose => "goose feather"
                };

                shaft = ArrowLength.ToString();


                return $"Your selected arrows are made up of {arrowHead} arrowheads, {fletching} fetching, and have a lenght of {shaft} centimeters.";
            }
        }
        /*------------------------------------------- Enumerations ------------------------------------------- */
        public enum ArrowHead { Steel, Wood, Obsidian }
        public enum Fletching { Plastic, Turkey, Goose }
    }
    
}