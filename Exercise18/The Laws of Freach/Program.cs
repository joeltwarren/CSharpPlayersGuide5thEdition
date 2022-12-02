namespace The_Laws_of_Freach
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * The town of Freach recently had an awful looping disaster. The lead investigator found that it was a faulty ++ operatore in an old for loop, but the town
             * council has chosen to ban all loops but the foreach loop. Yet Freach uses the code presented earlier in this level to compute the minimum and average value
             * in an int array. They have hired you to rework their existing for-based code to use the foreach loops instead.
             * 
             * Original code:
             * 
             * int [] array = new int [] { 4, 51, -7, 13, -99, 15, -8, 45, 90};
             * int currentSmallest = int.MaxValue; // start higher than anything in the array.
             * for ( int index = 0; index < array.Length; index++)
             * {
             *      if (array[index] < currentSmallest)
             *      currentSmallest = array[index];
             * }
             * Console.WriteLine(currentSmallest);
             * ========================================================================================
             * int [] array = new int [] { 4, 51, -7, 13, -99, 15, -8, 45, 90};
             * int total =0
             * for (int index = 0; index < array.Length; index++) total += array[index];
             * float average = (float)total / array.length;
             * Console.WriteLine(average);
             * 
             * Objective:
             * Start with the above code for computing an array's minimum and average values.
             * Modify the code to use foreach loops instead of for loops.
             */

            Console.WriteLine("Per the town councils request I have modified your program to only use the ForEach loop."); // notice to user of completion of modification of code
            int[] array = new int[] { 4, 51, -7, 13, -99, 15, -8, 45, 90 }; // original array
            int minimumValue = int.MaxValue; // start with max size since we are looking for the smallest answer.
            int total = 0; // start the total a 0 and add from there.

            foreach (int value in array) // replaced two for loops with a single foreach loop doing multiple operations
            {
                if (value < minimumValue) minimumValue= value;
                total = total + value;
            }
            Console.WriteLine($"The Minimum value of your array: {minimumValue:00.}");
            Console.WriteLine($"The Average of the array values: {(float)total /array.Length: 00.00}");
        }
    }
}