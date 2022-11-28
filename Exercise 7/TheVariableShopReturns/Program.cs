namespace TheVariableShopReturns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * "Hey! Programmer!" It's the shopkeeper from the Variable Shop who hobbles over to you. "Thanks to your help, variables are selling like RAM cakes! But these people
             * just aren't any good at programming. They keep asking how to modify the values of the variable they're buying, and... well... frankly, I have no clue. Buy you're
             * a programmer, right? Maybe you could show me so I can show my customers?"
             * 
             * Objectvies:
             * Modify you Variable Shop program to assign a new, different literal value to each of the 14 original variables. Do not declare any additonal variable.
             * Use Console.WriteLine to display the updated contents of each variable.
             */

            // original variables
            int number1 = 1;
            uint number2 = 2;
            long number3 = 3;
            ulong number4 = 4;
            byte number5 = 5;
            sbyte number6 = 6;
            char c = 'c';
            string string1 = "strings";
            bool isTrue = true;
            float isFloat = 3.01F;
            double isDouble = 4.02;
            decimal isDecimal = 5.03M;


            // outputting origianl variables
            Console.WriteLine(number1);
            Console.WriteLine(number2);
            Console.WriteLine(number3);
            Console.WriteLine(number4);
            Console.WriteLine(number5);
            Console.WriteLine(number6);
            Console.WriteLine(c);
            Console.WriteLine(string1);
            Console.WriteLine(isTrue);
            Console.WriteLine(isFloat);
            Console.WriteLine(isDouble);
            Console.WriteLine(isDecimal);

            // newline character
            Console.WriteLine("\n");


            // modifying varaibles
            number1 = 10;
            number2 = 11;
            number3 = 12;
            number4 = 13;
            number5 = 14;
            number6 = 15;
            c = 'd';
            string1 = "Different String";
            isTrue = false;
            isFloat = 3.10F;
            isDouble = 4.12;
            isDecimal = 5.13M;

            // outputting new variable values.
            Console.WriteLine(number1);
            Console.WriteLine(number2);
            Console.WriteLine(number3);
            Console.WriteLine(number4);
            Console.WriteLine(number5);
            Console.WriteLine(number6);
            Console.WriteLine(c);
            Console.WriteLine(string1);
            Console.WriteLine(isTrue);
            Console.WriteLine(isFloat);
            Console.WriteLine(isDouble);
            Console.WriteLine(isDecimal);
        }
    }
}