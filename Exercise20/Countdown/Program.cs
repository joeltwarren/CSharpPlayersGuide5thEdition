namespace Countdown
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * NOTE: This challenge requires reading The Basics of Recursion side quest to attempt.
             * 
             * The Council of Freach has summoned you. New writing has appeared on the Tomb of Algol the Wise, the last True Programmer to wander this land.
             * The writing strikes fear and awe into the hearts of the loop-loving people of Freach."The next True Programmer shall be able to write any looping code with a method
             * call instead." The Senior Counselor, scared of a world without loops, asks you to put your skills to the test and rewrite the following code, which counts down
             * from 10 to 1, with no loops:
             * 
             * for (int x = 10; x > 0; x--)
             *      Console.WriteLine(x);
             * 
             * As you consider the words on the Tomb of Algol the Wise, you begin to think it might be correct and that you might be able to write this code using recursion instead
             * of a loop.
             */

            Console.WriteLine(@"Wecome to the Countdown method of using ""Recursion"" instead of loops");
            Console.Write("Pick a number to count backwards to 0 from: ");
            int userResponse = Convert.ToInt32(Console.ReadLine()!);
            RecursionTest(userResponse);

            /*---------------------------------------------------- Methods Begin Here ---------------------------------------------------- */

            /// <summary>
            /// Takes an int value as a parameter to countdown to zero from.
            /// </summary>
            int RecursionTest(int start)
            {
                Console.WriteLine(start);
                if (start == 0) return start;
                return RecursionTest(start - 1);


            }
        }
    }
}