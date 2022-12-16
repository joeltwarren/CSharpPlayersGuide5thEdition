using static VinsTrouble.Program;
using System.Xml.Linq;

namespace VinsTrouble
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* 
             * "Master Programmer!" Vin Fletcher shouts at you as he races to catch up to you. "I have a problem. I created an arrow for a young man who took it and changed
             * its length to be half as long as I had designed. It no longer fit in his bow correctly and misfired. It sliced his hand pretty bad. He'll survive, but is there
             * anyway we can make sure somebody doesn't change an arrow's length when they walk away from my shop? I don't want to be the cause of such self-inflicted pain."
             * With your knowledge of information hiding, you know you can help.
             * 
             * Objectives:
             * Modify your Arrow class to have private instead of public fields.
             * Add in getter methods for each of the fields that you have.
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
            // private variables
            private ArrowHead _arrowHead;
            private Fletching _fletching;
            private double _shaftLength;

            // getters
            public ArrowHead GetArrowHead() => _arrowHead;
            public Fletching GetFletching() => _fletching;
            public double GetShaftLength() => _shaftLength;

            // Constructor
            public Arrow(ArrowHead arrowHead, Fletching fletching, double shaftLength)
            {
                _arrowHead = arrowHead;
                _fletching = fletching;
                _shaftLength = shaftLength;
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

                arrowHeadPrice = _arrowHead switch // switch for pricing the head cost
                {
                    ArrowHead.Steel => 10, // sets the price of the arrowhead for steel
                    ArrowHead.Wood => 3, // sets the price of the arrowhead for wood
                    ArrowHead.Obsidian => 5, // sets the price of the arrowhead for obsidian
                    _ => 0
                };

                fletchingPrice = _fletching switch //switch for pricing the fletching
                {
                    Fletching.Plastic => 10, // sets the price of the fletching if plastic
                    Fletching.Turkey => 5, // sets the price of the fletching if turkey
                    Fletching.Goose => 3, // sets the price of the fletching if goose
                    _ => 0
                };
                shaftPrice = _shaftLength * .05; // calculates the price of the arrow lenght

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

                arrowHead = _arrowHead switch
                { 
                    ArrowHead.Steel => "steel",
                    ArrowHead.Wood => "wood",
                    ArrowHead.Obsidian => "obsidian"
                };

                fletching = _fletching switch
                { 
                    Fletching.Plastic => "plastic",
                    Fletching.Turkey => "turkey feather",
                    Fletching.Goose => "goose feather"
                };
                
                shaft = _shaftLength.ToString();

                
                return $"Your selected arrows are made up of {arrowHead} arrowheads, {fletching} fetching, and have a lenght of {shaft} centimeters.";
            }
        }   
        /*------------------------------------------- Enumerations ------------------------------------------- */
        public enum ArrowHead { Steel, Wood, Obsidian }
        public enum Fletching { Plastic, Turkey, Goose}
    }
}