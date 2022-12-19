namespace ArrowFactories
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Vin Fletcher somethimes makes custom-ordered arrows, but these are rare. Most of the time, he sells one of the following standard arrows.
             * The Elite Arrow, made from a steel arrowhead, plastic fletching, and a 95 cm shaft.
             * The Beginner Arrow, made from a wood arrowhead, goose feathers, and a 75 cm shaft.
             * The Marksman Arrow, made from a steel arrowhead, goose feathers, and a 65 cm shaft.
             * 
             * You can make static methods to make these variations of arrows easier to create.
             * 
             * Objectives:
             * Modify your Arrow class one final time to include static methods of the form public static Arrow CreateEliteArrow() {....} for each of the three above types.
             * Modify the program to allow users to choose one of these pre-defined types or a custom arrow. If they select one of the predefined styles, produce and Arrow
             * instance using one of the new static methods. If they choose a custom arrow, use your earlier code to get their custom data about the desired arrow.
             */

            Console.WriteLine("Welcome back to Vin Flethcers Arrow Shop!");

            Console.WriteLine("What type of arrows are you looking for?");
            Console.Write("Choose: (1 = Create Elite Arrows, 2 = Create Marksman Arrows, 3 = Create Beginner Arrows, 4 = Create Custom Arrows) ");
            int usersChoice = Convert.ToInt32(Console.ReadLine());
            Arrow NewArrows = usersChoice switch
            {
                1 => Arrow.CreateEliteArrow(),
                2 => Arrow.CreateMarksmanArrow(),
                3 => Arrow.CreateBeginnerArrow(),
                4 => new Arrow(UserGeneratedArrowHead(), UserGeneratedFletching(), UserGeneratedLength())

            };
            
            Console.WriteLine(NewArrows.ToString());
            double cost = NewArrows.GetArrowPrice();
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
            /// This method is static and returns a predefined arrow type Elite Arrow
            /// </summary>
            public static Arrow CreateEliteArrow() // creates an elite arrow based on a set of given attributes
            {
                return new Arrow(ArrowHead.Steel, Fletching.Plastic, 95);
            }
            /// <summary>
            /// This method is static and returns a predefined arrow type Beginner Arrow
            /// </summary>
            public static Arrow CreateBeginnerArrow() 
            {
                return new Arrow(ArrowHead.Wood, Fletching.Goose, 75);
            }
            /// <summary>
            /// This method is static and returns a predefined arrow type Marksman Arrow
            /// </summary>
            public static Arrow CreateMarksmanArrow()
            {
                return new Arrow(ArrowHead.Steel, Fletching.Goose, 65);
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


                return $"Your selected arrows are made up of {arrowHead} arrowheads, {fletching} fletching, and have a lenght of {shaft} centimeters.";
            }
        }
        /*------------------------------------------- Enumerations ------------------------------------------- */
        public enum ArrowHead { Steel, Wood, Obsidian }
        public enum Fletching { Plastic, Turkey, Goose }
    
    }
}