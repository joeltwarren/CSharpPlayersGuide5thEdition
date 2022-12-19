namespace ThePoint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * You arrive at the Catacombs of the Class, the place that will reveal the path to the Fountain of Objects. The Catacombs lie inside a mountain, with a wide stone 
             * entrance leading you into a series of three chambers. In the first chamber, you find five pedestals with the remnants of a class definition and specific instructions
             * by each. Etched above a sealed doorway at the back of the room is the text, "Only the True Programmer who can remake the Five Prototypes can proceed." Each pedestal
             * appears to have instructions for crafting a class. These are the Five Prototypes that you must ressemble.
             * 
             * The First pedestal asks you to create a Point class to store a point in two dimensions. Each point is represented by an x-coordinate(x), a side-to-side distance from
             * a special central point called the origin, and a y-coordinate(y), an up-and-down distance away from the origin.
             * 
             * Objectives:
             * 
             * Define a new Point class with properties for X and Y.
             * Add a constructor to create a point from a specific x- and y-coordinate.
             * Add a parameterless constructor to create a point at the origin(0,0).
             * In your main method, create a point at (2,3) and another at (-4,0). Display these points on the console windows in the format (x,y) to illustrate that the class works.
             * Answer this question: Are your X and Y properties immutable? Why did you choose what you did?
             */

            Point Point1 = new Point(2, 3); // first point requirements
            Point Point2 = new Point(-4, 0); // second point requirments
            
            Console.WriteLine($"Point 1 = ({Point1.xCoordinate},{Point1.yCoordinate})");
            Console.WriteLine($"Point 2 = ({Point2.xCoordinate},{Point2.yCoordinate})");
            Console.WriteLine($"Origin Point = ({Point.Origin.xCoordinate},{Point.Origin.yCoordinate})");

        }
        /// <summary>
        /// This class is used for tracking points in a 2D fashion from the distance of the origin point (0,0) X is Left to Right and Y is Up and Down
        /// </summary>
        public class Point 
        {
            private readonly int _x; // immutable coordinates
            private readonly  int _y; // immutable coordinates

            public int xCoordinate { get { return _x; } } // Getter for the X coordinate no setter as its a readonly property
            public int yCoordinate { get { return _y; } } // Getter for the Y coordinate no setter as its a readonly property
            public Point(int x, int y) { _x= x; _y = y; } // constructor to create a new point with give x and y parameters
            public Point() { _x = 0; _y = 0; } // parameterless constructor for creating the Origin point only
            public static Point Origin => new Point(); // static method for accessing the origin point coordinates
            

        }
    }
}