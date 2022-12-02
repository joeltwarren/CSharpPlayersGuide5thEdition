namespace TheReplicatorOfD_To
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * While searching an abandoned storage building containing strange code artifacts, you uncover the ancient Replicator of D'To. This can replicate the contents of any
             * int array into another array. But it appears to be broken and needs a Programmer to reforge the magic that allows it to replicate once again.
             * 
             * Objective:
             * Make a program that creates an array of length 5.
             * Ask the user for five numbers and put them in the array.
             * Make a second array of length 5.
             * Use a loop to copy the values out of the original array and into the new one.
             * Display the contents of both arrays one at a time to illustrate that the Replicator of D'To works again.
             */

            Console.WriteLine("Welcome to the putting the magic back into the Replicator of D'To");
            Console.WriteLine("First we need five numbers for our new INT array.");
            int[] array1 = new int [5]; // new array with length of 5
            int[] array2 = new int[5]; // new array with length of 5
            for (int index = 0; index < array1.Length; index++) // uses the array.lenght property of array1 to determine the number of loops for displaying
            {
                Console.Write("Please enter a number between 0 and 999: "); // it wont break the program it will break my formatting if the number is out of range.
                array1[index] = Convert.ToInt32(Console.ReadLine()!); // user input conversion
                Console.Write("\n"); // newline
                array2[index] = array1[index]; // duplicates array 1 to 2
            }
            Console.WriteLine("Array 001 | compared to | Array 002"); // formatted header
            Console.WriteLine("+++++++++++++++++++++++++++++++++++"); // used as a table line
            for (int index = 0; index < array1.Length; index++) // uses the array.lenght property of array1 to determine the number of loops for displaying
            {
                Console.WriteLine($"Value{array1[index]: 000.} | position  {index} | Value{array2[index]: 000.}"); // I could have done this across but down was more interesting
            }
            

        }
    }
}