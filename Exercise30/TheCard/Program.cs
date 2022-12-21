
namespace TheCard
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
             * The digital Realms of C# have playing cards like ours but with some differences. Each card has a color (red, green, blue, yellow) and rank ( the numbers 1 through
             * 10, followed by the symbols $, %, ^, and &). The third pedestal requires that you create a class to represent a card of this nature.
             * 
             * Objectives:
             * 
             * Define enumerations for card colors and card ranks.
             * Define a Card class to represent a card with a color and a rank, as described above
             * Add properties or methods that will tell you if a card is a number or symbol card (the equivalent of a face card).
             * Create a main method that will create a card instace for the whole deck (every color with every rank) and display each(for example, "The Red Ampersand" and and
             * "The Blue Seven".
             * Answer this Question: Why do you think we used a color enumeration here but made a color class in the previous challenge?
             * My answer is we did not need to define the colors themselves here, we needed to define different cards based on a set of colors.
             */
            Color[] colors = { Color.Red, Color.Green, Color.Blue, Color.Yellow };
            Rank[] ranks = { Rank.One, Rank.Two, Rank.Three, Rank.Four, Rank.Five, Rank.Six, Rank.Seven, Rank.Eight, Rank.Nine, Rank.Ten, Rank.Dollar, Rank.Percent, Rank.Carot, Rank.Ampersand };
            foreach (Color color in colors) 
            {
                foreach(Rank rank in ranks)
                {
                    Card card = new Card(color, rank);
                    Console.WriteLine($"This {card.CardType} card is a {card.Suit} {card.CardRank}");
                }
            }

        }
        /// <summary>
        /// This Class describes the cards and its properties.
        /// </summary>
        public class Card
        {
            // Auto Properties
            public Color Suit { get; init; }
            public Rank CardRank { get; init; }

            // constructor
            public Card(Color Suit, Rank CardRank) // 56 cards in total to have one card of each rank in each suit.
            {
                this.Suit = Suit;
                this.CardRank = CardRank;
            }
            // Properties with Logic
            public string CardType
            {

                get
                {
                    if (CardRank == Rank.Dollar || CardRank == Rank.Percent || CardRank == Rank.Carot || CardRank == Rank.Ampersand)
                    {
                        return "\"symbol\"";
                    }
                    else return "\"number\"";
                }
                

            }
        }
        // Enumerations
        public enum Color { Red, Green, Blue, Yellow }
        public enum Rank { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Dollar, Percent, Carot, Ampersand}
    }
}