namespace TheVariableShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * You see an old shopkeeper struggling to stack up variables in a window display."Hoo-wee! All these variable types sure are exciting but stting them all up
             * to show them off to excited new programmers like yourself is a lot of work for these aching bones," she says. "You wouldn't mind helping me set up this program with
             * one variable of every type, would you?"
             * 
             * Objectives:
             * Build a program with a variable of all fourteen types described in this level.
             * Assign each of them a value using a literal of the correct type.
             * Use Console.WriteLine to display the contents of each variable.
             *  NOTE: Types discussed in this level ( int, uint, short, ushort, long, ulong, byte, sbyte, char, string, bool, float, double, decimal )
             */

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