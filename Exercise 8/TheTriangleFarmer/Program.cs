namespace TheTriangleFarmer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * As you pass through the fields near Arithmetica City, you encounter P-Thag, a triangle farmer, scratching numbers in the dirt.
             * "What is all of that writing for?" you ask.
             * I'm just trying to calculate the area of all of my triangles. They sell by their size. The bigger they are, the more they are worth! But I have many triangles
             * on my farm, and the math gets tricky, and I sometimes make mistakes. Taking a tiny triangle to town thinking your're going to get 100 gold, only to be told it's
             * worth three, is not fun! If only I had a program that could help me....."Suddenly, P-Thag looks at you with fresh eyes. "Wait just a moment. You have the look
             * of a Programmer about you. Can you help me write a program that will compute the areas for me, so I can quit worrying about math mistakes and get back to tending to 
             * my triangles? The equation I'm using is this one here," he says, pointing to the formula, etched in a stone beside him: Area = Base times Height divided by 2
             * 
             * Objectives:
             * Write a program that lets you input the triangle's base size and height.
             * Compute the area of a triangle by turning the above equation in code.
             * Write the result of the computation.
             */

            // addressing the user
            Console.WriteLine("Hello P-Thag welcome to the Triangle Area Calculator");

            // asking user for the base width and storing in the string variable width.
            Console.WriteLine("What is the triangles base width?");
            string width = Console.ReadLine()!;
            

            // asking user for the triangles height and storing it in the string variable height
            Console.WriteLine("What is the triangles height?");
            string height = Console.ReadLine()!;
            
            // converting the width and height for working with the math. This has no error checking simply because of the current level of knowledge this book shows the users having.
            double triangleWidth = Convert.ToDouble(width);
            double triangleHeight = Convert.ToDouble(height);

            // do the math the () are used to maintain order of operations in C#
            double Area = (triangleWidth * triangleHeight) /2;

            // write it out to the screen for P-Thag
            Console.WriteLine($"Your triangle has an Area of {Area}");





        }
    }
}