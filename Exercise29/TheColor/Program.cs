namespace TheColor
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
             * The second pedestal asks you to create a Color class to represent a color. The pedestal includes an etching of this diagram that illustrates it potential usage
             *   -------
             *  |       | R --------------O 255
             *  |       | G ----------O---- 165
             *  |       | B O--------------   0
             *   -------
             * The color consists of three parts or channels: Red, Green, and Blue, which indicate how much those channels are lit up. Each channel can be from 0 to 255. 0
             * means completely off, 255 means completely on.
             * The pedestal also includes some color names, with a set of numbers indicating their specific values for each channel. These are commonly used colors: White (255,255,255),
             * Black (0,0,0), Red (255,0,0) Orange (255,265,0), Yellow (255,255,0), Green (0,128,0), Blue (0,0,255), Purple (128,0,128).
             * 
             * Objectives:
             * 
             * Define a new Color class with properties for its red, green, and blue channels.
             * Add appropriate constructors that you feel make sense for creating new Color objects.
             * Create static properties to define the eight commonly used colors for easy access.
             * In your main method, make two Color-typed variables. Use a constructor to create a color instance and use a static property for the other. Display each of their, red
             * green, and blue channel values.
             */

            Color pink = new Color(255,192,203);
            Color white = Color.White;
            Console.WriteLine($"The color Pink consists of - (Red:{pink.RedChannel}, Green:{pink.GreenChannel}, Blue:{pink.BlueChannel})");
            Console.WriteLine($"The color White consists of - (Red:{white.RedChannel}, Green:{white.GreenChannel}, Blue:{white.BlueChannel})");
        }
        /// <summary>
        /// This class will be used to define the properties of colors using the R,G,B channels.
        /// </summary>
        public class Color 
        {
            // auto properties that are immutable
            public int RedChannel { get; init; }
            public int GreenChannel { get; init; }
            public int BlueChannel { get; init; }

            public Color(int redChannel, int greenChannel, int blueChannel) // constructor
            {
                // utilizing this. to set the appropriate property values
                this.RedChannel = redChannel;
                this.GreenChannel = greenChannel;
                this.BlueChannel = blueChannel;
            }

            public static Color White => new Color(255,255,255); // static property for white
            public static Color Black => new Color(0, 0, 0); // static property for black
            public static Color Red => new Color(255, 0, 0); // static property for red
            public static Color Orange => new Color(255, 165, 0); // static property for orange
            public static Color Yellow => new Color(255, 255, 0); // static property for yellow
            public static Color Green => new Color(0, 128, 0); // static property for green
            public static Color Blue => new Color(0, 0, 255); // static property for blue
            public static Color Purple => new Color(128, 0, 128); // static property for purple

        }
    }
}